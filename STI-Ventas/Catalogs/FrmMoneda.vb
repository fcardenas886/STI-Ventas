
Imports STIVentas.Controller
Imports STIVentas.Model
''' <summary>
''' Form para monedas
''' </summary>
''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmMoneda

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim vendGroup As MonedaController
        Dim records As List(Of MonedaModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Moneda", .HeaderText = "Moneda"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "CodigoISO", .HeaderText = "Código ISO"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Simbolo", .HeaderText = "Simbolo"})
            End If

            vendGroup = New MonedaController()
            records = vendGroup.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As MonedaModel In records
                dtGridView.Rows().Add(model.CodigoMoneda, model.Nombre, model.CodigoISO, model.Simbolo)
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

End Class