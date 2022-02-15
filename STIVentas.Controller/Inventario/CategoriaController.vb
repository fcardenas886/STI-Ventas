Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para categoría de productos
''' </summary>
''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class CategoriaController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblCategoria"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As CategoriaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CategoriaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblCategoria(IdCategoria, Nombre, Activo) VALUES(@Id, @Name, @Activo);"

            params.Add(BuildParameter("@Id", table.IdCategoria, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Activo", table.Activo, DbType.Boolean))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As CategoriaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CategoriaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblCategoria WHERE IdCategoria = @Id;"

            params.Add(BuildParameter("@Id", table.IdCategoria, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As CategoriaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CategoriaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblCategoria SET Nombre = @Name, Activo = @Activo WHERE IdCategoria = @Id;"

            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Id", table.IdCategoria, DbType.String))
            params.Add(BuildParameter("@Activo", table.Activo, DbType.Boolean))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of CategoriaModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdCategoria, IFNULL(Nombre, ''), Activo FROM TblCategoria"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New CategoriaModel With {
                            .Id = dataRow(0),
                            .IdCategoria = dataRow(1),
                            .Nombre = dataRow(2),
                            .Activo = dataRow(3)
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
        Return NombreTabla
    End Function

#End Region


End Class
