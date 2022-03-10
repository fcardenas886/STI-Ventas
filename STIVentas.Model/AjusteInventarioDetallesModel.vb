
''' <summary>
''' Model para las líneas de ajuste de inventario.
''' </summary>
''' <remarks>06.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class AjusteInventarioDetallesModel : Implements IDBTable

	Private RecordId As Long

	Public Property IdAjuste As Integer
	Public Property IdArticulo As String
	Public Property IdProducto As Integer
	Public Property Unidad As String
	Public Property Cantidad As Decimal
	Public Property NumeroLinea As Integer
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
	''' Constructor default
	''' </summary>
	''' <remarks>06.03.2022 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		RecordId = 0
	End Sub

	Sub New(Id_ As Integer, IdAjuste_ As Integer, IdArticulo_ As String, IdProducto_ As Integer, Unidad_ As String, Cantidad_ As Decimal, NumeroLinea_ As Integer, Descripcion_ As String)
		Me.Id = Id_
		Me.IdAjuste = IdAjuste_
		Me.IdArticulo = IdArticulo_
		Me.IdProducto = IdProducto_
		Me.Unidad = Unidad_
		Me.Cantidad = Cantidad_
		Me.NumeroLinea = NumeroLinea_
		Me.Descripcion = Descripcion_
	End Sub

	Public Sub InitFromProductoModel(producto As ProductoModel)
		IdArticulo = producto.IdArticulo
		IdProducto = producto.Id
		Unidad = producto.IdUnidad
	End Sub
End Class