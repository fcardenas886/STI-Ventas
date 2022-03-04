''' <summary>
''' Clase para la ayuda. By jorge.nin92@gmail.com
''' </summary>
Public Class TextBoxPlaceHolder
    Inherits TextBox
#Region "Porperties"
    Private Const WM_PAINT As Int32 = &HF

    Private DefaultMessage As String
    Public Property PlaceHolder() As String
        Get
            Return DefaultMessage
        End Get
        Set(value As String)
            DefaultMessage = value
        End Set
    End Property
#End Region

#Region "Contructor"
    Public Sub New()
        MyBase.New()
        DefaultMessage = "Ingresa un valor"
    End Sub

    Public Sub New(placeHolder As String)
        MyBase.New()
        DefaultMessage = placeHolder
    End Sub
#End Region

#Region "Class methods"
    Protected Overrides Sub WndProc(ByRef message As Message)
        MyBase.WndProc(message)

        If message.Msg = WM_PAINT AndAlso Me.TextLength = 0 Then
            Using g = Me.CreateGraphics
                g.DrawString(DefaultMessage, Me.Font, Brushes.Gray, 1, 1)
            End Using
        Else
            ForeColor = Color.Black
        End If
    End Sub
#End Region
End Class