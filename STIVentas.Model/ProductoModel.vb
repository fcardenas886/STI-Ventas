
''' <summary>
''' Model para productos
''' </summary>
''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ProductoModel : Implements IDBTable

	Private RecordId As Long
	Public Property IdArticulo As String
	Public Property Nombre As String
	Public Property Descripcion As String
	Public Property IdUnidad As String
	Public Property IdCategoria As String
	Public Property Marca As String
	Public Property UnidadPorCaja As Decimal
	Public Property PrecioVenta As Decimal
	Public Property PrecioCompra As Decimal

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
	''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		RecordId = 0
	End Sub

End Class
