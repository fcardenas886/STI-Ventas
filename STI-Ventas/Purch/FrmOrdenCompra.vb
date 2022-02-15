
Imports STIVentas.Model
Imports STIVentas.Controller
''' <summary>
''' Edición de Orden de compra
''' </summary>
''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmOrdenCompra
#Region "Property"
    Public Property RecordId As Long
    Public Property NumeroCompra As String
    Private IsNewPurchaseOrder As Boolean
    Private AllowInitFromVendor As Boolean
    Private purchLineRecordId As Long
    Private ItemRecordId As Long
    Private NumeroLinea As Integer

#End Region

#Region "class Construct"
    Public Sub New(recId As Long)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        RecordId = recId
        NumeroCompra = String.Empty
        IsNewPurchaseOrder = True
    End Sub

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        RecordId = 0
        NumeroCompra = String.Empty
    End Sub

#End Region

#Region "class methods"
    ''' <summary>
    ''' Hereda los campos del proveedor a la OC
    ''' </summary>
    ''' <remarks>06.02.2022 jorge.nin92@gmail.com: V1</remarks>
    Protected Sub InitFromVendorTable()
        Dim controller As ProveedorController
        Dim records As List(Of ProveedorModel)
        Dim dbSelect As DBSelect

        Try
            If AllowInitFromVendor And cboProveedor.SelectedValue IsNot Nothing Then

                Cursor = Cursors.WaitCursor

                controller = New ProveedorController()
                dbSelect = New DBSelect(controller.TableName())
                dbSelect.FilterFields.Add(New DBFilterFields("IdProveedor", DBFilterType.Equal, cboProveedor.SelectedValue))

                records = controller.GetListWithFilters(Of ProveedorModel)(dbSelect)

                If records.Count > 0 Then
                    Dim ret As ProveedorModel = records.FirstOrDefault()

                    txtVendorName.Text = ret.Nombre
                    txtContacto.Text = ret.Contacto
                    txtEmail.Text = ret.Email

                    SetMonedaValue(ret.Moneda)
                    SetFormaPagoValue(ret.FormaPago)

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
    ''' <remarks>06.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Sub ClearFields()
        txtOrdenCompra.Clear()
        txtOrdenCompraId.Clear()
        txtOrdenProveedor.Clear()
        txtContacto.Clear()
        txtEmail.Clear()
        txtVendorName.Clear()

        AllowInitFromVendor = False
        dateTimeFechaEntrega.Value = Date.Now
        cboProveedor.SelectedIndex = -1
        cboFormaPago.SelectedIndex = -1

        Try
            If cboEstatus.DataSource IsNot Nothing Then
                cboEstatus.SelectedIndex = 0
            End If
        Catch ex As Exception
            HandleException(ex)
        End Try

        txtOrdenCompra.ReadOnly = False
        AllowInitFromVendor = True
    End Sub

    Protected Sub LoadComboBoxData()
        Try
            AllowInitFromVendor = False
            Cursor = Cursors.WaitCursor
            FillProveedorComboBox(Me, cboProveedor)
            FillCurrencyComboBox(Me, cboMoneda)
            FillFormaPagoComboBox(Me, cboFormaPago)
            FillUnidadMedidaComboBox(Me, cboUnidad)
        Finally
            Cursor = Cursors.Default
            AllowInitFromVendor = True
        End Try
    End Sub

    Public Function GetCurrentPurchaseOrder() As CompraHeaderModel
        Dim dbTable As New CompraHeaderModel With {
            .NumeroCompra = txtOrdenCompra.Text,
            .IdProveedor = cboProveedor.SelectedValue,
            .Nombre = txtVendorName.Text,
            .FormaPago = cboFormaPago.SelectedValue,
            .Estado = cboEstatus.SelectedValue,
            .Moneda = cboMoneda.SelectedValue,
            .OrdenProveedor = txtOrdenProveedor.Text,
            .FechaEntrega = dateTimeFechaEntrega.Value,
            .Correo = txtEmail.Text,
            .Contacto = txtContacto.Text
        }
        If Not String.IsNullOrEmpty(txtOrdenCompraId.Text) Then
            dbTable.Id = CType(txtOrdenCompraId.Text, Integer)
        End If

        Return dbTable
    End Function

    Protected Sub GetRecordsAndPopulateFields()
        Dim controller As ComprasController
        Dim records As List(Of CompraHeaderModel)
        Dim ordenCompra As CompraHeaderModel
        Dim dbSelect As DBSelect
        Dim strDetails As String

        Try
            Cursor = Cursors.WaitCursor

            controller = New ComprasController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("Id", DBFilterType.Equal, txtOrdenCompraId.Text))

            records = controller.GetListWithFilters(Of CompraHeaderModel)(dbSelect)

            If records.Count < 1 Then
                strDetails = String.Format("No se encontro la orden de compra con el identificador interno {0}.", txtOrdenCompraId.Text)

                If Not String.IsNullOrEmpty(controller.LastError) Then
                    strDetails &= Environment.NewLine & "Detalles del error: " & Environment.NewLine & controller.LastError
                End If

                HandleException(strDetails)
                Return
            ElseIf records.Count > 1 Then
                HandleException(String.Format("No se encontraron {1} ordenes de compra con el identificador interno {0}", txtOrdenCompraId.Text, records.Count))
            End If

            ordenCompra = records.FirstOrDefault()

            SetValuesFromPurchaseOrder(ordenCompra)

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

    Protected Sub SetValuesFromPurchaseOrder(ordenCompra As CompraHeaderModel)
        txtOrdenCompraId.Text = ordenCompra.Id
        txtOrdenCompra.Text = ordenCompra.NumeroCompra
        txtOrdenProveedor.Text = ordenCompra.OrdenProveedor
        txtContacto.Text = ordenCompra.Contacto
        txtEmail.Text = ordenCompra.Correo
        txtVendorName.Text = ordenCompra.Nombre
        cboEstatus.SelectedValue = ordenCompra.Estado

        If dateTimeFechaEntrega.MinDate < ordenCompra.FechaEntrega Then
            dateTimeFechaEntrega.Value = ordenCompra.FechaEntrega
        Else
            dateTimeFechaEntrega.Value = dateTimeFechaEntrega.MinDate
        End If

        SetProveedorValue(ordenCompra.IdProveedor)
        SetMonedaValue(ordenCompra.Moneda)
        SetFormaPagoValue(ordenCompra.FormaPago)

    End Sub

    Private Function ComboBoxHasValue(ByVal cboOrigin As ComboBox, id As String) As Boolean
        'Dim items As IEnumerator(Of TablaBaseModel)
        Dim modelBase As TablaBaseModel

        If cboOrigin.Items.Count > 0 Then
            Try
                For Each item As Object In cboOrigin.Items
                    modelBase = CType(item, TablaBaseModel)

                    If modelBase IsNot Nothing And modelBase.Id = id Then
                        Return True
                    End If
                Next
            Catch
                Return False
            End Try

        End If

        Return False
    End Function

    Protected Sub GetIdFromPurchaseNum(numOC As String)
        Dim controller As ComprasController
        Dim records As List(Of CompraHeaderModel)
        Dim ret As CompraHeaderModel = Nothing
        Dim dbSelect As DBSelect

        Try
            Cursor = Cursors.WaitCursor

            controller = New ComprasController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.SelectFields.Add(New DBSelectionField("Id"))
            dbSelect.FilterFields.Add(New DBFilterFields("NumeroCompra", DBFilterType.Equal, numOC))

            records = controller.GetListWithFilters(Of CompraHeaderModel)(dbSelect)

            If records.Count < 1 Then
                HandleException(String.Format("No se encontro el registro {0} en la base de datos", numOC))
            Else
                ret = records.FirstOrDefault()
                txtOrdenCompraId.Text = ret.Id.ToString()
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    ''' <summary>
    ''' Inserta/Actualiza la OC actual
    ''' </summary>
    ''' <returns>True si guardo</returns>
    ''' <remarks>06.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function UpsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim controller As ComprasController

        Try
            Cursor = Cursors.WaitCursor
            controller = New ComprasController()

            If IsNewPurchaseOrder Then
                ret = controller.Insert(GetCurrentPurchaseOrder())

                If ret And String.IsNullOrEmpty(txtOrdenCompraId.Text) Then
                    GetIdFromPurchaseNum(txtOrdenCompra.Text)
                End If
                dgvLines.Rows.Clear()
                ClearLineFields()
            Else
                ret = controller.Update(GetCurrentPurchaseOrder())
            End If
            If Not ret Then
                HandleException(controller.LastError)
            Else
                txtOrdenCompra.ReadOnly = True
                IsNewPurchaseOrder = False
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
        Dim controller As ComprasController

        Try
            Cursor = Cursors.WaitCursor
            controller = New ComprasController()
            deleted = controller.Delete(GetCurrentPurchaseOrder())

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
        IsNewPurchaseOrder = True
        txtOrdenCompra.ReadOnly = False
        dgvLines.Rows.Clear()
        purchLineRecordId = 0
        ItemRecordId = 0
        NumeroCompra = String.Empty

        ClearLineFields()
        EnableFieldsBasedOnEstatus()
    End Sub

    Protected Function DeleteInternal() As Boolean

        Dim ret As Boolean = False

        If IsNewPurchaseOrder Then
            ClearFields()
            ClearLineFields()
        ElseIf ValidateDeletePurchaseOrder() Then
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
    ''' <remarks>06.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function ValidateDeletePurchaseOrder() As Boolean
        Dim ret As Boolean = True
        Dim ordenCompra As CompraHeaderModel = GetCurrentPurchaseOrder()
        Dim strMsg As String = String.Empty

        If ordenCompra.Estado <> EstadoOrdenCompra.Borrador Then
            strMsg = "Solo se pueden eliminar ordenes de venta en borrador"
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        If ret Then
            ret = MessageBox.Show($"Desea eliminar la orden de compra {txtOrdenCompra.Text}?", GetPOSName(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) = DialogResult.Yes

        End If

        Return ret
    End Function

    Public Sub SetProveedorValue(value As String)

        AllowInitFromVendor = False
        If String.IsNullOrEmpty(value) Then
            cboProveedor.SelectedValue = -1
        ElseIf ComboBoxHasValue(cboProveedor, value) Then
            cboProveedor.SelectedValue = value
        Else
            FillProveedorComboBox(Me, cboProveedor)
            If ComboBoxHasValue(cboProveedor, value) Then
                cboProveedor.SelectedValue = value
            Else
                HandleException(String.Format("No se encontro el proveedor {0} en la base de datos", value))
            End If
        End If

        AllowInitFromVendor = True
    End Sub

    Public Sub SetMonedaValue(value As String)

        If String.IsNullOrEmpty(value) Then
            cboMoneda.SelectedValue = -1
        ElseIf ComboBoxHasValue(cboMoneda, value) Then
            cboMoneda.SelectedValue = value
        Else
            FillCurrencyComboBox(Me, cboMoneda)
            If ComboBoxHasValue(cboMoneda, value) Then
                cboMoneda.SelectedValue = value
            Else
                HandleException(String.Format("No se encontro la moneda {0} en la base de datos", value))
            End If
        End If
    End Sub

    Public Sub SetFormaPagoValue(value As String)

        If String.IsNullOrEmpty(value) Then
            cboFormaPago.SelectedValue = -1
        ElseIf ComboBoxHasValue(cboFormaPago, value) Then
            cboFormaPago.SelectedValue = value
        Else
            FillFormaPagoComboBox(Me, cboFormaPago)
            If ComboBoxHasValue(cboFormaPago, value) Then
                cboFormaPago.SelectedValue = value
            Else
                HandleException(String.Format("No se encontro la forma de pago {0} en la base de datos", value))
            End If
        End If

    End Sub

    Protected Function ValidateNumberIsOk(value As String) As Boolean
        Dim dcmValue As Decimal
        Dim ret As Boolean = True

        If Not String.IsNullOrEmpty(value) Then
            ret = Decimal.TryParse(value, dcmValue)
        End If

        Return ret
    End Function

    Protected Function ValidateNumerValue(texBox As TextBox) As Integer
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
            Dim textBox As TextBox = sender

            If Not ValidateNumerValue(textBox) Then
                e.Cancel = True
            End If
        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Sub CalculateNetAmount()
        Dim netAmount, unitPrice, discount, qty As Decimal

        Try

            Decimal.TryParse(txtCantidad.Text, qty)
            Decimal.TryParse(txtPrecioUnitario.Text, unitPrice)
            Decimal.TryParse(txtDescuento.Text, discount)

            netAmount = (qty * unitPrice) - discount
            txtMontoLinea.Text = netAmount.ToString("N2")
        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Private Sub BuscaProductoRelacionado(Optional fromButton As Boolean = False)

        If fromButton Then
            OpenSearchFormAndFillItem()
        Else

        End If

    End Sub

    Protected Sub OpenSearchFormAndFillItem()
        Dim iSelected As ISelectedRecord
        Dim frmBusqueda As FrmBuscaProducto

        Try
            frmBusqueda = New FrmBuscaProducto()
            frmBusqueda.ShowDialog(Me)

            iSelected = CType(frmBusqueda, ISelectedRecord)
            InitFieldsFromProduct(iSelected.SelectedRecord())

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Sub InitFieldsFromProduct(product As IDBTable)


        Try
            product.RecordId = 1

            txtCantidad.Text = 1
            txtPrecioUnitario.Text = 1.ToString()
            txtDescuento.Text = 0.ToString()

            CalculateNetAmount()

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Function ValidateWritePurchaseOrder() As Boolean
        Dim ret As Boolean = True
        Dim model As CompraHeaderModel
        Dim strErrorMsg As String = String.Empty

        model = GetCurrentPurchaseOrder()

        If model Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar la orden de compra actual")
        Else
            If String.IsNullOrEmpty(model.Id) Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado la orden de compra.")
            End If

        End If

        If Not String.IsNullOrEmpty(strErrorMsg) Then
            ret = CheckFailed(strErrorMsg)
        End If


        Return ret
    End Function

    Protected Function ValidateWritePurchaseOrderLine() As Boolean
        Dim ret As Boolean = True
        Dim model As CompraHeaderModel
        Dim modelLine As CompraDetallesModel
        Dim strErrorMsg As String = String.Empty

        model = GetCurrentPurchaseOrder()
        modelLine = GetCurrentPurchaseOrderLine()

        If model Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar la orden de compra actual.")
        Else
            If String.IsNullOrEmpty(model.Id) Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado la orden de compra.")
            End If
        End If
        If modelLine Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar la línea de orden de compra actual.")
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

    Public Function GetCurrentPurchaseOrderLine() As CompraDetallesModel
        '' ToDo: Cuando este productos eliminar línea
        ItemRecordId = 1
        Dim dbTable As New CompraDetallesModel With {
            .IdProducto = ItemRecordId,
            .NombreProducto = txtItemName.Text,
            .Unidad = cboUnidad.SelectedValue
        }
        If Not String.IsNullOrEmpty(txtOrdenCompraId.Text) Then
            dbTable.IdCompra = CType(txtOrdenCompraId.Text, Integer)
        End If
        If Not String.IsNullOrEmpty(txtPrecioUnitario.Text) Then
            Decimal.TryParse(txtPrecioUnitario.Text, dbTable.PrecioUnitario)
        End If
        If Not String.IsNullOrEmpty(txtCantidad.Text) Then
            Decimal.TryParse(txtCantidad.Text, dbTable.Cantidad)
        End If
        If Not String.IsNullOrEmpty(txtMontoLinea.Text) Then
            Decimal.TryParse(txtMontoLinea.Text, dbTable.MontoNeto)
        End If
        If Not String.IsNullOrEmpty(txtDescuento.Text) Then
            Decimal.TryParse(txtDescuento.Text, dbTable.Descuento)
        End If

        Return dbTable
    End Function

    Protected Sub GetRecordsAndPopulateLineFields()
        Dim controller As ComprasDetalleController
        Dim records As List(Of CompraDetallesModel)
        Dim dbSelect As DBSelect
        Dim isWaitCursor As Boolean

        Try
            isWaitCursor = True
            If Cursor IsNot Cursors.WaitCursor Then
                isWaitCursor = False
                Cursor = Cursors.WaitCursor
            End If

            controller = New ComprasDetalleController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("IdCompra", DBFilterType.Equal, txtOrdenCompraId.Text))

            records = controller.GetListWithFilters(Of CompraDetallesModel)(dbSelect)

            dgvLines.Rows.Clear()

            For Each model As CompraDetallesModel In records
                dgvLines.Rows().Add(model.Id, model.NumeroLinea, model.IdProducto, model.NombreProducto,
                                        model.Cantidad, model.PrecioUnitario, model.Descuento,
                                        model.MontoNeto)
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            If Not isWaitCursor Then
                Cursor = Cursors.Default
            End If
        End Try

    End Sub

    Protected Sub SetValuesFromPurchaseOrderLine()

        If dgvLines.CurrentRow IsNot Nothing Then
            purchLineRecordId = CType(dgvLines.CurrentRow.Cells(0).Value, Long)
            NumeroLinea = CType(dgvLines.CurrentRow.Cells(1).Value, Integer)
            txtItemId.Text = dgvLines.CurrentRow.Cells(2).Value
            txtItemName.Text = dgvLines.CurrentRow.Cells(3).Value
            txtCantidad.Text = dgvLines.CurrentRow.Cells(4).Value
            txtPrecioUnitario.Text = dgvLines.CurrentRow.Cells(5).Value
            txtDescuento.Text = dgvLines.CurrentRow.Cells(6).Value
            txtMontoLinea.Text = dgvLines.CurrentRow.Cells(7).Value
        End If

    End Sub

    ''' <summary>
    ''' Inserta/Actualiza la línea de OC actual
    ''' </summary>
    ''' <returns>True si guardo</returns>
    ''' <remarks>07.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function UpsertRecordPurchLine() As Boolean
        Dim ret As Boolean = False
        Dim controller As ComprasDetalleController
        Dim lineaCompra As CompraDetallesModel

        Try
            Cursor = Cursors.WaitCursor
            controller = New ComprasDetalleController()
            lineaCompra = GetCurrentPurchaseOrderLine()

            If purchLineRecordId = 0 Then
                lineaCompra.NumeroLinea = dgvLines.Rows().Count + 1
                ret = controller.Insert(lineaCompra)
            Else
                ret = controller.Update(lineaCompra)
            End If
            If Not ret Then
                HandleException(controller.LastError)
            Else
                GetRecordsAndPopulateLineFields()
                ClearLineFields()
                purchLineRecordId = 0
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

        txtItemId.Clear()
        txtItemName.Clear()

        txtDescuento.Text = 0
        txtPrecioUnitario.Text = 0
        txtCantidad.Text = 0
        txtMontoLinea.Text = "0.00"

        cboUnidad.SelectedIndex = -1

    End Sub

    Protected Function DeletePurchLineRecord() As Boolean
        Dim deleted As Boolean = False
        Dim controller As ComprasDetalleController
        Dim model As CompraDetallesModel

        Try
            model = GetCurrentPurchaseOrderLine()

            If model.Id = 0 Then
                ClearLineFields()
                Return True
            End If

            Cursor = Cursors.WaitCursor
            controller = New ComprasDetalleController()
            deleted = controller.Delete(model)

            If Not deleted Then
                HandleException(controller.LastError)
            Else
                ClearLineFields()
                GetRecordsAndPopulateLineFields()
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return deleted

    End Function

    Protected Sub ConfirmPurchaseOrder()
        Dim frmConfirm As FrmConfirmarOrdenCompra
        Dim ordenCompra As CompraHeaderModel
        Try
            ordenCompra = GetCurrentPurchaseOrder()
            ' ToDo: Actualizar
            If ValidateConfirmPurchaseOrder(ordenCompra) Or True Then
                frmConfirm = New FrmConfirmarOrdenCompra(ordenCompra)

                If frmConfirm.ShowDialog(Me) = DialogResult.OK Then
                    If frmConfirm.IsPurchConfirmed Then
                        cboEstatus.SelectedIndex = EstadoOrdenCompra.Confirmado
                        EnableFieldsBasedOnEstatus()
                    End If
                End If
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Function ValidateConfirmPurchaseOrder(ordenCompra As CompraHeaderModel) As Boolean
        Dim ret As Boolean = True
        Dim strMsg As String = String.Empty

        If ordenCompra Is Nothing Or ordenCompra.Id = 0 Then
            strMsg = "No se puede recuperar la orden de compra." & Environment.NewLine
        Else
            If ordenCompra.Estado <> EstadoOrdenCompra.Borrador Then
                strMsg = "La orden de compra tiene un estatus no valido." & Environment.NewLine
            End If
            If dgvLines.Rows.Count < 1 Then
                strMsg = "Se debe especificar al menos una línea para poder confirmar la orden de compra." & Environment.NewLine
            End If
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

    Private Sub EnableFieldsBasedOnEstatus()
        Dim allowEdit As Boolean

        Try
            allowEdit = cboEstatus.SelectedValue = EstadoOrdenCompra.Borrador

            txtOrdenCompra.ReadOnly = Not allowEdit
            txtVendorName.ReadOnly = Not allowEdit
            txtOrdenProveedor.ReadOnly = Not allowEdit
            txtContacto.ReadOnly = Not allowEdit
            txtEmail.ReadOnly = Not allowEdit
            dateTimeFechaEntrega.Enabled = allowEdit

            cboFormaPago.Enabled = Not allowEdit
            cboProveedor.Enabled = Not allowEdit
            cboMoneda.Enabled = Not allowEdit

            cboUnidad.Enabled = Not allowEdit
            txtItemId.ReadOnly = Not allowEdit
            txtItemName.ReadOnly = Not allowEdit
            txtCantidad.ReadOnly = Not allowEdit
            txtDescuento.ReadOnly = Not allowEdit
            txtPrecioUnitario.ReadOnly = Not allowEdit

            btnAddLine.Enabled = allowEdit
            btnGuardarOC.Enabled = allowEdit
            btnEditLine.Enabled = allowEdit
            btnDeleteLine.Enabled = allowEdit

            btnSeleccionarArticulo.Enabled = allowEdit
            ConfirmarToolStripMenuItem.Enabled = allowEdit
            EliminarToolStripMenuItem.Enabled = allowEdit

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

#End Region

#Region "Events"
    Private Sub btnDeleteLine_Click(sender As Object, e As EventArgs) Handles btnDeleteLine.Click
        DeletePurchLineRecord()
    End Sub

    Private Sub btnAddLine_Click(sender As Object, e As EventArgs) Handles btnAddLine.Click
        If ValidateWritePurchaseOrderLine() Then
            UpsertRecordPurchLine()
        End If
    End Sub

    Private Sub BtnGuardarOC_Click(sender As Object, e As EventArgs) Handles btnGuardarOC.Click
        If ValidateWritePurchaseOrder() Then
            UpsertRecord()
        End If
    End Sub

    Private Sub cboProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProveedor.SelectedIndexChanged
        InitFromVendorTable()
    End Sub

    Private Sub NuevoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem1.Click
        OnNewRecordSelected()
    End Sub

    Private Sub FrmOrdenCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadComboBoxData()

        If RecordId > 0 Then
            txtOrdenCompraId.Text = RecordId.ToString()
            GetRecordsAndPopulateFields()
            IsNewPurchaseOrder = False
            txtOrdenCompra.ReadOnly = False
        Else
            OnNewRecordSelected()
        End If

        AddHandler txtOrdenProveedor.Enter, AddressOf TextBox_Enter
        AddHandler txtContacto.Enter, AddressOf TextBox_Enter
        AddHandler txtOrdenCompra.Enter, AddressOf TextBox_Enter
        AddHandler txtVendorName.Enter, AddressOf TextBox_Enter
        AddHandler txtEmail.Enter, AddressOf TextBox_Enter

        cboEstatus.DataSource = [Enum].GetValues(GetType(EstadoOrdenCompra))

        '' Campos de líneas
        AddHandler txtCantidad.Enter, AddressOf TextBox_Enter
        AddHandler txtPrecioUnitario.Enter, AddressOf TextBox_Enter
        AddHandler txtMontoLinea.Enter, AddressOf TextBox_Enter
        AddHandler txtDescuento.Enter, AddressOf TextBox_Enter
        AddHandler txtItemId.Enter, AddressOf TextBox_Enter
        AddHandler txtItemName.Enter, AddressOf TextBox_Enter

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        DeleteInternal()
    End Sub

    Private Sub dgvLines_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLines.CellContentDoubleClick
        SetValuesFromPurchaseOrderLine()
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        CalculateNetAmount()
    End Sub

    Private Sub txtPrecioUnitario_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioUnitario.TextChanged
        CalculateNetAmount()
    End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged
        CalculateNetAmount()
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        ValidateNumbers(sender, e)
    End Sub

    Private Sub txtPrecioUnitario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioUnitario.KeyPress
        ValidateNumbers(sender, e)
    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
        ValidateNumbers(sender, e)
    End Sub

    Private Sub txtDescuento_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDescuento.Validating
        CheckNumberIsOk(sender, e)
    End Sub

    Private Sub txtPrecioUnitario_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPrecioUnitario.Validating
        CheckNumberIsOk(sender, e)
    End Sub

    Private Sub txtCantidad_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCantidad.Validating
        CheckNumberIsOk(sender, e)
    End Sub

    Private Sub btnSeleccionarArticulo_Click(sender As Object, e As EventArgs) Handles btnSeleccionarArticulo.Click
        BuscaProductoRelacionado(True)
    End Sub

    Private Sub ConfirmarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfirmarToolStripMenuItem.Click
        ConfirmPurchaseOrder()
    End Sub

#End Region
End Class