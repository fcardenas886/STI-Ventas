''' <summary>
''' Model para configuración del sistema
''' </summary>
''' <remarks>24.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ConfiguracionModel : Implements IDBTable

	Private RecordId As Long

	Public Property IdClienteMostrador As Integer
	Public Property Moneda As String
	Public Property FormaPagoVentas As String

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
	''' <remarks>24.02.2021 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		RecordId = 0
	End Sub

	Sub New(ByVal Id_ As Integer, ByVal IdClienteMostrador_ As Integer, ByVal Moneda_ As String, formaPagoVenta As String)
		Me.Id = Id_
		Me.IdClienteMostrador = IdClienteMostrador_
		Me.Moneda = Moneda_
		FormaPagoVentas = formaPagoVenta
	End Sub
End Class
