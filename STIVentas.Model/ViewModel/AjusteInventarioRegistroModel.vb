
''' <summary>
''' Model para el registro de ajuste de inventario.
''' </summary>
''' <remarks>09.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class AjusteInventarioRegistroModel

	Public Property Id As Integer
	Public Property Referencia As String
	Public Property RegistradoPor As Integer
	Public Property ResultadoSP As Integer

	''' <summary>
	''' Constructor default
	''' </summary>
	''' <remarks>07.03.2022 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		Id = 0
	End Sub

	Public Sub InitFromAjusteInventario(ajusteInventario As AjusteInventarioModel)
		Id = ajusteInventario.Id
		Referencia = ajusteInventario.GetReference()
	End Sub

	Public Function GetReference() As String

		If Not String.IsNullOrEmpty(Referencia) Then
			Return Referencia
		End If

		Dim reference As String = "OV" & Id.ToString("D8")

		Return reference
	End Function

End Class
