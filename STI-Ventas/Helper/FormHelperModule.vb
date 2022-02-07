Imports STIVentas.Controller
Imports STIVentas.Model
''' <summary>
''' Modulo para eventos y validaciones a nivel form.
''' </summary>
''' <remarks>
''' 01.02.2021 jorge.nin92@gmail.com: Se crea la clase
''' 06.02.2021 jorge.nin92@gmail.com: Se agregan metodos para llenar un combo a partir de un ID
''' </remarks>
Module FormHelperModule
    Public Sub TextBox_Enter(sender As Object, e As EventArgs)
        Dim textBox As TextBox

        Try
            textBox = CType(sender, TextBox)
            textBox.SelectAll()
        Catch ex As Exception
            HandleException(ex)
        End Try

    End Sub
#Region "Metodos que muestran mensajes al usuario"
    Public Sub HandleException(ByVal exception As Exception)
        MsgBox(exception.Message, MsgBoxStyle.Exclamation, "STI-Ventas") ', GetSTI-VentasName())
    End Sub

    Public Sub HandleException(exception As String)
        MsgBox(exception, MsgBoxStyle.Exclamation, "STI-Ventas")
    End Sub

    Public Function ConfirmDeleteRecord(ByVal _id As String) As Boolean
        Return MessageBox.Show(String.Format("Desea eliminar el registro {0}", _id), "STI-Ventas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes

    End Function

    Public Function CheckFailed(ByVal _message As String) As Boolean
        MessageBox.Show(_message, "STI-Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Return False
    End Function
#End Region

#Region "Helpers para forms"

    Public Sub SetupDataGridView(ByVal dgv As DataGridView)
        dgv.RowsDefaultCellStyle.BackColor = Color.PaleTurquoise
        dgv.RowsDefaultCellStyle.ForeColor = Color.MidnightBlue
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        dgv.BackgroundColor = Color.White
        dgv.ReadOnly = True
        dgv.AllowUserToResizeColumns = True
    End Sub

    Public Sub ValidateLetters(ByVal o As Object, ByVal e As KeyPressEventArgs)
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub ValidateNumbers(ByVal o As Object, ByVal e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub FillCurrencyComboBox(caller As Form, ByRef cboMoneda As ComboBox)
        Dim controller As MonedaController
        Dim dbTable As List(Of TablaBaseModel)
        Dim dbSelect As DBSelect

        Try
            caller.Cursor = Cursors.WaitCursor
            cboMoneda.DataSource = Nothing

            controller = New MonedaController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.SelectFields.Add(New DBSelectionField("CodigoMoneda", "Id"))

            dbTable = controller.GetListWithFilters(Of TablaBaseModel)(dbSelect)

            cboMoneda.DataSource = dbTable
            cboMoneda.DisplayMember = "Id"
            cboMoneda.ValueMember = "Id"
            cboMoneda.SelectedIndex = -1

        Catch ex As Exception
            HandleException(ex)
        Finally
            caller.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub FillGrupoProveedorComboBox(caller As Form, ByRef cboGrupoProveedor As ComboBox)
        Dim controller As GrupoProveedorController
        Dim dbTable As List(Of TablaBaseModel)
        Dim dbSelect As DBSelect

        Try
            caller.Cursor = Cursors.WaitCursor
            cboGrupoProveedor.DataSource = Nothing

            controller = New GrupoProveedorController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.SelectFields.Add(New DBSelectionField("Grupo", "Id"))

            dbTable = controller.GetListWithFilters(Of TablaBaseModel)(dbSelect)

            cboGrupoProveedor.DataSource = dbTable
            cboGrupoProveedor.DisplayMember = "Id"
            cboGrupoProveedor.ValueMember = "Id"
            cboGrupoProveedor.SelectedIndex = -1

        Catch ex As Exception
            HandleException(ex)
        Finally
            caller.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub FillFormaPagoComboBox(caller As Form, ByRef cboFormaPago As ComboBox)
        Dim controller As FormaPagoController
        Dim dbTable As List(Of TablaBaseModel)
        Dim dbSelect As DBSelect

        Try
            caller.Cursor = Cursors.WaitCursor
            cboFormaPago.DataSource = Nothing

            controller = New FormaPagoController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.SelectFields.Add(New DBSelectionField("IdFormaPago", "Id"))

            dbTable = controller.GetListWithFilters(Of TablaBaseModel)(dbSelect)

            cboFormaPago.DataSource = dbTable
            cboFormaPago.DisplayMember = "Id"
            cboFormaPago.ValueMember = "Id"
            cboFormaPago.SelectedIndex = -1

        Catch ex As Exception
            HandleException(ex)
        Finally
            caller.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub FillProveedorComboBox(caller As Form, ByRef cboProveedor As ComboBox)
        Dim controller As ProveedorController
        Dim dbTable As List(Of TablaBaseModel)
        Dim dbSelect As DBSelect

        Try
            caller.Cursor = Cursors.WaitCursor
            cboProveedor.DataSource = Nothing

            controller = New ProveedorController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.SelectFields.Add(New DBSelectionField("IdProveedor", "Id"))

            dbTable = controller.GetListWithFilters(Of TablaBaseModel)(dbSelect)

            cboProveedor.DataSource = dbTable
            cboProveedor.DisplayMember = "Id"
            cboProveedor.ValueMember = "Id"
            cboProveedor.SelectedIndex = -1

        Catch ex As Exception
            HandleException(ex)
        Finally
            caller.Cursor = Cursors.Default
        End Try
    End Sub

#End Region
End Module
