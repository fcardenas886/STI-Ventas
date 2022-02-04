
Imports STIVentas.Controller
Imports STIVentas.Model
''' <summary>
''' Form para grupo de proveedores
''' </summary>
''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class FrmGrupoProveedor
    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim vendGroup As GrupoProveedorController

        Try
            Cursor = Cursors.WaitCursor
            vendGroup = New GrupoProveedorController()
            deleted = vendGroup.Delete(GetCurrentTable())

            If Not deleted Then
                HandleException(vendGroup.LastError)
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
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        Return txtGroupId.Text
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim vendGroup As GrupoProveedorController

        Try
            Cursor = Cursors.WaitCursor
            vendGroup = New GrupoProveedorController()
            ret = vendGroup.Insert(GetCurrentTable())

            If Not ret Then
                HandleException(vendGroup.LastError)
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
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function UpdateRecord() As Boolean
        Dim ret As Boolean = False
        Dim vendGroup As GrupoProveedorController

        Try
            Cursor = Cursors.WaitCursor
            vendGroup = New GrupoProveedorController()
            ret = vendGroup.Update(GetCurrentTable())

            If Not ret Then
                HandleException(vendGroup.LastError)
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
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ClearFields()
        txtName.Clear()
        txtGroupId.Clear()
        txtGroupId.Enabled = True

        txtGroupId.Select()
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        MyBase.OnFormLoaded()
        AddHandler txtGroupId.Enter, AddressOf TextBox_Enter
        AddHandler txtName.Enter, AddressOf TextBox_Enter

        txtGroupId.Select()
    End Sub

    Public Overrides Function GetCurrentTable() As IDBTable
        Dim dbTable As New GrupoProveedorModel With {
            .Id = 0,
            .Grupo = txtGroupId.Text,
            .Nombre = txtName.Text
        }

        Return dbTable
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then

            txtGroupId.Text = dtGridView.Item(0, e.RowIndex).Value
            txtName.Text = dtGridView.Item(1, e.RowIndex).Value

            isNewRecord = False
            txtGroupId.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim vendGroup As GrupoProveedorController
        Dim records As List(Of GrupoProveedorModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Grupo", .HeaderText = "Grupo"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre"})
            End If

            vendGroup = New GrupoProveedorController()
            records = vendGroup.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As GrupoProveedorModel In records
                dtGridView.Rows().Add(model.Grupo, model.Nombre)
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(vendGroup.LastError) Then
                HandleException(vendGroup.LastError)
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
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function AskToDelete() As Boolean
        Return ConfirmDeleteRecord(GetRecordIdentification())
    End Function

End Class