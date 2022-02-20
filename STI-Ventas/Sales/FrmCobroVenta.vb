
''' <summary>
''' Se agrega el form
''' </summary>
''' <remarks>18.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmCobroVenta
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub FrmCobroVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEfectivo.Text = FrmMainMDI.ID_USUARIO.ToString()
    End Sub
End Class