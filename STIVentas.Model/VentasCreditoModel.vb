''' <summary>
''' Model para llevar las ventas a credito
''' </summary>
''' <remarks>15.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class VentasCreditoModel : Implements IDBTable

	Private RecordId As Long

	Public Property Id As Long Implements IDBTable.RecordId
		Get
			Return RecordId
		End Get
		Set(value As Long)
			RecordId = value
		End Set
	End Property

	Public Property IdCliente As Integer
	Public Property IdVenta As Integer
	Public Property Moneda As String
	Public Property CodigoCliente As String
	Public Property Fecha As DateTime
	Public Property Monto As Decimal
	Public Property Abono As Decimal
	Public Property Estado As EstadoVentaCredito
	Public Property MontoPagado As Decimal
	Public Property CobradoPor As Integer

	Sub New(Id_ As Int64, IdCliente_ As Integer, Moneda_ As String, Fecha_ As DateTime, Monto_ As Decimal, Status_ As EstadoVentaCredito, MontoPagado_ As Decimal, CobradoPor_ As Integer,
			IdVenta_ As Integer, CodigoCliente_ As String, Abono_ As Decimal)
		Id = Id_
		IdCliente = IdCliente_
		Moneda = Moneda_
		Fecha = Fecha_
		Monto = Monto_
		Estado = Status_
		MontoPagado = MontoPagado_
		CobradoPor = CobradoPor_
		IdVenta = IdVenta_
		CodigoCliente = CodigoCliente_
		Abono = Abono_
	End Sub

	''' <summary>
	''' Constructor sin params
	''' </summary>
	''' <remarks>15.03.2022 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		RecordId = 0
	End Sub

End Class
