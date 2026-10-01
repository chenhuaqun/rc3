'单个打印列的定义。字段名对应 DataGridViewColumn.DataPropertyName，
'以便按原始值取值（合计求和与屏幕格式化后的显示值无关）
Public Class ClsGridPrintColumn

    Public Enum ClsGridPrintAlign
        Left = 0
        Center = 1
        Right = 2
    End Enum

    Private _FieldName As String = ""          '对应 DataPropertyName
    Private _Caption As String = ""            '表头文字
    Private _SourceIndex As Integer = -1       '在 DataGridView.Columns 中的位置
    Private _WidthWeight As Single = 0         '列宽权重，0 表示按网格实际宽度比例
    Private _Align As ClsGridPrintAlign = ClsGridPrintAlign.Left
    Private _Format As String = ""             '合计行的格式化串，如 g_FormatJe0
    Private _Sum As Boolean = False            '是否需要合计

    '在 DataGridView.Columns 中的位置。-1 表示无对应列
    Public Property SourceIndex() As Integer
        Get
            Return _SourceIndex
        End Get
        Set(ByVal Value As Integer)
            _SourceIndex = Value
        End Set
    End Property

    '原始值的字段名。合计按此字段从 DataRow 取值求和
    Public Property FieldName() As String
        Get
            Return _FieldName
        End Get
        Set(ByVal Value As String)
            _FieldName = Value
        End Set
    End Property

    '表头文字
    Public Property Caption() As String
        Get
            Return _Caption
        End Get
        Set(ByVal Value As String)
            _Caption = Value
        End Set
    End Property

    '列宽权重。设为 0 时按 DataGridViewColumn.Width 的比例分配可打印宽度
    Public Property WidthWeight() As Single
        Get
            Return _WidthWeight
        End Get
        Set(ByVal Value As Single)
            _WidthWeight = Value
        End Set
    End Property

    '单元格对齐方式
    Public Property Align() As ClsGridPrintAlign
        Get
            Return _Align
        End Get
        Set(ByVal Value As ClsGridPrintAlign)
            _Align = Value
        End Set
    End Property

    '合计行的数字格式，空表示用默认格式
    Public Property Format() As String
        Get
            Return _Format
        End Get
        Set(ByVal Value As String)
            _Format = Value
        End Set
    End Property

    '是否对该列求和
    Public Property Sum() As Boolean
        Get
            Return _Sum
        End Get
        Set(ByVal Value As Boolean)
            _Sum = Value
        End Set
    End Property

End Class