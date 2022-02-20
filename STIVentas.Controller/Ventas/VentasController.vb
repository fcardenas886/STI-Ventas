﻿Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para OV
''' </summary>
''' <remarks>17.02.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class VentasController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblVenta"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As OrdenVentaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, OrdenVentaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblVenta(NumeroVenta, Moneda, Nombre, Cliente, Contacto, OrdenCliente, Estado, FormaPago, Fecha, Correo, Total, IdUsuario) " &
                    "VALUES(@Id, @Moneda, @Name, @Cliente, @Contacto, @OrdenCliente, @Estado, @FormaPago, @Fecha, @Correo, @Total, @IdUsuario);"

            params.Add(BuildParameter("@Id", table.NumeroVenta, DbType.String))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Cliente", table.Cliente, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))
            params.Add(BuildParameter("@OrdenCliente", table.OrdenCliente, DbType.String))

            params.Add(BuildParameter("@Estado", table.Estado, DbType.String))
            params.Add(BuildParameter("@FormaPago", table.FormaPago, DbType.String))
            params.Add(BuildParameter("@Fecha", table.Fecha, DbType.Date))
            params.Add(BuildParameter("@Correo", table.Correo, DbType.String))
            params.Add(BuildParameter("@Total", table.Total, DbType.Decimal))
            params.Add(BuildParameter("@IdUsuario", table.IdUsuario, DbType.Int16))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As OrdenVentaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, OrdenVentaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblVenta WHERE NumeroVenta = @Id;"

            params.Add(BuildParameter("@Id", table.NumeroVenta, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As OrdenVentaModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, OrdenVentaModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblVenta SET Nombre = @Name, " &
                    "Moneda = @Moneda, Cliente = @Cliente, Contacto = @Contacto, OrdenCliente = @OrdenCliente, " &
                    "Estado = @Estado, FormaPago = @FormaPago, Fecha = @Fecha, Correo = @Correo, Total = @Total " &
                    "WHERE NumeroVenta = @Id;"

            params.Add(BuildParameter("@Id", table.NumeroVenta, DbType.String))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Cliente", table.Cliente, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))
            params.Add(BuildParameter("@OrdenCliente", table.OrdenCliente, DbType.String))

            params.Add(BuildParameter("@Estado", table.Estado, DbType.String))
            params.Add(BuildParameter("@FormaPago", table.FormaPago, DbType.String))
            params.Add(BuildParameter("@Fecha", table.Fecha, DbType.Date))
            params.Add(BuildParameter("@Correo", table.Correo, DbType.String))
            params.Add(BuildParameter("@Total", table.Total, DbType.Decimal))
            'params.Add(BuildParameter("@IdUsuario", table.IdUsuario, DbType.Int16))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of OrdenVentaModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, NumeroVenta, Moneda, Nombre, Cliente, Contacto, OrdenCliente, Estado, FormaPago, Fecha, Correo, Contacto, Total, IdUsuario FROM TblVenta"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New OrdenVentaModel With {
                            .Id = dataRow(0),
                            .NumeroVenta = dataRow(1),
                            .Moneda = dataRow(2),
                            .Nombre = dataRow(3),
                            .Cliente = dataRow(4),
                            .Contacto = dataRow(5),
                            .OrdenCliente = dataRow(6),
                            .Estado = dataRow(7),
                            .FormaPago = dataRow(8),
                            .Fecha = dataRow(9),
                            .Correo = dataRow(10),
                            .Total = dataRow(11),
                            .IdUsuario = dataRow(12)
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
    Public Function CobrarOrdenVenta(table As OrdenVentaModel) As Boolean
        Dim ret As Boolean = False
        Dim records As List(Of OrdenVentaDetalleModel)
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

            For Each salesLine As OrdenVentaDetalleModel In records
                inventTrans = New TransaccionInventarioModel With {
                    .IdArticulo = salesLine.IdProducto,
                    .Cantidad = salesLine.Cantidad,
                    .Costo = salesLine.Monto,
                    .Estatus = EstadoInventario.Comprado,
                    .FechaMovimiento = DateTime.Now,
                    .IdTransaccion = String.Format("{0}-{1}", table.NumeroVenta, iCounter),
                    .Moneda = table.Moneda,
                    .NumeroReferencia = table.NumeroVenta,
                    .Referencia = OrdenCompraReferencia(),
                    .TipoTransaccion = TipoTransaccionInventario.Compras,
                    .Unidad = salesLine.Unidad
                }

                iCounter += 1
                transacciones.Add(inventTrans)
            Next

            sqlUpdate = $"UPDATE TblVenta SET Estado = 2 WHERE Id = {table.Id};"

            controller = New TransaccionInventarioController()
            ret = controller.InsertTransaction(transacciones, sqlUpdate)

            LastError = controller.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Function GetPurchaseOrderLines(idNumeroVenta As Long)
        Dim controller As ComprasDetalleController
        Dim records As List(Of OrdenVentaDetalleModel) = Nothing
        Dim dbSelect As DBSelect

        Try
            controller = New ComprasDetalleController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("IdCompra", DBFilterType.Equal, idNumeroVenta))

            records = controller.GetListWithFilters(Of OrdenVentaDetalleModel)(dbSelect)

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
        Dim model As OrdenVentaModel

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
