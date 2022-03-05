
''' <summary>
''' Model para cobros de OV
''' </summary>
''' <remarks>17.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class CobroVentasModel : Implements IDBTable

	Private RecordId As Long
	Public Property IdVenta As String
	Public Property FormaPago As String
	Public Property Monto As Decimal
	Public Property Fecha As String
	Public Property Moneda As String
	Public Property Credito As Decimal
	Public Property Propina As Decimal
	Public Property Vuelto As Decimal
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

	Sub New(ByVal Id_ As Integer, ByVal IdVenta_ As String, ByVal FormaPago_ As String, ByVal Monto_ As Decimal, ByVal Fecha_ As String, ByVal Moneda_ As String, ByVal Credito_ As Decimal, ByVal Propina_ As Decimal, ByVal Vuelto_ As Decimal, ByVal IdUsuario_ As Integer)
		Me.Id = Id_
		Me.IdVenta = IdVenta_
		Me.FormaPago = FormaPago_
		Me.Monto = Monto_
		Me.Fecha = Fecha_
		Me.Moneda = Moneda_
		Me.Credito = Credito_
		Me.Propina = Propina_
		Me.Vuelto = Vuelto_
		Me.IdUsuario = IdUsuario_
	End Sub
End Class
