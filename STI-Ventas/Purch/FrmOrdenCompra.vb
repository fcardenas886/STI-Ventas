
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

        dateTimeFechaEntrega.Value = Date.Now
        cboProveedor.SelectedIndex = -1
        cboMoneda.SelectedIndex = -1
        cboFormaPago.SelectedIndex = -1

        Try
            cboEstatus.SelectedIndex = 0
        Catch ex As Exception
            HandleException(ex)
        End Try

        txtOrdenCompra.Enabled = True
    End Sub

    Protected Sub LoadComboBoxData()
        Try
            Cursor = Cursors.WaitCursor
            FillProveedorComboBox(Me, cboProveedor)
            FillCurrencyComboBox(Me, cboMoneda)
            FillFormaPagoComboBox(Me, cboFormaPago)
        Finally
            Cursor = Cursors.Default
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

            If records.Count < 0 Then
                strDetails = String.Format("No se encontro la orden de compra con el identificador interno {0}", txtOrdenCompraId.Text)

                If Not String.IsNullOrEmpty(controller.LastError) Then
                    strDetails &= "Detalles del error: " & Environment.NewLine & controller.LastError
                End If

                HandleException(strDetails)
                Return
            ElseIf records.Count > 1 Then
                HandleException(String.Format("No se encontraron {1} ordenes de compra con el identificador interno {0}", txtOrdenCompraId.Text, records.Count))
            End If

            ordenCompra = records.FirstOrDefault()

            SetValuesFromPurchaseOrder(ordenCompra)

            'dtGridView.DataSource = records
            dgvLines.Rows.Clear()

            'For Each model As ProveedorModel In records
            '    dtGridView.Rows().Add(model.IdProveedor, model.Nombre, model.AliasName,
            '                            model.RUT, model.Grupo, model.Moneda,
            '                            model.FormaPago, model.Contacto, model.Direccion,
            '                            model.Telefono, model.Email)
            'Next

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


        If String.IsNullOrEmpty(ordenCompra.IdProveedor) Then
            cboProveedor.SelectedValue = -1
        ElseIf ComboBoxHasValue(cboProveedor, ordenCompra.IdProveedor) Then
            cboProveedor.SelectedValue = ordenCompra.IdProveedor
        Else
            FillProveedorComboBox(Me, cboProveedor)
            If ComboBoxHasValue(cboProveedor, ordenCompra.IdProveedor) Then
                cboProveedor.SelectedValue = ordenCompra.IdProveedor
            Else
                HandleException(String.Format("No se encontro el proveedor {0} en la base de datos", ordenCompra.IdProveedor))
            End If
        End If

        If String.IsNullOrEmpty(ordenCompra.Moneda) Then
            cboMoneda.SelectedValue = -1
        ElseIf ComboBoxHasValue(cboMoneda, ordenCompra.Moneda) Then
            cboMoneda.SelectedValue = ordenCompra.Moneda
        Else
            FillCurrencyComboBox(Me, cboMoneda)
            If ComboBoxHasValue(cboMoneda, ordenCompra.Moneda) Then
                cboMoneda.SelectedValue = ordenCompra.Moneda
            Else
                HandleException(String.Format("No se encontro la moneda {0} en la base de datos", ordenCompra.Moneda))
            End If
        End If

        If String.IsNullOrEmpty(ordenCompra.FormaPago) Then
            cboFormaPago.SelectedValue = -1
        ElseIf ComboBoxHasValue(cboFormaPago, ordenCompra.FormaPago) Then
            cboFormaPago.SelectedValue = ordenCompra.FormaPago
        Else
            FillFormaPagoComboBox(Me, cboFormaPago)
            If ComboBoxHasValue(cboFormaPago, ordenCompra.FormaPago) Then
                cboFormaPago.SelectedValue = ordenCompra.FormaPago
            Else
                HandleException(String.Format("No se encontro la forma de pago {0} en la base de datos", ordenCompra.FormaPago))
            End If
        End If

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
            Else
                ret = controller.Update(GetCurrentPurchaseOrder())
            End If
            If Not ret Then
                HandleException(controller.LastError)
            Else
                txtOrdenCompra.Enabled = False
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
        txtOrdenCompra.Enabled = True
    End Sub

    Protected Function DeleteInternal() As Boolean

        Dim ret As Boolean = False

        If IsNewPurchaseOrder Then
            ClearFields()
        ElseIf ValidateDeletePurchaseOrder() Then
            ret = DeleteRecord()

            If ret Then
                OnNewRecordSelected()
            End If

        End If

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

#End Region

#Region "Events"
    Private Sub btnDeleteLine_Click(sender As Object, e As EventArgs) Handles btnDeleteLine.Click

    End Sub

    Private Sub btnAddLine_Click(sender As Object, e As EventArgs) Handles btnAddLine.Click

    End Sub

    Private Sub BtnGuardarOC_Click(sender As Object, e As EventArgs) Handles btnGuardarOC.Click
        UpsertRecord()
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
            txtOrdenCompra.Enabled = False
        Else
            OnNewRecordSelected()
        End If

        AddHandler txtOrdenProveedor.Enter, AddressOf TextBox_Enter
        AddHandler txtContacto.Enter, AddressOf TextBox_Enter
        AddHandler txtOrdenCompra.Enter, AddressOf TextBox_Enter
        AddHandler txtVendorName.Enter, AddressOf TextBox_Enter
        AddHandler txtEmail.Enter, AddressOf TextBox_Enter

        cboEstatus.DataSource = [Enum].GetValues(GetType(EstadoOrdenCompra))

    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        DeleteInternal()
    End Sub
#End Region
End Class