Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Form para buscar productos y regresarlo al caller
''' </summary>
''' <remarks>07.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmBuscaProducto
    Implements ISelectedRecord

#Region "Class methods"
    Public Function SelectedRecord() As IDBTable Implements ISelectedRecord.SelectedRecord
        Dim ret As IDBTable = Nothing

        Try

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
        Dim controller As ComprasController
        Dim records As List(Of CompraHeaderModel)
        Dim dbSelect As DBSelect

        Try
            Cursor = Cursors.WaitCursor

            controller = New ComprasController()
            dbSelect = New DBSelect(controller.TableName())

            If Not String.IsNullOrEmpty(txtItemId.Text) Then
                dbSelect.FilterFields.Add(New DBFilterFields("IdProveedor", DBFilterType.Contains, String.Format("%{0}%", txtItemId.Text)))
            End If
            If Not String.IsNullOrEmpty(txtItemName.Text) Then
                dbSelect.FilterFields.Add(New DBFilterFields("Nombre", DBFilterType.Contains, String.Format("%{0}%", txtItemName.Text)))
            End If

            records = controller.GetListWithFilters(Of CompraHeaderModel)(dbSelect)
            dgvListPage.Rows.Clear()

            For Each model As CompraHeaderModel In records
                dgvListPage.Rows().Add(model.Id, model.NumeroCompra, model.IdProveedor,
                                        model.Nombre, model.Moneda, model.Estado,
                                        model.FechaEntrega, model.OrdenProveedor, model.FormaPago)
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
#End Region
End Class