Imports MySql.Data.MySqlClient
Imports STIVentas.Model

Public Class MonedaController : Inherits ControllerBase : Implements IDBOperations

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As MonedaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, MonedaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblMoneda(CodigoMoneda, Nombre, Descripcion, Simbolo, CodigoISO, Redondear, TipoRedondeo, RedondeoVentas, RedondeoCompras, RedondeoInventario, RedondearCompras, RedondearVentas, RedondearInventario) " _
                    & "VALUES(@Id, @Name, @Descripcion, @Simbolo, @CodigoISO, @Redondear, @TipoRedondeo, @RedondeoVentas, @RedondeoCompras, @RedondeoInventario, @RedondearCompras, @RedondearVentas, @RedondearInventario);"

            params.Add(BuildParameter("@Id", table.CodigoMoneda, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Descripcion", table.Descripcion, DbType.String))
            params.Add(BuildParameter("@Simbolo", table.Simbolo, DbType.String))
            params.Add(BuildParameter("@CodigoISO", table.CodigoISO, DbType.String))

            params.Add(BuildParameter("@Redondear", table.Redondear, DbType.Boolean))
            params.Add(BuildParameter("@TipoRedondeo", table.TipoRedondeo, DbType.Int16))
            params.Add(BuildParameter("@RedondeoVentas", table.RedondeoVentas, DbType.Int16))
            params.Add(BuildParameter("@RedondeoCompras", table.RedondeoCompras, DbType.Int16))
            params.Add(BuildParameter("@RedondeoInventario", table.RedondeoInventario, DbType.Int16))

            params.Add(BuildParameter("@RedondearCompras", table.RedondearCompras, DbType.Boolean))
            params.Add(BuildParameter("@RedondearVentas", table.RedondearVentas, DbType.Boolean))
            params.Add(BuildParameter("@RedondearInventario", table.RedondearInventario, DbType.Boolean))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As MonedaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, MonedaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblMoneda WHERE CodigoMoneda = @Id;"

            params.Add(BuildParameter("@Id", table.CodigoMoneda, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As MonedaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, MonedaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblMoneda SET Nombre = @Name, Descripcion = @Descripcion " _
                    & "Simbolo = @Simbolo, CodigoISO = @CodigoISO, " _
                    & "Redondear = @Redondear, TipoRedondeo = @TipoRedondeo, " _
                    & "RedondeoVentas = @RedondeoVentas, RedondeoCompras = @RedondeoCompras, " _
                    & "RedondeoInventario = @RedondeoInventario, RedondearCompras = @RedondearCompras, " _
                    & "RedondearVentas = @RedondearVentas, RedondearInventario = @RedondearInventario " _
                    & "WHERE CodigoMoneda = @Id;"

            params.Add(BuildParameter("@Id", table.CodigoMoneda, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Descripcion", table.Descripcion, DbType.String))
            params.Add(BuildParameter("@Simbolo", table.Simbolo, DbType.String))
            params.Add(BuildParameter("@CodigoISO", table.CodigoISO, DbType.String))

            params.Add(BuildParameter("@Redondear", table.Redondear, DbType.Boolean))
            params.Add(BuildParameter("@TipoRedondeo", table.TipoRedondeo, DbType.Int16))
            params.Add(BuildParameter("@RedondeoVentas", table.RedondeoVentas, DbType.Int16))
            params.Add(BuildParameter("@RedondeoCompras", table.RedondeoCompras, DbType.Int16))
            params.Add(BuildParameter("@RedondeoInventario", table.RedondeoInventario, DbType.Int16))

            params.Add(BuildParameter("@RedondearCompras", table.RedondearCompras, DbType.Boolean))
            params.Add(BuildParameter("@RedondearVentas", table.RedondearVentas, DbType.Boolean))
            params.Add(BuildParameter("@RedondearInventario", table.RedondearInventario, DbType.Boolean))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of MonedaModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "Select Id, CodigoMoneda, IFNULL(Nombre, ''), Descripcion, Simbolo, CodigoISO, Redondear, TipoRedondeo, RedondeoVentas, RedondeoCompras, RedondeoInventario, RedondearCompras, RedondearVentas, RedondearInventario FROM TblMoneda"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New MonedaModel With {
                            .Id = dataRow(0),
                            .CodigoMoneda = dataRow(1),
                            .Nombre = dataRow(2),
                            .Descripcion = dataRow(3),
                            .Simbolo = dataRow(4),
                            .CodigoISO = dataRow(5),
                            .Redondear = dataRow(6),
                            .TipoRedondeo = dataRow(7),
                            .RedondeoVentas = dataRow(8),
                            .RedondeoCompras = dataRow(9),
                            .RedondeoInventario = dataRow(10),
                            .RedondearCompras = dataRow(11),
                            .RedondearVentas = dataRow(12),
                            .RedondearInventario = dataRow(13)}
                        )
            Next

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function
#End Region
End Class
