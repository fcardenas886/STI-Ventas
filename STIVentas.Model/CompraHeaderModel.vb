
''' <summary>
''' Model para OC
''' </summary>
''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class CompraHeaderModel : Implements IDBTable
	Private RecordId As Long
	Public Property NumeroCompra As String
	Public Property Moneda As String
	Public Property Nombre As String
	Public Property IdProveedor As String
	Public Property OrdenProveedor As String
	Public Property Estado As Byte
	Public Property FormaPago As String
	Public Property FechaEntrega As DateTime
	Public Property Correo As String
	Public Property Contacto As String

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

	Sub New(ByVal Id_ As Integer, ByVal NumeroCompra_ As String, ByVal Moneda_ As String, ByVal Nombre_ As String, ByVal IdProveedor_ As String, ByVal OrdenProveedor_ As String, ByVal Estado_ As Byte, ByVal FormaPago_ As String, ByVal FechaEntrega_ As DateTime, ByVal Correo_ As String, ByVal Contacto_ As String)
		Id = Id_
		NumeroCompra = NumeroCompra_
		Moneda = Moneda_
		Nombre = Nombre_
		IdProveedor = IdProveedor_
		OrdenProveedor = OrdenProveedor_
		Estado = Estado_
		FormaPago = FormaPago_
		FechaEntrega = FechaEntrega_
		Correo = Correo_
		Contacto = Contacto_
	End Sub
End Class
