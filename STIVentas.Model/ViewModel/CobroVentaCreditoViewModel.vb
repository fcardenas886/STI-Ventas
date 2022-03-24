''' <summary>
''' Model para el cobro de las ventas a credito
''' </summary>
''' <remarks>23.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class CobroVentaCreditoViewModel
    Public Property IdVentaCredito As Integer
    Public Property MontoCobrado As Decimal
    Public Property NumeroPagos As Integer
    Public Property MontoPagado As Decimal
    Public Property MontoVenta As Decimal
    Public Property Moneda As String
    Public Property IdCliente As Integer
    Public Property CobradoPor As Integer
    Public Property ResultadoSP As Integer

    Public Sub New()
        IdVentaCredito = 0
    End Sub

    Public Function GetPendientePago() As Decimal

        Dim ret As Decimal

        If MontoPagado > MontoVenta Then
            ret = 0
        Else
            ret = MontoVenta - MontoPagado
        End If

        Return ret
    End Function
End Class
