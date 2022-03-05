Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Form para buscar productos y regresarlo al caller
''' </summary>
''' <remarks>07.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmBuscaProducto
    Implements ISelectedRecord

    Private IsLoadad As Boolean

#Region "Class methods"
    Public Function SelectedRecord() As IDBTable Implements ISelectedRecord.SelectedRecord
        Dim ret As ProductoModel = Nothing

        Try
            ret = New ProductoModel()

            If dgvListPage.CurrentRow IsNot Nothing Then
                ret = CType(dgvListPage.CurrentRow.DataBoundItem, ProductoModel)

            End If

        Catch ex As Exception
            HandleError(ex)
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' Busca el producto indicado en los parametros
    ''' </summary>
    ''' <remarks>07.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Private Sub FindProducts()
        Dim controller As ProductosController
        Dim records As List(Of ProductoModel)
        Dim dbSelect As DBSelect

        Try
            Cursor = Cursors.WaitCursor

            controller = New ProductosController()
            dbSelect = New DBSelect(controller.TableName())

            If Not String.IsNullOrEmpty(txtItemId.Text) Then
                dbSelect.FilterFields.Add(New DBFilterFields("IdArticulo", DBFilterType.Contains, String.Format("%{0}%", txtItemId.Text)))
            End If
            If Not String.IsNullOrEmpty(txtItemName.Text) Then
                dbSelect.FilterFields.Add(New DBFilterFields("Nombre", DBFilterType.Contains, String.Format("%{0}%", txtItemName.Text)))
            End If

            If Not IsLoadad Then
                IdArticulo.DataPropertyName = "IdArticulo"
                Nombre.DataPropertyName = "Nombre"
                IdProducto.DataPropertyName = "Id"
                Descripcion.DataPropertyName = "Descripcion"
                Marca.DataPropertyName = "Marca"
                Unidad.DataPropertyName = "IdUnidad"
                PrecioCompra.DataPropertyName = "PrecioCompra"
                PrecioVenta.DataPropertyName = "PrecioVenta"
                IdCategoria.DataPropertyName = "IdCategoria"
                UnidadPorCaja.DataPropertyName = "UnidadPorCaja"

                IsLoadad = True

            End If

            records = controller.GetListWithFilters(Of ProductoModel)(dbSelect)

            dgvListPage.DataSource = records

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub InitFromExistingValues(itemId As String, records As List(Of ProductoModel))

        Try

            txtItemId.Text = itemId

            If Not IsLoadad Then
                IdArticulo.DataPropertyName = "IdArticulo"
                Nombre.DataPropertyName = "Nombre"
                IdProducto.DataPropertyName = "Id"
                Descripcion.DataPropertyName = "Descripcion"
                Marca.DataPropertyName = "Marca"
                Unidad.DataPropertyName = "IdUnidad"
                PrecioCompra.DataPropertyName = "PrecioCompra"
                PrecioVenta.DataPropertyName = "PrecioVenta"
                IdCategoria.DataPropertyName = "IdCategoria"
                UnidadPorCaja.DataPropertyName = "UnidadPorCaja"

                IsLoadad = True
            Else

            End If

            dgvListPage.DataSource = records

        Catch ex As Exception
            HandleException(ex)
        End Try

    End Sub

#End Region

#Region "Events"
    Private Sub txtItemName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyUp
        If e.KeyData = Keys.Enter Then
            FindProducts()
        End If
    End Sub

    Private Sub txtItemId_KeyUp(sender As Object, e As KeyEventArgs) Handles txtItemId.KeyUp
        If e.KeyData = Keys.Enter Then
            FindProducts()
        End If
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        FindProducts()
    End Sub

    Private Sub FrmBuscaProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView(dgvListPage)
    End Sub

    Private Sub dgvListPage_KeyUp(sender As Object, e As KeyEventArgs) Handles dgvListPage.KeyUp
        If e.KeyData = Keys.Enter And dgvListPage.CurrentRow IsNot Nothing Then
            Close()
        End If
    End Sub

    Private Sub btnSeleccionarRegistro_Click(sender As Object, e As EventArgs) Handles btnSeleccionarRegistro.Click
        Close()
    End Sub

    Private Sub dgvListPage_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListPage.CellContentDoubleClick
        If e.RowIndex >= 0 Then
            Close()
        End If
    End Sub
#End Region
End Class