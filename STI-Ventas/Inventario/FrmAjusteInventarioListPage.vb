Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Lista de ajustes de inventario
''' </summary>
''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmAjusteInventarioListPage
    Private isFromFilterButton As Boolean

#Region "Class methods"

    ''' <summary>
    ''' Reestablece los filtros
    ''' </summary>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ResetFilters()
        txtOrdenCompra.Clear()
        txtDescripcion.Clear()

        chkEnableStatusFilter.Checked = False

        cboEstatus.SelectedIndex = -1
        cboUsuario.SelectedIndex = -1
    End Sub

    ''' <summary>
    ''' Elimina el registro
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim controller As AjusteInventarioController

        Try
            Cursor = Cursors.WaitCursor
            controller = New AjusteInventarioController()
            deleted = controller.Delete(GetCurrentPostInventAdjustment())

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
    ''' Carga los registros de OC
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        If dgvListPage.CurrentRow IsNot Nothing Then
            Return CStr(dgvListPage.CurrentRow().Cells().Item(1).Value)

        End If
        Return String.Empty
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim controller As AjusteInventarioController
        Dim records As List(Of AjusteInventarioViewModel)
        Dim dbSelect As DBSelect
        Dim dbFilter As DBFilterFields

        Try
            Cursor = Cursors.WaitCursor

            If dgvListPage.Columns().Count < 1 Then
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Numero", .HeaderText = "Número"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Descripcion", .HeaderText = "Descripción"})
                dgvListPage.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Registrado", .HeaderText = "Registrado"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FechaRegistro", .HeaderText = "Fecha de registro"})

                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "CreadoPor", .HeaderText = "Creado por"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "RegistradoPor", .HeaderText = "Registrado por"})

                dgvListPage.Columns(1).Visible = True

            End If

            controller = New AjusteInventarioController()
            dbSelect = New DBSelect(controller.TableName())

            If isFromFilterButton Then
                If chkEnableStatusFilter.Checked AndAlso cboEstatus.SelectedIndex <> -1 Then
                    dbFilter = New DBFilterFields("Registrado", DBFilterType.Equal, cboEstatus.SelectedIndex)
                    dbSelect.FilterFields.Add(dbFilter)
                End If
                If Not String.IsNullOrEmpty(txtDescripcion.Text) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("Descripcion", DBFilterType.Contains, String.Format("%{0}%", txtDescripcion.Text)))
                End If
                If Not String.IsNullOrEmpty(txtOrdenCompra.Text) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("Numero", DBFilterType.Contains, String.Format("%{0}%", txtOrdenCompra.Text)))
                End If
                If cboUsuario.SelectedValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(cboUsuario.SelectedValue.ToString) Then
                    dbSelect.FilterFields.Add(New DBFilterFields("CreadoPor", DBFilterType.Equal, cboUsuario.SelectedValue))
                End If
            End If

            records = controller.GetAjusteInventarioViewList(dbSelect)
            dgvListPage.Rows.Clear()

            For Each model As AjusteInventarioViewModel In records
                dgvListPage.Rows().Add(model.Id, model.Numero, model.Descripcion,
                                        model.Registrado, model.FechaRegistro,
                                        model.CreadoPor, model.RegistradoPor)
                'dgvListPage.Rows().Add(model.Id)
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
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnNewRecordSelected()
        Dim child As Form = New FrmAjusteInventario With {
            .MdiParent = Me.MdiParent
        }
        child.Show()
    End Sub

    ''' <summary>
    ''' Abre el boton para edición
    ''' </summary>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnEditRecordSelected()
        Dim recordId As Long = GetCurrentRecordId()

        If recordId < 1 Then
            HandleException("Seleccione un registro en la tabla para poder editar.")
            Return
        End If

        Dim child As Form = New FrmAjusteInventario(recordId) With {
            .MdiParent = Me.MdiParent
        }
        child.Show()
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()

        MyBase.OnFormLoaded()

        cboEstatus.Enabled = False

        FillComboBox()

    End Sub

    ''' <summary>
    ''' Filtra las OCs
    ''' </summary>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
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

            FillUsuarioComboBox(Me, cboUsuario)

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
        Dim ajusteInventario As AjusteInventarioModel = GetCurrentPostInventAdjustment()
        Dim strMsg As String = String.Empty

        If ajusteInventario.Registrado Then
            strMsg = "Solo se pueden eliminar ajustes de inventario registrados"
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

    Public Function GetCurrentPostInventAdjustment() As AjusteInventarioModel
        Dim dbTable As New AjusteInventarioModel
        Dim controller As AjusteInventarioController
        Dim records As List(Of AjusteInventarioModel)
        Dim dbSelect As DBSelect
        Dim strId As String
        Dim strDetails As String

        Try
            Cursor = Cursors.WaitCursor

            strId = GetCurrentRecordId().ToString()
            controller = New AjusteInventarioController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("Id", DBFilterType.Equal, strId))

            records = controller.GetListWithFilters(Of AjusteInventarioModel)(dbSelect)

            If records.Count < 0 Then
                strDetails = String.Format("No se encontro el ajuste de inventario con el identificador interno {0}", strId)

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
    ''' <remarks>14.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnRowEnter(rowIndex As Integer)
        Dim enabled As Boolean = False
        Dim estatus As Boolean

        If rowIndex >= 0 Then
            estatus = CBool(dgvListPage.Rows().Item(rowIndex).Cells.Item("Registrado").Value)
            enabled = Not estatus
        End If

        EliminarToolStripMenuItem.Enabled = enabled
        RegistrarToolStripMenuItem.Enabled = enabled
        RegistrarToolStripMenuItem.Visible = True
    End Sub

    Protected Sub ConfirmPostInventAdjustment()
        'Dim frmConfirm As FrmConfirmarajusteInventario
        Dim ajusteInventario As AjusteInventarioModel
        Try
            ajusteInventario = GetCurrentPostInventAdjustment()

            If ValidateConfirmPostInventAdjustment(ajusteInventario) Or True Then
                Info("Ok")
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Function ValidateConfirmPostInventAdjustment(ajusteInventario As AjusteInventarioModel) As Boolean
        Dim ret As Boolean = True
        Dim strMsg As String = String.Empty

        If ajusteInventario Is Nothing Or ajusteInventario.Id = 0 Then
            strMsg = "No se puede recuperar el ajuste de inventario." & Environment.NewLine
        Else
            If ajusteInventario.Registrado Then
                strMsg = "el ajuste de inventario tiene un estatus no valido." & Environment.NewLine
            End If
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

#End Region

#Region "Events"

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem.Click
        ConfirmPostInventAdjustment()
    End Sub

    Private Sub chkEnableStatusFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableStatusFilter.CheckedChanged
        HandleStatusFilter()
    End Sub

#End Region
End Class