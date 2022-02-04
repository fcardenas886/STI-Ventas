
''' <summary>
''' Model para grupo de proveedores
''' </summary>
''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class GrupoProveedorModel : Implements IDBTable

	Private RecordId As Long
	Public Property Grupo As String
	Public Property Nombre As String

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

	Sub New(ByVal Id_ As Integer, ByVal Grupo_ As String, ByVal Nombre_ As String)
		Me.Id = Id_
		Me.Grupo = Grupo_
		Me.Nombre = Nombre_
	End Sub
End Class
