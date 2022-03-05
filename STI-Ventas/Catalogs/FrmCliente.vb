Imports STIVentas.Controller
Imports STIVentas.Model

Public Class FrmCliente







    Protected Function ValidateWrite() As Boolean

        Dim ret As Boolean = True

        If String.IsNullOrEmpty(txtId.Text) Then
            ret = CheckFailed("Debe completar el id de Cliente antes de continuar")
        End If

        Return ret
    End Function






    '' nuevo cod

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim uomController As ClienteController

        Try
            Cursor = Cursors.WaitCursor
            uomController = New ClienteController()
            deleted = uomController.Delete(GetCurrentTable())

            If Not deleted Then
                HandleException(uomController.LastError)
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
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        Return txtId.Text
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim uomController As ClienteController

        Try
            Cursor = Cursors.WaitCursor
            uomController = New ClienteController()
            ret = uomController.Insert(GetCurrentTable())

            If Not ret Then
                HandleException(uomController.LastError)
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
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function UpdateRecord() As Boolean
        Dim ret As Boolean = False
        Dim dbController As ClienteController

        Try
            If ValidateWrite() Then
                Cursor = Cursors.WaitCursor
                dbController = New ClienteController()
                ret = dbController.Update(GetCurrentTable())

                If Not ret Then
                    HandleException(dbController.LastError)
                End If
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
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ClearFields()
        txtId.Clear()
        txtRut.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtCupo.Clear()
        txtId.Enabled = True
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        MyBase.OnFormLoaded()
        AddHandler txtId.Enter, AddressOf TextBox_Enter
        AddHandler txtRut.Enter, AddressOf TextBox_Enter
        AddHandler txtNombre.Enter, AddressOf TextBox_Enter

        AddHandler txtDireccion.Enter, AddressOf TextBox_Enter
        AddHandler txtCupo.Enter, AddressOf TextBox_Enter

    End Sub

    Public Overrides Function GetCurrentTable() As IDBTable
        Dim dbTable As New ClienteModel With {
            .Rut = txtRut.Text,
            .Nombre = txtNombre.Text,
            .Direccion = txtDireccion.Text,
            .Cupo = Convert.ToInt32(txtCupo.Text)
        }
        If Not String.IsNullOrEmpty(txtId.Text) Then
            dbTable.Id = CType(txtId.Text, Integer)
        End If

        Return dbTable
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then

            txtId.Text = dtGridView.Item(0, e.RowIndex).Value
            txtRut.Text = dtGridView.Item(1, e.RowIndex).Value
            txtNombre.Text = dtGridView.Item(2, e.RowIndex).Value
            txtDireccion.Text = dtGridView.Item(3, e.RowIndex).Value
            txtCupo.Text = dtGridView.Item(4, e.RowIndex).Value
            isNewRecord = False
            txtId.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim dbController As ClienteController
        Dim records As List(Of ClienteModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Rut", .HeaderText = "Rut"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Direccion", .HeaderText = "Direccion"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Cupo", .HeaderText = "Cupo"})

            End If

            dbController = New ClienteController()
            records = dbController.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As ClienteModel In records
                dtGridView.Rows().Add(model.Id, model.Rut, model.Nombre, model.Direccion, model.Cupo)
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(dbController.LastError) Then
                HandleException(dbController.LastError)
                dtGridView.Rows.Add()
                dtGridView.Rows.Add()
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
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function AskToDelete() As Boolean
        Return ConfirmDeleteRecord(GetRecordIdentification())
    End Function



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class