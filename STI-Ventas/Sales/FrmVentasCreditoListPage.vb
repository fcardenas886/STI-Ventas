Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Muestra todas las ventas a credito
''' </summary>
''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmVentasCreditoListPage
    Private isFromFilterButton As Boolean

#Region "Class methods"

    ''' <summary>
    ''' Reestablece los filtros
    ''' </summary>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ResetFilters()
        txtOrdenVenta.Clear()
        cboCliente.SelectedIndex = -1
        cboMoneda.SelectedIndex = -1
        chkEnableStatusFilter.Checked = False
    End Sub

    ''' <summary>
    ''' Elimina el registro
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim controller As VentasCreditoController

        Try
            Cursor = Cursors.WaitCursor
            controller = New VentasCreditoController()
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

    ''' <summary>
    ''' Carga los registros de OV
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String

        If dgvListPage.CurrentRow IsNot Nothing Then

            Return dgvListPage.CurrentRow().Cells().Item(1).Value.ToString()

        End If
        Return String.Empty
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim controller As VentasCreditoController
        Dim records As List(Of VentasCreditoViewModel)
        Dim dbSelect As DBSelect
        Dim dbFilter As DBFilterFields
        Dim style As DataGridViewCellStyle

        Try
            Cursor = Cursors.WaitCursor

            If dgvListPage.Columns().Count < 1 Then

                style = New DataGridViewCellStyle()
                style.Alignment = DataGridViewContentAlignment.MiddleRight

                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "NumeroVenta", .HeaderText = "Número"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Cliente", .HeaderText = "Cliente"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre cliente"})

                Dim cboEstatusOC As New DataGridViewComboBoxColumn With {
                    .DataSource = GetOrdenVentaStatusValues(),
                    .Name = "Estado",
                    .HeaderText = "Estado",
                    .ValueType = GetType(EstadoVentaCredito),
                    .FlatStyle = FlatStyle.Flat
                }

                dgvListPage.Columns.Add(cboEstatusOC)
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FechaVenta", .HeaderText = "Fecha"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "MontoVenta", .HeaderText = "Total Venta", .DefaultCellStyle = style})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Abono", .HeaderText = "Abono", .DefaultCellStyle = style})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "MontoPagado", .HeaderText = "Monto pagado", .DefaultCellStyle = style})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Moneda", .HeaderText = "Moneda"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "CreadoPor", .HeaderText = "Creado por"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "NumeroPagos", .HeaderText = "Número de pagos", .DefaultCellStyle = style})
                dgvListPage.Columns(1).Visible = True

            End If

            controller = New VentasCreditoController()
            dbSelect = New DBSelect(controller.TableName())

            If isFromFilterButton Then
                If chkEnableStatusFilter.Checked Then
                    dbFilter = New DBFilterFields("Estado", DBFilterType.Equal, cboEstatus.SelectedValue)
                    dbSelect.FilterFields.Add(dbFilter)
                End If
                If cboCliente.SelectedValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(cboCliente.SelectedValue.ToString()) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("IdCliente", DBFilterType.Equal, cboCliente.SelectedValue))
                End If
                If Not String.IsNullOrEmpty(txtOrdenVenta.Text) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("NumeroVenta", DBFilterType.Contains, String.Format("%{0}%", txtOrdenVenta.Text)))
                End If
                If cboMoneda.SelectedValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(cboMoneda.SelectedValue.ToString()) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("Moneda", DBFilterType.Equal, cboMoneda.SelectedValue))
                End If
            End If

            records = controller.GetViewModel(dbSelect)
            dgvListPage.Rows.Clear()

            For Each model As VentasCreditoViewModel In records
                dgvListPage.Rows().Add(model.Id, model.NumeroVenta, model.CodigoCliente,
                                        model.Nombre, model.Estado,
                                        model.Fecha.ToShortDateString(), model.MontoVenta.ToString("N2"), model.Abono.ToString("N2"), model.MontoPagado.ToString("N2"),
                                        model.Moneda, model.CreadoPor, model.NumeroPago)
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Abre el boton para creación
    ''' </summary>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnNewRecordSelected()
        Dim child As Form = New FrmVentaPOS With {
            .MdiParent = MdiParent
        }

        child.Show()
    End Sub

    ''' <summary>
    ''' Abre el boton para edición
    ''' </summary>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnEditRecordSelected()
        Dim model As VentasCreditoViewModel = GetCurrentDataGridRecord()

        If model IsNot Nothing AndAlso model.Id < 1 Then
            HandleException("Seleccione un registro en la tabla para poder ver los detalles.")
            Return
        End If

        Dim pagos As New FrmVentaCreditoDetallePagoListPage(model) With {
            .MdiParent = MdiParent
        }

        pagos.Show()
    End Sub

    Private Function GetOrdenVentaStatusValues() As Array
        Return [Enum].GetValues(GetType(EstadoVentaCredito))
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        Dim estatus As Array

        MyBase.OnFormLoaded()

        estatus = GetOrdenVentaStatusValues()
        FillComboBox()

        cboEstatus.DataSource = estatus
        cboEstatus.Enabled = False

        NuevoToolStripMenuItem1.Text = "Nueva orden de venta"
        EliminarToolStripMenuItem.Visible = False
        EditarToolStripMenuItem.Visible = False

        If Not AccionesToolStripMenuItem.DropDownItems.Contains(CobrarVentaToolStripMenuItem) Then
            AccionesToolStripMenuItem.DropDownItems.Add(CobrarVentaToolStripMenuItem)
        End If

        CobrarVentaToolStripMenuItem.Visible = True

    End Sub

    ''' <summary>
    ''' Filtra las OVs
    ''' </summary>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub FilterRecords()
        Try
            isFromFilterButton = True
            LoadRecords()
            isFromFilterButton = False
        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Private Sub HandleStatusFilter()
        Dim enabled As Boolean

        Try
            enabled = chkEnableStatusFilter.Checked
            cboEstatus.Enabled = enabled

            If enabled Then
                cboEstatus.DroppedDown = True
                cboEstatus.Select()

            End If
        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Sub FillComboBox()

        Try
            Cursor = Cursors.WaitCursor

            FillClienteComboBox(Me, cboCliente)
            FillCurrencyComboBox(Me, cboMoneda)

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Protected Function GetCurrentRecordId() As Integer
        Dim recordId As Integer = 0

        Try
            If dgvListPage.CurrentRow IsNot Nothing Then
                recordId = CInt(dgvListPage.CurrentRow().Cells().Item(0).Value)

            End If
        Catch ex As Exception
            HandleException(ex)
        End Try
        Return recordId
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            OnEditRecordSelected()
        End If
    End Sub

    ''' <summary>
    ''' Valida si puede eliminar el registro
    ''' </summary>
    ''' <returns>True si puede borrar el registro</returns>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function ValidateDelete() As Boolean
        Dim ret As Boolean = True
        Dim ordenVenta As VentasCreditoModel = GetCurrentSalesOrder()
        Dim strMsg As String = String.Empty

        If ordenVenta.Estado <> EstadoVentaCredito.Creado Then
            strMsg = "Solo se pueden eliminar ordenes de venta en creado."
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

    Public Function GetCurrentSalesOrder() As VentasCreditoModel
        Dim dbTable As New VentasCreditoModel
        Dim controller As VentasCreditoController
        Dim records As List(Of VentasCreditoModel)
        Dim dbSelect As DBSelect
        Dim strId As String
        Dim strDetails As String

        Try
            Cursor = Cursors.WaitCursor

            strId = GetCurrentRecordId().ToString()
            controller = New VentasCreditoController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("Id", DBFilterType.Equal, strId))

            records = controller.GetListWithFilters(Of VentasCreditoModel)(dbSelect)

            If records.Count < 0 Then
                strDetails = String.Format("No se encontro la orden de venta con el identificador interno {0}", strId)

                If Not String.IsNullOrEmpty(controller.LastError) Then
                    strDetails &= "Detalles del error: " & Environment.NewLine & controller.LastError
                End If

                Throw New Exception(strDetails)
            End If

            dbTable = records.FirstOrDefault()

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                Throw New Exception(controller.LastError)
            End If
        Finally
            Cursor = Cursors.Default
        End Try
        Return dbTable
    End Function

    ''' <summary>
    ''' Activa botones
    ''' </summary>
    ''' <param name="rowIndex">Fila seleccionada</param>
    ''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnRowEnter(rowIndex As Integer)
        Dim enabled As Boolean = False
        Dim estatus As EstadoVentaCredito

        If rowIndex >= 0 Then
            estatus = CType(dgvListPage.Rows().Item(rowIndex).Cells.Item("Estado").Value, EstadoVentaCredito)
            enabled = estatus = EstadoVentaCredito.PendientePago
        End If

        CobrarVentaToolStripMenuItem.Enabled = enabled
    End Sub

    Protected Function ValidateConfirmPurchaseOrder(ordenVenta As VentasCreditoModel) As Boolean
        Dim ret As Boolean = True
        Dim strMsg As String = String.Empty

        If ordenVenta Is Nothing Or ordenVenta.Id = 0 Then
            strMsg = "No se puede recuperar la orden de venta." & Environment.NewLine
        Else
            If ordenVenta.Estado <> EstadoVentaCredito.PendientePago Then
                strMsg = "La orden de venta tiene un estatus no valido." & Environment.NewLine
            End If
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

    Private Sub CobrarVenta()
        Dim cobro As FrmCobrarVentaCredito

        Try
            If ValidateCobrarVenta() Then
                cobro = New FrmCobrarVentaCredito(GetCurrentDataGridRecord())

                cobro.ShowDialog(Me)

                If cobro.Cobrado Then

                    FilterRecords()
                End If
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Private Function ValidateCobrarVenta() As Boolean
        Dim ret As Boolean = True
        Dim model As VentasCreditoViewModel = GetCurrentDataGridRecord()

        If model Is Nothing OrElse model.Id < 1 Then
            CheckFailed("No se pudo recuperar la orden de venta actual.")
        Else
            If model.Estado <> EstadoVentaCredito.PendientePago Then
                CheckFailed("Solo se pueden cobrar ordenes de venta pendientes de pago.")
            End If
        End If

        Return ret
    End Function

    Public Function GetCurrentDataGridRecord() As VentasCreditoViewModel
        Dim dbTable As New VentasCreditoViewModel
        Dim dataGridViewRow As DataGridViewRow

        Try
            Cursor = Cursors.WaitCursor

            dbTable.Id = GetCurrentRecordId()

            If dgvListPage.CurrentRow IsNot Nothing Then
                dataGridViewRow = dgvListPage.CurrentRow()

                dbTable.NumeroVenta = CStr((dataGridViewRow.Cells().Item(1).Value))
                dbTable.MontoVenta = CDec((dataGridViewRow.Cells().Item(6).Value))
                dbTable.NumeroPago = CInt((dataGridViewRow.Cells().Item(11).Value))
                dbTable.Estado = CType((dataGridViewRow.Cells().Item(4).Value), EstadoVentaCredito)

            End If

        Finally
            Cursor = Cursors.Default
        End Try
        Return dbTable
    End Function

#End Region

#Region "Events"

    Private Sub chkEnableStatusFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableStatusFilter.CheckedChanged
        HandleStatusFilter()
    End Sub

    Private Sub CobrarVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobrarVentaToolStripMenuItem.Click
        CobrarVenta()
    End Sub

#End Region
End Class