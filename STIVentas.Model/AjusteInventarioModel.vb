
''' <summary>
''' Model para los de ajuste de inventario. Base para cargar disponible.
''' </summary>
''' <remarks>06.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class AjusteInventarioModel : Implements IDBTable

	Private RecordId As Long
	Public Property Numero As String
	Public Property Descripcion As String
	Public Property Registrado As Boolean
	Public Property FechaRegistro As DateTime
	Public Property CreadoPor As Integer
	Public Property RegistradoPor As Integer

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

	Sub New(Id_ As Integer, Numero_ As String, Descripcion_ As String, Registrado_ As Boolean, FechaRegistro_ As DateTime, CreadoPor_ As Integer, RegistradoPor_ As Integer)
		Me.Id = Id_
		Me.Numero = Numero_
		Me.Descripcion = Descripcion_
		Me.Registrado = Registrado_
		Me.FechaRegistro = FechaRegistro_
		Me.CreadoPor = CreadoPor_
		Me.RegistradoPor = RegistradoPor_
	End Sub

	Public Function GetReference() As String
		Dim reference As String

		If Id.ToString() = Numero OrElse String.IsNullOrEmpty(Numero) Then
			reference = "INV" & Id.ToString("D8")
		Else
			reference = Numero
		End If

		Return reference
	End Function

End Class
