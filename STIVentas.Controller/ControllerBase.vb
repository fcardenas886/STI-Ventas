Imports System.Reflection
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
        If value Is Nothing Then
            Select Case dbType
                Case DbType.String
                    param.Value = String.Empty
                Case DbType.Int16
                Case DbType.Int32
                Case DbType.Int64
                Case DbType.Byte
                Case DbType.Decimal
                Case DbType.Single
                Case DbType.Double
                    param.Value = 0
                Case DbType.Boolean
                    param.Value = False
            End Select
        End If
        Return param
    End Function

    Protected Function BuildParameter(ByVal name As String, ByVal value As Object) As MySqlParameter
        Dim param As New MySqlParameter With {
            .ParameterName = name,
            .Value = value
        }

        Return param
    End Function

    Public Overridable Function GetListSQL(ByVal sql As String) As IEnumerable(Of IDBTable)

        Return Nothing
    End Function

    Public Overridable Function GetListWithFilters(Of T As {Class, New})(ByVal dbSelect As DBSelect) As List(Of T)
        Dim ret As List(Of T) = Nothing
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim params As List(Of MySqlParameter)

        Try
            dbConnector = New DBConnector()
            sql = dbSelect.GetAsSQL()
            ret = New List(Of T)
            params = New List(Of MySqlParameter)

            For Each param As DBFilterFields In dbSelect.FilterFields
                params.Add(BuildParameter("@" & param.FieldName, param.FieldValue))
            Next

            dataTable = dbConnector.ReadDataTable(sql, params)

            ret = ToList(Of T)(dataTable)

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Protected Function ToList(Of T As {Class, New})(ByVal table As DataTable) As List(Of T)
        Dim list As List(Of T) = Nothing

        Try
            list = New List(Of T)()

            For Each row In table.AsEnumerable()
                Dim obj As New T()
                Dim propertyName As String

                For Each prop In obj.[GetType]().GetProperties()
                    propertyName = String.Empty
                    Try
                        Dim propertyInfo As PropertyInfo = obj.[GetType]().GetProperty(prop.Name)
                        propertyName = prop.Name
                        propertyInfo.SetValue(obj, Convert.ChangeType(row(prop.Name), propertyInfo.PropertyType), Nothing)
                    Catch
                        HandleCustomRowForQueryToList(obj, row, propertyName)
                    End Try
                Next

                list.Add(obj)
            Next

            Return list
        Catch ex As Exception
            strLastError += ex.Message + Environment.NewLine
        End Try
        Return list
    End Function

    Protected Overridable Sub HandleCustomRowForQueryToList(ByRef objectToReturn As Object, ByVal dataRow As DataRow, propertyName As String)

    End Sub

    Public Overridable Function TableName() As String
        Throw New Exception("Tabla no especificada.")
    End Function

#End Region
End Class
