
Imports STIVentas.Model
''' <summary>
''' Model para usuarios del sistema
''' </summary>
''' <remarks>18.02.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class UsuarioModel : Implements IDBTable

    Private RecordId As Long
    Public Property Username As String
    Public Property Nombre As String
    Public Property AliasName As String
    Public Property Password As String
    Public Property Status As EstadoUsuario
    Public Property Email As String
    Public Property FechaCreacion As TimeSpan

    Public Property Id As Long Implements IDBTable.RecordId
        Get
            Return RecordId
        End Get
        Set(value As Long)
            RecordId = value
        End Set
    End Property

    ''' <summary>
    ''' Constructor sin params
    ''' </summary>
    ''' <remarks>18.02.2021 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
    Sub New()
        RecordId = 0
    End Sub

    Sub New(ByVal Id_ As Integer, userName_ As String, ByVal Nombre_ As String, ByVal Alias_ As String, ByVal Password_ As String, ByVal Status_ As EstadoUsuario,
                    ByVal Email_ As String, ByVal FechaCreacion_ As TimeSpan)
        Me.Id = Id_
        Username = userName_
        Me.Nombre = Nombre_
        Me.AliasName = Alias_
        Me.Password = Password_
        Me.Status = Status_
        Me.Email = Email_
        Me.FechaCreacion = FechaCreacion_
    End Sub

    Sub New(ByVal Id_ As String, userName_ As String, ByVal Nombre_ As String, ByVal Alias_ As String, ByVal Password_ As String, ByVal Status_ As EstadoUsuario,
                    ByVal Email_ As String)
        Me.Id = Id_
        Username = userName_
        Me.Nombre = Nombre_
        Me.AliasName = Alias_
        Me.Password = Password_
        Me.Status = Status_
        Me.Email = Email_
    End Sub

    Public Shared Widening Operator CType(v As UsuarioModel) As UsuarioModel
        Throw New NotImplementedException()
    End Operator
End Class
