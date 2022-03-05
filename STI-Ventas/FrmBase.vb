Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Template base
''' </summary>
''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
Public Class FrmBase

    Protected isNewRecord As Boolean
    Protected iRecordId As Long

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
        DeleteInternal()
        isNewRecord = True
    End Sub
    Private Sub FrmBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearFields()
        OnFormLoaded()
    End Sub

    Private Sub FrmBase_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not CanCloseForm() Then
            e.Cancel = True
        End If
    End Sub

    Private Sub dtGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtGridView.CellDoubleClick
        OnSelectedRow(e)
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

        If isNewRecord Then
            If InsertRecord() Then
                LoadRecords()
                ClearFields()
                isNewRecord = True
            End If
        Else
            If UpdateRecord() Then
                LoadRecords()
                ClearFields()
                isNewRecord = True
            End If
        End If

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si insert</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Function InsertRecord() As Boolean

        Dim ret As Boolean = False

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Function UpdateRecord() As Boolean

        Dim ret As Boolean = False

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Sub ClearFields()
        isNewRecord = True
    End Sub

    ''' <summary>
    ''' Indica si debe haber interacción con el usuario para eliminar un registro
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Function AskToDelete() As Boolean
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

        If isNewRecord Then
            ClearFields()
        ElseIf AskToDelete() Then
            ret = DeleteRecord()

            If ret Then
                ClearFields()
                LoadRecords()
            End If

        End If

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Function DeleteRecord() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Function GetRecordIdentification() As String
        Return String.Empty
    End Function

    Protected Sub HandleException(ByVal exception As Exception)
        MsgBox(exception.Message, MsgBoxStyle.Exclamation, GetPOSName())
    End Sub

    Protected Sub HandleException(ByVal exception As String)
        MsgBox(exception, MsgBoxStyle.Exclamation, GetPOSName())
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overridable Sub OnFormLoaded()
        isNewRecord = True
        SetupDataGridView(dtGridView)
        LoadRecords()
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overridable Sub LoadRecords()

    End Sub

    ''' <summary>
    ''' Sobreescribir en caso de validar el cierre del form
    ''' </summary>
    ''' <returns>True si desea cancelar el cierre del form</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overridable Function CanCloseForm() As Boolean
        Return True
    End Function

    ''' <summary>
    ''' Regresa la interfaz que implementa el form
    ''' </summary>
    ''' <returns>La tabla que esta manejando</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overridable Function GetCurrentTable() As IDBTable
        Return Nothing
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overridable Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)

    End Sub

#End Region
End Class