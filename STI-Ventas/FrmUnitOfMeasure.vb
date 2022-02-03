
Imports STIVentas.Controller
Imports STIVentas.Model
''' <summary>
''' Unidades de medida
''' </summary>
''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class FrmUnitOfMeasure
    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim uomController As UnidadController

        Try
            Cursor = Cursors.WaitCursor
            uomController = New UnidadController()
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
        Return txtUnitId.Text
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim uomController As UnidadController

        Try
            Cursor = Cursors.WaitCursor
            uomController = New UnidadController()
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
        Dim uomController As UnidadController

        Try
            Cursor = Cursors.WaitCursor
            uomController = New UnidadController()
            ret = uomController.Update(GetCurrentTable())

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
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ClearFields()
        txtAlias.Clear()
        txtName.Clear()
        txtUnitId.Clear()
        txtUnitId.Enabled = True
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        MyBase.OnFormLoaded()
        AddHandler txtUnitId.Enter, AddressOf TextBox_Enter
        AddHandler txtAlias.Enter, AddressOf TextBox_Enter
        AddHandler txtName.Enter, AddressOf TextBox_Enter
    End Sub

    Public Overrides Function GetCurrentTable() As IDBTable
        Dim dbTable As New UnidadMedidaModel With {
            .Id = 0,
            .Unidad = txtUnitId.Text,
            .Nombre = txtName.Text,
            .AliasUnidad = txtAlias.Text
        }

        Return dbTable
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then

            txtUnitId.Text = dtGridView.Item(0, e.RowIndex).Value
            txtName.Text = dtGridView.Item(1, e.RowIndex).Value
            txtAlias.Text = dtGridView.Item(2, e.RowIndex).Value

            isNewRecord = False
            txtUnitId.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim uomController As UnidadController
        Dim records As List(Of UnidadMedidaModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Unidad", .HeaderText = "Unidad"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Alias", .HeaderText = "Alias"})
            End If

            uomController = New UnidadController()
            records = uomController.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As UnidadMedidaModel In records
                dtGridView.Rows().Add(model.Unidad, model.Nombre, model.AliasUnidad)
            Next

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

End Class
