
''' <summary>
''' Model para monedas
''' </summary>
''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class MonedaModel : Implements IDBTable

	Private RecordId As Long
	Public Property CodigoMoneda As String
	Public Property Nombre As String
	Public Property Descripcion As String
	Public Property Simbolo As String
	Public Property CodigoISO As String
	Public Property Redondear As Boolean
	Public Property TipoRedondeo As TipoRedondeoMoneda
	Public Property RedondeoVentas As TipoRedondeoMoneda
	Public Property RedondeoCompras As TipoRedondeoMoneda
	Public Property RedondeoInventario As TipoRedondeoMoneda
	Public Property RedondearCompras As Boolean
	Public Property RedondearVentas As Boolean
	Public Property RedondearInventario As Boolean

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

	Sub New(ByVal Id_ As Integer, ByVal CodigoMoneda_ As String, ByVal Nombre_ As String, ByVal Descripcion_ As String, ByVal Simbolo_ As String, ByVal CodigoISO_ As String,
			ByVal Redondear_ As Boolean, ByVal TipoRedondeo_ As TipoRedondeoMoneda, ByVal RedondeoVentas_ As TipoRedondeoMoneda, ByVal RedondeoCompras_ As TipoRedondeoMoneda, ByVal RedondeoInventario_ As TipoRedondeoMoneda,
			ByVal RedondearCompras_ As Boolean, ByVal RedondearVentas_ As Boolean, ByVal RedondearInventario_ As Boolean)
		Id = Id_
		CodigoMoneda = CodigoMoneda_
		Nombre = Nombre_
		Descripcion = Descripcion_
		Simbolo = Simbolo_
		CodigoISO = CodigoISO_
		Redondear = Redondear_
		TipoRedondeo = TipoRedondeo_
		RedondeoVentas = RedondeoVentas_
		RedondeoCompras = RedondeoCompras_
		RedondeoInventario = RedondeoInventario_
		RedondearCompras = RedondearCompras_
		RedondearVentas = RedondearVentas_
		RedondearInventario = RedondearInventario_
	End Sub
End Class
