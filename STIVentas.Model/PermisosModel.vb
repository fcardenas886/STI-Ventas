Imports STIVentas.Model

Public Class PermisosModel : Implements IDBTable

    Private RecordId As Long
    Public Property IdUsuario As Integer
    Public Property IdModulo As Integer
    Public Property Insertar As Boolean
    Public Property Editar As Boolean
    Public Property Eliminar As Boolean


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

    Sub New(ByVal Id_ As Integer, ByVal IdUsuario_ As Integer, ByVal IdModulo_ As Integer, ByVal Insertar_ As Boolean, ByVal Editar_ As Boolean, ByVal Eliminar_ As Boolean)

        Id = Id_
        IdUsuario = IdUsuario_
        IdModulo = IdModulo_
        Insertar = Insertar_
        Editar = Editar_
        Eliminar = Eliminar_

    End Sub

    Sub New(ByVal IdUsuario_ As Integer, ByVal IdModulo_ As Integer, ByVal Insertar_ As Boolean, ByVal Editar_ As Boolean, ByVal Eliminar_ As Boolean)


        IdUsuario = IdUsuario_
        IdModulo = IdModulo_
        Insertar = Insertar_
        Editar = Editar_
        Eliminar = Eliminar_

    End Sub
End Class
