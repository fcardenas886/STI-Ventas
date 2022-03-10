Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para líneas de ajustes de inventario
''' </summary>
''' <remarks>06.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class AjusteInventarioDetalleController
    Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblAjusteInventarioDetalles"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As AjusteInventarioDetallesModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, AjusteInventarioDetallesModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblAjusteInventarioDetalles(IdArticulo, IdAjuste, IdProducto, Descripcion, NumeroLinea, Cantidad, Unidad) " &
                                                "VALUES(@Id, @IdAjuste, @IdProducto, @Descripcion, @NumeroLinea, @Cantidad, @Unidad);"

            params.Add(BuildParameter($"@Id", table.IdArticulo, DbType.String))
            params.Add(BuildParameter($"@IdAjuste", table.IdAjuste, DbType.Int32))
            params.Add(BuildParameter($"@IdProducto", table.IdProducto, DbType.Int32))

            params.Add(BuildParameter($"@Descripcion", table.Descripcion, DbType.String))
            params.Add(BuildParameter($"@NumeroLinea", table.NumeroLinea, DbType.String))
            params.Add(BuildParameter($"@Cantidad", table.Cantidad, DbType.Decimal))
            params.Add(BuildParameter($"@Unidad", table.Unidad, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As AjusteInventarioDetallesModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, AjusteInventarioDetallesModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblAjusteInventarioDetalles WHERE Id = @Id;"

            params.Add(BuildParameter($"@Id", table.Id, DbType.Int32))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As AjusteInventarioDetallesModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, AjusteInventarioDetallesModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblAjusteInventarioDetalles SET IdArticulo = @IdArticulo, " &
                    "IdAjuste = @IdAjuste, IdProducto = @IdProducto, " &
                    "Descripcion = @Descripcion, NumeroLinea = @NumeroLinea, Cantidad = @Cantidad, Unidad=@Unidad " &
                    "WHERE Id = @Id;"

            params.Add(BuildParameter($"@Id", table.Id, DbType.Int32))
            params.Add(BuildParameter($"@IdArticulo", table.IdArticulo, DbType.String))
            params.Add(BuildParameter($"@IdAjuste", table.IdAjuste, DbType.Int32))
            params.Add(BuildParameter($"@IdProducto", table.IdProducto, DbType.Int32))

            params.Add(BuildParameter($"@Descripcion", table.Descripcion, DbType.String))
            params.Add(BuildParameter($"@NumeroLinea", table.NumeroLinea, DbType.Int32))
            params.Add(BuildParameter($"@Cantidad", table.Cantidad, DbType.Decimal))
            params.Add(BuildParameter($"@Unidad", table.Unidad, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of AjusteInventarioDetallesModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdArticulo, IdAjuste, IdProducto, Descripcion, NumeroLinea, Cantidad, Unidad FROM TblAjusteInventarioDetalles"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New AjusteInventarioDetallesModel With {
                            .Id = dataRow(0),
                            .IdArticulo = dataRow(1),
                            .IdAjuste = dataRow(2),
                            .IdProducto = dataRow(3),
                            .Descripcion = dataRow(4),
                            .NumeroLinea = dataRow(5),
                            .Cantidad = dataRow(6),
                            .Unidad = dataRow(7)
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
