'通用网格打印组件：把任意 DataGridView 当前显示的内容打印成规范表格。
'
'定位与 RPS 的分工：
'   RPS     —— 固定版式的正式报表与业务单据，版式在 .rft 模板里，需注册 COM 组件
'   本组件  —— 列不固定的查询结果与临时台账，纯 GDI+ 无需模板，不依赖 COM
'
'设计要点：
'   1. 列自动提取自 DataGridView：取 DataPropertyName 与 HeaderText，跳过不可见列
'   2. 列宽按网格 Width 比例映射到纸面，所见即所得
'   3. 绘制单位为毫米（GraphicsUnit.Millimeter），不受打印机缩放与 DPI 干扰
'   4. 合计按 DataRow 原始值求和，与屏幕格式化后的显示值无关，避免精度损失
'   5. 表头跨页重复，页脚可显示页码、打印时间、打印人
'
'用法一：最简，按标题预览
'   MdlGridPrint.Preview(rcDataGridView, "库存明细表")
'
'用法二：带设置预览
'   Dim opt As New ClsGridPrintOption()
'   opt.Title = "库存明细表"
'   opt.SubTitle = "截至 " & Now.ToString("yyyy-MM-dd")
'   opt.Landscape = True
'   opt.SumColumns.Add("sl")            '合计 sl 列
'   opt.ColumnSettings("je") = New ClsGridPrintColumn With {
'       .WidthWeight = 60,
'       .Align = ClsGridPrintColumn.ClsGridPrintAlign.Right,
'       .Sum = True
'   }
'   MdlGridPrint.Preview(rcDataGridView, opt)
'
'用法三：直接打印，不弹预览
'   MdlGridPrint.Print(rcDataGridView, "库存明细表")
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Linq
Imports System.Windows.Forms

Module MdlGridPrint

#Region "对外入口"

    '预览打印。strTitle 为报表标题
    Public Sub Preview(ByVal rcGrid As DataGridView, ByVal strTitle As String)
        Preview(rcGrid, MakeOption(strTitle))
    End Sub

    '预览打印
    Public Sub Preview(ByVal rcGrid As DataGridView, ByVal opt As ClsGridPrintOption)
        If Not CheckGrid(rcGrid) Then Return
        If CheckDemo() Then Return

        Try
            Using rcDoc As New PrintDocument()
                BuildDocument(rcGrid, opt, rcDoc)
                Using rcDlg As New PrintPreviewDialog()
                    rcDlg.Document = rcDoc
                    rcDlg.Width = 900
                    rcDlg.Height = 700
                    rcDlg.ShowDialog()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        End Try
    End Sub

    '直接打印，先弹出系统打印对话框
    Public Sub Print(ByVal rcGrid As DataGridView, ByVal strTitle As String)
        Print(rcGrid, MakeOption(strTitle))
    End Sub

    '直接打印
    Public Sub Print(ByVal rcGrid As DataGridView, ByVal opt As ClsGridPrintOption)
        If Not CheckGrid(rcGrid) Then Return
        If CheckDemo() Then Return

        Try
            Using rcDoc As New PrintDocument()
                BuildDocument(rcGrid, opt, rcDoc)
                Using rcDlg As New PrintDialog()
                    rcDlg.Document = rcDoc
                    If rcDlg.ShowDialog() = DialogResult.OK Then
                        rcDoc.Print()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
        End Try
    End Sub

    '按标题生成一份默认设置
    Public Function MakeOption(ByVal strTitle As String) As ClsGridPrintOption
        Dim opt As New ClsGridPrintOption()
        opt.Title = strTitle
        Return opt
    End Function

#End Region

