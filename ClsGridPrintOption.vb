'通用网格打印的设置项。未设置的项取默认值。
'配合 MdlGridPrint 使用，把任意 DataGridView 的当前显示内容打印成规范表格。
'
'与 RPS 的分工：RPS 负责固定版式的正式报表与业务单据（有 .rft 模板），
'本组件负责列不固定的查询结果与临时台账，无需模板。
Public Class ClsGridPrintOption

    Private _Title As String = ""                       '报表标题
    Private _SubTitle As String = ""                    '副标题
    Private _Landscape As Boolean = False               '横向
    Private _PaperSize As System.Drawing.Printing.PaperKind = System.Drawing.Printing.PaperKind.A4
    Private _MarginMM As Single = 15                    '页边距（毫米）
    Private _RepeatHeader As Boolean = True            '跨页重复表头
    Private _ShowGridLine As Boolean = True             '画表格线
    Private _ShowPageNumber As Boolean = True           '页脚显示页码
    Private _ShowPrintTime As Boolean = True            '页脚显示打印时间
    Private _ShowPrintUser As Boolean = True            '页脚显示打印人
    Private _ShowSumRow As Boolean = False              '是否输出合计行
    Private _SumText As String = "合计"                 '合计行首格文字
    Private _FontName As String = "宋体"
    Private _FontSize As Single = 9                     '正文字号（磅）
    Private _HeaderFontSize As Single = 10              '表头字号（磅）
    Private _TitleFontSize As Single = 14               '标题字号（磅）
    Private _RowHeightMM As Single = 5                  '单行高度（毫米）

    '需要合计的列，按字段名（FieldName）指定，避免列顺序变化时错位
    Public ReadOnly Property SumColumns As New List(Of String)

    '各列的个性化设置，键为 FieldName。未在集合中的列采用自动提取的默认值
    Public ReadOnly Property ColumnSettings As New Dictionary(Of String, ClsGridPrintColumn)

    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal Value As String)
            _Title = Value
        End Set
    End Property

    Public Property SubTitle() As String
        Get
            Return _SubTitle
        End Get
        Set(ByVal Value As String)
            _SubTitle = Value
        End Set
    End Property

    Public Property Landscape() As Boolean
        Get
            Return _Landscape
        End Get
        Set(ByVal Value As Boolean)
            _Landscape = Value
        End Set
    End Property

    Public Property PaperSize() As System.Drawing.Printing.PaperKind
        Get
            Return _PaperSize
        End Get
        Set(ByVal Value As System.Drawing.Printing.PaperKind)
            _PaperSize = Value
        End Set
    End Property

    Public Property MarginMM() As Single
        Get
            Return _MarginMM
        End Get
        Set(ByVal Value As Single)
            _MarginMM = Value
        End Set
    End Property

    Public Property RepeatHeader() As Boolean
        Get
            Return _RepeatHeader
        End Get
        Set(ByVal Value As Boolean)
            _RepeatHeader = Value
        End Set
    End Property

    Public Property ShowGridLine() As Boolean
        Get
            Return _ShowGridLine
        End Get
        Set(ByVal Value As Boolean)
            _ShowGridLine = Value
        End Set
    End Property

    Public Property ShowPageNumber() As Boolean
        Get
            Return _ShowPageNumber
        End Get
        Set(ByVal Value As Boolean)
            _ShowPageNumber = Value
        End Set
    End Property

    Public Property ShowPrintTime() As Boolean
        Get
            Return _ShowPrintTime
        End Get
        Set(ByVal Value As Boolean)
            _ShowPrintTime = Value
        End Set
    End Property

    Public Property ShowPrintUser() As Boolean
        Get
            Return _ShowPrintUser
        End Get
        Set(ByVal Value As Boolean)
            _ShowPrintUser = Value
        End Set
    End Property

    Public Property ShowSumRow() As Boolean
        Get
            Return _ShowSumRow
        End Get
        Set(ByVal Value As Boolean)
            _ShowSumRow = Value
        End Set
    End Property

    Public Property SumText() As String
        Get
            Return _SumText
        End Get
        Set(ByVal Value As String)
            _SumText = Value
        End Set
    End Property

    Public Property FontName() As String
        Get
            Return _FontName
        End Get
        Set(ByVal Value As String)
            _FontName = Value
        End Set
    End Property

    Public Property FontSize() As Single
        Get
            Return _FontSize
        End Get
        Set(ByVal Value As Single)
            _FontSize = Value
        End Set
    End Property

    Public Property HeaderFontSize() As Single
        Get
            Return _HeaderFontSize
        End Get
        Set(ByVal Value As Single)
            _HeaderFontSize = Value
        End Set
    End Property

    Public Property TitleFontSize() As Single
        Get
            Return _TitleFontSize
        End Get
        Set(ByVal Value As Single)
            _TitleFontSize = Value
        End Set
    End Property

    Public Property RowHeightMM() As Single
        Get
            Return _RowHeightMM
        End Get
        Set(ByVal Value As Single)
            _RowHeightMM = Value
        End Set
    End Property

End Class