''' <summary>
''' Clase base para los enumeradores
''' </summary>
''' <remarks>10.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class EnumValue
    ''Public Property EnumValue As Integer
    Public Property EnumValue As String
    Public Property Description As String

    Public Sub New()
        EnumValue = String.Empty
        Description = String.Empty
    End Sub

    Public Sub New(value As String, desc As String)
        EnumValue = value
        Description = desc
    End Sub
End Class
