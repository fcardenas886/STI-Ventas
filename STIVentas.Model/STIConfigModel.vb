''' <summary>
''' Model para configuración dinamica
''' </summary>
''' <remarks>24.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class STIConfigModel : Implements IDBTable

	Private RecordId As Long
	Public Property clave As String
	Public Property valor As String

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

	Sub New(id_ As Integer, clave_ As String, valor_ As String)
		Me.Id = id_
		Me.clave = clave_
		Me.valor = valor_
	End Sub
End Class
