Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Template base para lista de OC
''' </summary>
''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmComprasListPage
#Region "Class methods"

    ''' <summary>
    ''' Reestablece los filtros
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Sub ResetFilters()
        txtOrdenCompra.Clear()
        cboProveedor.SelectedIndex = -1
    End Sub

    ''' <summary>
    ''' Elimina el registro
    ''' </summary>
    ''' <returns>True si elimino</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function DeleteRecord() As Boolean
        Return False
    End Function

    ''' <summary>
    ''' Carga los registros de OC
    ''' </summary>
    ''' <returns>Devuelve el identificador para el registrro</returns>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Friend Overrides Function GetRecordIdentification() As String
        Return String.Empty
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para cargar el grid
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim controller As ComprasController
        Dim records As List(Of CompraHeaderModel)

        Try
            Cursor = Cursors.WaitCursor

            If dgvListPage.Columns().Count < 1 Then
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "NumeroCompra", .HeaderText = "Número"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Proveedor", .HeaderText = "Proveedor"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Moneda", .HeaderText = "Moneda"})
                'dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Estado", .HeaderText = "Estado"})
                Dim cboEstatusOC As New DataGridViewComboBoxColumn
                cboEstatusOC.DataSource = GetOrdenCompraStatusValues()
                cboEstatusOC.Name = "Estado"
                cboEstatusOC.HeaderText = "Estado"
                cboEstatusOC.ValueType = GetType(EstadoOrdenCompra)

                dgvListPage.Columns.Add(cboEstatusOC)
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FechaEntrega", .HeaderText = "Fecha entrega"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "OrdenProveedor", .HeaderText = "Orden proveedor"})
                dgvListPage.Columns(1).Visible = True

            End If

            controller = New ComprasController()
            records = controller.GetList()
            dgvListPage.Rows.Clear()

            For Each model As CompraHeaderModel In records
                dgvListPage.Rows().Add(model.Id, model.NumeroCompra, model.IdProveedor,
                                        model.Nombre, model.Moneda, model.Estado,
                                        model.FechaEntrega, model.OrdenProveedor)
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
    ''' Abre el boton para creación
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnNewRecordSelected()
        Dim child As Form = New FrmOrdenCompra With {
            .MdiParent = Me.MdiParent
        }
        child.Show()
    End Sub

    ''' <summary>
    ''' Abre el boton para edición
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Public Overrides Sub OnEditRecordSelected()
        Dim child As Form = New FrmOrdenCompra With {
            .MdiParent = Me.MdiParent
        }
        child.Show()
    End Sub

    Private Function GetOrdenCompraStatusValues() As Array
        Return [Enum].GetValues(GetType(EstadoOrdenCompra))
    End Function

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()
        MyBase.OnFormLoaded()

        cboEstatus.DataSource = GetOrdenCompraStatusValues()

    End Sub

    ''' <summary>
    ''' Filtra las OCs
    ''' </summary>
    ''' <remarks>05.02.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub FilterRecords()

    End Sub

#End Region
End Class