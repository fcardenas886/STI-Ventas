Imports System.Text
''' <summary>
''' Clase para hacer un select generico.
''' </summary>
''' <remarks>05.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class DBSelect
    Public Property TableName As String
    Public Property SelectFields As List(Of DBSelectionField)
    Public Property FilterFields As List(Of DBFilterFields)

#Region "Constructor"
    Public Sub New()
        SelectFields = New List(Of DBSelectionField)
        FilterFields = New List(Of DBFilterFields)
    End Sub

    Public Sub New(ByVal table As String)
        TableName = table
        SelectFields = New List(Of DBSelectionField)
        FilterFields = New List(Of DBFilterFields)
    End Sub

    Public Sub New(ByVal table As String, ByVal fields As List(Of DBSelectionField))
        TableName = table
        SelectFields = fields
        FilterFields = New List(Of DBFilterFields)
    End Sub

    Public Sub New(ByVal table As String, ByVal fields As List(Of DBSelectionField), ByVal filterFields As List(Of DBFilterFields))
        TableName = table
        SelectFields = fields
        Me.FilterFields = filterFields
    End Sub

#End Region

    Friend Function GetAsSQL() As String
        Dim sql As String
        Dim sBuilder As New StringBuilder
        Dim iCounter As Integer = 0

        sBuilder.Append("SELECT ")

        If SelectFields.Count > 0 Then
            For Each selectField As DBSelectionField In SelectFields
                If iCounter > 0 Then
                    sBuilder.Append(", ")
                End If
                sBuilder.Append(selectField.GetAsSQL())
                iCounter += 1
            Next
        Else
            sBuilder.Append("* ")
        End If

        sBuilder.AppendFormat(" FROM {0} ", TableName)

        If FilterFields.Count > 0 Then
            sBuilder.Append(" WHERE ")
            iCounter = 0

            For Each filterField As DBFilterFields In FilterFields
                If iCounter > 0 Then
                    sBuilder.Append(" AND ")
                End If
                sBuilder.Append(filterField.GetAsSQL())
                iCounter += 1
            Next
        End If

        sql = sBuilder.ToString()

        Return sql
    End Function
End Class
