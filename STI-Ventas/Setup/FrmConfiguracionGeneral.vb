
Imports STIVentas.Model
Imports STIVentas.Controller
''' <summary>
''' Configuración general del sistema
''' </summary>
''' <remarks>24.02.2022 jorge.nin92@gmail.com: Se crea el form</remarks>
Public Class FrmConfiguracionGeneral

#Region "Properties"
    Protected CurrentConfiguration As ConfiguracionModel
    Dim IsLoaded As Boolean
#End Region

#Region "Constructor"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetAndSetDefaultSettings()
    End Sub
#End Region

#Region "ClassMethods"
    Protected Sub LoadComboBoxData()
        Try
            Cursor = Cursors.WaitCursor

            FillClienteComboBox(Me, cboIdCliente)
            FillCurrencyComboBox(Me, cboMoneda)
            FillFormaPagoComboBox(Me, cboFormaPagoVentas)

            If Not IsLoaded Then
                GetAndSetDefaultSettings()
            End If
            SetDefaultSettings()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Protected Sub GetAndSetDefaultSettings()
        Dim controller As ConfiguracionController
        Dim model As ConfiguracionModel
        Dim resetCursor As Boolean

        Try
            If Cursor <> Cursors.WaitCursor Then
                Cursor = Cursors.WaitCursor
                resetCursor = True
            End If

            controller = New ConfiguracionController()
            model = controller.Find()

            If model IsNot Nothing Then
                CurrentConfiguration = model
                IsLoaded = True
            End If

            If Not String.IsNullOrEmpty(controller.LastError) And (model?.Id Is Nothing Or model?.Id = 0) Then
                HandleException(controller.LastError)
                IsLoaded = False
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            If resetCursor Then
                Cursor = Cursors.Default
            End If
        End Try
    End Sub

    Protected Sub SetDefaultSettings()

        Try
            If CurrentConfiguration IsNot Nothing Then
                If CurrentConfiguration.IdClienteMostrador > 0 Then
                    SetClienteValue(CurrentConfiguration.IdClienteMostrador.ToString())
                End If

                SetMonedaValue(CurrentConfiguration.Moneda)
                SetFormaPagoVentasValue(CurrentConfiguration.FormaPagoVentas)
            End If

        Catch ex As Exception
            HandleException(ex)
        End Try
    End Sub

    Public Sub SetClienteValue(value As String)

        If String.IsNullOrEmpty(value) Then
            cboIdCliente.SelectedValue = -1
        ElseIf ComboBoxContainTablaBaseIdValue(cboIdCliente, value) Then
            cboIdCliente.SelectedValue = value
        Else
            FillClienteComboBox(Me, cboIdCliente)
            If ComboBoxContainTablaBaseIdValue(cboIdCliente, value) Then
                cboIdCliente.SelectedValue = value
            Else
                HandleException(String.Format("No se encontro el cliente {0} en la base de datos", value))
            End If
        End If
    End Sub

    Public Sub SetMonedaValue(value As String)

        If String.IsNullOrEmpty(value) Then
            cboMoneda.SelectedValue = -1
        ElseIf ComboBoxContainTablaBaseIdValue(cboMoneda, value) Then
            cboMoneda.SelectedValue = value
        Else
            FillCurrencyComboBox(Me, cboMoneda)
            If ComboBoxContainTablaBaseIdValue(cboMoneda, value) Then
                cboMoneda.SelectedValue = value
            Else
                HandleException(String.Format("No se encontro la moneda {0} en la base de datos", value))
            End If
        End If
    End Sub

    Public Sub SetFormaPagoVentasValue(value As String)

        If String.IsNullOrEmpty(value) Then
            cboFormaPagoVentas.SelectedValue = -1
        ElseIf ComboBoxContainTablaBaseIdValue(cboFormaPagoVentas, value) Then
            cboFormaPagoVentas.SelectedValue = value
        Else
            FillCurrencyComboBox(Me, cboFormaPagoVentas)
            If ComboBoxContainTablaBaseIdValue(cboFormaPagoVentas, value) Then
                cboFormaPagoVentas.SelectedValue = value
            Else
                HandleException(String.Format("No se encontro la forma de pago {0} en la base de datos", value))
            End If
        End If
    End Sub

    Protected Function GetCurrentConfiguration() As ConfiguracionModel

        Try
            If CurrentConfiguration Is Nothing Then
                CurrentConfiguration = New ConfiguracionModel()
            End If
            CurrentConfiguration.IdClienteMostrador = CType(cboIdCliente.SelectedValue, Integer)
            CurrentConfiguration.Moneda = cboMoneda.SelectedValue
            CurrentConfiguration.FormaPagoVentas = cboFormaPagoVentas.SelectedValue
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try
        Return CurrentConfiguration
    End Function

    Protected Sub Upsert()
        Dim controller As ConfiguracionController
        Dim model As ConfiguracionModel
        Dim isOK As Boolean

        Try
            Cursor = Cursors.WaitCursor
            model = GetCurrentConfiguration()

            controller = New ConfiguracionController()

            If model.Id > 0 Then
                isOK = controller.Update(model)
            Else
                isOK = controller.Insert(model)
            End If

            If Not isOK Then
                HandleError(controller.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


#End Region

#Region "Events"
    Private Sub FrmConfiguracionGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComboBoxData()
    End Sub

    Private Sub btnGuardarOC_Click(sender As Object, e As EventArgs) Handles btnGuardarOC.Click
        Upsert()
    End Sub
#End Region
End Class