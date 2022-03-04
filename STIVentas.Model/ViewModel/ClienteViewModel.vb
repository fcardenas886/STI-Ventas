''' <summary>
''' Clase que tendra el template para el cliente mostrador
''' </summary>
''' <remarks>24.02.2022 jorge.nin92@gmail.com: Se crea el model</remarks>
Public Class ClienteViewModel
    Public Property Rut As String
    Public Property Nombre As String
    Public Property Id As Integer
    Public Property Moneda As String
    ''' <summary>
    ''' Forma de pago asociada a la configuración. By jorge.nin92@gmail.com
    ''' </summary>
    ''' <returns>La forma de pago predeterminada.</returns>
    Public Property FormaPago As String
End Class
