''' <summary>
''' Modulo para eventos y validaciones a nivel form.
''' </summary>
''' <remarks>01.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
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

    Public Sub HandleException(ByVal exception As Exception)
        MsgBox(exception.Message, MsgBoxStyle.Exclamation, "POS") ', GetPOSName())
    End Sub

End Module
