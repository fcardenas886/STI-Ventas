Imports System.ComponentModel

''' <summary>
''' Enum para los estados de ventas a credito
''' </summary>
''' <remarks>15.03.2022 jorge.nin92@gmail.com: Se crea el enum</remarks>
<Description("Estado venta a crédito")>
Public Enum EstadoVentaCredito
    <Description("Creado")>
    Creado
    <Description("Pendiente")>
    PendientePago
    <Description("Cancelado")>
    Cancelado
    <Description("Cobrado")>
    Cobrado
End Enum
