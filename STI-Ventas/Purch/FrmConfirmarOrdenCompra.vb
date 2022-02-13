
Imports STIVentas.Controller
Imports STIVentas.Model
''' <summary>
''' Form para confirmar las OC
''' </summary>
''' <remarks>08.02.2028 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmConfirmarOrdenCompra
#Region "Variables and Properties"
    Dim ordenCompraActual As CompraHeaderModel

    Private IsConfirmed As Boolean

    Public ReadOnly Property IsPurchConfirmed() As Boolean
        Get
            Return IsConfirmed
        End Get
    End Property

#End Region

#Region "Constructor"
    Public Sub New(ordenCompra As CompraHeaderModel)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ordenCompraActual = ordenCompra

    End Sub
#End Region

#Region "Class methods"
    Protected Sub ConfirmPurchaseOrder()
        Dim controller As ComprasController
        Dim isOk As Boolean
        Try
            If ValidateConfirmPurchaseOrder(ordenCompraActual) Then
                controller = New ComprasController()
                isOk = controller.ConfirmPurchaseOrder(ordenCompraActual)

                If isOk Then
                    IsConfirmed = True
                    Info("Se ha confirmado la orden de compra " & ordenCompraActual.NumeroCompra)
                    DialogResult = DialogResult.OK
                    Close()
                Else
                    HandleException("Error al confirmar la orden de compra " & ordenCompraActual.NumeroCompra & Environment.NewLine & controller.LastError)
                End If
            End If

        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub

    Protected Function ValidateConfirmPurchaseOrder(ordenCompra As CompraHeaderModel) As Boolean
        Dim ret As Boolean = True
        Dim strMsg As String = String.Empty

        If ordenCompra Is Nothing Or ordenCompra.Id = 0 Then
            strMsg = "No se puede recuperar la orden de compra." & Environment.NewLine
        Else
            If ordenCompra.Estado <> EstadoOrdenCompra.Borrador Then
                strMsg = "La orden de compra tiene un estatus no valido." & Environment.NewLine
            End If
            If CType(txtNumeroLineas.Text, Integer) < 1 Then
                strMsg = "Se debe especificar al menos una línea para poder confirmar la orden de compra." & Environment.NewLine
            End If
        End If

        If String.IsNullOrEmpty(txtNumeroLineas.Text) Or CType(txtNumeroLineas.Text, Decimal) = 0 Then
            strMsg = "La orden de compra debe tener al menos una línea." & Environment.NewLine
        End If

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

    Protected Sub LoadCurrentRecord()
        Dim controller As ComprasController
        Dim totals As OrdenCompraTotales

        Try
            Cursor = Cursors.WaitCursor

            txtOrdenCompraId.TextAlign = HorizontalAlignment.Center
            txtOrdenCompraId.Text = ordenCompraActual.Id.ToString()
            txtOrdenCompra.Text = ordenCompraActual.NumeroCompra
            txtVendorName.Text = ordenCompraActual.Nombre
            txtContacto.Text = ordenCompraActual.Contacto
            txtEmail.Text = ordenCompraActual.Correo
            txtOrdenProveedor.Text = ordenCompraActual.OrdenProveedor

            cboEstatus.Items.Add(ordenCompraActual.Estado)
            cboProveedor.Items.Add(ordenCompraActual.IdProveedor)
            cboMoneda.Items.Add(ordenCompraActual.Moneda)
            cboFormaPago.Items.Add(ordenCompraActual.FormaPago)

            cboEstatus.Enabled = False
            cboProveedor.Enabled = False
            cboMoneda.Enabled = False
            cboFormaPago.Enabled = False

            cboEstatus.SelectedIndex = cboEstatus.Items.Count - 1
            cboProveedor.SelectedIndex = cboProveedor.Items.Count - 1
            cboMoneda.SelectedIndex = cboMoneda.Items.Count - 1
            cboFormaPago.SelectedIndex = cboFormaPago.Items.Count - 1

            controller = New ComprasController()
            totals = controller.GetTotals(ordenCompraActual.Id)

            If totals Is Nothing Then
                HandleException(IIf(String.IsNullOrEmpty(controller.LastError), "Error recuperando los totales", controller.LastError))
            Else
                If Not String.IsNullOrEmpty(controller.LastError) Then
                    HandleException(controller.LastError)
                End If

                txtMontoLinea.Text = String.Format("{0:n2}", totals.Total)
                txtNumeroLineas.Text = String.Format("{0:n2}", totals.NumeroLineas)
            End If

            txtMontoLinea.TextAlign = HorizontalAlignment.Center
            txtNumeroLineas.TextAlign = HorizontalAlignment.Center

        Catch ex As Exception
            HandleError(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        ConfirmPurchaseOrder()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmConfirmarOrdenCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCurrentRecord()
    End Sub

    Private Sub FrmConfirmarOrdenCompra_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating
        If Not ValidateConfirmPurchaseOrder(ordenCompraActual) Then
            e.Cancel = True
        End If
    End Sub

#End Region
End Class