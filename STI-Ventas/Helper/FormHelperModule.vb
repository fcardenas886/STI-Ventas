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

    Public Function ConfirmDeleteRecord(ByVal _id As String) As Boolean
        Return MessageBox.Show(String.Format("Desea eliminar el registro {0}", _id), "POS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) = DialogResult.Yes

    End Function

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
End Module
