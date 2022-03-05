Imports System.ComponentModel

''' <summary>
''' Enum para los tipos de transacciones de inventario
''' </summary>
''' <remarks>08.02.2021 jorge.nin92@gmail.com: Se crea el enum</remarks>
<Description("Tipo transacción de inventario")>
Public Enum TipoTransaccionInventario
    <Description("Ninguno")>
    Ninguno = 0
    <Description("Compras")>
    Compras = 1
    <Description("Ventas")>
    Ventas = 2
    <Description("Ajuste de Inventario")>
    AjusteInventario = 3
    <Description("Otros")>
    Otro = 4
End Enum
