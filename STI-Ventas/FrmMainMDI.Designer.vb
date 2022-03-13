<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMainMDI
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusMDI = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfigurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripUnitOfMeasure = New System.Windows.Forms.ToolStripMenuItem()
        Me.GrupoDeProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonedasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormaDePagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoriasDeProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValoresDefaultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodasLasOrdenesDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaccionesDeInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjustesDeInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodosLosAjustesDeInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PuntoDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodasLasVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusUserName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusMDI, Me.ToolStripStatusLabel2, Me.ToolStripStatusUserName})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 424)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 26)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 20)
        '
        'ToolStripStatusMDI
        '
        Me.ToolStripStatusMDI.Name = "ToolStripStatusMDI"
        Me.ToolStripStatusMDI.Size = New System.Drawing.Size(48, 21)
        Me.ToolStripStatusMDI.Text = "En línea"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurarToolStripMenuItem, Me.ComprasToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.ToolStripMenuItem1, Me.VentasToolStripMenuItem, Me.ToolStripMenuItem2})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfigurarToolStripMenuItem
        '
        Me.ConfigurarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripUnitOfMeasure, Me.GrupoDeProveedoresToolStripMenuItem, Me.MonedasToolStripMenuItem, Me.FormaDePagoToolStripMenuItem, Me.ProveedoresToolStripMenuItem, Me.CategoriasDeProductosToolStripMenuItem, Me.ProductosToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.ValoresDefaultToolStripMenuItem})
        Me.ConfigurarToolStripMenuItem.Name = "ConfigurarToolStripMenuItem"
        Me.ConfigurarToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.ConfigurarToolStripMenuItem.Text = "Configurar"
        '
        'toolStripUnitOfMeasure
        '
        Me.toolStripUnitOfMeasure.Name = "toolStripUnitOfMeasure"
        Me.toolStripUnitOfMeasure.Size = New System.Drawing.Size(203, 22)
        Me.toolStripUnitOfMeasure.Text = "Unidades de medida"
        '
        'GrupoDeProveedoresToolStripMenuItem
        '
        Me.GrupoDeProveedoresToolStripMenuItem.Name = "GrupoDeProveedoresToolStripMenuItem"
        Me.GrupoDeProveedoresToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.GrupoDeProveedoresToolStripMenuItem.Text = "Grupo de proveedores"
        '
        'MonedasToolStripMenuItem
        '
        Me.MonedasToolStripMenuItem.Name = "MonedasToolStripMenuItem"
        Me.MonedasToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.MonedasToolStripMenuItem.Text = "Monedas"
        '
        'FormaDePagoToolStripMenuItem
        '
        Me.FormaDePagoToolStripMenuItem.Name = "FormaDePagoToolStripMenuItem"
        Me.FormaDePagoToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FormaDePagoToolStripMenuItem.Text = "Forma de pago"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'CategoriasDeProductosToolStripMenuItem
        '
        Me.CategoriasDeProductosToolStripMenuItem.Name = "CategoriasDeProductosToolStripMenuItem"
        Me.CategoriasDeProductosToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CategoriasDeProductosToolStripMenuItem.Text = "Categorías de productos"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'ValoresDefaultToolStripMenuItem
        '
        Me.ValoresDefaultToolStripMenuItem.Name = "ValoresDefaultToolStripMenuItem"
        Me.ValoresDefaultToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ValoresDefaultToolStripMenuItem.Text = "Valores default"
        '
        'ComprasToolStripMenuItem
        '
        Me.ComprasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TodasLasOrdenesDeCompraToolStripMenuItem, Me.NuevaCompraToolStripMenuItem})
        Me.ComprasToolStripMenuItem.Name = "ComprasToolStripMenuItem"
        Me.ComprasToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.ComprasToolStripMenuItem.Text = "Compras"
        '
        'TodasLasOrdenesDeCompraToolStripMenuItem
        '
        Me.TodasLasOrdenesDeCompraToolStripMenuItem.Name = "TodasLasOrdenesDeCompraToolStripMenuItem"
        Me.TodasLasOrdenesDeCompraToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.TodasLasOrdenesDeCompraToolStripMenuItem.Text = "Todas las ordenes de compra"
        '
        'NuevaCompraToolStripMenuItem
        '
        Me.NuevaCompraToolStripMenuItem.Name = "NuevaCompraToolStripMenuItem"
        Me.NuevaCompraToolStripMenuItem.Size = New System.Drawing.Size(226, 22)
        Me.NuevaCompraToolStripMenuItem.Text = "Nueva compra"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsultasToolStripMenuItem1, Me.AjustesDeInventarioToolStripMenuItem, Me.TodosLosAjustesDeInventarioToolStripMenuItem})
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.ConsultasToolStripMenuItem.Text = "Inventario"
        '
        'ConsultasToolStripMenuItem1
        '
        Me.ConsultasToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransaccionesDeInventarioToolStripMenuItem})
        Me.ConsultasToolStripMenuItem1.Name = "ConsultasToolStripMenuItem1"
        Me.ConsultasToolStripMenuItem1.Size = New System.Drawing.Size(236, 22)
        Me.ConsultasToolStripMenuItem1.Text = "Consultas"
        '
        'TransaccionesDeInventarioToolStripMenuItem
        '
        Me.TransaccionesDeInventarioToolStripMenuItem.Name = "TransaccionesDeInventarioToolStripMenuItem"
        Me.TransaccionesDeInventarioToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.TransaccionesDeInventarioToolStripMenuItem.Text = "Transacciones de inventario"
        '
        'AjustesDeInventarioToolStripMenuItem
        '
        Me.AjustesDeInventarioToolStripMenuItem.Name = "AjustesDeInventarioToolStripMenuItem"
        Me.AjustesDeInventarioToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.AjustesDeInventarioToolStripMenuItem.Text = "Ajustes de inventario"
        '
        'TodosLosAjustesDeInventarioToolStripMenuItem
        '
        Me.TodosLosAjustesDeInventarioToolStripMenuItem.Name = "TodosLosAjustesDeInventarioToolStripMenuItem"
        Me.TodosLosAjustesDeInventarioToolStripMenuItem.Size = New System.Drawing.Size(236, 22)
        Me.TodosLosAjustesDeInventarioToolStripMenuItem.Text = "Todos los Ajustes de inventario"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PuntoDeVentasToolStripMenuItem, Me.TodasLasVentasToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        '
        'PuntoDeVentasToolStripMenuItem
        '
        Me.PuntoDeVentasToolStripMenuItem.Name = "PuntoDeVentasToolStripMenuItem"
        Me.PuntoDeVentasToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.PuntoDeVentasToolStripMenuItem.Text = "Punto de Ventas"
        '
        'TodasLasVentasToolStripMenuItem
        '
        Me.TodasLasVentasToolStripMenuItem.Name = "TodasLasVentasToolStripMenuItem"
        Me.TodasLasVentasToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.TodasLasVentasToolStripMenuItem.Text = "Todas las ventas"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(12, 20)
        '
        'ToolStripStatusUserName
        '
        Me.ToolStripStatusUserName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusUserName.Name = "ToolStripStatusUserName"
        Me.ToolStripStatusUserName.Size = New System.Drawing.Size(86, 21)
        Me.ToolStripStatusUserName.Text = "Id usuario"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(67, 21)
        Me.ToolStripStatusLabel2.Text = "Usuario:"
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmMainMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.STI_Ventas.My.Resources.Resources.MDI
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMainMDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMainMDI"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents ToolStripStatusMDI As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ConfigurarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripUnitOfMeasure As ToolStripMenuItem
    Friend WithEvents GrupoDeProveedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MonedasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodasLasOrdenesDeCompraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaCompraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FormaDePagoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CategoriasDeProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TransaccionesDeInventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PuntoDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ValoresDefaultToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodasLasVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjustesDeInventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodosLosAjustesDeInventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusUserName As ToolStripStatusLabel
    Private WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
End Class
