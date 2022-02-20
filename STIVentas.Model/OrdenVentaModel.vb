
''' <summary>
''' Model para header de OV
''' </summary>
''' <remarks>17.02.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class OrdenVentaModel : Implements IDBTable

	Private RecordId As Long
	Public Property NumeroVenta As String
	Public Property Cliente As String
	Public Property Nombre As String
	Public Property Estado As EstadoOrdenVenta
	Public Property OrdenCliente As String
	Public Property Fecha As DateTime
	Public Property FormaPago As String
	Public Property Correo As String
	Public Property Contacto As String
	Public Property Total As Decimal
	Public Property FechaCreacion As DateTime
	Public Property Moneda As String
	Public Property IdUsuario As Integer

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

	Sub New(ByVal Id_ As Integer, ByVal NumeroVenta_ As String, ByVal Cliente_ As String, ByVal Nombre_ As String, ByVal Estado_ As EstadoOrdenVenta,
			ByVal OrdenCliente_ As String, ByVal Fecha_ As DateTime, ByVal FormaPago_ As String, ByVal Correo_ As String,
			ByVal Contacto_ As String, ByVal Total_ As Decimal, ByVal FechaCreacion_ As DateTime, ByVal Moneda_ As String, ByVal IdUsuario_ As Integer)
		Me.Id = Id_
		Me.NumeroVenta = NumeroVenta_
		Me.Cliente = Cliente_
		Me.Nombre = Nombre_
		Me.Estado = Estado_
		Me.OrdenCliente = OrdenCliente_
		Me.Fecha = Fecha_
		Me.FormaPago = FormaPago_
		Me.Correo = Correo_
		Me.Contacto = Contacto_
		Me.Total = Total_
		Me.FechaCreacion = FechaCreacion_
		Me.Moneda = Moneda_
		Me.IdUsuario = IdUsuario_
	End Sub

End Class
