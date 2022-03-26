Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Se agrega el form
''' </summary>
''' <remarks>23.03.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmVentaCreditoDetallePagoListPage
    Private isFromFilterButton As Boolean
    Protected VentaCredito As VentasCreditoViewModel

    Public Sub New(model As VentasCreditoViewModel)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        VentaCredito = model
    End Sub

#Region "Class methods"

    ''' <summary>
    ''' Se debe sobreescribir para el metodo Load
    ''' </summary>
    ''' <remarks>23.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub OnFormLoaded()

        MyBase.OnFormLoaded()

        NuevoToolStripMenuItem1.Visible = False
        EliminarToolStripMenuItem.Visible = False
        EditarToolStripMenuItem.Visible = False

        AccionesToolStripMenuItem.Visible = True

    End Sub

    ''' <summary>
    ''' Filtra las OVs
    ''' </summary>
    ''' <remarks>23.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub FilterRecords()
        Try
            isFromFilterButton = True
            LoadRecords()
            isFromFilterButton = False
        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Carga los registros del form
    ''' </summary>
    ''' <remarks>23.03.2022 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Overrides Sub LoadRecords()
        Dim controller As CobroVentasCreditoController
        Dim records As List(Of CobroVentasCreditoModel)
        Dim dbSelect As DBSelect
        Dim style As DataGridViewCellStyle

        Try
            Cursor = Cursors.WaitCursor

            If dgvListPage.Columns().Count < 1 Then

                style = New DataGridViewCellStyle()
                style.Alignment = DataGridViewContentAlignment.MiddleRight

                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Venta", .HeaderText = "Venta"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Moneda", .HeaderText = "Moneda"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Fecha", .HeaderText = "Fecha"})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Estado", .HeaderText = "Estado"})

                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "MontoPagado", .HeaderText = "Monto pagado", .DefaultCellStyle = style})
                dgvListPage.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "CreadoPor", .HeaderText = "Creado por"})

                dgvListPage.Columns(1).Visible = True

            End If

            controller = New CobroVentasCreditoController()
            dbSelect = New DBSelect(controller.TableName())

            dbSelect.FilterFields.Add(New DBFilterFields("IdVentaCredito", DBFilterType.Equal, VentaCredito.Id))

            If isFromFilterButton Then
                '' Validar campos
            End If

            records = controller.GetCobrosPorVenta(dbSelect)
            dgvListPage.Rows.Clear()

            For Each model As CobroVentasCreditoModel In records
                dgvListPage.Rows().Add(model.Id, VentaCredito.NumeroVenta, model.Moneda,
                                        model.Fecha.ToShortDateString(), model.Estado,
                                        model.MontoPagado.ToString("N2"),
                                        model.CobradoPor)
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

#Region "events"

    Private Sub FrmVentaCreditoDetallePagoListPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Detalles de cobros, venta " + VentaCredito.NumeroVenta
    End Sub

#End Region

End Class