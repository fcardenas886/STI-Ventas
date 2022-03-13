Imports STIVentas.Controller
Imports STIVentas.Model


Public Class FrmLogin

    Dim IdUsuario As Integer

    Public Function login() As Boolean

        Dim pass = Loadpass()
        If Not String.IsNullOrEmpty(pass) AndAlso pass.Equals(txtContraseña.Text) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If Not ValidaDatos() Then
            CheckFailed("Ingrese el usuario y contraseña.")
            Return
        End If

        If login() = True Then
            AbreFormPredeterminado()
            Me.DialogResult = DialogResult.OK
            Close()
        Else
            MessageBox.Show("contraseña o usuario  incorrecto vuelva a intentarlo")
            txtUsuario.Clear()
            txtUsuario.Focus()
            txtContraseña.Clear()
        End If



    End Sub

    Private Function Loadpass() As String
        Dim controller As UsuarioController
        Dim records As UsuarioModel
        Dim s As String
        Try

            Cursor = Cursors.WaitCursor

            controller = New UsuarioController()
            records = controller.GetListuser(txtUsuario.Text)
            s = records.Password
            IdUsuario = CInt(records.Id)

            s = CStr(IIf(String.IsNullOrEmpty(s), s, AES.Decrypt256(s)))


            Return s
        Catch ex As Exception
            HandleException(ex)
            Return ""
        Finally
            Cursor = Cursors.Default
        End Try

    End Function

    Private Function ValidaDatos() As Boolean
        Return Not String.IsNullOrWhiteSpace(txtUsuario.Text) AndAlso Not String.IsNullOrWhiteSpace(txtContraseña.Text)
    End Function

    Private Sub AbreFormPredeterminado()
        Dim mdi As New FrmMainMDI(IdUsuario, txtUsuario.Text)

        mdi.ToolStripStatusUserName.Text = txtUsuario.Text
        mdi.Show()
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuario.SelectAll()
    End Sub

    Private Sub txtContraseña_KeyUp(sender As Object, e As KeyEventArgs) Handles txtContraseña.KeyUp
        If e.KeyData = Keys.Enter Then
            If ValidaDatos() Then
                btnLogin.PerformClick()
            Else
                txtUsuario.Select()
            End If
        End If
    End Sub

    Private Sub txtUsuario_KeyUp(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyUp
        If e.KeyData = Keys.Enter Then
            If ValidaDatos() Then
                btnLogin.PerformClick()
            Else
                txtContraseña.Select()
            End If
        End If
    End Sub
End Class