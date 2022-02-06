
Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para Unidades de medida
''' </summary>
''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class UnidadController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblUnidadMedida"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As UnidadMedidaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, UnidadMedidaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblUnidadMedida(IdUnidad, Nombre, Alias) VALUES(@Id, @Name, @Alias);"

            params.Add(BuildParameter("@Id", table.Unidad, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Alias", table.AliasUnidad, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As UnidadMedidaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, UnidadMedidaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblUnidadMedida WHERE IdUnidad = @Id;"

            params.Add(BuildParameter("@Id", table.Unidad, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As UnidadMedidaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, UnidadMedidaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblUnidadMedida SET Nombre = @Name, Alias = @Alias WHERE IdUnidad = @Id;"

            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Alias", table.AliasUnidad, DbType.String))
            params.Add(BuildParameter("@Id", table.Unidad, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of UnidadMedidaModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdUnidad, IFNULL(Nombre, ''), IFNULL(Alias, '') FROM TblUnidadMedida"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New UnidadMedidaModel With {
                            .Id = dataRow(0),
                            .Unidad = dataRow(1),
                            .Nombre = dataRow(2),
                            .AliasUnidad = dataRow(3)}
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
