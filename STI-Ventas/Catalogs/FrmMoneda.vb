
Imports STIVentas.Controller
Imports STIVentas.Model
''' <summary>
''' Form para monedas
''' </summary>
''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmMoneda

    Private Function GetComboBoxColumn(ByVal name As String, ByVal label As String) As DataGridViewComboBoxColumn
        Dim cboColumn As New DataGridViewComboBoxColumn

        cboColumn.Name = name
        cboColumn.HeaderText = label
        cboColumn.DataSource = DataModelHelper.GetDescriptionAttributes(GetType(TipoRedondeoMoneda))
        cboColumn.MaxDropDownItems = 5
        'cboColumn.Items.AddRange(DataModelHelper.GetDescriptionAttributes(GetType(TipoRedondeoMoneda)))
        cboColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        'cboColumn.DataPropertyName = "TipoRedondeoMoneda"
        Return cboColumn
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim dbController As MonedaController
        Dim records As List(Of MonedaModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Moneda", .HeaderText = "Moneda"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Descripcion", .HeaderText = "Descripción"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "CodigoISO", .HeaderText = "Código ISO"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Simbolo", .HeaderText = "Simbolo"})

                dtGridView.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "RedondearGral", .HeaderText = "Redondeo"})
                dtGridView.Columns.Add(GetComboBoxColumn("TipoRedondeoGral", "Tipo redondeo"))
                'dtGridView.Columns.Add(New DataGridViewComboBoxColumn With {.Name = "TipoRedondeGral", .HeaderText = "Tipo redondeo", .DataSource = DataModelHelper.GetDescriptionAttributes(GetType(TipoRedondeoMoneda)).ToList()})

                dtGridView.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "RedondearInvent", .HeaderText = "Inventario"})
                dtGridView.Columns.Add(GetComboBoxColumn("TipoRedondeoInvent", "Tipo redondeo"))
                dtGridView.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "RedondearSales", .HeaderText = "Ventas"})
                dtGridView.Columns.Add(GetComboBoxColumn("TipoRedondeoSales", "Tipo redondeo"))
                dtGridView.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "RedondearPurch", .HeaderText = "Compras"})
                dtGridView.Columns.Add(GetComboBoxColumn("TipoRedondeoPurch", "Tipo redondeo"))

            End If

            dbController = New MonedaController()
            records = dbController.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As MonedaModel In records
                dtGridView.Rows().Add(model.CodigoMoneda, model.Nombre, model.Descripcion, model.CodigoISO, model.Simbolo,
                                        model.Redondear, GetEnumDescription(model.TipoRedondeo),
                                        model.RedondearInventario, GetEnumDescription(model.RedondeoInventario),
                                        model.RedondearVentas, GetEnumDescription(model.RedondeoVentas),
                                        model.RedondearCompras, GetEnumDescription(model.RedondeoCompras)
                                        )
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
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>04.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim dbController As MonedaController

        Try
            Cursor = Cursors.WaitCursor
            dbController = New MonedaController()
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
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>04.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        Return txtCodigoMoneda.Text
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>04.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim dbController As MonedaController

        Try
            If ValidateWrite() Then
                Cursor = Cursors.WaitCursor
                dbController = New MonedaController()
                ret = dbController.Insert(GetCurrentTable())

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
    ''' <returns>True si actualizo</returns>
    ''' <remarks>04.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function UpdateRecord() As Boolean
        Dim ret As Boolean = False
        Dim dbController As MonedaController

        Try
            If ValidateWrite() Then
                Cursor = Cursors.WaitCursor
                dbController = New MonedaController()
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
    ''' <remarks>04.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ClearFields()
        txtCodigoMoneda.Clear()
        txtName.Clear()
        txtAlias.Clear()
        txtCodigoIso.Clear()
        txtSimbolo.Clear()
        chkBoxRedondeoGral.Checked = False
        cboTipoRedondeoGral.SelectedIndex = -1

        chkBoxRedondeoInvent.Checked = False
        cboTipoRedondeoInvent.SelectedIndex = -1
        chkBoxRedondeoPurch.Checked = False
        cboTipoRedondeoPurch.SelectedIndex = -1
        chkBoxRedondeoSales.Checked = False
        cboTipoRedondeoSales.SelectedIndex = -1

        txtCodigoMoneda.Enabled = True
        txtCodigoMoneda.Select()
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>04.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        Dim tipoRedondeoValues As String()

        MyBase.OnFormLoaded()
        AddHandler txtCodigoMoneda.Enter, AddressOf TextBox_Enter
        AddHandler txtAlias.Enter, AddressOf TextBox_Enter
        AddHandler txtName.Enter, AddressOf TextBox_Enter
        AddHandler txtCodigoIso.Enter, AddressOf TextBox_Enter
        AddHandler txtSimbolo.Enter, AddressOf TextBox_Enter

        tipoRedondeoValues = DataModelHelper.GetDescriptionAttributes(GetType(TipoRedondeoMoneda))
        cboTipoRedondeoGral.Items.AddRange(tipoRedondeoValues)
        cboTipoRedondeoInvent.Items.AddRange(tipoRedondeoValues)
        cboTipoRedondeoPurch.Items.AddRange(tipoRedondeoValues)
        cboTipoRedondeoSales.Items.AddRange(tipoRedondeoValues)
    End Sub

    Public Overrides Function GetCurrentTable() As IDBTable
        Dim dbTable As New MonedaModel With {
            .Id = 0,
            .CodigoMoneda = txtCodigoMoneda.Text,
            .Nombre = txtName.Text,
            .Descripcion = txtAlias.Text,
            .CodigoISO = txtCodigoIso.Text,
            .Simbolo = txtSimbolo.Text,
            .Redondear = chkBoxRedondeoGral.Checked,
            .TipoRedondeo = cboTipoRedondeoGral.SelectedIndex,
 _
            .RedondearInventario = chkBoxRedondeoInvent.Checked,
            .RedondeoInventario = cboTipoRedondeoInvent.SelectedIndex,
            .RedondearVentas = chkBoxRedondeoSales.Checked,
            .RedondeoVentas = cboTipoRedondeoSales.SelectedIndex,
            .RedondearCompras = chkBoxRedondeoPurch.Checked,
            .RedondeoCompras = cboTipoRedondeoPurch.SelectedIndex
        }

        If dbTable.TipoRedondeo < 0 Then
            dbTable.TipoRedondeo = 0
        End If
        If dbTable.RedondeoInventario < 0 Then
            dbTable.RedondeoInventario = 0
        End If
        If dbTable.RedondeoVentas < 0 Then
            dbTable.RedondeoVentas = 0
        End If
        If dbTable.RedondeoCompras < 0 Then
            dbTable.RedondeoCompras = 0
        End If

        Return dbTable
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>04.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then

            txtCodigoMoneda.Text = dtGridView.Item(0, e.RowIndex).Value
            txtName.Text = dtGridView.Item(1, e.RowIndex).Value
            txtAlias.Text = dtGridView.Item(2, e.RowIndex).Value
            txtCodigoIso.Text = dtGridView.Item(3, e.RowIndex).Value
            txtSimbolo.Text = dtGridView.Item(4, e.RowIndex).Value

            chkBoxRedondeoGral.Checked = dtGridView.Item(5, e.RowIndex).Value
            cboTipoRedondeoGral.SelectedIndex = GetIndexForTipoCambio(dtGridView.Item(6, e.RowIndex).Value)

            chkBoxRedondeoInvent.Checked = dtGridView.Item(7, e.RowIndex).Value
            cboTipoRedondeoInvent.SelectedIndex = GetIndexForTipoCambio(dtGridView.Item(8, e.RowIndex).Value)
            chkBoxRedondeoSales.Checked = dtGridView.Item(9, e.RowIndex).Value
            cboTipoRedondeoSales.SelectedIndex = GetIndexForTipoCambio(dtGridView.Item(10, e.RowIndex).Value)
            chkBoxRedondeoPurch.Checked = dtGridView.Item(11, e.RowIndex).Value
            cboTipoRedondeoPurch.SelectedIndex = GetIndexForTipoCambio(dtGridView.Item(12, e.RowIndex).Value)

            isNewRecord = False
            txtCodigoMoneda.Enabled = False
        End If
    End Sub
    ''' <summary>
    ''' Indica si debe haber interacción con el usuario para eliminar un registro
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>04.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function AskToDelete() As Boolean
        Return ConfirmDeleteRecord(GetRecordIdentification())
    End Function

    Protected Function ValidateWrite() As Boolean

        Dim ret As Boolean = True

        If String.IsNullOrEmpty(txtCodigoMoneda.Text) Then
            ret = CheckFailed("Debe completar el código de moneda antes de continuar")
        End If

        Return ret
    End Function

    Private Sub DataGridView_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles dtGridView.DataError
        If (e.Context = (DataGridViewDataErrorContexts.Formatting Or DataGridViewDataErrorContexts.PreferredSize)) Then
            e.ThrowException = False
        End If
    End Sub

    Private Function GetIndexForTipoCambio(value As String)
        Dim ret As TipoRedondeoMoneda
        Try
            ret = GetEnumFromDescriptionAttribute(Of TipoRedondeoMoneda)(value)
            Return ret
        Catch ex As Exception
            HandleException(ex)
        End Try

        Return -1
    End Function

End Class