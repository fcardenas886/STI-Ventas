
Imports STIVentas.Model
Imports STIVentas.Controller
''' <summary>
''' Edición y creación de Ajustes de inventario
''' </summary>
''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmAjusteInventario

#Region "Property"
    Public Property RecordId As Long
    Public Property Numero As String
    Private IsNewRecord As Boolean
    Private AjusteDetalleRecordId As Long
    Private ItemRecordId As Long
    Private NumeroLinea As Integer
    Protected AjusteInventarioActual As AjusteInventarioModel
    Protected LineaAjusteInventarioActual As AjusteInventarioDetallesModel
    Protected CargandoDeExistente As Boolean

#End Region

#Region "class Construct"
    Public Sub New(recId As Long)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        RecordId = recId
        Numero = String.Empty
        IsNewRecord = True
        CargandoDeExistente = RecordId > 0
    End Sub

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        RecordId = 0
        Numero = String.Empty
    End Sub

#End Region

#Region "class methods"

    ''' <summary>
    ''' Limpia los campos
    ''' </summary>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Sub ClearFields()
        txtNumeroAjuste.Clear()
        txtIdAjuste.Clear()
        txtDescripcionAjuste.Clear()

        txtNumeroAjuste.ReadOnly = False

    End Sub

    Protected Sub LoadComboBoxData()
        Try

            Cursor = Cursors.WaitCursor

            FillUnidadMedidaComboBox(Me, cboUnidad)
        Finally
            Cursor = Cursors.Default

        End Try
    End Sub

    Public Function GetCurrentInventAdjustment() As AjusteInventarioModel
        Dim dbTable As AjusteInventarioModel

        If AjusteInventarioActual IsNot Nothing Then
            dbTable = AjusteInventarioActual

            dbTable.Descripcion = txtDescripcionAjuste.Text
            dbTable.Numero = txtNumeroAjuste.Text
        Else
            dbTable = New AjusteInventarioModel With {
                .Numero = txtNumeroAjuste.Text,
                .Descripcion = txtDescripcionAjuste.Text,
                .CreadoPor = FrmMainMDI.ID_USUARIO
            }
            If Not String.IsNullOrEmpty(txtIdAjuste.Text) Then
                dbTable.Id = CType(txtIdAjuste.Text, Integer)
            End If

        End If

        Return dbTable
    End Function

    Protected Sub GetRecordsAndPopulateFields()
        Dim controller As AjusteInventarioController
        Dim records As List(Of AjusteInventarioModel)
        Dim ajusteInventario As AjusteInventarioModel
        Dim dbSelect As DBSelect
        Dim strDetails As String

        Try
            Cursor = Cursors.WaitCursor

            controller = New AjusteInventarioController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("Id", DBFilterType.Equal, txtIdAjuste.Text))

            records = controller.GetListWithFilters(Of AjusteInventarioModel)(dbSelect)

            If records.Count < 1 Then
                strDetails = String.Format("No se encontro el ajuste de inventario con el identificador interno {0}.", txtIdAjuste.Text)

                If Not String.IsNullOrEmpty(controller.LastError) Then
                    strDetails &= Environment.NewLine & "Detalles del error: " & Environment.NewLine & controller.LastError
                End If

                HandleException(strDetails)
                Return
            ElseIf records.Count > 1 Then
                HandleException(String.Format("Se encontraron {1} ajustes de inventario con el identificador interno {0}", txtIdAjuste.Text, records.Count))
            End If

            ajusteInventario = records.FirstOrDefault()

            SetValuesFromPurchaseOrder(ajusteInventario)
            AjusteInventarioActual = ajusteInventario

            GetRecordsAndPopulateLineFields()

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Protected Sub SetValuesFromPurchaseOrder(ajusteInventario As AjusteInventarioModel)
        txtIdAjuste.Text = ajusteInventario.Id.ToString()
        txtNumeroAjuste.Text = ajusteInventario.Numero
        txtDescripcionAjuste.Text = ajusteInventario.Descripcion

    End Sub

    Private Function ComboBoxHasValue(ByVal cboOrigin As ComboBox, id As String) As Boolean

        Dim modelBase As TablaBaseModel

        If cboOrigin.Items.Count > 0 Then
            Try
                For Each item As Object In cboOrigin.Items
                    modelBase = CType(item, TablaBaseModel)

                    If modelBase IsNot Nothing And modelBase.Id = id Then
                        Return True
                    End If
                Next
            Catch
                Return False
            End Try

        End If

        Return False
    End Function

    Protected Sub GetIdFromNum(numInvent As String)
        Dim controller As AjusteInventarioController
        Dim records As List(Of AjusteInventarioModel)
        Dim ret As AjusteInventarioModel
        Dim dbSelect As DBSelect

        Try
            Cursor = Cursors.WaitCursor

            controller = New AjusteInventarioController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.SelectFields.Add(New DBSelectionField("Id"))
            dbSelect.FilterFields.Add(New DBFilterFields("Numero", DBFilterType.Equal, numInvent))

            records = controller.GetListWithFilters(Of AjusteInventarioModel)(dbSelect)

            If records.Count < 1 Then
                HandleException(String.Format("No se encontro el registro {0} en la base de datos", numInvent))
            Else
                ret = records.FirstOrDefault()
                txtIdAjuste.Text = ret.Id.ToString()
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    ''' <summary>
    ''' Inserta/Actualiza la OC actual
    ''' </summary>
    ''' <returns>True si guardo</returns>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function UpsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim controller As AjusteInventarioController

        Try
            Cursor = Cursors.WaitCursor
            controller = New AjusteInventarioController()

            If IsNewRecord Then
                ret = controller.Insert(GetCurrentInventAdjustment())

                If ret And String.IsNullOrEmpty(txtIdAjuste.Text) Then
                    GetIdFromNum(txtNumeroAjuste.Text)
                End If
                dgvLines.Rows.Clear()
                ClearLineFields()
            Else
                ret = controller.Update(GetCurrentInventAdjustment())
            End If
            If Not ret Then
                HandleException(controller.LastError)
            Else
                txtNumeroAjuste.ReadOnly = True
                IsNewRecord = False
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    Protected Function DeleteRecord() As Boolean
        Dim deleted As Boolean = False
        Dim controller As AjusteInventarioController

        Try
            Cursor = Cursors.WaitCursor
            controller = New AjusteInventarioController()
            deleted = controller.Delete(GetCurrentInventAdjustment())

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

    Protected Sub OnNewRecordSelected()
        ClearFields()
        IsNewRecord = True
        txtNumeroAjuste.ReadOnly = False
        dgvLines.Rows.Clear()
        AjusteDetalleRecordId = 0
        ItemRecordId = 0
        Numero = String.Empty
        NumeroLinea = 1

        ClearLineFields()
        EnableFieldsBasedOnEstatus()
    End Sub

    Protected Function DeleteInternal() As Boolean

        Dim ret As Boolean = False

        If IsNewRecord Then
            ClearFields()
            ClearLineFields()
        ElseIf ValidateDeletePurchaseOrder() Then
            ret = DeleteRecord()

            If ret Then
                OnNewRecordSelected()
            End If

        End If
        EnableFieldsBasedOnEstatus()
        Return ret
    End Function

    ''' <summary>
    ''' Valida si puede eliminar el registro
    ''' </summary>
    ''' <returns>True si puede borrar el registro</returns>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function ValidateDeletePurchaseOrder() As Boolean
        Dim ret As Boolean = True
        Dim ajusteInventario As AjusteInventarioModel = GetCurrentInventAdjustment()
        Dim strMsg As String = String.Empty

        If ajusteInventario.Registrado Then
            strMsg = "Solo se pueden eliminar ajustes de inventario no registrados"
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        If ret Then
            ret = MessageBox.Show($"Desea eliminar el ajuste de inventario {txtNumeroAjuste.Text}?", GetPOSName(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation) = DialogResult.Yes

        End If

        Return ret
    End Function

    Private Sub BuscaProductoRelacionado(Optional fromButton As Boolean = False)

        If fromButton Then
            OpenSearchFormAndFillItem()
        Else
            CheckExistItemId()
        End If

    End Sub

    Protected Sub OpenSearchFormAndFillItem()
        Dim iSelected As ISelectedRecord
        Dim frmBusqueda As FrmBuscaProducto

        Try
            frmBusqueda = New FrmBuscaProducto()
            frmBusqueda.ShowDialog(Me)

            iSelected = CType(frmBusqueda, ISelectedRecord)
            InitFieldsFromProduct(CType(iSelected.SelectedRecord(), ProductoModel))

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Sub InitFieldsFromProduct(product As ProductoModel)


        Try
            If product.Id <> 0 Then
                txtCantidad.Value = 1
            Else
                txtCantidad.Value = 0
            End If

            txtItemId.Text = product.IdArticulo
            txtItemName.Text = product.Nombre

            If product.IdUnidad Is Nothing Then
                cboUnidad.SelectedIndex = -1
            Else
                cboUnidad.SelectedValue = product.IdUnidad
            End If

            If LineaAjusteInventarioActual Is Nothing Then
                LineaAjusteInventarioActual = New AjusteInventarioDetallesModel()
            End If

            LineaAjusteInventarioActual.IdArticulo = product.IdArticulo
            LineaAjusteInventarioActual.IdProducto = CInt(product.Id)
            LineaAjusteInventarioActual.Descripcion = product.Nombre
            LineaAjusteInventarioActual.Unidad = product.IdUnidad


        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Function ValidateWriteInventAdjustment() As Boolean
        Dim ret As Boolean = True
        Dim model As AjusteInventarioModel
        Dim strErrorMsg As String = String.Empty

        model = GetCurrentInventAdjustment()

        If model Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar el ajuste de inventario actual")
        Else
            If String.IsNullOrEmpty(model.Numero) Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado el ajuste de inventario.")
            End If

            If model.Registrado Then
                strErrorMsg = AppendLastError(strErrorMsg, "El ajuste de inventario ya se ha registrado.")
            End If

        End If

        If Not String.IsNullOrEmpty(strErrorMsg) Then
            ret = CheckFailed(strErrorMsg)
        End If


        Return ret
    End Function

    Protected Function ValidateWriteInventAdjustmentLine() As Boolean
        Dim ret As Boolean = True
        Dim model As AjusteInventarioModel
        Dim modelLine As AjusteInventarioDetallesModel
        Dim strErrorMsg As String = String.Empty

        model = GetCurrentInventAdjustment()
        modelLine = GetCurrentInventTrans()

        If model Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar el ajuste de inventario actual.")
        Else
            If (String.IsNullOrEmpty(model.Numero) And Not txtNumeroAjuste.ReadOnly) OrElse model.Id < 1 Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado el ajuste de inventario.")
            End If
            If model.Registrado Then
                strErrorMsg = AppendLastError(strErrorMsg, "El ajuste de inventario ya se ha registrado.")
            End If

        End If
        If modelLine Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar la línea de orden de compra actual.")
        Else
            If modelLine.IdProducto < 1 Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado el producto para la nueva línea.")
            End If
            If modelLine.Cantidad = 0 Then
                strErrorMsg = AppendLastError(strErrorMsg, "Debe indicar una cantidad para continuar.")
            End If
        End If

        If Not String.IsNullOrEmpty(strErrorMsg) Then
            ret = CheckFailed(strErrorMsg)
        End If


        Return ret
    End Function

    Public Function GetCurrentInventTrans() As AjusteInventarioDetallesModel

        ItemRecordId = 1
        Dim dbTable As AjusteInventarioDetallesModel

        If LineaAjusteInventarioActual IsNot Nothing Then
            dbTable = LineaAjusteInventarioActual

            dbTable.Descripcion = txtItemName.Text
            dbTable.Cantidad = txtCantidad.Value
            dbTable.NumeroLinea = NumeroLinea
            dbTable.IdArticulo = txtItemId.Text

        Else
            dbTable = New AjusteInventarioDetallesModel With {
            .IdProducto = 0,
            .Id = CInt(ItemRecordId),
            .Descripcion = txtItemName.Text,
            .Cantidad = txtCantidad.Value,
            .NumeroLinea = NumeroLinea
        }
        End If

        '.Unidad = CStr(IIf(cboUnidad.SelectedValue Is Nothing, String.Empty, cboUnidad.SelectedValue.ToString)),

        If cboUnidad.SelectedValue IsNot Nothing Then
            dbTable.Unidad = cboUnidad.SelectedValue.ToString
        End If

        dbTable.IdAjuste = CInt(GetCurrentInventAdjustment().Id)

        Return dbTable
    End Function

    Protected Sub GetRecordsAndPopulateLineFields()
        Dim controller As AjusteInventarioDetalleController
        Dim records As List(Of AjusteInventarioDetallesModel)
        Dim dbSelect As DBSelect
        Dim isWaitCursor As Boolean
        Dim minLineNum As Integer

        Try
            isWaitCursor = True
            If Cursor IsNot Cursors.WaitCursor Then
                isWaitCursor = False
                Cursor = Cursors.WaitCursor
            End If

            controller = New AjusteInventarioDetalleController()
            dbSelect = New DBSelect(controller.TableName())
            dbSelect.FilterFields.Add(New DBFilterFields("IdAjuste", DBFilterType.Equal, txtIdAjuste.Text))

            records = controller.GetListWithFilters(Of AjusteInventarioDetallesModel)(dbSelect)

            dgvLines.Rows.Clear()
            minLineNum = -1

            For Each model As AjusteInventarioDetallesModel In records
                dgvLines.Rows().Add(model.Id, model.NumeroLinea, model.IdArticulo, model.Descripcion,
                                        model.Cantidad, model.Unidad, model.IdProducto)

                If CargandoDeExistente Then
                    If model.NumeroLinea > NumeroLinea Then
                        NumeroLinea = model.NumeroLinea
                    End If
                End If
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            Else
                If CargandoDeExistente Then
                    NumeroLinea += 1
                End If
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            If Not isWaitCursor Then
                Cursor = Cursors.Default
            End If
        End Try

    End Sub

    Protected Sub SetValuesFromGridLine()

        If dgvLines.CurrentRow IsNot Nothing Then
            LineaAjusteInventarioActual = New AjusteInventarioDetallesModel()

            AjusteDetalleRecordId = CType(dgvLines.CurrentRow.Cells(0).Value, Long)
            'NumeroLinea = CType(dgvLines.CurrentRow.Cells(1).Value, Integer)
            txtItemId.Text = CStr(dgvLines.CurrentRow.Cells(2).Value)
            txtItemName.Text = CStr(dgvLines.CurrentRow.Cells(3).Value)
            txtCantidad.Text = CStr(dgvLines.CurrentRow.Cells(4).Value)

            LineaAjusteInventarioActual.Id = AjusteDetalleRecordId
            LineaAjusteInventarioActual.NumeroLinea = CType(dgvLines.CurrentRow.Cells(1).Value, Integer)
            LineaAjusteInventarioActual.IdArticulo = CStr(dgvLines.CurrentRow.Cells(2).Value)
            LineaAjusteInventarioActual.Descripcion = CStr(dgvLines.CurrentRow.Cells(3).Value)
            LineaAjusteInventarioActual.Cantidad = CType(dgvLines.CurrentRow.Cells(4).Value, Decimal)
            LineaAjusteInventarioActual.Unidad = CType(dgvLines.CurrentRow.Cells(5).Value, String)
            LineaAjusteInventarioActual.IdProducto = CInt(dgvLines.CurrentRow.Cells(6).Value)

            SetUnidadValue(LineaAjusteInventarioActual.Unidad)

        End If

    End Sub

    Public Sub SetUnidadValue(value As String)

        If String.IsNullOrEmpty(value) Then
            cboUnidad.SelectedValue = -1
        ElseIf ComboBoxHasValue(cboUnidad, value) Then
            cboUnidad.SelectedValue = value
        Else
            FillUnidadMedidaComboBox(Me, cboUnidad)
            If ComboBoxHasValue(cboUnidad, value) Then
                cboUnidad.SelectedValue = value
            Else
                HandleException(String.Format("No se encontro la unidad {0} en la base de datos", value))
            End If
        End If
    End Sub

    ''' <summary>
    ''' Inserta/Actualiza la línea de OC actual
    ''' </summary>
    ''' <returns>True si guardo</returns>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Function UpsertRecordInventTrans() As Boolean
        Dim ret As Boolean = False
        Dim controller As AjusteInventarioDetalleController
        Dim lineaCompra As AjusteInventarioDetallesModel

        Try
            Cursor = Cursors.WaitCursor
            controller = New AjusteInventarioDetalleController()
            lineaCompra = GetCurrentInventTrans()

            If AjusteDetalleRecordId = 0 Then
                lineaCompra.NumeroLinea = NumeroLinea

                ret = controller.Insert(lineaCompra)

                NumeroLinea += CInt(IIf(ret, 1, 0))
            Else
                ret = controller.Update(lineaCompra)
            End If
            If Not ret Then
                HandleException(controller.LastError)
            Else
                GetRecordsAndPopulateLineFields()
                ClearLineFields()
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Limpia los campos para líneas
    ''' </summary>
    ''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Sub ClearLineFields()

        txtItemId.Clear()
        txtItemName.Clear()

        txtCantidad.Value = 0

        cboUnidad.SelectedIndex = -1
        LineaAjusteInventarioActual = Nothing
        AjusteDetalleRecordId = 0

    End Sub

    Protected Function DeleteInventTransRecord() As Boolean
        Dim deleted As Boolean = False
        Dim controller As AjusteInventarioDetalleController
        Dim model As AjusteInventarioDetallesModel

        Try
            model = GetCurrentInventTrans()

            If model.Id = 0 Then
                ClearLineFields()
                Return True
            End If

            Cursor = Cursors.WaitCursor
            controller = New AjusteInventarioDetalleController()
            deleted = controller.Delete(model)

            If Not deleted Then
                HandleException(controller.LastError)
            Else
                ClearLineFields()
                GetRecordsAndPopulateLineFields()
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return deleted

    End Function

    Protected Function ValidatePostInvent(ajusteInventario As AjusteInventarioModel) As Boolean
        Dim ret As Boolean = True
        Dim strMsg As String = String.Empty

        If ajusteInventario Is Nothing Or ajusteInventario.Id = 0 Then
            strMsg = "No se puede recuperar el ajuste de inventario." & Environment.NewLine
        Else
            If ajusteInventario.Registrado Then
                strMsg = "El ajuste de inventario tiene ya se ha registrado anteriormente." & Environment.NewLine
            End If
            If dgvLines.Rows.Count < 1 Then
                strMsg = "Se debe especificar al menos una línea para poder registrar el ajuste de inventario." & Environment.NewLine
            End If
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

    Private Sub EnableFieldsBasedOnEstatus()
        Dim allowEdit As Boolean

        Try
            allowEdit = Not GetCurrentInventAdjustment().Registrado

            txtNumeroAjuste.ReadOnly = Not allowEdit
            txtDescripcionAjuste.ReadOnly = Not allowEdit

            cboUnidad.Enabled = allowEdit
            txtItemId.ReadOnly = Not allowEdit
            txtItemName.ReadOnly = Not allowEdit
            txtCantidad.ReadOnly = Not allowEdit

            btnAddLine.Enabled = allowEdit
            btnGuardarHeader.Enabled = allowEdit
            btnEditLine.Enabled = allowEdit
            btnDeleteLine.Enabled = allowEdit

            btnSeleccionarArticulo.Enabled = allowEdit
            EliminarToolStripMenuItem.Enabled = allowEdit

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Sub CheckExistItemId()
        Dim iSelected As ISelectedRecord
        Dim frmBusqueda As FrmBuscaProducto
        Dim controller As ProductosController
        Dim records As List(Of ProductoModel)
        Dim dbSelect As DBSelect
        Dim model As ProductoModel

        Try
            If String.IsNullOrEmpty(txtItemId.Text) Then
                OpenSearchFormAndFillItem()
            Else
                Cursor = Cursors.WaitCursor

                controller = New ProductosController()
                dbSelect = New DBSelect(controller.TableName())

                dbSelect.FilterFields.Add(New DBFilterFields("IdArticulo", DBFilterType.Contains, String.Format("%{0}%", txtItemId.Text)))
                records = controller.GetListWithFilters(Of ProductoModel)(dbSelect)

                If records.Count < 1 Then
                    OpenSearchFormAndFillItem()
                ElseIf records.Count = 1 Then
                    model = records.FirstOrDefault()
                    InitFieldsFromProduct(model)
                Else
                    frmBusqueda = New FrmBuscaProducto()
                    frmBusqueda.InitFromExistingValues(txtItemId.Text, records)
                    frmBusqueda.ShowDialog(Me)

                    iSelected = CType(frmBusqueda, ISelectedRecord)
                    InitFieldsFromProduct(CType(iSelected.SelectedRecord(), ProductoModel))

                End If

            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub OnFormLoaded()

        CargandoDeExistente = False
        LoadComboBoxData()

        If RecordId > 0 Then
            CargandoDeExistente = True

            txtIdAjuste.Text = RecordId.ToString()
            GetRecordsAndPopulateFields()
            ClearLineFields()
            EnableFieldsBasedOnEstatus()

            IsNewRecord = False
            txtNumeroAjuste.ReadOnly = True
            CargandoDeExistente = False

            If NumeroLinea < 1 Then
                NumeroLinea = 1
            End If
        Else
            OnNewRecordSelected()
        End If

        AddHandler txtNumeroAjuste.Enter, AddressOf TextBox_Enter
        AddHandler txtDescripcionAjuste.Enter, AddressOf TextBox_Enter

        '' Campos de líneas
        AddHandler txtItemId.Enter, AddressOf TextBox_Enter
        AddHandler txtItemName.Enter, AddressOf TextBox_Enter

        txtCantidad.Maximum = Decimal.MaxValue
        'txtCantidad.Minimum = 10000
        'txtCantidad.Value = 0

    End Sub

    Private Sub RegistraMovimiento()

        Dim estaRegistrado As Boolean

        If ValidaRegistroAjuste() Then
            estaRegistrado = RegistraAjusteInventario()

            If estaRegistrado Then
                OnNewRecordSelected()

                Info("Operación completada de manera correcta")
            End If
        End If
    End Sub

    Protected Function ValidaRegistroAjuste() As Boolean

        Dim ret As Boolean = True
        Dim model As AjusteInventarioModel
        Dim strErrorMsg As String = String.Empty

        model = GetCurrentInventAdjustment()

        If model Is Nothing Then
            strErrorMsg = AppendLastError(strErrorMsg, "No se pudo recuperar el ajuste de inventario actual")
        Else
            If String.IsNullOrEmpty(model.Numero) OrElse model.Id < 1 Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se ha especificado el ajuste de inventario.")
            End If

            If model.Registrado Then
                strErrorMsg = AppendLastError(strErrorMsg, "El ajuste de inventario ya se ha registrado.")
            End If

        End If

        If String.IsNullOrEmpty(strErrorMsg) Then

            If dgvLines.Rows().Count < 1 Then
                strErrorMsg = AppendLastError(strErrorMsg, "No se han especificado líneas para registrar.")
            End If

        End If

        If Not String.IsNullOrEmpty(strErrorMsg) Then
            ret = CheckFailed(strErrorMsg)
        End If


        Return ret

    End Function

    Protected Function GetAjusteInventarioAsView() As AjusteInventarioRegistroModel

        Dim ret As New AjusteInventarioRegistroModel

        ret.InitFromAjusteInventario(GetCurrentInventAdjustment())

        ret.RegistradoPor = FrmMainMDI.ID_USUARIO

        Return ret

    End Function

    Protected Function RegistraAjusteInventario() As Boolean

        Dim ret As Boolean = False
        Dim controller As AjusteInventarioController

        Try
            controller = New AjusteInventarioController()
            ret = controller.RegistrarAjusteInventario(GetAjusteInventarioAsView())

            If Not ret Then
                If Not String.IsNullOrEmpty(controller.LastError) Then
                    HandleException(controller.LastError)
                Else
                    HandleException("Error interno al intentar registrar el ajuste actual.")
                End If

            End If

        Catch ex As Exception
            HandleException(ex)
        End Try

        Return ret
    End Function

#End Region

#Region "Events"

    Private Sub FrmAjusteInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OnFormLoaded()
    End Sub

    Private Sub btnDeleteLine_Click(sender As Object, e As EventArgs) Handles btnDeleteLine.Click
        DeleteInventTransRecord()
    End Sub

    Private Sub btnAddLine_Click(sender As Object, e As EventArgs) Handles btnAddLine.Click
        If ValidateWriteInventAdjustmentLine() Then
            UpsertRecordInventTrans()
        End If
    End Sub

    Private Sub BtnGuardarOC_Click(sender As Object, e As EventArgs) Handles btnGuardarHeader.Click
        If ValidateWriteInventAdjustment() Then
            UpsertRecord()
        End If
    End Sub

    Private Sub NuevoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem1.Click
        OnNewRecordSelected()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        DeleteInternal()
    End Sub

    Private Sub dgvLines_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLines.CellContentDoubleClick
        SetValuesFromGridLine()
    End Sub

    Private Sub btnSeleccionarArticulo_Click(sender As Object, e As EventArgs) Handles btnSeleccionarArticulo.Click
        BuscaProductoRelacionado(True)
    End Sub

    Private Sub txtItemId_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItemId.KeyUp
        If e.KeyData = Keys.Enter Then
            BuscaProductoRelacionado()
        End If
    End Sub

    Private Sub RegistrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarToolStripMenuItem.Click
        RegistraMovimiento()
    End Sub

#End Region
End Class