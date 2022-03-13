Imports STIVentas.Controller
Imports STIVentas.Model


''' <summary>
''' Se agrega el form
''' </summary>
''' <remarks>18.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmVentaPOS
#Region "Property"
    Public Property RecordId As Long
    Public Property NumeroVenta As String
    Private IsNewSalesOrder As Boolean
    Private AllowInitFromCustomer As Boolean
    Public Shared ClienteActual As ClienteViewModel
    Public MonedaDefault As String
    Private NumeroLinea As Integer
    Public OrdenVentaActual As OrdenVentaModel

#End Region

#Region "class Construct"
    Public Sub New(recId As Long)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        RecordId = recId
        NumeroVenta = String.Empty
        IsNewSalesOrder = True
        NumeroLinea = 1
        IsNewSalesOrder = True
        txtBuscaProducto.PlaceHolder = "Presiona Enter para buscar o guardar"
        LabelNombreProducto.Text = "Ingrese un producto. Seleccione el cuadro de búsqueda"
    End Sub

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        RecordId = 0
        NumeroVenta = String.Empty
        NumeroLinea = 1
        IsNewSalesOrder = True
        txtBuscaProducto.PlaceHolder = "Presiona Enter para buscar o guardar"
        LabelNombreProducto.Text = "Ingrese un producto. Seleccione el cuadro de búsqueda"
        OrdenVentaActual = Nothing
    End Sub

#End Region

