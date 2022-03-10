<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjusteInventario
    Inherits Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.GroupBoxLineDetails = New System.Windows.Forms.GroupBox()
        Me.dgvLines = New System.Windows.Forms.DataGridView()
        Me.GroupBoxLine = New System.Windows.Forms.GroupBox()
        Me.cboUnidad = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnSeleccionarArticulo = New System.Windows.Forms.Button()
        Me.PanelLineActions = New System.Windows.Forms.Panel()
        Me.btnDeleteLine = New System.Windows.Forms.Button()
        Me.btnEditLine = New System.Windows.Forms.Button()
        Me.btnAddLine = New System.Windows.Forms.Button()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.txtItemId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBoxHeader = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtNumeroAjuste = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcionAjuste = New System.Windows.Forms.TextBox()
        Me.txtIdAjuste = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnGuardarHeader = New System.Windows.Forms.Button()
        Me.MenuStripMain = New System.Windows.Forms.MenuStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelContainer.SuspendLayout()
        Me.GroupBoxLineDetails.SuspendLayout()
        CType(Me.dgvLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxLine.SuspendLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLineActions.SuspendLayout()
        Me.GroupBoxHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.MenuStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.White
        Me.PanelContainer.Controls.Add(Me.GroupBoxLineDetails)
        Me.PanelContainer.Controls.Add(Me.GroupBoxLine)
        Me.PanelContainer.Controls.Add(Me.GroupBoxHeader)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 25)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(1105, 425)
        Me.PanelContainer.TabIndex = 0
        '
        'GroupBoxLineDetails
        '
        Me.GroupBoxLineDetails.Controls.Add(Me.dgvLines)
        Me.GroupBoxLineDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxLineDetails.Location = New System.Drawing.Point(0, 211)
        Me.GroupBoxLineDetails.Name = "GroupBoxLineDetails"
        Me.GroupBoxLineDetails.Size = New System.Drawing.Size(1105, 214)
        Me.GroupBoxLineDetails.TabIndex = 3
        Me.GroupBoxLineDetails.TabStop = False
        Me.GroupBoxLineDetails.Text = "Detalle de línea"
        '
        'dgvLines
        '
        Me.dgvLines.AllowUserToAddRows = False
        Me.dgvLines.AllowUserToDeleteRows = False
        Me.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.LineNum, Me.ItemId, Me.ItemName, Me.Qty, Me.Unidad, Me.IdProducto})
        Me.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLines.Location = New System.Drawing.Point(3, 16)
        Me.dgvLines.Name = "dgvLines"
        Me.dgvLines.ReadOnly = True
        Me.dgvLines.Size = New System.Drawing.Size(1099, 195)
        Me.dgvLines.TabIndex = 0
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Controls.Add(Me.cboUnidad)
        Me.GroupBoxLine.Controls.Add(Me.Label15)
        Me.GroupBoxLine.Controls.Add(Me.txtCantidad)
        Me.GroupBoxLine.Controls.Add(Me.Label14)
        Me.GroupBoxLine.Controls.Add(Me.btnSeleccionarArticulo)
        Me.GroupBoxLine.Controls.Add(Me.PanelLineActions)
        Me.GroupBoxLine.Controls.Add(Me.txtItemName)
        Me.GroupBoxLine.Controls.Add(Me.txtItemId)
        Me.GroupBoxLine.Controls.Add(Me.Label2)
        Me.GroupBoxLine.Controls.Add(Me.Label3)
        Me.GroupBoxLine.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxLine.Location = New System.Drawing.Point(0, 73)
        Me.GroupBoxLine.MaximumSize = New System.Drawing.Size(2000, 138)
        Me.GroupBoxLine.MinimumSize = New System.Drawing.Size(961, 138)
        Me.GroupBoxLine.Name = "GroupBoxLine"
        Me.GroupBoxLine.Size = New System.Drawing.Size(1105, 138)
        Me.GroupBoxLine.TabIndex = 2
        Me.GroupBoxLine.TabStop = False
        Me.GroupBoxLine.Text = "Línea"
        '
        'cboUnidad
        '
        Me.cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidad.FormattingEnabled = True
        Me.cboUnidad.Location = New System.Drawing.Point(494, 54)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(138, 21)
        Me.cboUnidad.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(491, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 17)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Unidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtCantidad.Location = New System.Drawing.Point(670, 54)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(151, 23)
        Me.txtCantidad.TabIndex = 12
        Me.txtCantidad.ThousandsSeparator = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(667, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 17)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Cantidad"
        '
        'btnSeleccionarArticulo
        '
        Me.btnSeleccionarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSeleccionarArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionarArticulo.Location = New System.Drawing.Point(148, 52)
        Me.btnSeleccionarArticulo.Name = "btnSeleccionarArticulo"
        Me.btnSeleccionarArticulo.Size = New System.Drawing.Size(86, 25)
        Me.btnSeleccionarArticulo.TabIndex = 10
        Me.btnSeleccionarArticulo.Text = "&Buscar"
        Me.btnSeleccionarArticulo.UseVisualStyleBackColor = True
        '
        'PanelLineActions
        '
        Me.PanelLineActions.Controls.Add(Me.btnDeleteLine)
        Me.PanelLineActions.Controls.Add(Me.btnEditLine)
        Me.PanelLineActions.Controls.Add(Me.btnAddLine)
        Me.PanelLineActions.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelLineActions.Location = New System.Drawing.Point(902, 16)
        Me.PanelLineActions.Name = "PanelLineActions"
        Me.PanelLineActions.Size = New System.Drawing.Size(200, 119)
        Me.PanelLineActions.TabIndex = 9
        '
        'btnDeleteLine
        '
        Me.btnDeleteLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDeleteLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteLine.Location = New System.Drawing.Point(0, 41)
        Me.btnDeleteLine.Name = "btnDeleteLine"
        Me.btnDeleteLine.Size = New System.Drawing.Size(200, 39)
        Me.btnDeleteLine.TabIndex = 101
        Me.btnDeleteLine.Text = "Elimina&r"
        Me.btnDeleteLine.UseVisualStyleBackColor = True
        '
        'btnEditLine
        '
        Me.btnEditLine.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnEditLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditLine.Location = New System.Drawing.Point(0, 80)
        Me.btnEditLine.Name = "btnEditLine"
        Me.btnEditLine.Size = New System.Drawing.Size(200, 39)
        Me.btnEditLine.TabIndex = 102
        Me.btnEditLine.Text = "&Editar"
        Me.btnEditLine.UseVisualStyleBackColor = True
        '
        'btnAddLine
        '
        Me.btnAddLine.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAddLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddLine.Location = New System.Drawing.Point(0, 0)
        Me.btnAddLine.Name = "btnAddLine"
        Me.btnAddLine.Size = New System.Drawing.Size(200, 41)
        Me.btnAddLine.TabIndex = 100
        Me.btnAddLine.Text = "&Agregar"
        Me.btnAddLine.UseVisualStyleBackColor = True
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(252, 54)
        Me.txtItemName.MaxLength = 100
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(213, 20)
        Me.txtItemName.TabIndex = 8
        '
        'txtItemId
        '
        Me.txtItemId.Location = New System.Drawing.Point(16, 54)
        Me.txtItemId.MaxLength = 20
        Me.txtItemId.Name = "txtItemId"
        Me.txtItemId.Size = New System.Drawing.Size(128, 20)
        Me.txtItemId.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(249, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(13, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Id artículo"
        '
        'GroupBoxHeader
        '
        Me.GroupBoxHeader.Controls.Add(Me.Panel2)
        Me.GroupBoxHeader.Controls.Add(Me.Panel3)
        Me.GroupBoxHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxHeader.Name = "GroupBoxHeader"
        Me.GroupBoxHeader.Size = New System.Drawing.Size(1105, 73)
        Me.GroupBoxHeader.TabIndex = 0
        Me.GroupBoxHeader.TabStop = False
        Me.GroupBoxHeader.Text = "Encabezado"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtNumeroAjuste)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtDescripcionAjuste)
        Me.Panel2.Controls.Add(Me.txtIdAjuste)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(899, 54)
        Me.Panel2.TabIndex = 42
        '
        'txtNumeroAjuste
        '
        Me.txtNumeroAjuste.Location = New System.Drawing.Point(313, 14)
        Me.txtNumeroAjuste.Name = "txtNumeroAjuste"
        Me.txtNumeroAjuste.Size = New System.Drawing.Size(167, 20)
        Me.txtNumeroAjuste.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Consecutivo"
        '
        'txtDescripcionAjuste
        '
        Me.txtDescripcionAjuste.Location = New System.Drawing.Point(573, 14)
        Me.txtDescripcionAjuste.Name = "txtDescripcionAjuste"
        Me.txtDescripcionAjuste.Size = New System.Drawing.Size(320, 20)
        Me.txtDescripcionAjuste.TabIndex = 2
        '
        'txtIdAjuste
        '
        Me.txtIdAjuste.Cursor = System.Windows.Forms.Cursors.Help
        Me.txtIdAjuste.Location = New System.Drawing.Point(82, 14)
        Me.txtIdAjuste.MaxLength = 20
        Me.txtIdAjuste.Name = "txtIdAjuste"
        Me.txtIdAjuste.ReadOnly = True
        Me.txtIdAjuste.Size = New System.Drawing.Size(167, 20)
        Me.txtIdAjuste.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(263, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Número"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(504, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Descripción"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnGuardarHeader)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(902, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 54)
        Me.Panel3.TabIndex = 43
        '
        'btnGuardarHeader
        '
        Me.btnGuardarHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnGuardarHeader.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardarHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarHeader.Location = New System.Drawing.Point(0, 0)
        Me.btnGuardarHeader.Name = "btnGuardarHeader"
        Me.btnGuardarHeader.Size = New System.Drawing.Size(200, 47)
        Me.btnGuardarHeader.TabIndex = 101
        Me.btnGuardarHeader.Text = "&Guardar"
        Me.btnGuardarHeader.UseVisualStyleBackColor = True
        '
        'MenuStripMain
        '
        Me.MenuStripMain.AllowMerge = False
        Me.MenuStripMain.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStripMain.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.InventarioToolStripMenuItem})
        Me.MenuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMain.Name = "MenuStripMain"
        Me.MenuStripMain.Size = New System.Drawing.Size(1105, 25)
        Me.MenuStripMain.TabIndex = 1
        Me.MenuStripMain.Text = "MenuStrip1"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem1, Me.EliminarToolStripMenuItem})
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(63, 21)
        Me.NuevoToolStripMenuItem.Text = "Edición"
        '
        'NuevoToolStripMenuItem1
        '
        Me.NuevoToolStripMenuItem1.Name = "NuevoToolStripMenuItem1"
        Me.NuevoToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.NuevoToolStripMenuItem1.Text = "Nuevo"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'InventarioToolStripMenuItem
        '
        Me.InventarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarToolStripMenuItem})
        Me.InventarioToolStripMenuItem.Name = "InventarioToolStripMenuItem"
        Me.InventarioToolStripMenuItem.Size = New System.Drawing.Size(82, 21)
        Me.InventarioToolStripMenuItem.Text = "Inventario"
        '
        'RegistrarToolStripMenuItem
        '
        Me.RegistrarToolStripMenuItem.Name = "RegistrarToolStripMenuItem"
        Me.RegistrarToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.RegistrarToolStripMenuItem.Text = "Registrar"
        '
        'Id
        '
        Me.Id.Frozen = True
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        '
        'LineNum
        '
        Me.LineNum.Frozen = True
        Me.LineNum.HeaderText = "Línea"
        Me.LineNum.Name = "LineNum"
        Me.LineNum.ReadOnly = True
        Me.LineNum.Width = 70
        '
        'ItemId
        '
        Me.ItemId.HeaderText = "Id Artículo"
        Me.ItemId.Name = "ItemId"
        Me.ItemId.ReadOnly = True
        Me.ItemId.Width = 150
        '
        'ItemName
        '
        Me.ItemName.HeaderText = "Descripción"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        Me.ItemName.Width = 200
        '
        'Qty
        '
        Me.Qty.HeaderText = "Cantidad"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 150
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.ReadOnly = True
        Me.Unidad.Width = 140
        '
        'IdProducto
        '
        Me.IdProducto.HeaderText = "IdProducto"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.ReadOnly = True
        Me.IdProducto.Visible = False
        '
        'FrmAjusteInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 450)
        Me.Controls.Add(Me.PanelContainer)
        Me.Controls.Add(Me.MenuStripMain)
        Me.Name = "FrmAjusteInventario"
        Me.Text = "Ajustes de inventario"
        Me.PanelContainer.ResumeLayout(False)
        Me.GroupBoxLineDetails.ResumeLayout(False)
        CType(Me.dgvLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxLine.ResumeLayout(False)
        Me.GroupBoxLine.PerformLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLineActions.ResumeLayout(False)
        Me.GroupBoxHeader.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.MenuStripMain.ResumeLayout(False)
        Me.MenuStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelContainer As Panel
    Friend WithEvents GroupBoxHeader As GroupBox
    Friend WithEvents txtDescripcionAjuste As TextBox
    Friend WithEvents txtNumeroAjuste As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtIdAjuste As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBoxLine As GroupBox
    Friend WithEvents cboUnidad As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCantidad As NumericUpDown
    Friend WithEvents Label14 As Label
    Friend WithEvents btnSeleccionarArticulo As Button
    Friend WithEvents PanelLineActions As Panel
    Friend WithEvents btnDeleteLine As Button
    Friend WithEvents btnEditLine As Button
    Friend WithEvents btnAddLine As Button
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents txtItemId As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBoxLineDetails As GroupBox
    Friend WithEvents dgvLines As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnGuardarHeader As Button
    Friend WithEvents MenuStripMain As MenuStrip
    Friend WithEvents NuevoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents LineNum As DataGridViewTextBoxColumn
    Friend WithEvents ItemId As DataGridViewTextBoxColumn
    Friend WithEvents ItemName As DataGridViewTextBoxColumn
    Friend WithEvents Qty As DataGridViewTextBoxColumn
    Friend WithEvents Unidad As DataGridViewTextBoxColumn
    Friend WithEvents IdProducto As DataGridViewTextBoxColumn
End Class
