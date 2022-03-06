Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Template base para lista de OV
''' </summary>
''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmVentasListPage

    Private isFromFilterButton As Boolean

#Region "Class methods"

    ''' <summary>
    ''' Reestablece los filtros
    ''' </summary>
    ''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ResetFilters()
        txtOrdenVenta.Clear()
        cboCliente.SelectedIndex = -1
    End Sub

    ''' <summary>
    ''' Elimina el registro
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim controller As VentasController

        Try
            Cursor = Cursors.WaitCursor
            controller = New VentasController()
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

    ''' <summary>
    ''' Carga los registros de OV
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String

        If dgvListPage.CurrentRow IsNot Nothing Then

            Return dgvListPage.CurrentRow().Cells().Item(1).Value.ToString()

        End If
        Return String.Empty
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim controller As VentasController
        Dim records As List(Of OrdenVentaModel)
        Dim dbSelect As DBSelect
        Dim dbFilter As DBFilterFields

        Try
            Cursor = Cursors.WaitCursor

            If dgvListPage.Columns().Count < 1 Then
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "NumeroVenta", .HeaderText = "Número"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Cliente", .HeaderText = "Cliente"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Moneda", .HeaderText = "Moneda"})

                Dim cboEstatusOC As New DataGridViewComboBoxColumn With {
                    .DataSource = GetOrdenVentaStatusValues(),
                    .Name = "Estado",
                    .HeaderText = "Estado",
                    .ValueType = GetType(EstadoOrdenVenta)
                }

                dgvListPage.Columns.Add(cboEstatusOC)
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FechaEntrega", .HeaderText = "Fecha"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "OrdenCliente", .HeaderText = "Orden Cliente"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FormaPago", .HeaderText = "Forma pago"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Total", .HeaderText = "Total"})
                dgvListPage.Columns(1).Visible = True

            End If

            controller = New VentasController()
            dbSelect = New DBSelect(controller.TableName())

            If isFromFilterButton Then
                If chkEnableStatusFilter.Checked Then
                    dbFilter = New DBFilterFields("Estado", DBFilterType.Equal, cboEstatus.SelectedValue)
                    dbSelect.FilterFields.Add(dbFilter)
                End If
                If cboCliente.SelectedValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(cboCliente.SelectedValue.ToString()) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("Cliente", DBFilterType.Equal, cboCliente.SelectedValue))
                End If
                If Not String.IsNullOrEmpty(txtOrdenVenta.Text) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("NumeroVenta", DBFilterType.Contains, String.Format("%{0}%", txtOrdenVenta.Text)))
                End If
                If cboMoneda.SelectedValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(cboMoneda.SelectedValue.ToString()) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("Moneda", DBFilterType.Equal, cboMoneda.SelectedValue))
                End If
                If cboFormaPago.SelectedValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(cboFormaPago.SelectedValue.ToString()) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("FormaPago", DBFilterType.Equal, cboFormaPago.SelectedValue))
                End If
            End If

            'records = controller.GetList()
            records = controller.GetListWithFilters(Of OrdenVentaModel)(dbSelect)
            dgvListPage.Rows.Clear()

            For Each model As OrdenVentaModel In records
                dgvListPage.Rows().Add(model.Id, model.NumeroVenta, model.Cliente,
                                        model.Nombre, model.Moneda, model.Estado,
                                        model.Fecha, model.OrdenCliente, model.FormaPago, model.Total.ToString("N2"))
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
    ''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnNewRecordSelected()
        Dim child As Form = New FrmVentaPOS With {
            .MdiParent = MdiParent
        }

        child.Show()
    End Sub

    ''' <summary>
    ''' Abre el boton para edición
    ''' </summary>
    ''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnEditRecordSelected()
        Dim recordId As Long = GetCurrentRecordId()

        If recordId < 1 Then
            HandleException("Seleccione un registro en la tabla para poder editar.")
            Return
        End If

        HandleException("No implementado")
    End Sub

    Private Function GetOrdenVentaStatusValues() As Array
        Return [Enum].GetValues(GetType(EstadoOrdenVenta))
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        Dim estatus As Array

        MyBase.OnFormLoaded()

        estatus = GetOrdenVentaStatusValues()
        FillComboBox()

        cboEstatus.DataSource = estatus
        cboEstatus.Enabled = False

    End Sub

    ''' <summary>
    ''' Filtra las OVs
    ''' </summary>
    ''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
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

            FillClienteRutComboBox(Me, cboCliente)
            FillCurrencyComboBox(Me, cboMoneda)
            FillFormaPagoComboBox(Me, cboFormaPago)

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
    ''' <remarks>07.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            OnEditRecordSelected()
        End If
    End Sub

    ''' <summary>
    ''' Valida si puede eliminar el registro
    ''' </summary>
    ''' <returns>True si puede borrar el registro</returns>
    ''' <remarks>06.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function ValidateDelete() As Boolean
        Dim ret As Boolean = True
        Dim ordenVenta As OrdenVentaModel = GetCurrentPurchaseOrder()
        Dim strMsg As String = String.Empty

        If ordenVenta.Estado <> EstadoOrdenVenta.Borrador Then
            strMsg = "Solo se pueden eliminar ordenes de venta en borrador"
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

    Public Function GetCurrentPurchaseOrder() As OrdenVentaModel
        Dim dbTable As New OrdenVentaModel
        Dim controller As VentasController
        Dim records As List(Of OrdenVentaModel)
        Dim dbSelect As DBSelect
        Dim strId As String
        Dim strDetails As String

        Try
            Cursor = Cursors.WaitCursor

            strId = GetCurrentRecordId().ToString()
            controller = New VentasController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("Id", DBFilterType.Equal, strId))

            records = controller.GetListWithFilters(Of OrdenVentaModel)(dbSelect)

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
    ''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnRowEnter(rowIndex As Integer)
        Dim enabled As Boolean = False
        Dim estatus As EstadoOrdenVenta

        If rowIndex >= 0 Then
            estatus = CType(dgvListPage.Rows().Item(rowIndex).Cells.Item("Estado").Value, EstadoOrdenVenta)
            enabled = estatus = EstadoOrdenVenta.Borrador
        End If

        EliminarToolStripMenuItem.Enabled = enabled
    End Sub

    Protected Function ValidateConfirmPurchaseOrder(ordenVenta As OrdenVentaModel) As Boolean
        Dim ret As Boolean = True
        Dim strMsg As String = String.Empty

        If ordenVenta Is Nothing Or ordenVenta.Id = 0 Then
            strMsg = "No se puede recuperar la orden de venta." & Environment.NewLine
        Else
            If ordenVenta.Estado <> EstadoOrdenVenta.Borrador Then
                strMsg = "La orden de venta tiene un estatus no valido." & Environment.NewLine
            End If
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

#End Region

#Region "Events"

    Private Sub chkEnableStatusFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableStatusFilter.CheckedChanged
        HandleStatusFilter()
    End Sub

#End Region
End Class