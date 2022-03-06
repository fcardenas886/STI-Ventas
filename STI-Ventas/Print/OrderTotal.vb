
''' <summary>
''' Clase para los totales del ticket.
''' </summary>
''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class OrderTotal
    Private ReadOnly delimitador As Char() = New Char() {"?"c}

    Public Sub New(delimit As Char)
        delimitador = New Char() {delimit}
    End Sub

    Public Function GetTotalName(totalItem As String) As String
        Dim delimitado As String() = totalItem.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function GetTotalCantidad(totalItem As String) As String
        Dim delimitado As String() = totalItem.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function GenerateTotal(totalName As String, price As String) As String
        Return totalName & delimitador(0) & price
    End Function
End Class
