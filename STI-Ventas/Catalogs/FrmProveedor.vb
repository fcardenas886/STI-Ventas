Imports STIVentas.Controller
Imports STIVentas.Model
''' <summary>
''' Se agrega form para proveedores
''' </summary>
''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmProveedor

#Region "Class Methods"
    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim uomController As ProveedorController

        Try
            Cursor = Cursors.WaitCursor
            uomController = New ProveedorController()
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
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        Return txtProveedorId.Text
    End Function

    ''' <summary>
    ''' Se debe sobreescribir el metodo por cada tabla
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim uomController As ProveedorController

        Try
            Cursor = Cursors.WaitCursor
            uomController = New ProveedorController()
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
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function UpdateRecord() As Boolean
        Dim ret As Boolean = False
        Dim uomController As ProveedorController

        Try
            Cursor = Cursors.WaitCursor
            uomController = New ProveedorController()
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
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ClearFields()
        txtAlias.Clear()
        txtName.Clear()
        txtProveedorId.Clear()
        txtRUT.Clear()
        txtFormaPago.Clear()

        txtContacto.Clear()
        txtDireccion.Clear()
        txtEmail.Clear()
        txtTelefono.Clear()
        cboGrupoProveedor.SelectedIndex = -1
        cboMoneda.SelectedIndex = -1

        txtProveedorId.Enabled = True
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        MyBase.OnFormLoaded()
        AddHandler txtProveedorId.Enter, AddressOf TextBox_Enter
        AddHandler txtAlias.Enter, AddressOf TextBox_Enter
        AddHandler txtName.Enter, AddressOf TextBox_Enter

        AddHandler txtRUT.Enter, AddressOf TextBox_Enter
        AddHandler txtFormaPago.Enter, AddressOf TextBox_Enter
        AddHandler txtContacto.Enter, AddressOf TextBox_Enter
        AddHandler txtDireccion.Enter, AddressOf TextBox_Enter
        AddHandler txtTelefono.Enter, AddressOf TextBox_Enter
        AddHandler txtEmail.Enter, AddressOf TextBox_Enter

        FillGrupoProveedorComboBox()
        FillCurrencyComboBox()
    End Sub

    Public Overrides Function GetCurrentTable() As IDBTable
        Dim dbTable As New ProveedorModel With {
            .Id = 0,
            .IdProveedor = txtProveedorId.Text,
            .Nombre = txtName.Text,
            .AliasName = txtAlias.Text,
            .RUT = txtRUT.Text,
            .FormaPago = txtFormaPago.Text,
            .Contacto = txtContacto.Text,
            .Direccion = txtDireccion.Text,
            .Telefono = txtTelefono.Text,
            .Email = txtEmail.Text,
            .Grupo = cboGrupoProveedor.SelectedValue,
            .Moneda = cboMoneda.SelectedValue
        }

        Return dbTable
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)
        Dim proveedorModel As ProveedorModel

        If e.RowIndex >= 0 Then

            txtProveedorId.Text = dtGridView.Item(0, e.RowIndex).Value

            proveedorModel = GetProveedorPorId(txtProveedorId.Text)

            If proveedorModel IsNot Nothing And Not String.IsNullOrEmpty(proveedorModel.IdProveedor) Then

                txtAlias.Text = proveedorModel.AliasName
                txtName.Text = proveedorModel.Nombre
                txtProveedorId.Text = proveedorModel.IdProveedor
                txtRUT.Text = proveedorModel.RUT
                txtFormaPago.Text = proveedorModel.FormaPago

                txtContacto.Text = proveedorModel.Contacto
                txtDireccion.Text = proveedorModel.Direccion
                txtEmail.Text = proveedorModel.Email
                txtTelefono.Text = proveedorModel.Telefono

                If String.IsNullOrEmpty(proveedorModel.Grupo) Then
                    cboGrupoProveedor.SelectedValue = -1
                ElseIf ComboBoxHasValue(cboGrupoProveedor, proveedorModel.Grupo) Then
                    cboGrupoProveedor.SelectedValue = proveedorModel.Grupo
                Else
                    FillGrupoProveedorComboBox()
                    If ComboBoxHasValue(cboGrupoProveedor, proveedorModel.Grupo) Then
                        cboGrupoProveedor.SelectedValue = proveedorModel.Grupo
                    Else
                        Me.HandleException(String.Format("No se encontro el Grupo de proveedor {0} en la base de datos", proveedorModel.Grupo))
                    End If
                End If

                If String.IsNullOrEmpty(proveedorModel.Moneda) Then
                    cboMoneda.SelectedValue = -1
                ElseIf ComboBoxHasValue(cboMoneda, proveedorModel.Moneda) Then
                    cboMoneda.SelectedValue = proveedorModel.Moneda
                Else
                    FillCurrencyComboBox()
                    If ComboBoxHasValue(cboMoneda, proveedorModel.Moneda) Then
                        cboMoneda.SelectedValue = proveedorModel.Moneda
                    Else
                        Me.HandleException(String.Format("No se encontro la moneda {0} en la base de datos", proveedorModel.Moneda))
                    End If
                End If

                isNewRecord = False
                txtProveedorId.Enabled = False
            Else
                isNewRecord = True
                txtProveedorId.Enabled = True
                ClearFields()
            End If

        End If
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim uomController As ProveedorController
        Dim records As List(Of ProveedorModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Proveedor", .HeaderText = "Proveedor"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Alias", .HeaderText = "Alias"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "RUT", .HeaderText = "RUT"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Grupo", .HeaderText = "Grupo"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Moneda", .HeaderText = "Moneda"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FormaPago", .HeaderText = "Forma pago"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Contacto", .HeaderText = "Contacto"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Dirección", .HeaderText = "Direccióm"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Telefono", .HeaderText = "Telefono"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Email", .HeaderText = "E-mail"})
            End If

            uomController = New ProveedorController()
            records = uomController.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As ProveedorModel In records
                dtGridView.Rows().Add(model.IdProveedor, model.Nombre, model.AliasName,
                                        model.RUT, model.Grupo, model.Moneda,
                                        model.FormaPago, model.Contacto, model.Direccion,
                                        model.Telefono, model.Email)
            Next

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
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function AskToDelete() As Boolean
        Return ConfirmDeleteRecord(GetRecordIdentification())
    End Function

    Protected Sub FillCurrencyComboBox()
        Dim controller As MonedaController
        Dim dbTable As List(Of TablaBaseModel)
        Dim dbSelect As DBSelect

        Try
            Cursor = Cursors.WaitCursor
            cboMoneda.DataSource = Nothing

            controller = New MonedaController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.SelectFields.Add(New DBSelectionField("CodigoMoneda", "Id"))

            dbTable = controller.GetListWithFilters(Of TablaBaseModel)(dbSelect)

            'cboMoneda.Items.AddRange(dbTable.Select(Of String)(Function(model) model.CodigoMoneda))
            cboMoneda.DataSource = dbTable
            cboMoneda.DisplayMember = "Id"
            cboMoneda.ValueMember = "Id"
            cboMoneda.SelectedIndex = -1

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Protected Sub FillGrupoProveedorComboBox()
        Dim controller As GrupoProveedorController
        Dim dbTable As List(Of TablaBaseModel)
        Dim dbSelect As DBSelect

        Try
            Cursor = Cursors.WaitCursor
            cboGrupoProveedor.DataSource = Nothing

            controller = New GrupoProveedorController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.SelectFields.Add(New DBSelectionField("Grupo", "Id"))

            dbTable = controller.GetListWithFilters(Of TablaBaseModel)(dbSelect)

            cboGrupoProveedor.DataSource = dbTable
            cboGrupoProveedor.DisplayMember = "Id"
            cboGrupoProveedor.ValueMember = "Id"
            cboGrupoProveedor.SelectedIndex = -1

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Regresa el proveedor con el id proporcionado
    ''' </summary>
    ''' <param name="proveedorId"></param>
    ''' <returns></returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function GetProveedorPorId(proveedorId As String) As ProveedorModel
        Dim controller As ProveedorController
        Dim records As List(Of ProveedorModel)
        Dim ret As ProveedorModel = Nothing
        Dim dbSelect As DBSelect

        Try
            Cursor = Cursors.WaitCursor

            controller = New ProveedorController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("IdProveedor", DBFilterType.Equal, proveedorId))

            records = controller.GetListWithFilters(Of ProveedorModel)(dbSelect)

            If records.Count < 0 Then
                Throw New Exception(String.Format("No se encontro el registro {0} en la base de datos", proveedorId))
            End If
            ret = records.FirstOrDefault()

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    Private Function ComboBoxHasValue(ByVal cboOrigin As ComboBox, id As String) As Boolean
        'Dim items As IEnumerator(Of TablaBaseModel)
        Dim modelBase As TablaBaseModel

        If cboOrigin.Items.Count > 0 Then

            For Each item As Object In cboOrigin.Items
                modelBase = CType(item, TablaBaseModel)

                If modelBase IsNot Nothing And modelBase.Id = id Then
                    Return True
                End If
            Next

            'items = CType(cboOrigin.Items.GetEnumerator(), IEnumerator(Of TablaBaseModel))

            'While items.MoveNext()
            '    modelBase = CType(items.Current, TablaBaseModel)

            '    If modelBase IsNot Nothing And modelBase.Id = id Then
            '        Return True
            '    End If
            'End While

            'Return items.Any(Function(item) item.Id = id)
        End If

        Return False
    End Function

#End Region

#Region "Events"

    Private Sub FrmProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F5 Then
            FillCurrencyComboBox()
            FillGrupoProveedorComboBox()
        End If
    End Sub
#End Region
End Class