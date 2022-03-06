''' <summary>
''' Lineas para los tickets.
''' </summary>
''' <remarks>05.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class OrderItem
    Private ReadOnly delimitador As Char() = New Char() {"?"c}

    Public Sub New(delimit As Char)
        delimitador = New Char() {delimit}
    End Sub

    Public Function GetItemName(orderItem As String) As String
        Dim delimitado As String() = orderItem.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function GetItemCantidad(orderItem As String) As String
        Dim delimitado As String() = orderItem.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function GetItemPrice(orderItem As String) As String
        Dim delimitado As String() = orderItem.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function GetItemTotal(orderItem As String) As String
        Dim delimitado As String() = orderItem.Split(delimitador)
        Return delimitado(3)
    End Function

    Public Function GenerateItem(cantidad As String, itemName As String, price As String) As String
        Return itemName & delimitador(0) & cantidad & delimitador(0) & price
    End Function

    Public Function GenerateItem(cantidad As String, itemName As String, price As String, total As String) As String
        Return itemName & delimitador(0) & cantidad & delimitador(0) & price & delimitador(0) & total
    End Function
End Class
