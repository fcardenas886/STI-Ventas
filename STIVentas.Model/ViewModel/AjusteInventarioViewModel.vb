
''' <summary>
''' Model para listpage de ajuste de inventario.
''' </summary>
''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class AjusteInventarioViewModel

	Public Property Id As Integer
	Public Property Numero As String
	Public Property Descripcion As String
	Public Property Registrado As Boolean
	Public Property FechaRegistro As DateTime
	Public Property CreadoPor As String
	Public Property RegistradoPor As String

	''' <summary>
	''' Constructor default
	''' </summary>
	''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		Id = 0
	End Sub

	Sub New(Id_ As Integer, Numero_ As String, Descripcion_ As String, Registrado_ As Boolean, FechaRegistro_ As DateTime, CreadoPor_ As String, RegistradoPor_ As String)
		Id = Id_
		Numero = Numero_
		Descripcion = Descripcion_
		Registrado = Registrado_
		FechaRegistro = FechaRegistro_
		CreadoPor = CreadoPor_
		RegistradoPor = RegistradoPor_
	End Sub

End Class
