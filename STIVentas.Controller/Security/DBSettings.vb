Imports System.Xml

''' <summary>
''' Se agrega clase para guardar la cadena de conexión
''' </summary>
''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea clase</remarks>
Public Class DBSettings
    Private Shared aes As AES = New AES()
    Public Shared CnString As String
    Shared dbcnString As String
    Public Shared appPwdUnique As String = "P@5sW@rd.STIVentas"

    Public Shared Function CheckServer() As Object
        Dim doc As New XmlDocument()
        doc.Load("ConnectionString.xml")
        Dim root As XmlElement = doc.DocumentElement
        dbcnString = root.Attributes(0).Value
        CnString = (aes.Decrypt(dbcnString, appPwdUnique, 256))
        Return CnString
    End Function
End Class
