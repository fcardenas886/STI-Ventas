''' <summary>
''' Clase que contiene los campos para filtrar un select generico.
''' </summary>
''' <remarks>05.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class DBFilterFields
    Public Property FieldName As String
    Public Property FilterType As DBFilterType
    Public Property FieldValue As Object

#Region "Constructor"
    Public Sub New()
        FieldName = String.Empty
        FilterType = DBFilterType.Equal
        FieldValue = String.Empty
    End Sub

    Public Sub New(ByVal name As String)
        FieldName = name
        FilterType = DBFilterType.Equal
        FieldValue = String.Empty
    End Sub

    Public Sub New(ByVal name As String, ByVal filter As DBFilterType)
        FieldName = name
        FilterType = filter
        FieldValue = String.Empty
    End Sub

    Public Sub New(ByVal name As String, ByVal filter As DBFilterType, ByVal value As Object)
        FieldName = name
        FilterType = filter
        FieldValue = value
    End Sub
#End Region

#Region "Class methods"
    Friend Function GetAsSQL() As String
        Dim sql As String

        Select Case FilterType
            Case DBFilterType.Equal
                sql = String.Format("{0} = @{0}", FieldName)
            Case DBFilterType.GreaterThan
                sql = String.Format("{0} > @{0}", FieldName)
            Case DBFilterType.GreaterThanEqual
                sql = String.Format("{0} >= @{0}", FieldName)
            Case DBFilterType.LessThan
                sql = String.Format("{0} < @{0}", FieldName)
            Case DBFilterType.LessThanEqual
                sql = String.Format("{0} <= @{0}", FieldName)
            Case DBFilterType.NotEqual
                sql = String.Format("{0} <> @{0}", FieldName)
            Case Else
                Throw New Exception(String.Format("Operador no identificado - {0}", FilterType))
        End Select

        Return sql
    End Function
#End Region
End Class
