
Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Form para formas de pago
''' </summary>
''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class FrmFormaPago

    ''' <summary>
    ''' Elimina un registro en la BD
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim dbController As FormaPagoController

        Try
            Cursor = Cursors.WaitCursor
            dbController = New FormaPagoController()
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
    ''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        Return txtFormaPago.Text
    End Function

    ''' <summary>
    ''' Inserta un nuevo registro
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim dbController As FormaPagoController

        Try
            Cursor = Cursors.WaitCursor
            dbController = New FormaPagoController()
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
    ''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function UpdateRecord() As Boolean
        Dim ret As Boolean = False
        Dim dbController As FormaPagoController

        Try
            Cursor = Cursors.WaitCursor
            dbController = New FormaPagoController()
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
    ''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ClearFields()
        txtName.Clear()
        txtFormaPago.Clear()
        txtFormaPago.Enabled = True

        txtFormaPago.Select()
    End Sub

    ''' <summary>
    ''' Habilita eventos y metodos necesarios una vez que se cargo el form
    ''' </summary>
    ''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        MyBase.OnFormLoaded()
        AddHandler txtFormaPago.Enter, AddressOf TextBox_Enter
        AddHandler txtName.Enter, AddressOf TextBox_Enter

        txtFormaPago.Select()
    End Sub

    Public Overrides Function GetCurrentTable() As IDBTable
        Dim dbTable As New FormaPagoModel With {
            .Id = 0,
            .IdFormaPago = txtFormaPago.Text,
            .Descripcion = txtName.Text
        }

        Return dbTable
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then

            txtFormaPago.Text = dtGridView.Item(0, e.RowIndex).Value
            txtName.Text = dtGridView.Item(1, e.RowIndex).Value

            isNewRecord = False
            txtFormaPago.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim dbController As FormaPagoController
        Dim records As List(Of FormaPagoModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "IdFormaPago", .HeaderText = "Forma de Pago", .Width = 100})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Descripcion", .HeaderText = "Descripción", .Width = 450})
                dtGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End If

            dbController = New FormaPagoController()
            records = dbController.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As FormaPagoModel In records
                dtGridView.Rows().Add(model.IdFormaPago, model.Descripcion)
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
    ''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function AskToDelete() As Boolean
        Return ConfirmDeleteRecord(GetRecordIdentification())
    End Function

End Class