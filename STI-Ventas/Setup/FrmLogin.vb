Imports STIVentas.Controller
Imports STIVentas.Model


Public Class FrmLogin


    Public Function login() As Boolean

        Dim pass = Loadpass()
        If pass.Equals(txtContraseña.Text) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If login() = True Then
            Me.DialogResult = DialogResult.OK
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



            controller = New UsuarioController()
            records = controller.GetListuser(txtUsuario.Text)
            s = records.Password

            s = IIf(String.IsNullOrEmpty(s), s, AES.Decrypt256(s))


            Return s
        Catch ex As Exception
            HandleException(ex)
            Return ""
        Finally
            Cursor = Cursors.Default
        End Try

    End Function
End Class