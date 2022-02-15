Imports System.ComponentModel

''' <summary>
''' Enum para los estados de inventario
''' </summary>
''' <remarks>08.02.2021 jorge.nin92@gmail.com: Se crea el enum</remarks>
<Description("Estado de inventario")>
Public Enum EstadoInventario
    <Description("Borrador")>
    Borrador = 0
    <Description("Comprado")>
    Comprado = 1
    <Description("Vendido")>
    Vendido = 2
    <Description("Ajuste de Inventario")>
    AjusteInventario = 3
    <Description("Cancelado")>
    Cancelado = 4
End Enum