#Region "文档装配"

    '按设置装配 PrintDocument：页面、绘制委托、文档名
    Private Sub BuildDocument(ByVal rcGrid As DataGridView,
                              ByVal opt As ClsGridPrintOption,
                              ByVal rcDoc As PrintDocument)
        Dim rcLayout As New ClsGridPrintLayout(rcGrid, opt)

        rcDoc.DocumentName = If(String.IsNullOrEmpty(opt.Title), "报表", opt.Title)
        rcDoc.OriginAtMargins = False

        '纸张规格在设置里按 PaperKind 给：取打印机支持的同名规格，取不到就保留驱动默认纸型
        '（PaperSize 只能取自打印机，自行 new 出来的 Kind 一律是 Custom）
        For Each item As PaperSize In rcDoc.PrinterSettings.PaperSizes
            If item.Kind = opt.PaperSize Then
                rcDoc.DefaultPageSettings.PaperSize = item
                Exit For
            End If
        Next
        'PageSettings 只有 Landscape 属性可设方向，没有 Orientation
        rcDoc.DefaultPageSettings.Landscape = opt.Landscape
        'PrintDocument 以百分之一英寸为单位设置边距，故按毫米换算
        rcDoc.DefaultPageSettings.Margins = New Margins(
            CInt(opt.MarginMM / 25.4 * 100),
            CInt(opt.MarginMM / 25.4 * 100),
            CInt(opt.MarginMM / 25.4 * 100),
            CInt(opt.MarginMM / 25.4 * 100))

        AddHandler rcDoc.PrintPage, AddressOf rcLayout.OnPrintPage
    End Sub

#End Region

