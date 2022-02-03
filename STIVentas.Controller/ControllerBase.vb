Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controlador base
''' </summary>
''' <remarks>01.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ControllerBase : Implements IDBOperations

#Region "Property"
    Private strLastError As String

    Public Property LastError() As String
        Get
            Return strLastError
        End Get
        Set(ByVal value As String)
            strLastError = value
        End Set
    End Property
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Inicializa variables
    ''' </summary>
    Protected Sub New()
        ResetLastError()
    End Sub
#End Region

#Region "Class methods"

    Protected Sub ResetLastError()
        strLastError = String.Empty
    End Sub

    Protected Sub AppendError(ByVal exception As Exception)
        strLastError = exception.Message
        Dim innerException As Exception

        Try
            innerException = exception.InnerException

            While innerException IsNot Nothing
                strLastError &= vbCrLf & innerException.Message
                innerException = innerException.InnerException
            End While
        Catch ex As Exception

        End Try

    End Sub

    Public Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Throw New NotImplementedException()
    End Function

    Public Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Throw New NotImplementedException()
    End Function

    Public Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Throw New NotImplementedException()
    End Function

    Public Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Throw New NotImplementedException()
    End Function
#End Region

#Region "BD Methods"
    Protected Function BuildParameter(ByVal name As String, ByVal value As Object, ByVal dbType As DbType) As MySqlParameter
        Dim param As New MySqlParameter With {
            .ParameterName = name,
            .Value = value,
            .DbType = dbType
        }

        Return param
    End Function
#End Region
End Class
