
''' <summary>
''' Model para proveedores
''' </summary>
''' <remarks>03.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ProveedorModel : Implements IDBTable

	Private RecordId As Long
	Public Property IdProveedor As String
	Public Property Nombre As String
	Public Property AliasName As String
	Public Property Direccion As String
	Public Property Grupo As String
	Public Property RUT As String
	Public Property Moneda As String
	Public Property Telefono As String
	Public Property Email As String
	Public Property Contacto As String
	Public Property FormaPago As String

	Public Property Id As Long Implements IDBTable.RecordId
		Get
			Return RecordId
		End Get
		Set(value As Long)
			RecordId = value
		End Set
	End Property

	Sub New(ByVal Id_ As Integer, ByVal IdProveedor_ As String, ByVal Nombre_ As String, ByVal AliasName_ As String, ByVal Direccion_ As String, ByVal Grupo_ As String, ByVal RUT_ As String, ByVal Moneda_ As String, ByVal Telefono_ As String, ByVal Email_ As String, ByVal Contacto_ As String, ByVal FormaPago_ As String)
		Id = Id_
		IdProveedor = IdProveedor_
		Nombre = Nombre_
		AliasName = AliasName_
		Direccion = Direccion_
		Grupo = Grupo_
		RUT = RUT_
		Moneda = Moneda_
		Telefono = Telefono_
		Email = Email_
		Contacto = Contacto_
		FormaPago = FormaPago_
	End Sub
End Class
