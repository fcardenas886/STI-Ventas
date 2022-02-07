
''' <summary>
''' Model para formas de pago
''' </summary>
''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class FormaPagoModel : Implements IDBTable

	Private RecordId As Long
	Public Property IdFormaPago As String
	Public Property Descripcion As String

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
	''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		RecordId = 0
	End Sub

	Sub New(Id_ As Integer, formaPago As String, Nombre_ As String)
		Me.Id = Id_
		Me.IdFormaPago = formaPago
		Me.Descripcion = Nombre_
	End Sub
End Class
