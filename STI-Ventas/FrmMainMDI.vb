Imports STIVentas.Controller

''' <summary>
''' MDI principal
''' </summary>
''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class FrmMainMDI
#Region "Events"
    Private Sub FrmMainMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitControls()
    End Sub

    Private Sub toolStripUnitOfMeasure_Click(sender As Object, e As EventArgs) Handles toolStripUnitOfMeasure.Click
        Dim child As Form = New FrmUnitOfMeasure
        child.MdiParent = Me
        child.Show()
    End Sub

    '' <remarks>03.02.2021 jorge.nin92@gmail.com: Add grupo de proveedores</remarks>
    Private Sub GrupoDeProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrupoDeProveedoresToolStripMenuItem.Click
        Dim child As Form = New FrmGrupoProveedor With {
            .MdiParent = Me
        }
        child.Show()
    End Sub

    '' <remarks>03.02.2021 jorge.nin92@gmail.com: Add Monedas</remarks>
    Private Sub MonedasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonedasToolStripMenuItem.Click
        Dim child As Form = New FrmMoneda With {
            .MdiParent = Me
        }
        child.Show()
    End Sub

#End Region

#Region "Class methods"

    ''' <summary>
    ''' Inicializa estilos
    ''' </summary>
    ''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el metodo</remarks>
    Protected Sub InitControls()
        Me.Text = GetPOSName()
    End Sub

#End Region
End Class