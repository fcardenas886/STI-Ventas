
''' <summary>
''' Model para transacciones de inventario
''' </summary>
''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class TransaccionInventarioModel : Implements IDBTable

	Private RecordId As Long
	Public Property IdArticulo As Integer
	Public Property Moneda As String
	Public Property FechaMovimiento As DateTime
	Public Property Costo As Decimal
	Public Property Estatus As Byte
	Public Property TipoTransaccion As Byte
	Public Property Referencia As String
	Public Property NumeroReferencia As String
	Public Property Cantidad As Decimal
	Public Property Unidad As String
	Public Property IdTransaccion As String

	Public Property Id As Long Implements IDBTable.RecordId
		Get
			Return RecordId
		End Get
		Set(value As Long)
			RecordId = value
		End Set
	End Property

	Sub New(ByVal Id_ As Integer, ByVal IdArticulo_ As Integer, ByVal Moneda_ As String, ByVal FechaMovimiento_ As DateTime, ByVal Costo_ As Decimal, ByVal Estatus_ As Byte, ByVal TipoTransaccion_ As Byte, ByVal Referencia_ As String, ByVal NumeroReferencia_ As String, ByVal Cantidad_ As Decimal, ByVal Unidad_ As String, ByVal IdTransaccion_ As String)
		Id = Id_
		IdArticulo = IdArticulo_
		Moneda = Moneda_
		FechaMovimiento = FechaMovimiento_
		Costo = Costo_
		Estatus = Estatus_
		TipoTransaccion = TipoTransaccion_
		Referencia = Referencia_
		NumeroReferencia = NumeroReferencia_
		Cantidad = Cantidad_
		Unidad = Unidad_
		IdTransaccion = IdTransaccion_
	End Sub
End Class
