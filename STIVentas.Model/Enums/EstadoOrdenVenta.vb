Imports System.ComponentModel

''' <summary>
''' Enum para los estatus de OV
''' </summary>
''' <remarks>17.02.2022 jorge.nin92@gmail.com: Se crea el enum</remarks>
<Description("Estado de la orden de venta")>
Public Enum EstadoOrdenVenta
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
