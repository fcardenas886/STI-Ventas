''' <summary>
''' Clase que contiene los campos para seleccionar un campo de una tabla.
''' </summary>
''' <remarks>05.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class DBSelectionField
    Public Property FieldName As String
    Public Property FieldAlias As String

#Region "Constructor"
    Public Sub New()
        FieldName = String.Empty
        FieldAlias = String.Empty
    End Sub

    Public Sub New(ByVal name As String)
        FieldName = name
        FieldAlias = String.Empty
    End Sub

    Public Sub New(ByVal name As String, ByVal aliasName As String)
        FieldName = name
        FieldAlias = aliasName
    End Sub

#End Region

#Region "Class methods"
    Friend Function GetAsSQL() As String
        Dim sql As String

        If String.IsNullOrEmpty(FieldName) Then
            sql = FieldName
        Else
            sql = FieldName & " AS " & FieldAlias
        End If

        Return sql
    End Function
#End Region
End Class
