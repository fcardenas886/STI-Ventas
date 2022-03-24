''' <summary>
''' Model para la presentación de las ventas a credito
''' </summary>
''' <remarks>19.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class VentasCreditoViewModel

	Public Property Id As Integer
	Public Property Nombre As String
	Public Property NumeroVenta As String
	Public Property Moneda As String
	Public Property CodigoCliente As String
	Public Property Fecha As DateTime
	Public Property MontoVenta As Decimal
	Public Property Abono As Decimal
	Public Property Estado As EstadoVentaCredito
	Public Property MontoPagado As Decimal
	Public Property CreadoPor As String
	Public Property NumeroPago As Integer

	Sub New(Id_ As Integer, Nombre_ As String, Moneda_ As String, Fecha_ As DateTime, MontoVenta_ As Decimal, Status_ As EstadoVentaCredito, MontoPagado_ As Decimal, CobradoPor_ As String,
			NumeroVenta_ As String, CodigoCliente_ As String, Abono_ As Decimal, NumPagos As Integer)
		Id = Id_
		Nombre = Nombre_
		Moneda = Moneda_
		Fecha = Fecha_
		MontoVenta = MontoVenta_
		Estado = Status_
		MontoPagado = MontoPagado_
		CreadoPor = CobradoPor_
		NumeroVenta = NumeroVenta_
		CodigoCliente = CodigoCliente_
		Abono = Abono_
		NumeroPago = NumPagos
	End Sub

	''' <summary>
	''' Constructor sin params
	''' </summary>
	''' <remarks>19.03.2022 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		Id = 0
	End Sub

End Class
