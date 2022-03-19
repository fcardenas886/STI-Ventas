Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' Se agrega el form
''' </summary>
''' <remarks>18.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmCobroVenta
#Region "Properties"
    Protected OrdenVenta As OrdenVentaModel
    Protected Totals As OrdenVentaTotales
    Protected IsLoaded As Boolean
    Private IsPaymentSucces As Boolean
    Public Lineas As List(Of OrdenVentaDetalleModel)
    Protected MontoCredito As Decimal

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
    Protected Sub New(idVenta As Long)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InitSalesOrder(idVenta)
        MontoCredito = 0
    End Sub

    Public Sub New(ordenVenta As OrdenVentaModel)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.OrdenVenta = ordenVenta
        MontoCredito = 0
    End Sub
#End Region

#Region "Class methods"
    Protected Sub InitSalesOrder(idVenta As Long)
        OrdenVenta = New OrdenVentaModel()
        OrdenVenta.Id = idVenta
    End Sub

    Protected Function CobrarVenta() As Boolean
        Dim ret As Boolean = False
        Dim controller As VentasController

        Try
            MontoCredito = 0

            controller = New VentasController()
            ret = controller.CobrarOrdenVenta(GetOrdenVentaCobroModel())

            If Not ret AndAlso Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If

            IsLoaded = True
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

                    PrintTicket()

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
            If Totals.NumeroLineas < 1 Then
                strMsg = "Se debe especificar al menos una línea para poder continuar." & Environment.NewLine
            End If
        End If
        If txtEfectivo.Value < txtMontoPagar.Value Then
            CobroErrorProvider.SetError(txtEfectivo, "El monto de cobro debe ser mayor o igual al monto a pagar")
            strMsg = "El monto de cobro debe ser mayor o igual al monto a pagar." & Environment.NewLine
        Else
            CobroErrorProvider.SetError(txtEfectivo, "")
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If
        Return ret
    End Function

    Protected Sub InitTotals()
        Dim controller As VentasController

        Try
            controller = New VentasController()
            Totals = controller.GetTotals_CreditLimit(CInt(OrdenVenta.Id))

            If Totals Is Nothing OrElse Totals.NumeroLineas < 1 OrElse Not String.IsNullOrEmpty(controller.LastError) Then
                Totals = controller.GetTotals_CreditLimit(CInt(OrdenVenta.Id))
            End If

            If Totals Is Nothing OrElse Totals.NumeroLineas < 1 Then
                Throw New Exception($"No se ha podido recuperar las líneas de la orden de venta {OrdenVenta.NumeroVenta}. {Environment.NewLine} {controller.LastError}")
            End If

            IsLoaded = True
            InitFields()
        Catch ex As Exception
            HandleException(ex)
        End Try

    End Sub

    Protected Function GetOrdenVentaCobroModel() As OrdenVentaCobroViewModel
        Dim ret As New OrdenVentaCobroViewModel

        If OrdenVenta IsNot Nothing Then
            ret.InitFromOrdenVentaModel(OrdenVenta)
        End If
        If Totals IsNot Nothing Then
            ret.InitFromOrdenVentaTotales(Totals)
        End If

        If ret.IdUsuario < 1 Then
            ret.IdUsuario = FrmMainMDI.ID_USUARIO
        End If
        If String.IsNullOrEmpty(ret.Moneda) Then
            ret.Moneda = FrmVentaPOS.ClienteActual.Moneda
        End If
        If String.IsNullOrEmpty(ret.FormaPago) Then
            ret.FormaPago = FrmVentaPOS.ClienteActual.FormaPago
        End If

        ret.Credito = MontoCredito
        ret.Total = txtMontoPagar.Value
        ret.Vuelto = CType(txtCambio.Text, Decimal)
        ret.Propina = txtPropina.Value
        ret.Efectivo = txtEfectivo.Value
        ret.UserName = FrmMainMDI.USERNAME

        Return ret
    End Function

    Protected Sub InitFields()
        txtMontoPagar.Maximum = Decimal.MaxValue
        txtEfectivo.Maximum = Decimal.MaxValue

        If Totals Is Nothing Then
            InitTotals()
        End If
        If Totals IsNot Nothing Then
            txtMontoPagar.Value = Totals.Total
        Else
            txtMontoPagar.Value = 0
        End If

        UpdateCreditLimitFields()

        txtEfectivo.Select()
    End Sub

    Protected Sub UpdateFields()
        Try
            If txtEfectivo.Value >= txtMontoPagar.Value Then
                txtCambio.Text = String.Format("{0:N2}", txtEfectivo.Value - txtMontoPagar.Value)
            Else
                txtCambio.Text = "0.0"
            End If

            UpdateCreditFields()

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Sub PrintTicket()
        Dim totalView As OrdenVentaCobroViewModel

        Try

            totalView = GetOrdenVentaCobroModel()

            If Not VentasHelper.PrintTicket(totalView, OrdenVenta, lineas) Then
                HandleError("Error imprimiendo el ticket, intente nuevamente por favor.")
            End If

        Catch ex As Exception
            HandleError(ex)
        End Try

    End Sub

    Protected Sub CobrarACredito()
        Dim isOK As Boolean

        Try
            Cobrado = False

            If ValidaCobrarCredito() Then
                isOK = CobrarVentaCredito()

                If isOK Then
                    Cobrado = True
                    Info("Operación completada")

                    PrintTicket()

                    DialogResult = DialogResult.OK
                    Close()
                End If
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try

    End Sub

    Protected Sub UpdateCreditLimitFields()

        Dim creditActivo As Boolean

        Try

            If Totals IsNot Nothing Then
                creditActivo = Totals.LimiteCreditoActivo()

                btnPagoCredito.Enabled = creditActivo

                If creditActivo Then

                    If Totals.GetPendientePago() + Totals.Total <= Totals.LimiteCredito Then
                        txtDetallesCredito.Text = String.Format("El cliente tiene límite de crédito de '{0:n2}', si utiliza el crédito actual para pagar la orden de venta quedara un saldo de '{1:n2}'",
                                                                Totals.LimiteCredito,
                                                                Totals.LimiteCredito - (Totals.GetPendientePago() + Totals.Total))
                        btnPagoCredito.ForeColor = Color.Green
                        txtDetallesCredito.ForeColor = Color.Green

                    Else
                        btnPagoCredito.Enabled = False

                        If Totals.CreditoActual <> 0 Then
                            txtDetallesCredito.Text = String.Format("El cliente tiene límite de crédito de '{0:n2}', pero ha utilizado '{1:n2}', por lo que no puede utilizar más la opción a crédito a menos que realice el pago o aumente su límite de crédito.",
                                                                    Totals.LimiteCredito,
                                                                    Totals.CreditoActual)

                            txtDetallesCredito.ForeColor = Color.Orange

                        Else

                            txtDetallesCredito.Text = String.Format("El cliente tiene límite de crédito de '{0:n2}', pero no se puede utilizar ya que la orden de venta supera el monto actual.",
                                                                    Totals.LimiteCredito)
                            txtDetallesCredito.ForeColor = Color.Blue

                        End If

                        btnPagoCredito.ForeColor = Color.Red

                    End If

                End If

            Else
                txtDetallesCredito.Text = "Cliente sin acceso a límite de crédito"
                btnPagoCredito.Enabled = False
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Protected Function ValidaCobrarCredito() As Boolean
        Dim ret As Boolean = True
        Dim strMsg As String = String.Empty

        If OrdenVenta Is Nothing OrElse OrdenVenta.Id = 0 Then
            strMsg = "No se puede recuperar la orden de venta."
        ElseIf Totals Is Nothing Then
            strMsg = "No se puede recuperar las líneas de la orden de venta."
        Else
            If Totals.NumeroLineas < 1 Then
                strMsg = "Se debe especificar al menos una línea para poder continuar." & Environment.NewLine
            End If
        End If
        If txtEfectivo.Value >= txtMontoPagar.Value Then
            CobroErrorProvider.SetError(txtEfectivo, String.Format("Esta seleccionando la venta a crédito, pero el monto del pago {0:n2} recibido como pago es igual o mayor al total de la venta {1:n2}", txtEfectivo.Value, txtMontoPagar.Value))
            strMsg = "El monto de cobro debe ser menor al monto a pagar para ventas a crédito." & Environment.NewLine
        Else
            CobroErrorProvider.SetError(txtEfectivo, "")
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If
        Return ret
    End Function

    Protected Function CobrarVentaCredito() As Boolean
        Dim ret As Boolean = False
        Dim controller As VentasController

        Try
            MontoCredito = txtMontoPagar.Value - txtEfectivo.Value

            controller = New VentasController()
            ret = controller.CobrarOrdenVenta(GetOrdenVentaCobroModel())

            If Not ret AndAlso Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If

            IsLoaded = True
        Catch ex As Exception
            HandleException(ex)
        End Try
        Return ret
    End Function

    Private Sub UpdateCreditFields()


        Try
            If Totals IsNot Nothing AndAlso Totals.LimiteCreditoActivo() Then

                Dim total As Decimal = Totals.Total - txtEfectivo.Value

                If Totals.Total < txtEfectivo.Value Then
                    total = 0
                End If

                If Totals.GetPendientePago() + total <= Totals.LimiteCredito Then
                    txtDetallesCredito.Text = String.Format("El cliente tiene límite de crédito de '{0:n2}', si utiliza el crédito actual para pagar la orden de venta quedara un saldo de '{1:n2}'",
                                                            Totals.LimiteCredito,
                                                            Totals.LimiteCredito - (Totals.GetPendientePago() + total))
                    btnPagoCredito.ForeColor = Color.Green
                    txtDetallesCredito.ForeColor = Color.Green

                Else
                    btnPagoCredito.Enabled = False

                    If Totals.CreditoActual <> 0 Then
                        txtDetallesCredito.Text = String.Format("El cliente tiene límite de crédito de '{0:n2}', pero ha utilizado '{1:n2}', por lo que no puede utilizar más la opción a crédito a menos que realice el pago o aumente su límite de crédito.",
                                                                Totals.LimiteCredito,
                                                                Totals.CreditoActual)

                        txtDetallesCredito.ForeColor = Color.Orange

                    Else

                        txtDetallesCredito.Text = String.Format("El cliente tiene límite de crédito de '{0:n2}', pero no se puede utilizar ya que la orden de venta supera el monto actual.",
                                                                Totals.LimiteCredito)
                        txtDetallesCredito.ForeColor = Color.Blue

                    End If

                    btnPagoCredito.ForeColor = Color.Red

                End If
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try

    End Sub

