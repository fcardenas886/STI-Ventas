
Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para configuración dinamica
''' </summary>
''' <remarks>24.02.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class STIConfigController : Inherits ControllerBase : Implements IDBOperations

    Private Const DescripcionTabla As String = "config"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As STIConfigModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, STIConfigModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO config(clave, valor) VALUES(@Id, @Name);"

            params.Add(BuildParameter("@Id", table.clave, DbType.String))
            params.Add(BuildParameter("@Name", table.valor, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As STIConfigModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, STIConfigModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM config WHERE clave = @Id;"

            params.Add(BuildParameter("@Id", table.clave, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As STIConfigModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, STIConfigModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE config SET valor = @Name WHERE clave = @Id;"

            params.Add(BuildParameter("@Name", table.valor, DbType.String))
            params.Add(BuildParameter("@Id", table.clave, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of STIConfigModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, clave, IFNULL(valor, '') FROM config"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New STIConfigModel With {
                            .Id = dataRow(0),
                            .clave = dataRow(1),
                            .valor = dataRow(2)
                            }
                        )
            Next

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overrides Function TableName() As String
        Return DescripcionTabla
    End Function

#End Region

End Class
