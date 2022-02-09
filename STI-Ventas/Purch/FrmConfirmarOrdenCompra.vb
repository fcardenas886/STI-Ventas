
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

        If Not String.IsNullOrEmpty(strMsg) Then
            ret = CheckFailed(strMsg)
        End If

        Return ret
    End Function

    Protected Sub LoadCurrentRecord()
        txtMontoLinea.Text = "0.0"
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

#End Region
End Class