#Region "前置检查"

    Private Function CheckGrid(ByVal rcGrid As DataGridView) As Boolean
        If rcGrid Is Nothing Then
            MsgBox("没有可打印的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return False
        End If

        '新增行占位与行头都不计入数据，故 AllowUserToAddRows 无需禁止
        If CountPrintableRows(rcGrid) = 0 Then
            MsgBox("没有可打印的数据。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return False
        End If

        If CountPrintableColumns(rcGrid) = 0 Then
            MsgBox("网格没有可打印的列。" & Chr(13) & "请确认列已设置 DataPropertyName 且可见。",
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return False
        End If

        Return True
    End Function

    '可打印行：数据行且已绑定。新增行占位与行头一律排除
    Private Function CountPrintableRows(ByVal rcGrid As DataGridView) As Integer
        If rcGrid Is Nothing Then Return 0
        Dim intCount As Integer = 0
        For i As Integer = 0 To rcGrid.Rows.Count - 1
            If IsPrintableRow(rcGrid.Rows(i)) Then
                intCount = intCount + 1
            End If
        Next
        Return intCount
    End Function

    Private Function IsPrintableRow(ByVal rcRow As DataGridViewRow) As Boolean
        If rcRow Is Nothing Then Return False
        If rcRow.IsNewRow Then Return False            '新增行占位不打印
        Return Not rcRow.DataBoundItem Is Nothing
    End Function

    '可打印列：可见且有字段名
    Private Function CountPrintableColumns(ByVal rcGrid As DataGridView) As Integer
        Dim intCount As Integer = 0
        For Each col As DataGridViewColumn In rcGrid.Columns
            If IsPrintableColumn(col) Then
                intCount = intCount + 1
            End If
        Next
        Return intCount
    End Function

    Private Function IsPrintableColumn(ByVal col As DataGridViewColumn) As Boolean
        If col Is Nothing Then Return False
        Return col.Visible AndAlso Not String.IsNullOrEmpty(col.DataPropertyName)
    End Function

    '试用版不能打印，沿用既有约定
    Private Function CheckDemo() As Boolean
        If g_Demo = 1 Then
            MsgBox("对不起，试用软件不能打印。", MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            Return True
        End If
        Return False
    End Function

#End Region

#Region "排版计算"

    '一次打印的排版数据：列集合、列宽、行高、各区域高度
    Public Class ClsGridPrintLayout

        Public Columns As New List(Of ClsGridPrintColumn)
        Public Widths As New List(Of Single)          '各列宽度（毫米）
        Public ColLefts As New List(Of Single)        '各列左边距（毫米）

        Public TitleHeight As Single = 0               '标题区高度
        Public SubTitleHeight As Single = 0
        Public HeaderHeight As Single = 0              '表头高度
        Public RowHeight As Single = 0                 '数据行高
        Public FooterSpace As Single = 0               '页脚预留
        Public PrintLeft As Single = 0                 '可打印区左边（毫米）
        Public PrintTop As Single = 0                  '可打印区上边（毫米）
        Public TotalHeight As Single = 0               '可打印总高度

        Private _opt As ClsGridPrintOption
        Private _grid As DataGridView
        Private _rowCount As Integer = 0               '数据行数
        Private _rowCursor As Integer = 0              '绘制游标
        Private _pageNo As Integer = 0                 '当前页
        Private _showSum As Boolean = False          '是否输出合计行（SumColumns 非空即要输出）
        Private _sums As New Dictionary(Of String, Double)  '字段名 -> 合计值

        Public Sub New(ByVal rcGrid As DataGridView, ByVal opt As ClsGridPrintOption)
            _opt = opt
            _grid = rcGrid
            _rowCount = CountPrintableRows(rcGrid)
            BuildColumns(rcGrid, opt)
            '指定了合计列即视为要合计行，免去再设一次 ShowSumRow
            _showSum = opt.ShowSumRow Or opt.SumColumns.Count > 0
            BuildSums(rcGrid, opt)
        End Sub

        '磅换算毫米：1 磅 = 25.4/72 毫米。标题空时高度为 0
        Public Sub MeasureArea(ByVal printableLeft As Single,
                                ByVal printableTop As Single,
                                ByVal printableHeight As Single)
            PrintLeft = printableLeft
            PrintTop = printableTop
            TotalHeight = printableHeight
            TitleHeight = If(String.IsNullOrEmpty(_opt.Title), 0, PointMM(_opt.TitleFontSize) * 1.8)
            SubTitleHeight = If(String.IsNullOrEmpty(_opt.SubTitle), 0, PointMM(_opt.FontSize) * 1.8)
            HeaderHeight = PointMM(_opt.HeaderFontSize) * 1.8
            RowHeight = If(_opt.RowHeightMM > 0, _opt.RowHeightMM, 5)
            FooterSpace = If(HasFooter(), PointMM(_opt.FontSize) * 1.8, 0)
        End Sub

        Private Function PointMM(ByVal dblPoint As Single) As Single
            Return dblPoint * 25.4F / 72F
        End Function

        Public Function HasFooter() As Boolean
            Return _opt.ShowPageNumber Or _opt.ShowPrintTime Or _opt.ShowPrintUser
        End Function

        Public Function RowCount() As Integer
            Return _rowCount
        End Function

        Public Function RowCursor() As Integer
            Return _rowCursor
        End Function

        Public Function Advance() As Integer
            _rowCursor = _rowCursor + 1
            Return _rowCursor
        End Function

        Public Function IsFinished() As Boolean
            Return _rowCursor >= _rowCount
        End Function

        Public Function NextPage() As Integer
            _pageNo = _pageNo + 1
            Return _pageNo
        End Function

        Public Function PageNo() As Integer
            Return _pageNo
        End Function

        Public Function SumValue(ByVal strField As String) As Double
            Dim dbl As Double = 0
            If _sums.ContainsKey(strField) Then
                dbl = _sums(strField)
            End If
            Return dbl
        End Function

        '从网格提取列：跳过不可见与无字段名的列，套用个性化设置
        Private Sub BuildColumns(ByVal rcGrid As DataGridView, ByVal opt As ClsGridPrintOption)
            For intIndex As Integer = 0 To rcGrid.Columns.Count - 1
                Dim col As DataGridViewColumn = rcGrid.Columns(intIndex)
                If IsPrintableColumn(col) Then
                    Dim newCol As New ClsGridPrintColumn()
                    newCol.SourceIndex = intIndex
                    newCol.FieldName = col.DataPropertyName
                    newCol.Caption = If(String.IsNullOrEmpty(col.HeaderText), col.DataPropertyName, col.HeaderText)
                    newCol.WidthWeight = CType(col.Width, Single)

                    If opt.ColumnSettings.ContainsKey(col.DataPropertyName) Then
                        Dim cfg As ClsGridPrintColumn = opt.ColumnSettings(col.DataPropertyName)
                        If cfg.WidthWeight > 0 Then
                            newCol.WidthWeight = cfg.WidthWeight
                        End If
                        newCol.Align = cfg.Align
                        newCol.Format = cfg.Format
                        '列上标了 Sum 即视为需要合计，免去再往 SumColumns 里加一次
                        If cfg.Sum AndAlso Not opt.SumColumns.Contains(newCol.FieldName) Then
                            opt.SumColumns.Add(newCol.FieldName)
                        End If
                    End If

                    Columns.Add(newCol)
                End If
            Next

            '各列宽度按权重占比得到相对值，绘制前再按可打印宽度等比放大
            Dim dblSum As Single = 0
            For Each col As ClsGridPrintColumn In Columns
                dblSum = dblSum + ColWeight(col)
            Next
            If dblSum <= 0 Then Return

            Dim dblLeft As Single = 0
            For i As Integer = 0 To Columns.Count - 1
                Dim dblW As Single = ColWeight(Columns(i)) / dblSum
                Widths.Add(dblW)
                ColLefts.Add(dblLeft)
                dblLeft = dblLeft + dblW
            Next
        End Sub

        '权重为 0 或负数时按 1 计，避免该列被压成零宽
        Private Function ColWeight(ByVal col As ClsGridPrintColumn) As Single
            If col.WidthWeight > 0 Then
                Return col.WidthWeight
            End If
            Return 1
        End Function

        '按原始值求和。DataBoundItem 可能是 DataRowView 或 DataRow
        Private Sub BuildSums(ByVal rcGrid As DataGridView, ByVal opt As ClsGridPrintOption)
            If opt.SumColumns.Count = 0 Then Return

            For Each strField As String In opt.SumColumns
                If Not _sums.ContainsKey(strField) Then
                    _sums.Add(strField, 0)
                End If
            Next

            For i As Integer = 0 To rcGrid.Rows.Count - 1
                If IsPrintableRow(rcGrid.Rows(i)) Then
                    Dim obj As Object = rcGrid.Rows(i).DataBoundItem
                    For Each strField As String In opt.SumColumns
                        AddToSum(obj, strField)
                    Next
                End If
            Next
        End Sub

        '单值累加。原始值可能是数值型，也可能是 Oracle 取回的字符串，故两种都要试。
        '仅无组合格式分隔的纯数字参与求和，带千分位或货币符号的一律跳过
        Private Sub AddToSum(ByVal obj As Object, ByVal strField As String)
            Dim objValue As Object = GetRawValue(obj, strField)
            If objValue Is Nothing OrElse objValue Is DBNull.Value Then Return

            Dim dbl As Double
            If TypeOf objValue Is Decimal OrElse TypeOf objValue Is Double OrElse
               TypeOf objValue Is Single OrElse TypeOf objValue Is Integer OrElse
               TypeOf objValue Is Long Then
                dbl = Convert.ToDouble(objValue)
            Else
                Dim strText As String = Convert.ToString(objValue).Trim()
                If Not Double.TryParse(strText, dbl) Then Return
            End If

            _sums(strField) = _sums(strField) + dbl
        End Sub

        Public Shared Function GetRawValue(ByVal obj As Object, ByVal strField As String) As Object
            Dim row As DataRow = TryCast(obj, DataRow)
            If Not row Is Nothing Then
                If row.Table.Columns.Contains(strField) Then
                    Return row.Item(strField)
                End If
                Return Nothing
            End If

            Dim rv As DataRowView = TryCast(obj, DataRowView)
            If Not rv Is Nothing Then
                If rv.Row.Table.Columns.Contains(strField) Then
                    Return rv.Row.Item(strField)
                End If
                Return Nothing
            End If

            Return Nothing
        End Function

        '单个单元格在纸面上的矩形区域
        Private Function CellRect(ByVal intIndex As Integer, ByVal dblTop As Single,
                                  ByVal dblWidth As Single, ByVal dblHeight As Single) As RectangleF
            Return New RectangleF(PrintLeft + ColLefts(intIndex), dblTop, dblWidth, dblHeight)
        End Function

        'GDI+ 的 DrawRectangle 没有 RectangleF 重载，故按四个单精度坐标画，
        '与 DrawString 的区域严格一致，不会因取整而错位
        Private Sub DrawCellFrame(ByVal g As Graphics, ByVal rect As RectangleF)
            g.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height)
        End Sub

        Private Function ToStringAlignment(ByVal align As ClsGridPrintColumn.ClsGridPrintAlign) As StringAlignment
            Select Case align
                Case ClsGridPrintColumn.ClsGridPrintAlign.Center
                    Return StringAlignment.Center
                Case ClsGridPrintColumn.ClsGridPrintAlign.Right
                    Return StringAlignment.Far
                Case Else
                    Return StringAlignment.Near
            End Select
        End Function

#Region "绘制"

        'PrintPage 事件处理：逐页绘制数据与页脚
        Public Sub OnPrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
            Try
                If Columns.Count = 0 Then
                    e.HasMorePages = False
                    Return
                End If

                '每进入一次 PrintPage 即为新的一页
                NextPage()

                Dim g As Graphics = e.Graphics
                '以毫米为单位绘制，不受打印机缩放与 DPI 干扰
                g.PageUnit = GraphicsUnit.Millimeter

                'PrintableArea 的单位是百分之一英寸，转毫米后即为可打印区域，
                '其中已排除页边距，故绘图起点就是它自身的偏移
                Dim area As RectangleF = e.PageSettings.PrintableArea
                Dim printableLeft As Single = area.X / 100F * 25.4F
                Dim printableTop As Single = area.Y / 100F * 25.4F
                Dim printableWidth As Single = area.Width / 100F * 25.4F
                Dim printableHeight As Single = area.Height / 100F * 25.4F
                MeasureArea(printableLeft, printableTop, printableHeight)

                '列宽按可打印宽度等比放大
                RescaleWidths(printableWidth)

                Dim dblTop As Single = printableTop
                If PageNo() = 1 Then
                    dblTop = DrawTitle(g, dblTop, printableWidth)
                End If
                If PageNo() = 1 Or _opt.RepeatHeader Then
                    dblTop = DrawHeader(g, dblTop)
                End If

                Dim dblBottom As Single = printableTop + printableHeight - FooterSpace
                Dim intCapacity As Integer = Int((dblBottom - dblTop) / RowHeight)

                '页面过窄时仍须放行一行，否则翻页死循环
                If intCapacity < 1 Then intCapacity = 1

                Dim intAllow As Integer = intCapacity
                If _showSum AndAlso (_rowCount - _rowCursor) <= intCapacity - 1 Then
                    '本页即为末页，须为合计行预留一行
                    intAllow = intCapacity - 1
                    If intAllow < 1 Then intAllow = 1
                End If

                Dim rcGrid As DataGridView = _grid
                For i As Integer = 1 To intAllow
                    If IsFinished() Then Exit For
                    DrawRow(rcGrid, g, dblTop)
                    dblTop = dblTop + RowHeight
                    Advance()
                Next

                '末页补合计行
                If IsFinished() AndAlso _showSum Then
                    DrawSumRow(g, dblTop)
                End If

                DrawFooter(g, printableTop + printableHeight)

                e.HasMorePages = Not IsFinished()
            Catch ex As Exception
                e.HasMorePages = False
                MsgBox("程序错误。" & Chr(13) & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Question, "提示信息")
            End Try
        End Sub

        '按可打印宽度把列宽换算成毫米。除以总和即为比例，故重复调用结果稳定
        Private Sub RescaleWidths(ByVal printableWidth As Single)
            Dim dblSum As Single = 0
            For Each w As Single In Widths
                dblSum = dblSum + w
            Next
            If dblSum <= 0 Then Return

            Dim dblLeft As Single = 0
            For i As Integer = 0 To Widths.Count - 1
                Dim dblNew As Single = Widths(i) / dblSum * printableWidth
                Widths(i) = dblNew
                ColLefts(i) = dblLeft
                dblLeft = dblLeft + dblNew
            Next
        End Sub

        '标题与副标题，返回新的纵坐标
        Private Function DrawTitle(ByVal g As Graphics, ByVal dblTop As Single,
                                   ByVal printableWidth As Single) As Single
            Dim opt As ClsGridPrintOption = _opt
            Dim dblNow As Single = dblTop

            Using fmt As New StringFormat
                fmt.Alignment = StringAlignment.Center
                fmt.LineAlignment = StringAlignment.Center

                If Not String.IsNullOrEmpty(opt.Title) Then
                    Using font As New Font(opt.FontName, opt.TitleFontSize, FontStyle.Bold)
                        g.DrawString(opt.Title, font, Brushes.Black,
                                     New RectangleF(PrintLeft, dblNow, printableWidth, TitleHeight), fmt)
                    End Using
                    dblNow = dblNow + TitleHeight
                End If

                If Not String.IsNullOrEmpty(opt.SubTitle) Then
                    Using font As New Font(opt.FontName, opt.FontSize, FontStyle.Regular)
                        g.DrawString(opt.SubTitle, font, Brushes.Black,
                                     New RectangleF(PrintLeft, dblNow, printableWidth, SubTitleHeight), fmt)
                    End Using
                    dblNow = dblNow + SubTitleHeight
                End If
            End Using

            Return dblNow
        End Function

        '表头，返回新的纵坐标
        Private Function DrawHeader(ByVal g As Graphics, ByVal dblTop As Single) As Single
            Dim opt As ClsGridPrintOption = _opt

            Using font As New Font(opt.FontName, opt.HeaderFontSize, FontStyle.Bold)
                Using fmt As New StringFormat
                    fmt.Alignment = StringAlignment.Center
                    fmt.LineAlignment = StringAlignment.Center
                    fmt.Trimming = StringTrimming.EllipsisCharacter

                    For i As Integer = 0 To Columns.Count - 1
                        g.DrawString(Columns(i).Caption, font, Brushes.Black,
                                     CellRect(i, dblTop, Widths(i), HeaderHeight), fmt)
                        If opt.ShowGridLine Then
                            DrawCellFrame(g, CellRect(i, dblTop, Widths(i), HeaderHeight))
                        End If
                    Next
                End Using

                Using pen As New Pen(Brushes.Black, 1.5F)
                    g.DrawLine(pen, PrintLeft, dblTop + HeaderHeight,
                               PrintLeft + Widths.Sum(), dblTop + HeaderHeight)
                End Using
            End Using

            Return dblTop + HeaderHeight
        End Function

        Private Sub DrawRow(ByVal rcGrid As DataGridView, ByVal g As Graphics,
                            ByVal dblTop As Single)
            Dim opt As ClsGridPrintOption = _opt

            Dim rcRow As DataGridViewRow = FindRowByIndex(rcGrid, RowCursor())
            If rcRow Is Nothing Then Return

            '显示值取屏幕上的格式化结果，与所见一致
            Using font As New Font(opt.FontName, opt.FontSize, FontStyle.Regular)
                Using fmt As New StringFormat
                    fmt.LineAlignment = StringAlignment.Center
                    fmt.Trimming = StringTrimming.EllipsisCharacter
                    For i As Integer = 0 To Columns.Count - 1
                        Dim strText As String = CellText(rcRow, Columns(i).SourceIndex)
                        fmt.Alignment = ToStringAlignment(Columns(i).Align)
                        g.DrawString(strText, font, Brushes.Black, CellRect(i, dblTop, Widths(i), RowHeight), fmt)
                        If opt.ShowGridLine Then
                            DrawCellFrame(g, CellRect(i, dblTop, Widths(i), RowHeight))
                        End If
                    Next
                End Using
            End Using
        End Sub

        '取屏幕显示文字，取不到时退回原始值
        Private Function CellText(ByVal rcRow As DataGridViewRow, ByVal intIndex As Integer) As String
            If intIndex < 0 Or intIndex >= rcRow.Cells.Count Then Return ""
            Dim objValue As Object = rcRow.Cells(intIndex).FormattedValue
            If objValue Is Nothing Then Return ""
            Return Convert.ToString(objValue).Trim()
        End Function

        '取第 n 个可打印行，跳过新增行与非数据行
        Private Function FindRowByIndex(ByVal rcGrid As DataGridView, ByVal intIndex As Integer) As DataGridViewRow
            If intIndex < 0 Or rcGrid Is Nothing Then Return Nothing
            Dim intSeen As Integer = 0
            For i As Integer = 0 To rcGrid.Rows.Count - 1
                If Not rcGrid.Rows(i).IsNewRow AndAlso Not rcGrid.Rows(i).DataBoundItem Is Nothing Then
                    If intSeen = intIndex Then
                        Return rcGrid.Rows(i)
                    End If
                    intSeen = intSeen + 1
                End If
            Next
            Return Nothing
        End Function

        Private Sub DrawSumRow(ByVal g As Graphics, ByVal dblTop As Single)
            Dim opt As ClsGridPrintOption = _opt

            Using font As New Font(opt.FontName, opt.FontSize, FontStyle.Bold)
                Using fmt As New StringFormat
                    fmt.LineAlignment = StringAlignment.Center
                    fmt.Trimming = StringTrimming.EllipsisCharacter

                    For i As Integer = 0 To Columns.Count - 1
                        Dim strText As String = ""
                        If i = 0 Then
                            strText = opt.SumText
                        ElseIf opt.SumColumns.Contains(Columns(i).FieldName) Then
                            strText = FormatSum(Columns(i))
                        End If

                        fmt.Alignment = ToStringAlignment(Columns(i).Align)
                        g.DrawString(strText, font, Brushes.Black, CellRect(i, dblTop, Widths(i), RowHeight), fmt)
                        If opt.ShowGridLine Then
                            DrawCellFrame(g, CellRect(i, dblTop, Widths(i), RowHeight))
                        End If
                    Next
                End Using
            End Using
        End Sub

        '合计值格式化：优先用列上配置的格式串，其次用全局金额格式
        Private Function FormatSum(ByVal col As ClsGridPrintColumn) As String
            Dim dbl As Double = SumValue(col.FieldName)
            If String.IsNullOrEmpty(col.Format) Then
                Return Format(dbl, g_FormatJe0)
            End If
            Return Format(dbl, col.Format)
        End Function

        '页脚：页码、打印时间、打印人
        Private Sub DrawFooter(ByVal g As Graphics, ByVal printableBottom As Single)
            Dim opt As ClsGridPrintOption = _opt
            If Not HasFooter() Then Return

            Dim parts As New List(Of String)
            If opt.ShowPrintTime Then
                parts.Add("打印时间：" & Now.ToString("yyyy-MM-dd HH:mm"))
            End If
            If opt.ShowPrintUser Then
                parts.Add("打印人：" & g_User_DspName)
            End If
            If opt.ShowPageNumber Then
                parts.Add("第 " & PageNo().ToString & " 页")
            End If
            If parts.Count = 0 Then Return

            Using font As New Font(opt.FontName, opt.FontSize, FontStyle.Regular)
                Using fmt As New StringFormat
                    fmt.Alignment = StringAlignment.Far
                    fmt.LineAlignment = StringAlignment.Center
                    g.DrawString(String.Join("    ", parts), font, Brushes.Black,
                                 New RectangleF(PrintLeft, printableBottom - FooterSpace,
                                                TotalWidth(), FooterSpace), fmt)
                End Using
            End Using
        End Sub

        Private Function TotalWidth() As Single
            If Widths.Count = 0 Then Return 0
            Return Widths.Sum()
        End Function

#End Region

    End Class

#End Region

End Module