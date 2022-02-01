Imports STIVentas.Controller

''' <summary>
''' Template base
''' </summary>
''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
Public Class FrmBase

    Dim isNewRecord As Boolean

#Region "Events"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.SaveRecord()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Me.ClearFields()
        isNewRecord = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteRecord()
    End Sub
    Private Sub FrmBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


#End Region

#Region "Class methods"

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Function SaveRecord() As Boolean

        Dim ret As Boolean = False

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Function UpdateRecord() As Boolean

        Dim ret As Boolean = False

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Sub ClearFields()

    End Sub

    ''' <summary>
    ''' Indica si debe haber interacción con el usuario para eliminar un registro
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Function AskToDelete() As Boolean
        Return True
    End Function

    ''' <summary>
    ''' Valida si puede eliminar el registro
    ''' </summary>
    ''' <returns>True si puede borrar el registro</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Function ValidateDelete() As Boolean
        Dim ret As Boolean = True

        If AskToDelete() Then
            ret = MessageBox.Show($"Desea eliminar el registro {GetRecordIdentification()}?", GetPOSName(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) = DialogResult.Yes

        End If

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Function DeleteInternal() As Boolean

        Dim ret As Boolean = False

        If AskToDelete() Then
            ret = DeleteRecord()

            If ret Then
                ClearFields()
            End If

        End If

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Function DeleteRecord() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Function GetRecordIdentification() As String
        Return String.Empty
    End Function

#End Region
End Class