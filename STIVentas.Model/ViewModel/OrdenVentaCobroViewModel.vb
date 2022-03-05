''' <summary>
''' Model usado para cobrar una OV
''' </summary>
''' <remarks>03.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class OrdenVentaCobroViewModel

	Public Id As Long
	Public Property Referencia As String
	Public Property Fecha As Date
	Public Property Moneda As String
	Public Property FormaPago As String
	Public Property Total As Decimal
	Public Property Vuelto As Decimal
	Public Property Credito As Decimal
	Public Property Propina As Decimal
	Public Property IdUsuario As Integer
	Public Property ResultadoSP As Integer

	''' <summary>
	''' Constructor sin params
	''' </summary>
	''' <remarks>03.03.2022 jorge.nin92@gmail.com: Se agrega constructor vacio</remarks>
	Sub New()
		Id = 0
	End Sub

#Region "DB Helpers"
	Public Sub InitFromOrdenVentaModel(ventaModel As OrdenVentaModel)
		Id = ventaModel.Id
		Referencia = ventaModel.GetReference
		Moneda = ventaModel.Moneda
		FormaPago = ventaModel.FormaPago
		Total = ventaModel.Total
		IdUsuario = ventaModel.IdUsuario
	End Sub

	Public Sub InitFromOrdenVentaTotales(totals As OrdenVentaTotales)
		Total = totals.Total
	End Sub

	Public Sub InitValue()
		Total = 0
		Fecha = Date.Today
	End Sub

	Public Function GetReference() As String

		If Not String.IsNullOrEmpty(Referencia) Then
			Return Referencia
		End If

		Dim reference As String = "OV" & Id.ToString("D8")

		Return reference
	End Function
#End Region
End Class