#End Region

#Region "Events"
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        CobraVentaInterno()
    End Sub

    Private Sub FrmCobroVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitTotals()
        txtEfectivo.Select()
    End Sub

    Private Sub FrmCobroVenta_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating
        If Not ValidaCobrarVenta() Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub txtCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtMontoPagar.ValueChanged
        UpdateFields()
    End Sub

    Private Sub txtEfectivo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtEfectivo.Validating
        If txtEfectivo.Value < txtMontoPagar.Value Then
            CobroErrorProvider.SetError(CType(sender, Control), "El monto de cobro debe ser mayor o igual al monto a pagar")
        Else
            CobroErrorProvider.SetError(CType(sender, Control), "")
        End If
    End Sub

    Private Sub txtEfectivo_ValueChanged(sender As Object, e As EventArgs) Handles txtEfectivo.ValueChanged
        UpdateFields()
    End Sub

    Private Sub txtMontoPagar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtMontoPagar.KeyUp
        If e.KeyData = Keys.Enter Then
            CobraVentaInterno()
        End If
    End Sub

    Private Sub txtEfectivo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEfectivo.KeyUp
        If e.KeyData = Keys.Enter Then
            CobraVentaInterno()
        Else
            UpdateFields()
        End If
    End Sub

    Private Sub txtPropina_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPropina.KeyUp
        If e.KeyData = Keys.Enter Then
            CobraVentaInterno()
        End If
    End Sub

    Private Sub txtCambio_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCambio.KeyUp
        If e.KeyData = Keys.Enter Then
            CobraVentaInterno()
        End If
    End Sub

    Private Sub btnPagoCredito_Click(sender As Object, e As EventArgs) Handles btnPagoCredito.Click
        CobrarACredito()
    End Sub

#End Region

End Class