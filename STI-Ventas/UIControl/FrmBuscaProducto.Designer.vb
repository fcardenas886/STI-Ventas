Imports STIVentas.Model

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBuscaProducto
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBoxDetails = New System.Windows.Forms.GroupBox()
        Me.dgvListPage = New System.Windows.Forms.DataGridView()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadPorCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.GroupBoxFilters = New System.Windows.Forms.GroupBox()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.txtItemId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBoxButtonActions = New System.Windows.Forms.GroupBox()
        Me.btnSeleccionarRegistro = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.GroupBoxDetails.SuspendLayout()
        CType(Me.dgvListPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContainer.SuspendLayout()
        Me.GroupBoxFilters.SuspendLayout()
        Me.GroupBoxButtonActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxDetails
        '
        Me.GroupBoxDetails.Controls.Add(Me.dgvListPage)
        Me.GroupBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxDetails.Location = New System.Drawing.Point(0, 72)
        Me.GroupBoxDetails.Name = "GroupBoxDetails"
        Me.GroupBoxDetails.Size = New System.Drawing.Size(1082, 378)
        Me.GroupBoxDetails.TabIndex = 3
        Me.GroupBoxDetails.TabStop = False
        Me.GroupBoxDetails.Text = "Detalles"
        '
        'dgvListPage
        '
        Me.dgvListPage.AllowUserToAddRows = False
        Me.dgvListPage.AllowUserToDeleteRows = False
        Me.dgvListPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListPage.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProducto, Me.IdArticulo, Me.Nombre, Me.Descripcion, Me.Unidad, Me.IdCategoria, Me.UnidadPorCaja, Me.PrecioVenta, Me.PrecioCompra, Me.Marca})
        Me.dgvListPage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvListPage.Location = New System.Drawing.Point(3, 16)
        Me.dgvListPage.Name = "dgvListPage"
        Me.dgvListPage.ReadOnly = True
        Me.dgvListPage.Size = New System.Drawing.Size(1076, 359)
        Me.dgvListPage.TabIndex = 0
        '
        'IdProducto
        '
        Me.IdProducto.HeaderText = "Id"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.ReadOnly = True
        '
        'IdArticulo
        '
        Me.IdArticulo.HeaderText = "Id Artículo"
        Me.IdArticulo.Name = "IdArticulo"
        Me.IdArticulo.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.ReadOnly = True
        '
        'IdCategoria
        '
        Me.IdCategoria.HeaderText = "Categoría"
        Me.IdCategoria.Name = "IdCategoria"
        Me.IdCategoria.ReadOnly = True
        '
        'UnidadPorCaja
        '
        DataGridViewCellStyle1.Format = "N2"
        Me.UnidadPorCaja.DefaultCellStyle = DataGridViewCellStyle1
        Me.UnidadPorCaja.HeaderText = "Unidad Por Caja"
        Me.UnidadPorCaja.Name = "UnidadPorCaja"
        Me.UnidadPorCaja.ReadOnly = True
        '
        'PrecioVenta
        '
        DataGridViewCellStyle2.Format = "N2"
        Me.PrecioVenta.DefaultCellStyle = DataGridViewCellStyle2
        Me.PrecioVenta.HeaderText = "Precio Venta"
        Me.PrecioVenta.Name = "PrecioVenta"
        Me.PrecioVenta.ReadOnly = True
        '
        'PrecioCompra
        '
        DataGridViewCellStyle3.Format = "N2"
        Me.PrecioCompra.DefaultCellStyle = DataGridViewCellStyle3
        Me.PrecioCompra.HeaderText = "Precio Compra"
        Me.PrecioCompra.Name = "PrecioCompra"
        Me.PrecioCompra.ReadOnly = True
        '
        'Marca
        '
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        Me.Marca.ReadOnly = True
        '
        'PanelContainer
        '
        Me.PanelContainer.Controls.Add(Me.GroupBoxFilters)
        Me.PanelContainer.Controls.Add(Me.GroupBoxButtonActions)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(1082, 72)
        Me.PanelContainer.TabIndex = 2
        '
        'GroupBoxFilters
        '
        Me.GroupBoxFilters.Controls.Add(Me.txtItemName)
        Me.GroupBoxFilters.Controls.Add(Me.txtItemId)
        Me.GroupBoxFilters.Controls.Add(Me.Label2)
        Me.GroupBoxFilters.Controls.Add(Me.Label3)
        Me.GroupBoxFilters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxFilters.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxFilters.Name = "GroupBoxFilters"
        Me.GroupBoxFilters.Size = New System.Drawing.Size(882, 72)
        Me.GroupBoxFilters.TabIndex = 0
        Me.GroupBoxFilters.TabStop = False
        Me.GroupBoxFilters.Text = "Filtros"
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(326, 29)
        Me.txtItemName.MaxLength = 100
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(251, 20)
        Me.txtItemName.TabIndex = 14
        '
        'txtItemId
        '
        Me.txtItemId.Location = New System.Drawing.Point(73, 29)
        Me.txtItemId.MaxLength = 20
        Me.txtItemId.Name = "txtItemId"
        Me.txtItemId.Size = New System.Drawing.Size(178, 20)
        Me.txtItemId.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(276, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Id artículo"
        '
        'GroupBoxButtonActions
        '
        Me.GroupBoxButtonActions.Controls.Add(Me.btnSeleccionarRegistro)
        Me.GroupBoxButtonActions.Controls.Add(Me.btnFiltrar)
        Me.GroupBoxButtonActions.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBoxButtonActions.Location = New System.Drawing.Point(882, 0)
        Me.GroupBoxButtonActions.Name = "GroupBoxButtonActions"
        Me.GroupBoxButtonActions.Size = New System.Drawing.Size(200, 72)
        Me.GroupBoxButtonActions.TabIndex = 0
        Me.GroupBoxButtonActions.TabStop = False
        Me.GroupBoxButtonActions.Text = "Opciones"
        '
        'btnSeleccionarRegistro
        '
        Me.btnSeleccionarRegistro.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSeleccionarRegistro.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSeleccionarRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSeleccionarRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSeleccionarRegistro.Location = New System.Drawing.Point(3, 39)
        Me.btnSeleccionarRegistro.Name = "btnSeleccionarRegistro"
        Me.btnSeleccionarRegistro.Size = New System.Drawing.Size(194, 23)
        Me.btnSeleccionarRegistro.TabIndex = 1
        Me.btnSeleccionarRegistro.Text = "&Seleccionar"
        Me.btnSeleccionarRegistro.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnFiltrar.Location = New System.Drawing.Point(3, 16)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(194, 23)
        Me.btnFiltrar.TabIndex = 0
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'FrmBuscaProducto
        '
        Me.AcceptButton = Me.btnFiltrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSeleccionarRegistro
        Me.ClientSize = New System.Drawing.Size(1082, 450)
        Me.Controls.Add(Me.GroupBoxDetails)
        Me.Controls.Add(Me.PanelContainer)
        Me.Name = "FrmBuscaProducto"
        Me.Text = "Productos disponibles"
        Me.GroupBoxDetails.ResumeLayout(False)
        CType(Me.dgvListPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContainer.ResumeLayout(False)
        Me.GroupBoxFilters.ResumeLayout(False)
        Me.GroupBoxFilters.PerformLayout()
        Me.GroupBoxButtonActions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBoxDetails As GroupBox
    Friend WithEvents dgvListPage As DataGridView
    Friend WithEvents PanelContainer As Panel
    Protected Friend WithEvents GroupBoxFilters As GroupBox
    Friend WithEvents GroupBoxButtonActions As GroupBox
    Friend WithEvents btnSeleccionarRegistro As Button
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents txtItemId As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents IdProducto As DataGridViewTextBoxColumn
    Friend WithEvents IdArticulo As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Unidad As DataGridViewTextBoxColumn
    Friend WithEvents IdCategoria As DataGridViewTextBoxColumn
    Friend WithEvents UnidadPorCaja As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVenta As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCompra As DataGridViewTextBoxColumn
    Friend WithEvents Marca As DataGridViewTextBoxColumn
End Class
