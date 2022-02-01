
''' <summary>
''' Model para Unidades de medida
''' </summary>
''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class UnidadMedidaModel
    Private RecordId As Integer
    Private strUnidad As String
    Private strName As String

#Region "Constructor"
    Sub New(Id As Integer, unidad As String, nombre As String)
        Me.RecordId = Id
        Me.strUnidad = unidad
        Me.Nombre = nombre
    End Sub

    Sub New()
        Me.RecordId = 0
        Me.strUnidad = String.Empty
        Me.Nombre = String.Empty
    End Sub

#End Region

#Region "Propiedades"
    Public Property Nombre() As String
        Get
            Return strName
        End Get
        Set(ByVal value As String)
            strName = value
        End Set
    End Property

    Public Property Unidad() As String
        Get
            Return strUnidad
        End Get
        Set(ByVal value As String)
            strUnidad = value
        End Set
    End Property

    Public Property Id() As Integer
        Get
            Return RecordId
        End Get
        Set(ByVal value As Integer)
            RecordId = value
        End Set
    End Property
#End Region

End Class
