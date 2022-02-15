Imports System.ComponentModel

''' <summary>
''' Enum para los tipos de redondeo
''' </summary>
''' <remarks>05.02.2021 jorge.nin92@gmail.com: Se crea el enum</remarks>
<Description("Estado de la orden de compra")>
Public Enum EstadoOrdenCompra
    <Description("Borrador")>
    Borrador = 0
    <Description("Confirmado")>
    Confirmado = 1
    <Description("Recibido")>
    Recibido = 2
    <Description("Pagado")>
    Pagado = 3
    <Description("Cancelado")>
    Cancelado = 4
End Enum
