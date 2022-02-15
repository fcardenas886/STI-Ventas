
Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Form para categorías de productos
''' </summary>
''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el form y clase</remarks>
Public Class FrmCategoriaProducto

    ''' <summary>
    ''' Elimina un registro en la BD
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim dbController As CategoriaController

        Try
            Cursor = Cursors.WaitCursor
            dbController = New CategoriaController()
            deleted = dbController.Delete(GetCurrentTable())

            If Not deleted Then
                HandleException(dbController.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return deleted

    End Function

    ''' <summary>
    ''' Obtiene el id del registro
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        Return txtCategoria.Text
    End Function

    ''' <summary>
    ''' Inserta un nuevo registro
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim dbController As CategoriaController

        Try
            If Not ValidateWrite() Then
                Return ret
            End If
            Cursor = Cursors.WaitCursor
            dbController = New CategoriaController()
            ret = dbController.Insert(GetCurrentTable())

            If Not ret Then
                HandleException(dbController.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Actualiza un registro en la BD
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function UpdateRecord() As Boolean
        Dim ret As Boolean = False
        Dim dbController As CategoriaController

        Try
            If Not ValidateWrite() Then
                Return ret
            End If
            Cursor = Cursors.WaitCursor
            dbController = New CategoriaController()
            ret = dbController.Update(GetCurrentTable())

            If Not ret Then
                HandleException(dbController.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Limpia los campos de entrada de datos del form
    ''' </summary>
    ''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ClearFields()
        txtName.Clear()
        txtCategoria.Clear()
        txtCategoria.Enabled = True
        chkEsActivo.Checked = False

        txtCategoria.Select()
    End Sub

    ''' <summary>
    ''' Habilita eventos y metodos necesarios una vez que se cargo el form
    ''' </summary>
    ''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        MyBase.OnFormLoaded()
        AddHandler txtCategoria.Enter, AddressOf TextBox_Enter
        AddHandler txtName.Enter, AddressOf TextBox_Enter

        txtCategoria.Select()
    End Sub

    Public Overrides Function GetCurrentTable() As IDBTable
        Dim dbTable As New CategoriaModel With {
            .Id = 0,
            .IdCategoria = txtCategoria.Text,
            .Nombre = txtName.Text,
            .Activo = chkEsActivo.Checked
        }

        Return dbTable
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then

            txtCategoria.Text = dtGridView.Item(0, e.RowIndex).Value
            txtName.Text = dtGridView.Item(1, e.RowIndex).Value
            chkEsActivo.Checked = dtGridView.Item(2, e.RowIndex).Value

            isNewRecord = False
            txtCategoria.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim dbController As CategoriaController
        Dim records As List(Of CategoriaModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "IdCategoria", .HeaderText = "Id categoría", .Width = 100})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre", .Width = 450})
                dtGridView.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Activo", .HeaderText = "Es Activo"})
                dtGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End If

            dbController = New CategoriaController()
            records = dbController.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As CategoriaModel In records
                dtGridView.Rows().Add(model.IdCategoria, model.Nombre, model.Activo)
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(dbController.LastError) Then
                HandleException(dbController.LastError)
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
    ''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function AskToDelete() As Boolean
        Return ConfirmDeleteRecord(GetRecordIdentification())
    End Function


    Protected Function ValidateWrite() As Boolean
        Dim dbTable As CategoriaModel
        Dim ret As Boolean = True

        Try
            dbTable = GetCurrentTable()

            If String.IsNullOrEmpty(dbTable.IdCategoria) Then
                ret = CheckFailed("Debe indicar el id de categoría.")
            End If

        Catch ex As Exception
            HandleError(ex)
            ret = False
        End Try

        Return ret
    End Function
End Class