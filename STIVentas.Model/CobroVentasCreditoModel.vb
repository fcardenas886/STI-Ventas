''' <summary>
''' Model para el cobro de las ventas a credito
''' </summary>
''' <remarks>15.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class CobroVentasCreditoModel : Implements IDBTable

	Private RecordId As Long

	Public Property Id As Long Implements IDBTable.RecordId
		Get
			Return RecordId
		End Get
		Set(value As Long)
			RecordId = value
		End Set
	End Property

	Public Property IdVenta As Integer
	Public Property IdCliente As Integer
	Public Property CodigoCliente As String
	Public Property MontoVenta As Decimal
	Public Property Abono As Decimal
	Public Property Estado As EstadoCobroVentas
	Public Property Moneda As String
	Public Property Fecha As DateTime
	Public Property CreadoPor As Integer
	Public Property IdVentaCredito As Integer
	Public Property MontoPagado As Decimal

	Sub New(Id_ As Integer, IdVenta_ As Integer, IdCliente_ As Integer, CodigoCliente_ As String, MontoVenta_ As Decimal, Abono_ As Decimal,
				Estado_ As EstadoCobroVentas, Moneda_ As String, Fecha_ As DateTime, CreadoPor_ As Integer, IdVentaCredito_ As Integer, MontoPagado_ As Decimal)
		Id = Id_
		IdVenta = IdVenta_
		IdCliente = IdCliente_
		CodigoCliente = CodigoCliente_
		MontoVenta = MontoVenta_
		Abono = Abono_
		Estado = Estado_
		Moneda = Moneda_
		Fecha = Fecha_
		CreadoPor = CreadoPor_
		IdVentaCredito = IdVentaCredito_
		MontoPagado = MontoPagado_
	End Sub

	''' <summary>
	''' Constructor sin params
	''' </summary>
	''' <remarks>15.03.2022 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		RecordId = 0
	End Sub

End Class
