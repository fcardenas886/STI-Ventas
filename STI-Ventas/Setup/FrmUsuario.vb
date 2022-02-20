Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Se agrega form para usuarios
''' </summary>
''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmUsuario

#Region "Class Methods"
    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim uomController As UsuarioController

        Try
            Cursor = Cursors.WaitCursor
            uomController = New UsuarioController()
            deleted = uomController.Delete(GetCurrentTable())

            If Not deleted Then
                HandleException(uomController.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return deleted

    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        Return txtUsername.Text
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim uomController As UsuarioController

        Try
            If Not ValidateWrite() Then
                Return ret
            End If

            Cursor = Cursors.WaitCursor
            uomController = New UsuarioController()
            ret = uomController.Insert(GetCurrentTable())

            If Not ret Then
                HandleException(uomController.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function UpdateRecord() As Boolean
        Dim ret As Boolean = False
        Dim uomController As UsuarioController

        Try
            If Not ValidateWrite() Then
                Return ret
            End If

            Cursor = Cursors.WaitCursor
            uomController = New UsuarioController()
            ret = uomController.Update(GetCurrentTable())

            If Not ret Then
                HandleException(uomController.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ClearFields()
        txtAlias.Clear()
        txtName.Clear()
        txtUsername.Clear()

        txtEmail.Clear()
        txtPassword.Clear()
        txtConfirmPassword.Clear()

        chkEnabled.Checked = True
        txtUsername.ReadOnly = False
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        MyBase.OnFormLoaded()
        AddHandler txtUsername.Enter, AddressOf TextBox_Enter
        AddHandler txtAlias.Enter, AddressOf TextBox_Enter
        AddHandler txtName.Enter, AddressOf TextBox_Enter

        AddHandler txtEmail.Enter, AddressOf TextBox_Enter
        AddHandler txtPassword.Enter, AddressOf TextBox_Enter
        AddHandler txtConfirmPassword.Enter, AddressOf TextBox_Enter

        chkEnabled.Checked = True

    End Sub

    Public Overrides Function GetCurrentTable() As IDBTable
        Dim dbTable As New UsuarioModel With {
            .Id = 0,
            .Username = txtUsername.Text,
            .Nombre = txtName.Text,
            .AliasName = txtAlias.Text,
            .Email = txtEmail.Text,
            .Password = txtPassword.Text
        }

        dbTable.Status = IIf(chkEnabled.Checked, EstadoUsuario.Activo, EstadoUsuario.Inactivo)

        Return dbTable
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)
        Dim UsuarioModel As UsuarioModel

        If e.RowIndex >= 0 Then

            txtUsername.Text = dtGridView.Item(0, e.RowIndex).Value

            UsuarioModel = GetProveedorPorId(txtUsername.Text)

            If UsuarioModel IsNot Nothing And Not String.IsNullOrEmpty(UsuarioModel.Username) Then

                txtAlias.Text = UsuarioModel.AliasName
                txtName.Text = UsuarioModel.Nombre
                txtUsername.Text = UsuarioModel.Username

                txtEmail.Text = UsuarioModel.Email
                txtPassword.Text = UsuarioModel.Password
                txtConfirmPassword.Text = UsuarioModel.Password
                txtEmail.Text = UsuarioModel.Email

                isNewRecord = False
                txtUsername.ReadOnly = True
                chkEnabled.Checked = UsuarioModel.Status = EstadoUsuario.Activo

                AddErrorToControl("", txtUsername)
                AddErrorToControl("", txtPassword)
                AddErrorToControl("", txtConfirmPassword)
            Else
                isNewRecord = True
                txtUsername.ReadOnly = False
                ClearFields()
            End If

        End If
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim controller As UsuarioController
        Dim records As List(Of UsuarioModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Username", .HeaderText = "Nombre de usuario"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre completo"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Alias", .HeaderText = "Alias"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Email", .HeaderText = "Email"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Password", .HeaderText = "Password", .Visible = False})
                dtGridView.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Estatus", .HeaderText = "Estatus"})
            End If

            controller = New UsuarioController()
            records = controller.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As UsuarioModel In records
                dtGridView.Rows().Add(model.Username, model.Nombre, model.AliasName,
                                         model.Email, model.Password, model.Status = EstadoUsuario.Activo)
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
    ''' Indica si debe haber interacción con el usuario para eliminar un registro
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function AskToDelete() As Boolean
        Return ConfirmDeleteRecord(GetRecordIdentification())
    End Function

    ''' <summary>
    ''' Regresa el usuario con el username indicado
    ''' </summary>
    ''' <param name="username"></param>
    ''' <returns></returns>
    ''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function GetProveedorPorId(username As String) As UsuarioModel
        'Dim controller As UsuarioController
        'Dim records As List(Of UsuarioModel)
        Dim ret As UsuarioModel = Nothing
        'Dim dbSelect As DBSelect
        Dim isEnabled As Boolean

        Try
            Cursor = Cursors.WaitCursor

            'controller = New UsuarioController()
            'dbSelect = New DBSelect(controller.TableName())
            'DBSelect.FilterFields.Add(New DBFilterFields("Username", DBFilterType.Equal, username))

            'records = controller.GetListWithFilters(Of UsuarioModel)(dbSelect)

            'If records.Count < 0 Then
            '    Throw New Exception(String.Format("No se encontro el registro {0} en la base de datos", username))
            'End If
            'ret = records.FirstOrDefault()
            ret = New UsuarioModel() With
                {
                .Id = 0,
                .Username = username
                }

            If dtGridView.CurrentRow IsNot Nothing Then
                isEnabled = dtGridView.CurrentRow().Cells().Item(5).Value

                ret.Email = dtGridView.CurrentRow().Cells().Item(3).Value
                ret.Nombre = dtGridView.CurrentRow().Cells().Item(1).Value
                ret.AliasName = dtGridView.CurrentRow().Cells().Item(2).Value
                ret.Password = dtGridView.CurrentRow().Cells().Item(4).Value
                ret.Status = IIf(isEnabled, EstadoUsuario.Activo, EstadoUsuario.Inactivo)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    Protected Sub AddErrorToControl(strMsg As String, control As Control)
        ErrorProviderUser.SetError(control, strMsg)
    End Sub

    Protected Function ValidateUsername(Optional mandatory As Boolean = False) As Boolean
        Dim ret As Boolean = False
        Dim controller As UsuarioController


        Try
            Cursor = Cursors.WaitCursor

            If String.IsNullOrEmpty(txtUsername.Text) Then
                ret = Not mandatory
                AddErrorToControl("Ingrese un nombre de usuario.", txtUsername)
            ElseIf Not txtUsername.ReadOnly Then
                controller = New UsuarioController()
                ret = controller.ExistUsername(txtUsername.Text)

                If ret Then
                    AddErrorToControl("", txtUsername)
                Else
                    AddErrorToControl("El nombre de usuario ya existe, ingrese otro.", txtUsername)
                End If
            Else
                ret = True
                AddErrorToControl("", txtUsername)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    Protected Function ShouldCheckPassword() As Boolean

        Return Not String.IsNullOrEmpty(txtPassword.Text) And Not String.IsNullOrEmpty(txtConfirmPassword.Text)
    End Function

    Protected Function CheckPasswords(passwordControl As TextBox) As Boolean
        Dim ret As Boolean = True


        Try
            If ShouldCheckPassword() Then
                If txtPassword.Text.Equals(txtConfirmPassword.Text) Then
                    AddErrorToControl("", txtPassword)
                    AddErrorToControl("", txtConfirmPassword)
                Else
                    AddErrorToControl("Las contraseñas deben ser las mismas.", passwordControl)
                End If
            Else
                AddErrorToControl("", passwordControl)
            End If
        Catch ex As Exception
            HandleException(ex)
        End Try

        Return ret
    End Function

    Protected Function ValidateWrite() As Boolean
        Dim ret As Boolean = True
        Dim model As UsuarioModel
        Dim strErrorMsg As String = String.Empty

        model = GetCurrentTable()

        If model Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar el usuario actual")
        Else
            If String.IsNullOrEmpty(model.Username) Then
                strErrorMsg = AppendLastError(strErrorMsg, "Debe indicar el nombre de usuario.")
            ElseIf Not ValidateUsername(True) Then
                strErrorMsg = AppendLastError(strErrorMsg, "El nombre de usuario ya existe, indique otro.")
            End If

            If Not ShouldCheckPassword() Then
                strErrorMsg = AppendLastError(strErrorMsg, "Debe indicar la contraseña, así como la confirmación.")
            ElseIf Not txtPassword.Text.Equals(txtConfirmPassword.Text) Then
                strErrorMsg = AppendLastError(strErrorMsg, "Las contraseñas deben ser las mismas.")
            Else
                AddErrorToControl("", txtPassword)
                AddErrorToControl("", txtConfirmPassword)
            End If

        End If

        If Not String.IsNullOrEmpty(strErrorMsg) Then
            ret = CheckFailed(strErrorMsg)
        End If


        Return ret
    End Function

#End Region

#Region "Events"

    Private Sub txtPassword_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPassword.Validating, txtConfirmPassword.Validating
        CheckPasswords(sender)
    End Sub

    Private Sub TxtUsername_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUsername.Validating
        If Not ValidateUsername() Then
            e.Cancel = True
        End If
    End Sub

    Private Sub txtConfirmPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress, txtConfirmPassword.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#End Region
End Class