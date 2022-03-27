
Imports STIVentas.Model
Public Class ModuloModel : Implements IDBTable

    Private RecordId As Long
    Public Property Idmodulo As String
    Public Property Nombre As String


    Public Property Id As Long Implements IDBTable.RecordId
        Get
            Return RecordId
        End Get
        Set(value As Long)
            RecordId = value
        End Set
    End Property


    Sub New()
        RecordId = 0
    End Sub

    Sub New(ByVal Id_ As Integer, idmodulo_ As String, ByVal Nombre_ As String)
        Me.Id = Id_
        Me.Idmodulo = idmodulo_
        Me.Nombre = Nombre_

    End Sub

    Sub New(idmodulo_ As String, ByVal Nombre_ As String)

        Me.Idmodulo = idmodulo_
        Me.Nombre = Nombre_

    End Sub

End Class
