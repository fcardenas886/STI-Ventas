
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

    Public Sub New()
        IdVenta = 0
    End Sub
End Class
