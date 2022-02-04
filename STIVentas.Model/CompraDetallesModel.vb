
''' <summary>
''' Model para líneas de la OC
''' </summary>
''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class CompraDetallesModel : Implements IDBTable

	Private RecordId As Long
	Public Property IdCompra As Integer
	Public Property NumeroLinea As Integer
	Public Property IdProducto As Integer
	Public Property Unidad As String
	Public Property NombreProducto As String
	Public Property Cantidad As Decimal
	Public Property PrecioUnitario As Decimal
	Public Property Descuento As Decimal
	Public Property MontoNeto As Decimal

	Public Property Id As Long Implements IDBTable.RecordId
		Get
			Return RecordId
		End Get
		Set(value As Long)
			RecordId = value
		End Set
	End Property

	''' <summary>
	''' Constructor sin params
	''' </summary>
	''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		RecordId = 0
	End Sub

	Sub New(ByVal Id_ As Integer, ByVal IdCompra_ As Integer, ByVal NumeroLinea_ As Integer, ByVal IdProducto_ As Integer, ByVal Unidad_ As String, ByVal NombreProducto_ As String, ByVal Cantidad_ As Decimal, ByVal PrecioUnitario_ As Decimal, ByVal Descuento_ As Decimal, ByVal MontoNeto_ As Decimal)
		Id = Id_
		IdCompra = IdCompra_
		NumeroLinea = NumeroLinea_
		IdProducto = IdProducto_
		Unidad = Unidad_
		NombreProducto = NombreProducto_
		Cantidad = Cantidad_
		PrecioUnitario = PrecioUnitario_
		Descuento = Descuento_
		MontoNeto = MontoNeto_
	End Sub
End Class
