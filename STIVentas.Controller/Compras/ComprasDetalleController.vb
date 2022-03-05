Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para encabezado de orden de compra
''' </summary>
''' <remarks>05.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ComprasDetalleController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblCompraDetalles"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As CompraDetallesModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CompraDetallesModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblCompraDetalles(IdCompra, NumeroLinea, IdProducto, Unidad, NombreProducto, Cantidad, PrecioUnitario, Descuento, MontoNeto) " &
                    "VALUES(@Id, @NumeroLinea, @IdProducto, @Unidad, @NombreProducto, @Cantidad, @PrecioUnitario, @Descuento, @MontoNeto);"

            params.Add(BuildParameter("@Id", table.IdCompra, DbType.Int32))
            params.Add(BuildParameter("@NumeroLinea", table.NumeroLinea, DbType.Int32))
            params.Add(BuildParameter("@IdProducto", table.IdProducto, DbType.Int32))
            params.Add(BuildParameter("@Unidad", table.Unidad, DbType.String))
            params.Add(BuildParameter("@NombreProducto", table.NombreProducto, DbType.String))
            params.Add(BuildParameter("@Cantidad", table.Cantidad, DbType.Decimal))

            params.Add(BuildParameter("@PrecioUnitario", table.PrecioUnitario, DbType.Decimal))
            params.Add(BuildParameter("@Descuento", table.Descuento, DbType.Decimal))
            params.Add(BuildParameter("@MontoNeto", table.MontoNeto, DbType.Decimal))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As CompraDetallesModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CompraDetallesModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblCompraDetalles WHERE Id = @Id;"

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
        Dim table As CompraDetallesModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CompraDetallesModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblCompraDetalles SET NumeroCompra = @IdCompra, IdCompra= @IdCompra, NumeroLinea= @NumeroLinea, IdProducto= @IdProducto, " &
                    "Unidad= @Unidad, NombreProducto= @NombreProducto, Cantidad= @Cantidad, PrecioUnitario= @PrecioUnitario, Descuento= @Descuento, MontoNeto = @MontoNeto " &
                    "WHERE Id = @Id;"

            params.Add(BuildParameter("@Id", table.Id, DbType.String))
            params.Add(BuildParameter("@IdCompra", table.IdCompra, DbType.Int32))
            params.Add(BuildParameter("@NumeroLinea", table.NumeroLinea, DbType.Int32))
            params.Add(BuildParameter("@IdProducto", table.IdProducto, DbType.Int32))
            params.Add(BuildParameter("@Unidad", table.Unidad, DbType.String))
            params.Add(BuildParameter("@NombreProducto", table.NombreProducto, DbType.String))
            params.Add(BuildParameter("@Cantidad", table.Cantidad, DbType.Decimal))

            params.Add(BuildParameter("@PrecioUnitario", table.PrecioUnitario, DbType.Decimal))
            params.Add(BuildParameter("@Descuento", table.Descuento, DbType.Decimal))
            params.Add(BuildParameter("@MontoNeto", table.MontoNeto, DbType.Decimal))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of CompraDetallesModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdCompra, NumeroLinea, IdProducto, Unidad, NombreProducto, Cantidad, PrecioUnitario, Descuento, MontoNeto FROM TblCompraDetalles"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New CompraDetallesModel With {
                            .Id = dataRow(0),
                            .IdCompra = dataRow(1),
                            .NumeroLinea = dataRow(2),
                            .IdProducto = dataRow(3),
                            .Unidad = dataRow(4),
                            .NombreProducto = dataRow(5),
                            .Cantidad = dataRow(6),
                            .PrecioUnitario = dataRow(7),
                            .Descuento = dataRow(8),
                            .MontoNeto = dataRow(9)
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
