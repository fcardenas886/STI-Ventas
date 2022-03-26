Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Muestra todas las ventas a credito
''' </summary>
''' <remarks>18.03.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmVentasCredito
    Private ReadOnly IdVentaCredito As Integer

#Region "Constructor"
    Public Sub New(idVentaCredito As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.IdVentaCredito = idVentaCredito
    End Sub

    Private Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region

#Region "Class methods"
    Private Sub LoadRecords()
        Dim controller As CobroVentasCreditoController
        Dim records As List(Of CobroVentasCreditoViewModel)
        Dim style As DataGridViewCellStyle

        Try
            Cursor = Cursors.WaitCursor

            If dgvLineas.Columns().Count < 1 Then

                style = New DataGridViewCellStyle()
                style.Alignment = DataGridViewContentAlignment.MiddleRight
                ' SELECT Id, Moneda, Fecha, Monto, MontoPagado, Estado, Username FROM CobrosClienteView
                dgvLineas.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})

                dgvLineas.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "FechaVenta", .HeaderText = "Fecha"})
                dgvLineas.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Moneda", .HeaderText = "Moneda"})
                dgvLineas.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "MontoVenta", .HeaderText = "Total Venta", .DefaultCellStyle = style})
                dgvLineas.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "MontoPagado", .HeaderText = "Monto pagado", .DefaultCellStyle = style})
                dgvLineas.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Estado", .HeaderText = "Estado"})
                dgvLineas.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "CreadoPor", .HeaderText = "Cobrado por"})

                dgvLineas.Columns(1).Visible = True

            End If

            controller = New CobroVentasCreditoController()

            records = controller.GetCobrosPorVentaCredito(IdVentaCredito)
            dgvLineas.Rows.Clear()

            For Each model As CobroVentasCreditoViewModel In records
                dgvLineas.Rows().Add(model.Id, model.Fecha.ToShortDateString(), model.Moneda,
                                        model.Monto.ToString("N2"), model.MontoPagado.ToString("N2"),
                                        model.Estado, model.CobradoPor)
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
    Private Sub FrmVentasCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView(dgvLineas)
        LoadRecords()
    End Sub
#End Region
End Class