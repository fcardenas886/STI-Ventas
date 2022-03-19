
''' <summary>
''' Model para totales de OV
''' </summary>
''' <remarks>17.02.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class OrdenVentaTotales
    Public Property IdVenta As Integer
    Public Property NumeroLineas As Decimal
    Public Property Total As Decimal
    Public Property Cantidad As Decimal
    Public Property Descuento As Decimal

#Region "Venta a credito"
    ' @jnieves 15.03.2022: Para ventas a credito
    Public Property LimiteCredito As Decimal
    ''' <summary>
    ''' Indica el credito que tiene pendiente de pago el cliente de la OV
    ''' </summary>
    ''' <returns>El credito pendiente del cliente</returns>
    Public Property CreditoActual As Decimal
    ''' <summary>
    ''' Monto de los creditos actuales que se ha pagado.
    ''' </summary>
    ''' <returns>El monto de pago de los creditos</returns>
    Public Property MontoPagado As Decimal
    ' Este es el monto pagado para las líneas, solo aplica cuando encuentre diferencias entre lo que tiene el credito contra los pagos realizados
    Public Property MontoPagadoCobros As Decimal

    Public Function LimiteCreditoActivo() As Boolean

        If LimiteCredito > 0 Then
            Dim pendientePago As Decimal = GetPendientePago()

            If pendientePago > 0 Then
                Return LimiteCredito > pendientePago
            Else
                ' Indica que pago de mas el cliente: Revisar este escenario
                Return True
            End If

        End If

        Return False

    End Function

    Public Function GetCreditoDisponible() As Decimal

        If LimiteCreditoActivo() Then

            Return LimiteCredito - GetPendientePago()
        End If

        Return 0
    End Function

    Public Function GetPendientePago() As Decimal
        Dim pendientePago As Decimal = CreditoActual - MontoPagado

        If pendientePago < 0 Then
            pendientePago = 0
        End If

        Return pendientePago
    End Function

#End Region

    Public Sub New()
        IdVenta = 0
    End Sub

End Class
