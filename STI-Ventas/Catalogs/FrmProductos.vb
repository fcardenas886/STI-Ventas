Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Se agrega form para productos
''' </summary>
''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el form y clase</remarks>
Public Class FrmProductos

#Region "Class Methods"
    ''' <summary>
    ''' Sobre escribe el metodo para productos
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim controller As ProductosController

        Try
            Cursor = Cursors.WaitCursor
            controller = New ProductosController()
            deleted = controller.Delete(GetCurrentTable())

            If Not deleted Then
                HandleException(controller.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return deleted

    End Function

    ''' <summary>
    ''' Sobre escribe el metodo para productos
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        Return txtArticuloId.Text
    End Function

    ''' <summary>
    ''' Sobre escribe el metodo para productos
    ''' </summary>
    ''' <returns>True si inserto</returns>
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim controller As ProductosController

        Try
            If Not ValidateWrite() Then
                Return ret
            End If
            Cursor = Cursors.WaitCursor
            controller = New ProductosController()
            ret = controller.Insert(GetCurrentTable())

            If Not ret Then
                HandleException(controller.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Sobre escribe el metodo para productos
    ''' </summary>
    ''' <returns>True si actualizo</returns>
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function UpdateRecord() As Boolean
        Dim ret As Boolean = False
        Dim controller As ProductosController

        Try
            If Not ValidateWrite() Then
                Return ret
            End If
            Cursor = Cursors.WaitCursor
            controller = New ProductosController()
            ret = controller.Update(GetCurrentTable())

            If Not ret Then
                HandleException(controller.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Sobre escribe el metodo para productos
    ''' </summary>
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ClearFields()
        txtDescripcion.Clear()
        txtName.Clear()
        txtArticuloId.Clear()

        txtMarca.Clear()
        txtPrecioCompra.ResetText()
        txtPrecioVenta.ResetText()
        txtUnidadPorCaja.ResetText()
        cboUnidad.SelectedIndex = -1
        cboCategoria.SelectedIndex = -1

        txtArticuloId.Enabled = True
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        MyBase.OnFormLoaded()
        AddHandler txtArticuloId.Enter, AddressOf TextBox_Enter
        AddHandler txtDescripcion.Enter, AddressOf TextBox_Enter
        AddHandler txtName.Enter, AddressOf TextBox_Enter

        AddHandler txtMarca.Enter, AddressOf TextBox_Enter

        txtPrecioCompra.Maximum = Decimal.MaxValue
        txtPrecioVenta.Maximum = Decimal.MaxValue
        txtUnidadPorCaja.Maximum = Decimal.MaxValue

        FillUnidadMedidaComboBox(Me, cboUnidad)
        FillCategoriaComboBox(Me, cboCategoria)
    End Sub

    Public Overrides Function GetCurrentTable() As IDBTable
        Dim dbTable As New ProductoModel With {
            .Id = 0,
            .IdArticulo = txtArticuloId.Text,
            .Nombre = txtName.Text,
            .Descripcion = txtDescripcion.Text,
            .Marca = txtMarca.Text,
            .IdUnidad = cboUnidad.SelectedValue,
            .IdCategoria = cboCategoria.SelectedValue,
            .UnidadPorCaja = txtUnidadPorCaja.Value,
            .PrecioCompra = txtPrecioCompra.Value,
            .PrecioVenta = txtPrecioVenta.Value
        }

        Return dbTable
    End Function

    ''' <summary>
    ''' Maneja el evento clic del grig
    ''' </summary>
    ''' <param name="e">Evento que se detona</param>
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnSelectedRow(ByVal e As DataGridViewCellEventArgs)
        Dim dbModel As ProductoModel

        If e.RowIndex >= 0 Then

            txtArticuloId.Text = dtGridView.Item(0, e.RowIndex).Value.ToString()

            dbModel = GetProductoPorId(txtArticuloId.Text)

            If dbModel IsNot Nothing AndAlso Not String.IsNullOrEmpty(dbModel.IdArticulo) Then

                txtDescripcion.Text = dbModel.Descripcion
                txtName.Text = dbModel.Nombre
                txtArticuloId.Text = dbModel.IdArticulo

                txtMarca.Text = dbModel.Marca
                txtPrecioCompra.Text = CStr(dbModel.PrecioCompra)
                txtPrecioVenta.Text = CStr(dbModel.PrecioVenta)
                txtUnidadPorCaja.Text = CStr(dbModel.UnidadPorCaja)

                If String.IsNullOrEmpty(dbModel.IdUnidad) Then
                    cboUnidad.SelectedValue = -1
                ElseIf ComboBoxHasValue(cboUnidad, dbModel.IdUnidad) Then
                    cboUnidad.SelectedValue = dbModel.IdUnidad
                Else
                    FillUnidadMedidaComboBox(Me, cboUnidad)
                    If ComboBoxHasValue(cboUnidad, dbModel.IdUnidad) Then
                        cboUnidad.SelectedValue = dbModel.IdUnidad
                    Else
                        Me.HandleException(String.Format("No se encontro el Grupo de proveedor {0} en la base de datos", dbModel.IdUnidad))
                    End If
                End If

                If String.IsNullOrEmpty(dbModel.IdCategoria) Then
                    cboCategoria.SelectedValue = -1
                ElseIf ComboBoxHasValue(cboCategoria, dbModel.IdCategoria) Then
                    cboCategoria.SelectedValue = dbModel.IdCategoria
                Else
                    FillCategoriaComboBox(Me, cboCategoria)
                    If ComboBoxHasValue(cboCategoria, dbModel.IdCategoria) Then
                        cboCategoria.SelectedValue = dbModel.IdCategoria
                    Else
                        Me.HandleException(String.Format("No se encontro la Categoria {0} en la base de datos", dbModel.IdCategoria))
                    End If
                End If

                isNewRecord = False
                txtArticuloId.Enabled = False
            Else
                isNewRecord = True
                txtArticuloId.Enabled = True
                ClearFields()
            End If

        End If
    End Sub

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim controller As ProductosController
        Dim records As List(Of ProductoModel)

        Try
            Cursor = Cursors.WaitCursor

            If dtGridView.Columns().Count < 1 Then
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "IdArticulo", .HeaderText = "Id Artículo"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Descripcion", .HeaderText = "Descripción"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Unidad", .HeaderText = "Unidad medida"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Categoria", .HeaderText = "Id Categoria"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Marca", .HeaderText = "Marca"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "UnidadPorCaja", .HeaderText = "Unidad por Caja"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "PrecioVenta", .HeaderText = "Precio Venta"})
                dtGridView.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "PrecioCompra", .HeaderText = "Precio Compra"})
            End If

            controller = New ProductosController()
            records = controller.GetList()

            'dtGridView.DataSource = records
            dtGridView.Rows.Clear()

            For Each model As ProductoModel In records
                dtGridView.Rows().Add(model.IdArticulo, model.Nombre, model.Descripcion,
                                        model.IdUnidad, model.IdCategoria,
                                        model.Marca, model.UnidadPorCaja, model.PrecioVenta,
                                        model.PrecioCompra)
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
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
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function AskToDelete() As Boolean
        Return ConfirmDeleteRecord(GetRecordIdentification())
    End Function

    ''' <summary>
    ''' Regresa el producto con el id proporcionado
    ''' </summary>
    ''' <param name="idProducto"></param>
    ''' <returns></returns>
    ''' <remarks>09.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function GetProductoPorId(idProducto As String) As ProductoModel
        Dim controller As ProductosController
        Dim records As List(Of ProductoModel)
        Dim ret As ProductoModel = Nothing
        Dim dbSelect As DBSelect

        Try
            Cursor = Cursors.WaitCursor

            controller = New ProductosController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("IdArticulo", DBFilterType.Equal, idProducto))

            records = controller.GetListWithFilters(Of ProductoModel)(dbSelect)

            If records.Count < 0 Then
                Throw New Exception(String.Format("No se encontro el registro {0} en la base de datos", idProducto))
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

        Dim modelBase As TablaBaseModel

        If cboOrigin.Items.Count > 0 Then

            For Each item As Object In cboOrigin.Items
                modelBase = CType(item, TablaBaseModel)

                If modelBase IsNot Nothing And modelBase.Id = id Then
                    Return True
                End If
            Next
        End If

        Return False
    End Function

    Protected Function ValidateWrite() As Boolean
        Dim dbTable As ProductoModel
        Dim ret As Boolean = True
        Dim strError As String = String.Empty

        Try
            dbTable = GetCurrentTable()

            If String.IsNullOrEmpty(dbTable.IdArticulo) Then
                AppendLastError(strError, "Debe indicar el código de producto.")
            End If
            If cboUnidad.SelectedValue Is Nothing Then
                AppendLastError(strError, "Debe indicar la unidad de medida.")
            End If

            If Not String.IsNullOrEmpty(strError) Then
                ret = CheckFailed(strError)
            End If

        Catch ex As Exception
            HandleError(ex)
            ret = False
        End Try

        Return ret
    End Function


#End Region

#Region "Events"
    Private Sub txtPrecioCompra_Enter(sender As Object, e As EventArgs) Handles txtPrecioCompra.Enter
        txtPrecioCompra.Select(0, 30)
    End Sub

    Private Sub txtPrecioVenta_Enter(sender As Object, e As EventArgs) Handles txtPrecioVenta.Enter
        txtPrecioVenta.Select(0, txtPrecioCompra.Left)
    End Sub

    Private Sub txtUnidadPorCaja_Enter(sender As Object, e As EventArgs) Handles txtUnidadPorCaja.Enter
        txtUnidadPorCaja.Select(0, 30)
    End Sub
#End Region
End Class