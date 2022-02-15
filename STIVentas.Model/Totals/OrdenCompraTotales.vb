
''' <summary>
''' Model para totales de OC
''' </summary>
''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class OrdenCompraTotales
    Public Property IdCompra As Integer
    Public Property NumeroLineas As Decimal
    Public Property Total As Decimal
    Public Property Cantidad As Decimal
    Public Property Descuento As Decimal

    Public Sub New()
        IdCompra = 0
    End Sub
End Class
