Imports STIVentas.Controller

''' <summary>
''' MDI principal
''' </summary>
''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class FrmMainMDI

#Region "Properties"
    Public Shared Property ID_USUARIO As Integer
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Se agrega constructor para dar un usuario por default
    ''' </summary>
    ''' <remarks>18.02.2022 jorge.nin92@gmail.com: Se crea constructor</remarks>
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ID_USUARIO = 3
    End Sub

    ''' <summary>
    ''' Se agregan constructor para aceptar el usuario que inicia sesión
    ''' </summary>
    ''' <param name="userId">Id de usuario</param>
    ''' <remarks>18.02.2022 jorge.nin92@gmail.com: Se crea contructor</remarks>
    Public Sub New(userId As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ID_USUARIO = userId
    End Sub
#End Region

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

    '' <remarks>05.02.2021 jorge.nin92@gmail.com: Add Monedas</remarks>
    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Dim child As Form = New FrmProveedor With {
            .MdiParent = Me
        }
        child.Show()
    End Sub

    '' <remarks>05.02.2021 jorge.nin92@gmail.com: Add ListPageOC</remarks>
    Private Sub TodasLasOrdenesDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodasLasOrdenesDeCompraToolStripMenuItem.Click
        Dim child As Form = New FrmComprasListPage With {
            .MdiParent = Me
        }
        child.Show()
    End Sub

    '' <remarks>05.02.2021 jorge.nin92@gmail.com: Add Ordens compra</remarks>
    Private Sub NuevaCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaCompraToolStripMenuItem.Click
        Dim child As Form = New FrmOrdenCompra With {
            .MdiParent = Me
        }
        child.Show()
    End Sub

    Private Sub FormaDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormaDePagoToolStripMenuItem.Click
        Dim child As Form = New FrmFormaPago With {
            .MdiParent = Me
        }
        child.Show()
    End Sub

    Private Sub CategoriasDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriasDeProductosToolStripMenuItem.Click
        Dim child As Form = New FrmCategoriaProducto With {
            .MdiParent = Me
        }
        child.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim child As Form = New FrmProductos With {
            .MdiParent = Me
        }
        child.Show()
    End Sub

    Private Sub TransaccionesDeInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaccionesDeInventarioToolStripMenuItem.Click
        Dim child As Form = New FrmTransaccionInventarioListPage With {
           .MdiParent = Me
       }
        child.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click

        Dim child As Form = New FrmCliente With {
           .MdiParent = Me
       }
        child.Show()

    End Sub

    Private Sub PuntoDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PuntoDeVentasToolStripMenuItem.Click

        Dim child As Form = New FrmVentaPOS With {
           .MdiParent = Me,
           .WindowState = FormWindowState.Maximized
       }
        child.Show()

    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click

        Dim child As Form = New FrmUsuario With {
           .MdiParent = Me
       }
        child.Show()

    End Sub

    Private Sub ValoresDefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ValoresDefaultToolStripMenuItem.Click
        Dim child As Form = New FrmConfiguracionGeneral With {
           .MdiParent = Me
       }
        child.Show()
    End Sub

    Private Sub TodasLasVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodasLasVentasToolStripMenuItem.Click
        Dim child As Form = New FrmVentasListPage With {
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