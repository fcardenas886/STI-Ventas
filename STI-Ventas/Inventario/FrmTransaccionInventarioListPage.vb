Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Consultas inventario
''' </summary>
''' <remarks>10.02.2022 jorge.nin92@gmail.com: Se crean filtros para consulta</remarks>
Public Class FrmTransaccionInventarioListPage

    Private isFromFilterButton As Boolean

#Region "Class methods"

    ''' <summary>
    ''' Reestablece los filtros
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ResetFilters()
        txtIdArticulo.Clear()
        txtReferencia.Clear()
    End Sub

    ''' <summary>
    ''' Elimina el registro
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False

        Return deleted

    End Function

    ''' <summary>
    ''' Carga los registros de OC
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        If dgvListPage.CurrentRow IsNot Nothing Then
            Return dgvListPage.CurrentRow().Cells().Item(1).Value

        End If
        Return String.Empty
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim controller As TransaccionInventarioController
        Dim records As List(Of TransaccionInventarioModel)
        Dim dbSelect As DBSelect
        Dim dbFilter As DBFilterFields

        Try
            Cursor = Cursors.WaitCursor

            If dgvListPage.Columns().Count < 1 Then
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "IdArticulo", .HeaderText = "Id Artículo"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FechaMovimiento", .HeaderText = "Fecha Movimiento"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Cantidad", .HeaderText = "Cantidad"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Costo", .HeaderText = "Costo"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Moneda", .HeaderText = "Moneda"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Unidad", .HeaderText = "Unidad"})

                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "TipoTransaccion", .HeaderText = "Tipo Transaccion"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Referencia", .HeaderText = "Referencia"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "NumeroReferencia", .HeaderText = "Número Referencia"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Estado", .HeaderText = "Estado"})

                dgvListPage.Columns(0).Visible = False

            End If

            controller = New TransaccionInventarioController()
            dbSelect = New DBSelect(controller.TableName())

            If isFromFilterButton Then
                If chkEnableStatusFilter.Checked Then
                    dbFilter = New DBFilterFields("Estatus", DBFilterType.Equal, cboEstatus.SelectedValue)
                    dbSelect.FilterFields.Add(dbFilter)
                End If
                If chkEnableTipoTransaccion.Checked Then
                    dbSelect.FilterFields.Add(New DBFilterFields("TipoTransaccion", DBFilterType.Equal, cboTipoTransaccion.SelectedValue))
                End If
                If Not String.IsNullOrEmpty(txtIdArticulo.Text) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("IdArticulo", DBFilterType.Contains, String.Format("%{0}%", txtIdArticulo.Text)))
                End If
                If Not String.IsNullOrEmpty(txtReferencia.Text) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("Referencia", DBFilterType.Contains, String.Format("%{0}%", txtReferencia.Text)))
                End If
            End If

            'records = controller.GetList()
            records = controller.GetListWithFilters(Of TransaccionInventarioModel)(dbSelect)
            dgvListPage.Rows.Clear()

            For Each model As TransaccionInventarioModel In records
                dgvListPage.Rows().Add(model.Id, model.IdArticulo, model.IdArticulo, model.FechaMovimiento,
                                        model.Cantidad, model.Costo, model.Moneda, model.Unidad,
                                        model.TipoTransaccion, model.Referencia, model.NumeroReferencia, model.Estatus)
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
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnNewRecordSelected()
        Dim child As Form = New FrmOrdenCompra With {
            .MdiParent = Me.MdiParent
        }
        child.Show()
    End Sub

    ''' <summary>
    ''' No se permite la edición
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnEditRecordSelected()
        CheckFailed("No se pueden editar las transacciones de inventario")
    End Sub

    Private Function GetOrdenStatusValues() As Array
        Return [Enum].GetValues(GetType(EstadoInventario))
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()

        MyBase.OnFormLoaded()

        FillComboBox()

    End Sub

    ''' <summary>
    ''' Filtra las OCs
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
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

            cboEstatus.DataSource = DataModelHelper.GetDescriptionAttributeAsList(GetType(EstadoInventario))
            cboEstatus.ValueMember = "EnumValue"
            cboEstatus.DisplayMember = "Description"
            cboEstatus.Enabled = False

            cboTipoTransaccion.DataSource = DataModelHelper.GetDescriptionAttributeAsList(GetType(TipoTransaccionInventario)) '  [Enum].GetValues(GetType(TipoTransaccionInventario))
            cboTipoTransaccion.Enabled = False
            cboTipoTransaccion.ValueMember = "EnumValue"
            cboTipoTransaccion.DisplayMember = "Description"

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Protected Function GetCurrentRecordId() As Integer
        Dim recordId As Integer = 0

        Try
            If dgvListPage.CurrentRow IsNot Nothing Then
                recordId = dgvListPage.CurrentRow().Cells().Item(0).Value

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
        Return CheckFailed("No se puede eliminar el registro seleccionado")
    End Function

    Private Sub HandleTransactionType()
        Dim enabled As Boolean

        Try
            enabled = chkEnableTipoTransaccion.Checked
            cboTipoTransaccion.Enabled = enabled

            If enabled Then
                cboTipoTransaccion.DroppedDown = True
                cboTipoTransaccion.Select()

            End If
        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

#End Region
#Region "Events"
    Private Sub chkEnableTipoTransaccion_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableTipoTransaccion.CheckedChanged
        HandleTransactionType()
    End Sub

    Private Sub chkEnableStatusFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableStatusFilter.CheckedChanged
        HandleStatusFilter()
    End Sub

#End Region

End Class