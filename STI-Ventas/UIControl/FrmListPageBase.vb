Imports STIVentas.Model

''' <summary>
''' Template base para listas
''' </summary>
''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmListPageBase

#Region "Class methods"

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Sub ResetFilters()

    End Sub

    ''' <summary>
    ''' Indica si debe haber interacción con el usuario para eliminar un registro
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Function AskToDelete() As Boolean
        Return True
    End Function

    ''' <summary>
    ''' Valida si puede eliminar el registro
    ''' </summary>
    ''' <returns>True si puede borrar el registro</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Function ValidateDelete() As Boolean
        Dim ret As Boolean = True

        Return ret
    End Function

    ''' <summary>
    ''' Valida si puede eliminar el registro y pregunta al usuario
    ''' </summary>
    ''' <returns>True si puede borrar el registro</returns>
    ''' <remarks>07.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Private Function CanDeleteRecord() As Boolean
        Dim ret As Boolean

        ret = ValidateDelete()

        If ret And AskToDelete() Then
            ret = ConfirmDeleteRecord(GetRecordIdentification())
        End If

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Function DeleteInternal() As Boolean

        Dim ret As Boolean = False

        If CanDeleteRecord() Then
            ret = DeleteRecord()

            If ret Then
                LoadRecords()
                ResetFilters()
            End If

        End If

        Return ret
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Function DeleteRecord() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overridable Function GetRecordIdentification() As String
        Return String.Empty
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overridable Sub OnFormLoaded()
        LoadRecords()
        SetupDataGridView(dgvListPage)
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overridable Sub LoadRecords()

    End Sub

    ''' <summary>
    ''' Sobreescribir en caso de validar el cierre del form
    ''' </summary>
    ''' <returns>True si desea cancelar el cierre del form</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overridable Function CanCloseForm() As Boolean
        Return True
    End Function

    ''' <summary>
    ''' Regresa la interfaz que implementa el form
    ''' </summary>
    ''' <returns>La tabla que esta manejando</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overridable Function GetCurrentTable() As IDBTable
        Return Nothing
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overridable Sub OnSelectedRow(e As DataGridViewCellEventArgs)

    End Sub

    ''' <summary>
    ''' Crea un nuevo registro
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overridable Sub OnNewRecordSelected()

    End Sub

    ''' <summary>
    ''' Edición de un registro
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overridable Sub OnEditRecordSelected()

    End Sub

    ''' <summary>
    ''' Se debe implementar para el filtro
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overridable Sub FilterRecords()

    End Sub

#End Region

#Region "Events"
    Private Sub FrmListPageBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OnFormLoaded()
        ResetFilters()
    End Sub

    Private Sub dgvListPage_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListPage.CellContentDoubleClick
        OnSelectedRow(e)
    End Sub

    Private Sub NuevoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem1.Click
        OnNewRecordSelected()
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        OnEditRecordSelected()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        DeleteInternal()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        FilterRecords()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub
#End Region


End Class