#Region "class methods"
    ''' <summary>
    ''' Obtiene el cliente por default
    ''' </summary>
    ''' <remarks>22.02.2022 jorge.nin92@gmail.com: V1</remarks>
    Protected Sub CheckClienteActual()
        Dim controller As ClienteController

        Try
            If ClienteActual Is Nothing OrElse ClienteActual.Id < 1 Then

                Cursor = Cursors.WaitCursor

                controller = New ClienteController()

                ClienteActual = controller.GetClienteMostrador()

                If ClienteActual Is Nothing Then
                    If String.IsNullOrEmpty(controller.LastError) Then
                        HandleError("Error recuperando el cliente mostrador.")
                    Else
                        HandleError(controller.LastError)
                    End If
                End If
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Limpia los campos
    ''' </summary>
    ''' <remarks>22.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Sub ClearFields()
        txtBuscaProducto.Clear()
        AllowInitFromCustomer = True
    End Sub

    Protected Sub LoadComboBoxData()
        Try
            AllowInitFromCustomer = False
            Cursor = Cursors.WaitCursor
            CheckClienteActual()

            txtBuscaProducto.Select()

        Finally
            Cursor = Cursors.Default
            AllowInitFromCustomer = True
        End Try
    End Sub

    Public Function GetCurrentSalesOrder() As OrdenVentaModel
        Dim dbTable As New OrdenVentaModel

        If OrdenVentaActual IsNot Nothing Then
            dbTable = OrdenVentaActual

            If String.IsNullOrEmpty(dbTable.NumeroVenta) AndAlso dbTable.Id <> 0 Then
                dbTable.NumeroVenta = dbTable.Id.ToString()
            End If

        Else
            dbTable.InitValue()
            dbTable.InitFromClienteView(ClienteActual)
            dbTable.IdUsuario = FrmMainMDI.ID_USUARIO

        End If

        Return dbTable
    End Function

    Protected Sub GetRecordsAndPopulateFields()
        Dim controller As VentasController
        Dim records As List(Of OrdenVentaModel)
        Dim ordenVenta As OrdenVentaModel
        Dim dbSelect As DBSelect
        Dim strDetails As String

        Try
            Cursor = Cursors.WaitCursor

            controller = New VentasController()
            dbSelect = New DBSelect(controller.TableName())
            'dbSelect.FilterFields.Add(New DBFilterFields("Id", DBFilterType.Equal, txtOrdenVentaId.Text))

            records = controller.GetListWithFilters(Of OrdenVentaModel)(dbSelect)

            If records.Count < 1 Then
                strDetails = String.Format("No se encontro la orden de venta con el identificador interno {0}.", "") 'txtOrdenVentaId.Text

                If Not String.IsNullOrEmpty(controller.LastError) Then
                    strDetails &= Environment.NewLine & "Detalles del error: " & Environment.NewLine & controller.LastError
                End If

                HandleException(strDetails)
                Return
            ElseIf records.Count > 1 Then
                HandleException(String.Format("No se encontraron {1} ordenes de venta con el identificador interno {0}", "", records.Count)) ' txtOrdenVentaId.Text
            End If

            ordenVenta = records.FirstOrDefault()

            SetValuesFromSalesOrder(ordenVenta)

            GetRecordsAndPopulateLineFields()

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Protected Sub SetValuesFromSalesOrder(ordenVenta As OrdenVentaModel)


    End Sub

    ''' <summary>
    ''' Inserta/Actualiza la OV actual
    ''' </summary>
    ''' <returns>True si guardo</returns>
    ''' <remarks>22.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function UpsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim controller As VentasController
        Dim ventaNueva As OrdenVentaModel

        Try
            Cursor = Cursors.WaitCursor
            controller = New VentasController()

            If IsNewSalesOrder Then
                ventaNueva = GetCurrentSalesOrder()
                ret = controller.Insert(ventaNueva)

                If ret Then
                    OrdenVentaActual = ventaNueva
                    OrdenVentaActual.Id = controller.LastId
                End If
                ClearLineFields()
            Else
                ret = controller.Update(GetCurrentSalesOrder())
            End If
            If Not ret Then
                HandleException(controller.LastError)
            Else
                'txtOrdenVenta.ReadOnly = True
                IsNewSalesOrder = False
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    Protected Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim controller As VentasController

        Try
            Cursor = Cursors.WaitCursor
            controller = New VentasController()
            deleted = controller.Delete(GetCurrentSalesOrder())

            If Not deleted Then
                HandleException(controller.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return deleted

    End Function

    Protected Sub OnNewRecordSelected()
        ClearFields()
        IsNewSalesOrder = True
        dgvLineas.Rows.Clear()
        NumeroVenta = String.Empty
        NumeroLinea = 1

        ClearLineFields()
        EnableFieldsBasedOnEstatus()
        txtBuscaProducto.PlaceHolder = "Presiona Enter para buscar o guardar"
        LabelNombreProducto.Text = "Ingrese un producto. Seleccione el cuadro de búsqueda"
        lblTotal.Text = "0.00"

        SetDetailsFields()

        txtBuscaProducto.Select()
    End Sub

    Protected Function DeleteInternal() As Boolean

        Dim ret As Boolean = False

        If IsNewSalesOrder Then
            ClearFields()
            ClearLineFields()
        ElseIf ValidateDeleteSalesOrder() Then
            ret = DeleteRecord()

            If ret Then
                OnNewRecordSelected()
            End If

        End If
        EnableFieldsBasedOnEstatus()
        Return ret
    End Function

    ''' <summary>
    ''' Valida si puede eliminar el registro
    ''' </summary>
    ''' <returns>True si puede borrar el registro</returns>
    ''' <remarks>22.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function ValidateDeleteSalesOrder() As Boolean
        Dim ret As Boolean = True
        Dim ordenVenta As OrdenVentaModel = GetCurrentSalesOrder()
        Dim strMsg As String = String.Empty

        If ordenVenta.Estado <> EstadoOrdenVenta.Borrador Then
            strMsg = "Solo se pueden eliminar ordenes de venta en borrador"
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        If ret Then
            ret = MessageBox.Show("Desea eliminar la orden de venta {txtOrdenVenta.Text}?", GetPOSName(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) = DialogResult.Yes

        End If

        Return ret
    End Function

    Protected Function ValidateNumberIsOk(value As String) As Boolean
        Dim dcmValue As Decimal
        Dim ret As Boolean = True

        If Not String.IsNullOrEmpty(value) Then
            ret = Decimal.TryParse(value, dcmValue)
        End If

        Return ret
    End Function

    Protected Function ValidateNumerValue(texBox As TextBox) As Boolean
        Dim ret As Boolean = True

        If Not ValidateNumberIsOk(texBox.Text) Then
            ErrorProviderSTI.SetError(texBox, "Ingrese un número para continuar.")
        Else
            ErrorProviderSTI.SetError(texBox, "")
        End If

        Return ret
    End Function

    Protected Sub CheckNumberIsOk(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            Dim textBox As TextBox = CType(sender, TextBox)

            If Not ValidateNumerValue(textBox) Then
                e.Cancel = True
            End If
        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Sub CalculateNetAmount()
        Dim qty As Decimal

        Try

            Decimal.TryParse(txtDetailsCantidad.Text, qty)
            'Decimal.TryParse(txtPrecioUnitario.Text, unitPrice)
            'Decimal.TryParse(txtDetailsDescuento.Text, discount)

            'netAmount = (qty * unitPrice) - discount
            'txtMontoLinea.Text = netAmount.ToString("N2")
        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Private Sub BuscaProductoRelacionado(Optional fromButton As Boolean = False)

        If fromButton Then
            OpenSearchFormAndFillItem()
        Else
            CheckExistItemId()
        End If

    End Sub

    Protected Sub OpenSearchFormAndFillItem()
        Dim iSelected As ISelectedRecord
        Dim frmBusqueda As FrmBuscaProducto

        Try
            frmBusqueda = New FrmBuscaProducto()
            frmBusqueda.ShowDialog(Me)

            iSelected = CType(frmBusqueda, ISelectedRecord)
            InitFieldsFromProduct(CType(iSelected.SelectedRecord(), ProductoModel))

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Sub InitFieldsFromProduct(product As ProductoModel)
        Dim total As Decimal
        Dim salesOrder As OrdenVentaModel

        Try
            If product IsNot Nothing And product.Id > 0 Then
                salesOrder = GetCurrentSalesOrder()
                If salesOrder.Id < 1 Then
                    SaveSalesOrder()
                End If

                salesOrder = GetCurrentSalesOrder()

                If salesOrder.Id > 0 Then
                    If UpsertRecordSalesLine(product) Then
                        total = txtCantidadBusqueda.Value * product.PrecioVenta
                        'dgvLineas.Rows().Add(product.IdArticulo, product.Nombre, txtCantidadBusqueda.Value, product.PrecioVenta, 0,
                        '                     total, product.Id, product.IdUnidad, product.Id, NumeroLinea)
                        CalcAndSetTotals()

                        NumeroLinea += 1
                    End If
                Else
                    HandleException("No se ha podido guardar la orden de venta.")
                End If
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Function ValidateWriteSalesOrder() As Boolean
        Dim ret As Boolean = True
        Dim model As OrdenVentaModel
        Dim strErrorMsg As String = String.Empty

        model = GetCurrentSalesOrder()

        If ClienteActual Is Nothing Then
            CheckClienteActual()

            If ClienteActual Is Nothing Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar el cliente mostrador")
            End If
        End If

        If model Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar la orden de venta actual")
        Else
            'If model.Id = 0 Then
            '    strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado la orden de venta.")
            'End If

            If model.Estado <> EstadoOrdenVenta.Borrador Then
                strErrorMsg = AppendLastError(strErrorMsg, "Solo se pueden editar ordenes de venta en estado borrador.")
            End If

        End If

        If Not String.IsNullOrEmpty(strErrorMsg) Then
            ret = CheckFailed(strErrorMsg)
        End If


        Return ret
    End Function

    Protected Function ValidateWriteSalesOrderLine(salesLine As OrdenVentaDetalleModel) As Boolean
        Dim ret As Boolean = True
        Dim model As OrdenVentaModel
        Dim modelLine As OrdenVentaDetalleModel
        Dim strErrorMsg As String = String.Empty

        model = GetCurrentSalesOrder()
        modelLine = salesLine

        If model Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar la orden de venta actual.")
        Else
            If model.Id = 0 Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado la orden de venta.")
            End If
            If model.Estado <> EstadoOrdenVenta.Borrador Then
                strErrorMsg = AppendLastError(strErrorMsg, "Solo se pueden editar ordenes de venta en estado borrador.")
            End If

        End If
        If modelLine Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar la línea de orden de venta actual.")
        Else
            If modelLine.IdProducto < 0 Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado el producto para la nueva línea.")
            End If
            If modelLine.Cantidad = 0 Then
                strErrorMsg = AppendLastError(strErrorMsg, "Debe indicar una cantidad para continuar.")
            End If
        End If

        If Not String.IsNullOrEmpty(strErrorMsg) Then
            ret = CheckFailed(strErrorMsg)
        End If


        Return ret
    End Function

    Public Function GetCurrentSalesOrderLine() As OrdenVentaDetalleModel
        Dim dbTable As New OrdenVentaDetalleModel()

        If dgvLineas.CurrentRow IsNot Nothing Then
            dbTable.IdArticulo = CStr(dgvLineas.CurrentRow.Cells.Item(0).Value)
            dbTable.Nombre = CStr(dgvLineas.CurrentRow.Cells.Item(1).Value)
            dbTable.PrecioUnitario = CDec(dgvLineas.CurrentRow.Cells.Item(3).Value)
            dbTable.Cantidad = CDec(dgvLineas.CurrentRow.Cells.Item(2).Value)
            dbTable.Descuento = CDec(dgvLineas.CurrentRow.Cells.Item(4).Value)
            dbTable.Monto = CDec(dgvLineas.CurrentRow.Cells.Item(5).Value)

            dbTable.IdProducto = CInt(dgvLineas.CurrentRow.Cells.Item(6).Value)
            dbTable.Unidad = CStr(dgvLineas.CurrentRow.Cells.Item(7).Value)
            dbTable.NumeroLinea = CInt(dgvLineas.CurrentRow.Cells.Item(8).Value)
            dbTable.Id = CLng(dgvLineas.CurrentRow.Cells.Item(9).Value)
        End If

        Return dbTable
    End Function

    Protected Sub GetRecordsAndPopulateLineFields()
        Dim controller As VentaDetallesController
        Dim records As List(Of OrdenVentaDetalleModel)
        Dim dbSelect As DBSelect
        Dim isWaitCursor As Boolean
        Dim salesId As Long

        Try
            salesId = GetCurrentSalesOrder().Id
            If salesId < 1 Then
                Return
            End If

            isWaitCursor = True
            If Cursor IsNot Cursors.WaitCursor Then
                isWaitCursor = False
                Cursor = Cursors.WaitCursor
            End If

            controller = New VentaDetallesController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("IdVenta", DBFilterType.Equal, salesId))

            records = controller.GetListWithFilters(Of OrdenVentaDetalleModel)(dbSelect)

            dgvLineas.Rows.Clear()

            For Each model As OrdenVentaDetalleModel In records
                dgvLineas.Rows().Add(model.IdArticulo, model.Nombre,
                                        model.Cantidad, model.PrecioUnitario, model.Descuento,
                                        model.Monto, model.IdProducto, model.Unidad, model.NumeroLinea, model.Id)
                'dgvLineas.Rows().Add(model.Id, model.NumeroLinea, model.IdProducto, model.Nombre,
                '                        model.Cantidad, model.PrecioUnitario, model.Descuento,
                '                        model.Monto)
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If
            CalcAndSetTotals()
        Catch ex As Exception
            HandleException(ex)
        Finally
            If Not isWaitCursor Then
                Cursor = Cursors.Default
            End If
        End Try

    End Sub

    ''' <summary>
    ''' Inserta/Actualiza la línea de OV actual
    ''' </summary>
    ''' <returns>True si guardo</returns>
    ''' <param name="product">El producto del que se inicializa</param>
    ''' <remarks>22.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function UpsertRecordSalesLine(Optional product As ProductoModel = Nothing) As Boolean
        Dim ret As Boolean = False
        Dim controller As VentaDetallesController
        Dim lineaVenta As OrdenVentaDetalleModel

        Try
            Cursor = Cursors.WaitCursor

            If product IsNot Nothing Then
                lineaVenta = GetSalesOrderFromProduct(product)
            Else
                lineaVenta = GetCurrentSalesOrderLine()
            End If

            If Not ValidateWriteSalesOrderLine(lineaVenta) Then
                Return ret
            End If

            controller = New VentaDetallesController()

            If lineaVenta.Id = 0 Then
                lineaVenta.NumeroLinea = NumeroLinea
                ret = controller.Insert(lineaVenta)
            Else
                ret = controller.Update(lineaVenta)
            End If
            If Not ret Then
                HandleException(controller.LastError)
            Else
                GetRecordsAndPopulateLineFields()
                ClearLineFields()
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Limpia los campos para líneas
    ''' </summary>
    ''' <remarks>07.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Sub ClearLineFields()

        txtBuscaProducto.Clear()
        txtCantidadBusqueda.Value = 1


    End Sub

    Protected Function DeleteSalesLineRecord() As Boolean
        Dim deleted As Boolean = False
        Dim controller As VentaDetallesController
        Dim model As OrdenVentaDetalleModel

        Try
            model = GetCurrentSalesOrderLine()

            If model.Id = 0 Then
                ClearLineFields()
                txtBuscaProducto.Select()

                Return True
            End If

            Cursor = Cursors.WaitCursor
            controller = New VentaDetallesController()
            deleted = controller.Delete(model)

            If Not deleted Then
                HandleException(controller.LastError)
            Else
                ClearLineFields()
                GetRecordsAndPopulateLineFields()

                If dgvLineas.Rows.Count < 1 Then
                    SetDetailsFields()
                End If
            End If

            txtBuscaProducto.Select()

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return deleted

    End Function

    Protected Sub ConfirmSalesOrder()
        'Dim frmConfirm As FrmConfirmarOrdenVenta
        'Dim ordenVenta As OrdenVentaModel
        'Try
        '    ordenVenta = GetCurrentSalesOrder()
        '    ' ToDo: Actualizar
        '    If ValidateConfirmSalesOrder(ordenVenta) Or True Then
        '        frmConfirm = New FrmConfirmarOrdenVenta(ordenVenta)

        '        If frmConfirm.ShowDialog(Me) = DialogResult.OK Then
        '            If frmConfirm.IsSalesConfirmed Then
        '                cboEstatus.SelectedIndex = EstadoOrdenVenta.Confirmado
        '                EnableFieldsBasedOnEstatus()
        '            End If
        '        End If
        '    End If

        'Catch ex As Exception
        '    HandleException(ex)
        'End Try
    End Sub

    Protected Function ValidateConfirmSalesOrder(ordenVenta As OrdenVentaModel) As Boolean
        Dim ret As Boolean = True
        Dim strMsg As String = String.Empty

        If ordenVenta Is Nothing Or ordenVenta.Id = 0 Then
            strMsg = "No se puede recuperar la orden de venta." & Environment.NewLine
        Else
            If ordenVenta.Estado <> EstadoOrdenVenta.Borrador Then
                strMsg = "La orden de venta tiene un estatus no valido." & Environment.NewLine
            End If
            If dgvLineas.Rows.Count < 1 Then
                strMsg = "Se debe especificar al menos una línea para poder confirmar la orden de venta." & Environment.NewLine
            End If
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

    Private Sub EnableFieldsBasedOnEstatus()
        'Dim allowEdit As Boolean

        Try
            'allowEdit = cboEstatus.SelectedValue = EstadoOrdenVenta.Borrador

            'txtOrdenVenta.ReadOnly = Not allowEdit
            'txtVendorName.ReadOnly = Not allowEdit
            'txtOrdenCliente.ReadOnly = Not allowEdit
            'txtContacto.ReadOnly = Not allowEdit
            'txtEmail.ReadOnly = Not allowEdit
            'dateTimeFechaEntrega.Enabled = allowEdit

            'cboFormaPago.Enabled = allowEdit
            'cboCliente.Enabled = allowEdit
            'cboMoneda.Enabled = allowEdit

            'cboUnidad.Enabled = allowEdit
            'txtBuscaProducto.ReadOnly = Not allowEdit
            'txtItemName.ReadOnly = Not allowEdit
            'txtDetailsCantidad.ReadOnly = Not allowEdit
            'txtDetailsDescuento.ReadOnly = Not allowEdit
            'txtPrecioUnitario.ReadOnly = Not allowEdit

            'btnAddLine.Enabled = allowEdit
            'btnGuardarOC.Enabled = allowEdit
            'btnEditLine.Enabled = allowEdit
            'btnDeleteLine.Enabled = allowEdit

            'btnSeleccionarArticulo.Enabled = allowEdit
            'ConfirmarToolStripMenuItem.Enabled = allowEdit
            'EliminarToolStripMenuItem.Enabled = allowEdit

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Sub CheckExistItemId()
        Dim iSelected As ISelectedRecord
        Dim frmBusqueda As FrmBuscaProducto
        Dim controller As ProductosController
        Dim records As List(Of ProductoModel)
        Dim dbSelect As DBSelect
        Dim model As ProductoModel

        Try
            If String.IsNullOrEmpty(txtBuscaProducto.Text) Then
                OpenSearchFormAndFillItem()
            Else
                Cursor = Cursors.WaitCursor

                controller = New ProductosController()
                dbSelect = New DBSelect(controller.TableName())

                dbSelect.FilterFields.Add(New DBFilterFields("IdArticulo", DBFilterType.Contains, String.Format("%{0}%", txtBuscaProducto.Text)))
                records = controller.GetListWithFilters(Of ProductoModel)(dbSelect)

                If records.Count < 1 Then
                    OpenSearchFormAndFillItem()
                ElseIf records.Count = 1 Then
                    model = records.FirstOrDefault()
                    InitFieldsFromProduct(model)
                Else
                    frmBusqueda = New FrmBuscaProducto()
                    frmBusqueda.InitFromExistingValues(txtBuscaProducto.Text, records)
                    frmBusqueda.ShowDialog(Me)

                    iSelected = CType(frmBusqueda, ISelectedRecord)
                    InitFieldsFromProduct(CType(iSelected.SelectedRecord(), ProductoModel))

                End If

            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
        Cursor = Cursors.Default

    End Sub

    Protected Sub SetDetailsFields()
        Dim salesLine = GetCurrentSalesOrderLine()
        Try
            If dgvLineas.CurrentRow IsNot Nothing Then
                txtDetailsCodigoBarras.Text = salesLine.IdArticulo
                txtDetailsDescripcion.Text = salesLine.Nombre
                txtDetailsPrecio.Text = salesLine.PrecioUnitario.ToString("N2")
                txtDetailsCantidad.Text = salesLine.Cantidad.ToString("N0")
                txtDetailsDescuento.Text = salesLine.Descuento.ToString("N2")
                txtDetailsTotalLinea.Text = salesLine.Monto.ToString("N2")

                LabelNombreProducto.Text = salesLine.Nombre
            Else
                txtDetailsCodigoBarras.Text = salesLine.IdArticulo
                txtDetailsDescripcion.Text = salesLine.Nombre
                txtDetailsPrecio.Text = salesLine.PrecioUnitario.ToString("N2")
                txtDetailsCantidad.Text = salesLine.Cantidad.ToString("N0")
                txtDetailsDescuento.Text = salesLine.Descuento.ToString("N2")
                txtDetailsTotalLinea.Text = salesLine.Monto.ToString("N2")
                LabelNombreProducto.Text = "Ingrese un producto. Seleccione el cuadro de búsqueda"
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try

    End Sub

    Private Sub CalcAndSetTotals()
        Dim total As Decimal

        Try
            total = GetTotals()

            lblTotal.Text = total.ToString("N2")

            If OrdenVentaActual IsNot Nothing Then
                OrdenVentaActual.Total = total
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Private Function GetTotals() As Decimal
        Dim total, auxValue As Decimal

        Try
            total = 0
            For Each row As DataGridViewRow In dgvLineas.Rows
                auxValue = CType(row.Cells("TotalLinea").Value, Decimal)
                total += auxValue
            Next

        Catch ex As Exception
            HandleException(ex)
        End Try

        Return total
    End Function

    Protected Sub SaveSalesOrder()

        Try

            If ValidateWriteSalesOrder() Then
                UpsertRecord()
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Function GetSalesOrderFromProduct(product As ProductoModel) As OrdenVentaDetalleModel

        Dim ret As New OrdenVentaDetalleModel

        ret.InitFromProduct(product)
        ret.IdVenta = CInt(GetCurrentSalesOrder().Id)
        ret.Monto = txtCantidadBusqueda.Value * product.PrecioVenta
        ret.NumeroLinea = NumeroLinea
        ret.Descuento = 0
        ret.Cantidad = txtCantidadBusqueda.Value

        Return ret
    End Function

    Protected Sub Cerrar()
        Close()
    End Sub

    Protected Function ValidateTicket() As Boolean
        Dim ret As Boolean = True
        Dim ordenVenta As OrdenVentaModel
        Dim strErrorMsg As String = String.Empty

        Try
            ordenVenta = GetCurrentSalesOrder()

            If ordenVenta Is Nothing Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar la orden de venta actual.")
            Else
                If ordenVenta.Id = 0 Then
                    strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado la orden de venta.")
                End If
                If ordenVenta.Estado <> EstadoOrdenVenta.Borrador Then
                    strErrorMsg = AppendLastError(strErrorMsg, "Solo se pueden editar ordenes de venta en estado borrador.")
                End If

            End If
            If dgvLineas.Rows.Count < 1 Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se han especificado líneas.")
            End If

            If Not String.IsNullOrEmpty(strErrorMsg) Then
                ret = CheckFailed(strErrorMsg)
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try

        Return ret
    End Function

    Protected Sub PreviewTicket()

        If ValidateTicket() Then
            PrintTicket()
        End If

    End Sub

    Protected Sub CobrarOV()
        Dim cobro As FrmCobroVenta

        If ValidateTicket() Then
            cobro = New FrmCobroVenta(GetCurrentSalesOrder()) With {
                .Lineas = GetLinesFromGrid()
            }

            cobro.ShowDialog(Me)

            If cobro.Cobrado Then
                OrdenVentaActual = Nothing
                OnNewRecordSelected()
            End If
        End If

    End Sub

    Private Function GetLinesFromGrid() As List(Of OrdenVentaDetalleModel)

        Dim ret As New List(Of OrdenVentaDetalleModel)
        Dim dbTable As OrdenVentaDetalleModel

        For Each row As DataGridViewRow In dgvLineas.Rows
            dbTable = New OrdenVentaDetalleModel()

            dbTable.IdArticulo = CStr(row.Cells.Item(0).Value)
            dbTable.Nombre = CStr(row.Cells.Item(1).Value)
            dbTable.PrecioUnitario = CDec(row.Cells.Item(3).Value)
            dbTable.Cantidad = CDec(row.Cells.Item(2).Value)
            dbTable.Descuento = CDec(row.Cells.Item(4).Value)
            dbTable.Monto = CDec(row.Cells.Item(5).Value)

            dbTable.IdProducto = CInt(row.Cells.Item(6).Value)
            dbTable.Unidad = CStr(row.Cells.Item(7).Value)
            dbTable.NumeroLinea = CInt(row.Cells.Item(8).Value)
            dbTable.Id = CLng(dgvLineas.CurrentRow.Cells.Item(9).Value)

            ret.Add(dbTable)
        Next

        Return ret
    End Function

    Protected Sub PrintTicket()
        Dim ordenVenta As OrdenVentaModel
        Dim totals As OrdenVentaCobroViewModel
        Dim lineas As List(Of OrdenVentaDetalleModel)

        Try

            ordenVenta = GetCurrentSalesOrder()
            ordenVenta.Total = GetTotals()

            lineas = GetLinesFromGrid()

            totals = New OrdenVentaCobroViewModel()

            totals.InitFromOrdenVentaModel(ordenVenta)
            totals.Efectivo = ordenVenta.Total
            totals.UserName = FrmMainMDI.USERNAME

            If Not VentasHelper.PrintTicket(totals, ordenVenta, lineas) Then
                HandleError("Error imprimiendo el ticket, intente nuevamente por favor.")
            End If

            ordenVenta = Nothing
            totals = Nothing
            lineas = Nothing

        Catch ex As Exception
            HandleError(ex)
        End Try

    End Sub

    Private Sub HandleQtyOk()
        If txtCantidadBusqueda.Value <> 0 And Not String.IsNullOrEmpty(txtBuscaProducto.Text) Then
            BuscaProductoRelacionado()

        End If
    End Sub

#End Region

#Region "Events"
    Private Sub btnCobrarOV_Click(sender As Object, e As EventArgs) Handles btnCobrarOV.Click
        CobrarOV()
    End Sub

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        BuscaProductoRelacionado(True)
    End Sub

    Private Sub txtBuscaProducto_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscaProducto.KeyUp
        If e.KeyData = Keys.Enter Then
            BuscaProductoRelacionado()
        End If
    End Sub

    Private Sub dgvLineas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvLineas.SelectionChanged
        SetDetailsFields()
    End Sub

    Private Sub FrmVentaPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBoxData()
    End Sub

    Private Sub btnGuardarLinea_Click(sender As Object, e As EventArgs) Handles btnGuardarLinea.Click
        SaveSalesOrder()
    End Sub

    Private Sub btnAnularProducto_Click(sender As Object, e As EventArgs) Handles btnAnularProducto.Click
        DeleteSalesLineRecord()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Cerrar()
    End Sub

    Private Sub btnTicketPreventa_Click(sender As Object, e As EventArgs) Handles btnTicketPreventa.Click
        PreviewTicket()
    End Sub

    Private Sub txtCantidadBusqueda_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCantidadBusqueda.KeyUp
        If e.KeyData = Keys.Enter Then
            HandleQtyOk()
        End If
    End Sub
#End Region
End Class