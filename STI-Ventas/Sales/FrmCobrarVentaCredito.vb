Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Se agrega el form
''' </summary>
''' <remarks>19.03.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmCobrarVentaCredito
#Region "Properties"
    Protected OrdenVenta As VentasCreditoViewModel
    Protected Totals As CobroVentaCreditoViewModel
    Protected IsLoaded As Boolean
    Private IsPaymentSucces As Boolean
    Protected OrdenVentaCredito As VentasCreditoModel

    Public Property Cobrado() As Boolean
        Get
            Return IsPaymentSucces
        End Get
        Protected Set(value As Boolean)
            IsPaymentSucces = value
        End Set
    End Property
#End Region

#Region "Contructor"
    Protected Sub New(idVenta As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InitSalesOrder(idVenta)

    End Sub

    Public Sub New(ordenVenta As VentasCreditoViewModel)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.OrdenVenta = ordenVenta

    End Sub
#End Region

#Region "Class methods"
    Protected Sub InitSalesOrder(idVenta As Integer)
        OrdenVenta = New VentasCreditoViewModel()
        OrdenVenta.Id = idVenta
    End Sub

    Protected Function CobrarVenta() As Boolean
        Dim ret As Boolean = False
        Dim controller As VentasCreditoController

        Try

            controller = New VentasCreditoController()
            ret = controller.CobrarVentaCredito(GetOrdenVentaCobroModel())

            If Not ret AndAlso Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
        Return ret
    End Function

    Private Sub CobraVentaInterno()
        Dim isOK As Boolean

        Try
            Cobrado = False
            If ValidaCobrarVenta() Then
                isOK = CobrarVenta()

                If isOK Then
                    Cobrado = True
                    Info("Operación completada")

                    DialogResult = DialogResult.OK
                    Close()
                End If
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try

    End Sub

    Protected Function ValidaCobrarVenta() As Boolean
        Dim ret As Boolean = True
        Dim strMsg As String = String.Empty

        If OrdenVenta Is Nothing OrElse OrdenVenta.Id = 0 Then
            strMsg = "No se puede recuperar la orden de venta."
        ElseIf Totals Is Nothing Then
            strMsg = "No se puede recuperar las líneas de la orden de venta."
        Else
            If Totals.GetPendientePago() <= 0 Then
                strMsg = "No se detecto pendiente de pago para esta venta." & Environment.NewLine
            End If
        End If
        If String.IsNullOrEmpty(strMsg) AndAlso txtEfectivo.Value <= 0 Then
            CobroErrorProvider.SetError(txtEfectivo, "El monto de cobro debe ser mayor a cero.")
            strMsg = "El monto de cobro debe ser mayor a cero." & Environment.NewLine
        Else
            CobroErrorProvider.SetError(txtEfectivo, "")
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If
        Return ret
    End Function

    Protected Sub InitTotals()
        Dim controller As VentasCreditoController

        Try
            controller = New VentasCreditoController()
            Totals = controller.GetTotalPorId(CInt(OrdenVenta.Id))

            If Totals Is Nothing OrElse Totals.IdVentaCredito < 1 OrElse Not String.IsNullOrEmpty(controller.LastError) Then
                Totals = controller.GetTotalPorId(CInt(OrdenVenta.Id))
            End If

            If Totals Is Nothing OrElse Totals.IdVentaCredito < 1 Then
                Throw New Exception($"No se ha podido recuperar la orden de venta {OrdenVenta.NumeroVenta}. {Environment.NewLine} {controller.LastError}")
            End If

            IsLoaded = True
            InitFields()
        Catch ex As Exception
            HandleException(ex)
        End Try

    End Sub

    Protected Function GetOrdenVentaCobroModel() As CobroVentaCreditoViewModel
        Dim ret As New CobroVentaCreditoViewModel

        ret.MontoCobrado = txtEfectivo.Value
        ret.IdCliente = Totals.IdCliente
        ret.IdVentaCredito = Totals.IdVentaCredito
        ret.Moneda = Totals.Moneda
        ret.MontoVenta = Totals.MontoVenta
        ret.NumeroPagos = Totals.NumeroPagos
        ret.MontoPagado = Totals.MontoPagado

        ret.CobradoPor = FrmMainMDI.ID_USUARIO

        Return ret
    End Function

    Protected Sub InitFields()
        txtMontoPagar.Maximum = Decimal.MaxValue
        txtEfectivo.Maximum = Decimal.MaxValue

        If Totals Is Nothing Then
            InitTotals()
        End If
        If Totals IsNot Nothing Then
            txtMontoPagar.Value = Totals.GetPendientePago()
        Else
            txtMontoPagar.Value = 0
        End If

        UpdateFields()

        txtEfectivo.Select()
    End Sub

    Protected Sub UpdateFields()
        Try

            txtPendientePago.Text = String.Format("{0:N2}", txtEfectivo.Value - txtMontoPagar.Value)

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        CobraVentaInterno()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub FrmCobrarVentaCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitTotals()

        txtEfectivo.Select()
    End Sub

    Private Sub txtEfectivo_ValueChanged(sender As Object, e As EventArgs) Handles txtEfectivo.ValueChanged
        UpdateFields()
    End Sub

    Private Sub txtCambio_TextChanged(sender As Object, e As EventArgs) Handles txtPendientePago.TextChanged
        UpdateFields()
    End Sub

    Private Sub txtEfectivo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEfectivo.KeyUp
        If txtEfectivo.Value <> 0 AndAlso e.KeyData = Keys.Enter Then
            CobraVentaInterno()
        Else
            UpdateFields()
        End If
    End Sub

    Private Sub txtPendientePago_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPendientePago.KeyUp
        If txtEfectivo.Value <> 0 AndAlso e.KeyData = Keys.Enter Then
            CobraVentaInterno()
        End If
    End Sub

#End Region
End Class