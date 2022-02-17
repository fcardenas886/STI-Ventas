Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para encabezado de orden de compra
''' </summary>
''' <remarks>05.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ComprasController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblCompraHeader"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As CompraHeaderModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CompraHeaderModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblCompraHeader(NumeroCompra, Moneda, Nombre, IdProveedor, Contacto, OrdenProveedor, Estado, FormaPago, FechaEntrega, Correo) " &
                    "VALUES(@Id, @Moneda, @Name, @IdProveedor, @Contacto, @OrdenProveedor, @Estado, @FormaPago, @FechaEntrega, @Correo);"

            params.Add(BuildParameter("@Id", table.NumeroCompra, DbType.String))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@IdProveedor", table.IdProveedor, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))
            params.Add(BuildParameter("@OrdenProveedor", table.OrdenProveedor, DbType.String))

            params.Add(BuildParameter("@Estado", table.Estado, DbType.String))
            params.Add(BuildParameter("@FormaPago", table.FormaPago, DbType.String))
            params.Add(BuildParameter("@FechaEntrega", table.FechaEntrega, DbType.Date))
            params.Add(BuildParameter("@Correo", table.Correo, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As CompraHeaderModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CompraHeaderModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblCompraHeader WHERE NumeroCompra = @Id;"

            params.Add(BuildParameter("@Id", table.NumeroCompra, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As CompraHeaderModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CompraHeaderModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblCompraHeader SET Nombre = @Name, " &
                    "Moneda = @Moneda, IdProveedor = @IdProveedor, Contacto = @Contacto, OrdenProveedor = @OrdenProveedor, " &
                    "Estado = @Estado, FormaPago = @FormaPago, FechaEntrega = @FechaEntrega, Correo = @Correo " &
                    "WHERE NumeroCompra = @Id;"

            params.Add(BuildParameter("@Id", table.NumeroCompra, DbType.String))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@IdProveedor", table.IdProveedor, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))
            params.Add(BuildParameter("@OrdenProveedor", table.OrdenProveedor, DbType.String))

            params.Add(BuildParameter("@Estado", table.Estado, DbType.String))
            params.Add(BuildParameter("@FormaPago", table.FormaPago, DbType.String))
            params.Add(BuildParameter("@FechaEntrega", table.FechaEntrega, DbType.Date))
            params.Add(BuildParameter("@Correo", table.Correo, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of CompraHeaderModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, NumeroCompra, Moneda, Nombre, IdProveedor, Contacto, OrdenProveedor, Estado, FormaPago, FechaEntrega, Correo, Contacto FROM TblCompraHeader"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New CompraHeaderModel With {
                            .Id = dataRow(0),
                            .NumeroCompra = dataRow(1),
                            .Moneda = dataRow(2),
                            .Nombre = dataRow(3),
                            .IdProveedor = dataRow(4),
                            .Contacto = dataRow(5),
                            .OrdenProveedor = dataRow(6),
                            .Estado = dataRow(7),
                            .FormaPago = dataRow(8),
                            .FechaEntrega = dataRow(9),
                            .Correo = dataRow(10)
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

#Region "Class methods: POS"
    Public Function ConfirmPurchaseOrder(table As CompraHeaderModel) As Boolean
        Dim ret As Boolean = False
        Dim records As List(Of CompraDetallesModel)
        Dim transacciones As List(Of TransaccionInventarioModel)
        Dim inventTrans As TransaccionInventarioModel
        Dim iCounter As Integer
        Dim controller As TransaccionInventarioController
        Dim sqlUpdate As String

        Try

            records = GetPurchaseOrderLines(table.Id)

            If records.Count < 1 And Not String.IsNullOrEmpty(LastError) Then
                Throw New Exception(String.Format("Error recuperando las líneas. " & LastError))
            End If

            transacciones = New List(Of TransaccionInventarioModel)
            iCounter = 1

            For Each purchLine As CompraDetallesModel In records
                inventTrans = New TransaccionInventarioModel With {
                    .IdArticulo = purchLine.IdProducto,
                    .Cantidad = purchLine.Cantidad,
                    .Costo = purchLine.MontoNeto,
                    .Estatus = EstadoInventario.Comprado,
                    .FechaMovimiento = DateTime.Now,
                    .IdTransaccion = String.Format("{0}-{1}", table.NumeroCompra, iCounter),
                    .Moneda = table.Moneda,
                    .NumeroReferencia = table.NumeroCompra,
                    .Referencia = OrdenCompraReferencia(),
                    .TipoTransaccion = TipoTransaccionInventario.Compras,
                    .Unidad = purchLine.Unidad
                }

                iCounter += 1
                transacciones.Add(inventTrans)
            Next

            sqlUpdate = $"UPDATE TblCompraHeader SET Estado = 1 WHERE Id = {table.Id};"

            controller = New TransaccionInventarioController()
            ret = controller.InsertTransaction(transacciones, sqlUpdate)

            LastError = controller.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Function GetPurchaseOrderLines(idNumeroCompra As Long)
        Dim controller As ComprasDetalleController
        Dim records As List(Of CompraDetallesModel) = Nothing
        Dim dbSelect As DBSelect

        Try
            controller = New ComprasDetalleController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("IdCompra", DBFilterType.Equal, idNumeroCompra))

            records = controller.GetListWithFilters(Of CompraDetallesModel)(dbSelect)

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                Throw New Exception(controller.LastError)
            End If

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return records
    End Function

    Public Function GetTotals(idCompra As Integer) As OrdenCompraTotales
        Dim totals As OrdenCompraTotales = Nothing
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim params As List(Of MySqlParameter)

        Try
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "select count(Id) NumeroLineas, sum(Cantidad) Cantidad, sum(MontoNeto) Total, sum(Descuento) Descuento from stiventas.TblCompraDetalles FORCE INDEX(IdHeader) WHERE IdCompra = @Id;"

            params.Add(BuildParameter("@Id", idCompra, DbType.Int32))
            dataTable = dbConnector.ReadDataTable(sql, params)
            totals = New OrdenCompraTotales()

            For Each dataRow As DataRow In dataTable.Rows
                totals =
                        New OrdenCompraTotales With {
                            .NumeroLineas = dataRow(0),
                            .Cantidad = dataRow(1),
                            .Total = dataRow(2),
                            .Descuento = dataRow(3)
                            }
                Exit For

            Next

            totals.IdCompra = idCompra
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return totals
    End Function

    Protected Overrides Sub HandleCustomRowForQueryToList(ByRef objectToReturn As Object, ByVal dataRow As DataRow, propertyName As String)
        Dim model As CompraHeaderModel

        Try
            model = objectToReturn

            If model Is Nothing Then
                Return
            End If

            Select Case propertyName.ToUpper()
                Case "ESTADO"
                    Dim iValue As Integer = CType(dataRow("Estado"), Integer)
                    model.Estado = iValue
            End Select

            objectToReturn = model
        Catch
            Return
        End Try
    End Sub

#End Region
End Class
