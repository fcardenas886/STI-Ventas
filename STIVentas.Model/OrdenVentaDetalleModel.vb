
''' <summary>
''' Model para detalles de OV
''' </summary>
''' <remarks>17.02.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class OrdenVentaDetalleModel : Implements IDBTable

	Private RecordId As Long
	Public Property NumeroLinea As Integer
	Public Property IdArticulo As String
	Public Property IdProducto As Integer
	Public Property Nombre As String
	Public Property Unidad As String
	Public Property Cantidad As Decimal
	Public Property PrecioUnitario As Decimal
	Public Property Descuento As Decimal
	Public Property Monto As Decimal
	Public Property IdVenta As Integer

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
	''' <remarks>17.02.2021 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		RecordId = 0
	End Sub

	Sub New(ByVal Id_ As Integer, ByVal NumeroLinea_ As Integer, ByVal IdArticulo_ As String, ByVal IdProducto_ As Integer, ByVal Nombre_ As String, ByVal Unidad_ As String,
			cantidad_ As Decimal, ByVal PrecioUnitario_ As Decimal, ByVal Descuento_ As Decimal, ByVal Monto_ As Decimal, ByVal IdVenta_ As Integer)
		Me.Id = Id_
		Me.NumeroLinea = NumeroLinea_
		Me.IdArticulo = IdArticulo_
		Me.IdProducto = IdProducto_
		Me.Nombre = Nombre_
		Me.Unidad = Unidad_
		Me.PrecioUnitario = PrecioUnitario_
		Me.Descuento = Descuento_
		Me.Monto = Monto_
		Me.IdVenta = IdVenta_
		Cantidad = cantidad_
	End Sub
End Class
