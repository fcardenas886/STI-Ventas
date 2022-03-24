Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para detalles de OV
''' </summary>
''' <remarks>17.02.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class VentaDetallesController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblVentaDetalle"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As OrdenVentaDetalleModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, OrdenVentaDetalleModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblVentaDetalle(IdVenta, NumeroLinea, IdProducto, Unidad, Nombre, Cantidad, PrecioUnitario, Descuento, Monto, IdArticulo) " &
                    "VALUES(@Id, @NumeroLinea, @IdProducto, @Unidad, @Nombre, @Cantidad, @PrecioUnitario, @Descuento, @Monto, @IdArticulo);"

            params.Add(BuildParameter("@Id", table.IdVenta, DbType.Int32))
            params.Add(BuildParameter("@NumeroLinea", table.NumeroLinea, DbType.Int32))
            params.Add(BuildParameter("@IdProducto", table.IdProducto, DbType.Int32))
            params.Add(BuildParameter("@Unidad", table.Unidad, DbType.String))
            params.Add(BuildParameter("@Nombre", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Cantidad", table.Cantidad, DbType.Decimal))

            params.Add(BuildParameter("@PrecioUnitario", table.PrecioUnitario, DbType.Decimal))
            params.Add(BuildParameter("@Descuento", table.Descuento, DbType.Decimal))
            params.Add(BuildParameter("@Monto", table.Monto, DbType.Decimal))
            params.Add(BuildParameter("@IdArticulo", table.IdArticulo, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As OrdenVentaDetalleModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, OrdenVentaDetalleModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblVentaDetalle WHERE Id = @Id;"

            params.Add(BuildParameter("@Id", table.Id, DbType.Int32))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As OrdenVentaDetalleModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, OrdenVentaDetalleModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblVentaDetalle SET IdVenta= @IdVenta, NumeroLinea= @NumeroLinea, IdProducto= @IdProducto, " &
                    "Unidad= @Unidad, Nombre= @Nombre, Cantidad= @Cantidad, PrecioUnitario= @PrecioUnitario, Descuento= @Descuento, Monto = @Monto, IdArticulo = @IdArticulo " &
                    "WHERE Id = @Id;"

            params.Add(BuildParameter("@Id", table.Id, DbType.String))
            params.Add(BuildParameter("@IdVenta", table.IdVenta, DbType.Int32))
            params.Add(BuildParameter("@NumeroLinea", table.NumeroLinea, DbType.Int32))
            params.Add(BuildParameter("@IdProducto", table.IdProducto, DbType.Int32))
            params.Add(BuildParameter("@Unidad", table.Unidad, DbType.String))
            params.Add(BuildParameter("@Nombre", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Cantidad", table.Cantidad, DbType.Decimal))

            params.Add(BuildParameter("@PrecioUnitario", table.PrecioUnitario, DbType.Decimal))
            params.Add(BuildParameter("@Descuento", table.Descuento, DbType.Decimal))
            params.Add(BuildParameter("@Monto", table.Monto, DbType.Decimal))
            params.Add(BuildParameter("@IdArticulo", table.IdArticulo, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of OrdenVentaDetalleModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdVenta, NumeroLinea, IdProducto, Unidad, Nombre, Cantidad, PrecioUnitario, Descuento, Monto, IdArticulo FROM TblVentaDetalle"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New OrdenVentaDetalleModel With {
                            .Id = dataRow(0),
                            .IdVenta = dataRow(1),
                            .NumeroLinea = dataRow(2),
                            .IdProducto = dataRow(3),
                            .Unidad = dataRow(4),
                            .Nombre = dataRow(5),
                            .Cantidad = dataRow(6),
                            .PrecioUnitario = dataRow(7),
                            .Descuento = dataRow(8),
                            .Monto = dataRow(9)
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
