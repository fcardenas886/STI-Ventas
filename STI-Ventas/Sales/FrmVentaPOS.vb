

''' <summary>
''' Se agrega el form
''' </summary>
''' <remarks>18.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmVentaPOS
    Private Sub btnCobrarOV_Click(sender As Object, e As EventArgs) Handles btnCobrarOV.Click
        Dim cobro As New FrmCobroVenta()
        cobro.ShowDialog(Me)
    End Sub
End Class