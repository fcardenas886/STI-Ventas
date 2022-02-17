Imports STIVentas.Model

Public Class ClienteModel : Implements IDBTable

    Private RecordId As Long
    Public Property Rut As String
    Public Property Nombre As String
    Public Property Direccion As String
    Public Property Cupo As Integer



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

    Sub New(ByVal Rut_ As String, ByVal Nombre_ As String, ByVal Direccion_ As String, ByVal Cupo_ As Integer)

        Rut = Rut_
        Nombre = Nombre_
        Direccion = Direccion_
        Cupo = Cupo_

    End Sub


End Class
