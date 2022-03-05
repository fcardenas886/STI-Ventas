
''' <summary>
''' Model para categorias de productos
''' </summary>
''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class CategoriaModel : Implements IDBTable

	Private RecordId As Long
	Public Property IdCategoria As String
	Public Property Nombre As String
	Public Property Activo As Boolean

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

	Sub New(Id_ As Integer, IdCategoria_ As String, Nombre_ As String, Activo_ As Boolean)
		Id = Id_
		IdCategoria = IdCategoria_
		Nombre = Nombre_
		Activo = Activo_
	End Sub
End Class
