Imports System.ComponentModel

''' <summary>
''' Enum para los estados del usuario del sistema
''' </summary>
''' <remarks>18.02.2022 jorge.nin92@gmail.com: Se crea el enum</remarks>
<Description("Estado actual del usuario")>
Public Enum EstadoUsuario
    <Description("Activo")>
    Activo = 0
    <Description("Inactivo")>
    Inactivo = 1
    <Description("Eliminado")>
    Eliminado = 2
End Enum
