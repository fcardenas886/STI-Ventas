<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrdenCompra
    Inherits System.Windows.Forms.Form

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
        Me.GroupBoxLine = New System.Windows.Forms.GroupBox()
        Me.PanelLineActions = New System.Windows.Forms.Panel()
        Me.btnDeleteLine = New System.Windows.Forms.Button()
        Me.btnEditLine = New System.Windows.Forms.Button()
        Me.btnAddLine = New System.Windows.Forms.Button()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.txtItemId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBoxLineDetails = New System.Windows.Forms.GroupBox()
        Me.dgvLines = New System.Windows.Forms.DataGridView()
        Me.LineNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBoxHeader = New System.Windows.Forms.GroupBox()
        Me.PanelHeaderActions = New System.Windows.Forms.Panel()
        Me.btnGuardarOC = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dateTimeFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtOrdenProveedor = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVendorName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboProveedor = New System.Windows.Forms.ComboBox()
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOrdenCompraId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfirmarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelContainer.SuspendLayout()
        Me.GroupBoxLine.SuspendLayout()
        Me.PanelLineActions.SuspendLayout()
        Me.GroupBoxLineDetails.SuspendLayout()
        CType(Me.dgvLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxHeader.SuspendLayout()
        Me.PanelHeaderActions.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelContainer
        '
        Me.PanelContainer.Controls.Add(Me.GroupBoxLine)
        Me.PanelContainer.Controls.Add(Me.GroupBoxLineDetails)
        Me.PanelContainer.Controls.Add(Me.GroupBoxHeader)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 25)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(961, 482)
        Me.PanelContainer.TabIndex = 0
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Controls.Add(Me.PanelLineActions)
        Me.GroupBoxLine.Controls.Add(Me.txtItemName)
        Me.GroupBoxLine.Controls.Add(Me.txtItemId)
        Me.GroupBoxLine.Controls.Add(Me.Label2)
        Me.GroupBoxLine.Controls.Add(Me.Label3)
        Me.GroupBoxLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxLine.Location = New System.Drawing.Point(0, 140)
        Me.GroupBoxLine.Name = "GroupBoxLine"
        Me.GroupBoxLine.Size = New System.Drawing.Size(961, 149)
        Me.GroupBoxLine.TabIndex = 1
        Me.GroupBoxLine.TabStop = False
        Me.GroupBoxLine.Text = "Línea"
        '
        'PanelLineActions
        '
        Me.PanelLineActions.Controls.Add(Me.btnDeleteLine)
        Me.PanelLineActions.Controls.Add(Me.btnEditLine)
        Me.PanelLineActions.Controls.Add(Me.btnAddLine)
        Me.PanelLineActions.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelLineActions.Location = New System.Drawing.Point(799, 16)
        Me.PanelLineActions.Name = "PanelLineActions"
        Me.PanelLineActions.Size = New System.Drawing.Size(159, 130)
        Me.PanelLineActions.TabIndex = 9
        '
        'btnDeleteLine
        '
        Me.btnDeleteLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDeleteLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteLine.Location = New System.Drawing.Point(0, 47)
        Me.btnDeleteLine.Name = "btnDeleteLine"
        Me.btnDeleteLine.Size = New System.Drawing.Size(159, 38)
        Me.btnDeleteLine.TabIndex = 1
        Me.btnDeleteLine.Text = "Eliminar"
        Me.btnDeleteLine.UseVisualStyleBackColor = True
        '
        'btnEditLine
        '
        Me.btnEditLine.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnEditLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditLine.Location = New System.Drawing.Point(0, 85)
        Me.btnEditLine.Name = "btnEditLine"
        Me.btnEditLine.Size = New System.Drawing.Size(159, 45)
        Me.btnEditLine.TabIndex = 2
        Me.btnEditLine.Text = "Editar"
        Me.btnEditLine.UseVisualStyleBackColor = True
        '
        'btnAddLine
        '
        Me.btnAddLine.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAddLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddLine.Location = New System.Drawing.Point(0, 0)
        Me.btnAddLine.Name = "btnAddLine"
        Me.btnAddLine.Size = New System.Drawing.Size(159, 47)
        Me.btnAddLine.TabIndex = 0
        Me.btnAddLine.Text = "Agregar"
        Me.btnAddLine.UseVisualStyleBackColor = True
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(75, 47)
        Me.txtItemName.MaxLength = 100
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(224, 20)
        Me.txtItemName.TabIndex = 8
        '
        'txtItemId
        '
        Me.txtItemId.Location = New System.Drawing.Point(75, 21)
        Me.txtItemId.MaxLength = 20
        Me.txtItemId.Name = "txtItemId"
        Me.txtItemId.Size = New System.Drawing.Size(104, 20)
        Me.txtItemId.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Id artículo"
        '
        'GroupBoxLineDetails
        '
        Me.GroupBoxLineDetails.Controls.Add(Me.dgvLines)
        Me.GroupBoxLineDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBoxLineDetails.Location = New System.Drawing.Point(0, 289)
        Me.GroupBoxLineDetails.Name = "GroupBoxLineDetails"
        Me.GroupBoxLineDetails.Size = New System.Drawing.Size(961, 193)
        Me.GroupBoxLineDetails.TabIndex = 2
        Me.GroupBoxLineDetails.TabStop = False
        Me.GroupBoxLineDetails.Text = "Detalle de línea"
        '
        'dgvLines
        '
        Me.dgvLines.AllowUserToAddRows = False
        Me.dgvLines.AllowUserToDeleteRows = False
        Me.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LineNum, Me.ItemId, Me.ItemName, Me.Qty, Me.UnitPrice, Me.LineAmount})
        Me.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLines.Location = New System.Drawing.Point(3, 16)
        Me.dgvLines.Name = "dgvLines"
        Me.dgvLines.ReadOnly = True
        Me.dgvLines.Size = New System.Drawing.Size(955, 174)
        Me.dgvLines.TabIndex = 0
        '
        'LineNum
        '
        Me.LineNum.HeaderText = "Línea"
        Me.LineNum.Name = "LineNum"
        Me.LineNum.ReadOnly = True
        '
        'ItemId
        '
        Me.ItemId.HeaderText = "Id Artículo"
        Me.ItemId.Name = "ItemId"
        Me.ItemId.ReadOnly = True
        '
        'ItemName
        '
        Me.ItemName.HeaderText = "Nombre artículo"
        Me.ItemName.Name = "ItemName"
        Me.ItemName.ReadOnly = True
        '
        'Qty
        '
        Me.Qty.HeaderText = "Cantidad"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        '
        'UnitPrice
        '
        Me.UnitPrice.HeaderText = "Precio unitario"
        Me.UnitPrice.Name = "UnitPrice"
        Me.UnitPrice.ReadOnly = True
        '
        'LineAmount
        '
        Me.LineAmount.HeaderText = "Monto"
        Me.LineAmount.Name = "LineAmount"
        Me.LineAmount.ReadOnly = True
        '
        'GroupBoxHeader
        '
        Me.GroupBoxHeader.Controls.Add(Me.PanelHeaderActions)
        Me.GroupBoxHeader.Controls.Add(Me.Label13)
        Me.GroupBoxHeader.Controls.Add(Me.dateTimeFechaEntrega)
        Me.GroupBoxHeader.Controls.Add(Me.txtContacto)
        Me.GroupBoxHeader.Controls.Add(Me.Label12)
        Me.GroupBoxHeader.Controls.Add(Me.txtEmail)
        Me.GroupBoxHeader.Controls.Add(Me.Label11)
        Me.GroupBoxHeader.Controls.Add(Me.txtOrdenProveedor)
        Me.GroupBoxHeader.Controls.Add(Me.Label10)
        Me.GroupBoxHeader.Controls.Add(Me.txtVendorName)
        Me.GroupBoxHeader.Controls.Add(Me.Label9)
        Me.GroupBoxHeader.Controls.Add(Me.cboFormaPago)
        Me.GroupBoxHeader.Controls.Add(Me.Label7)
        Me.GroupBoxHeader.Controls.Add(Me.Label5)
        Me.GroupBoxHeader.Controls.Add(Me.cboMoneda)
        Me.GroupBoxHeader.Controls.Add(Me.cboEstatus)
        Me.GroupBoxHeader.Controls.Add(Me.Label4)
        Me.GroupBoxHeader.Controls.Add(Me.cboProveedor)
        Me.GroupBoxHeader.Controls.Add(Me.txtOrdenCompra)
        Me.GroupBoxHeader.Controls.Add(Me.Label6)
        Me.GroupBoxHeader.Controls.Add(Me.Label8)
        Me.GroupBoxHeader.Controls.Add(Me.txtOrdenCompraId)
        Me.GroupBoxHeader.Controls.Add(Me.Label1)
        Me.GroupBoxHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxHeader.Name = "GroupBoxHeader"
        Me.GroupBoxHeader.Size = New System.Drawing.Size(961, 140)
        Me.GroupBoxHeader.TabIndex = 0
        Me.GroupBoxHeader.TabStop = False
        Me.GroupBoxHeader.Text = "Encabezado"
        '
        'PanelHeaderActions
        '
        Me.PanelHeaderActions.Controls.Add(Me.btnGuardarOC)
        Me.PanelHeaderActions.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelHeaderActions.Location = New System.Drawing.Point(799, 16)
        Me.PanelHeaderActions.Name = "PanelHeaderActions"
        Me.PanelHeaderActions.Size = New System.Drawing.Size(159, 121)
        Me.PanelHeaderActions.TabIndex = 44
        '
        'btnGuardarOC
        '
        Me.btnGuardarOC.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnGuardarOC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardarOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarOC.Location = New System.Drawing.Point(0, 0)
        Me.btnGuardarOC.Name = "btnGuardarOC"
        Me.btnGuardarOC.Size = New System.Drawing.Size(159, 47)
        Me.btnGuardarOC.TabIndex = 1
        Me.btnGuardarOC.Text = "Guardar"
        Me.btnGuardarOC.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(539, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Fecha entrega"
        '
        'dateTimeFechaEntrega
        '
        Me.dateTimeFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTimeFechaEntrega.Location = New System.Drawing.Point(621, 19)
        Me.dateTimeFechaEntrega.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dateTimeFechaEntrega.Name = "dateTimeFechaEntrega"
        Me.dateTimeFechaEntrega.Size = New System.Drawing.Size(167, 20)
        Me.dateTimeFechaEntrega.TabIndex = 42
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(621, 70)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(167, 20)
        Me.txtContacto.TabIndex = 41
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(526, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Nombre contacto"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(621, 45)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(167, 20)
        Me.txtEmail.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(538, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Email contacto"
        '
        'txtOrdenProveedor
        '
        Me.txtOrdenProveedor.Location = New System.Drawing.Point(357, 96)
        Me.txtOrdenProveedor.Name = "txtOrdenProveedor"
        Me.txtOrdenProveedor.Size = New System.Drawing.Size(155, 20)
        Me.txtOrdenProveedor.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(264, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Orden proveedor"
        '
        'txtVendorName
        '
        Me.txtVendorName.Location = New System.Drawing.Point(85, 96)
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.Size = New System.Drawing.Size(167, 20)
        Me.txtVendorName.TabIndex = 35
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(35, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Nombre"
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(357, 69)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(155, 21)
        Me.cboFormaPago.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(287, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Forma Pago"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(305, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(357, 45)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(155, 21)
        Me.cboMoneda.TabIndex = 30
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.Enabled = False
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Location = New System.Drawing.Point(357, 19)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(155, 21)
        Me.cboEstatus.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(309, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Estatus"
        '
        'cboProveedor
        '
        Me.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Location = New System.Drawing.Point(85, 69)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(167, 21)
        Me.cboProveedor.TabIndex = 26
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Location = New System.Drawing.Point(85, 45)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(167, 20)
        Me.txtOrdenCompra.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Proveedor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Orden compra"
        '
        'txtOrdenCompraId
        '
        Me.txtOrdenCompraId.Cursor = System.Windows.Forms.Cursors.Help
        Me.txtOrdenCompraId.Location = New System.Drawing.Point(85, 19)
        Me.txtOrdenCompraId.MaxLength = 20
        Me.txtOrdenCompraId.Name = "txtOrdenCompraId"
        Me.txtOrdenCompraId.ReadOnly = True
        Me.txtOrdenCompraId.Size = New System.Drawing.Size(167, 20)
        Me.txtOrdenCompraId.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Consecutivo"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.AccionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(961, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
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
        Me.NuevoToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.NuevoToolStripMenuItem1.Text = "Nuevo"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'AccionesToolStripMenuItem
        '
        Me.AccionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfirmarToolStripMenuItem, Me.CancelarToolStripMenuItem})
        Me.AccionesToolStripMenuItem.Name = "AccionesToolStripMenuItem"
        Me.AccionesToolStripMenuItem.Size = New System.Drawing.Size(73, 21)
        Me.AccionesToolStripMenuItem.Text = "Acciones"
        '
        'ConfirmarToolStripMenuItem
        '
        Me.ConfirmarToolStripMenuItem.Name = "ConfirmarToolStripMenuItem"
        Me.ConfirmarToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ConfirmarToolStripMenuItem.Text = "Confirmar"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.CancelarToolStripMenuItem.Text = "Cancelar"
        '
        'FrmOrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 507)
        Me.Controls.Add(Me.PanelContainer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmOrdenCompra"
        Me.Text = "Orden de compra"
        Me.PanelContainer.ResumeLayout(False)
        Me.GroupBoxLine.ResumeLayout(False)
        Me.GroupBoxLine.PerformLayout()
        Me.PanelLineActions.ResumeLayout(False)
        Me.GroupBoxLineDetails.ResumeLayout(False)
        CType(Me.dgvLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxHeader.ResumeLayout(False)
        Me.GroupBoxHeader.PerformLayout()
        Me.PanelHeaderActions.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelContainer As Panel
    Friend WithEvents GroupBoxLineDetails As GroupBox
    Friend WithEvents GroupBoxLine As GroupBox
    Friend WithEvents GroupBoxHeader As GroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents NuevoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AccionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfirmarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dgvLines As DataGridView
    Friend WithEvents LineNum As DataGridViewTextBoxColumn
    Friend WithEvents ItemId As DataGridViewTextBoxColumn
    Friend WithEvents ItemName As DataGridViewTextBoxColumn
    Friend WithEvents Qty As DataGridViewTextBoxColumn
    Friend WithEvents UnitPrice As DataGridViewTextBoxColumn
    Friend WithEvents LineAmount As DataGridViewTextBoxColumn
    Friend WithEvents txtOrdenCompraId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents txtItemId As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelLineActions As Panel
    Friend WithEvents btnDeleteLine As Button
    Friend WithEvents btnEditLine As Button
    Friend WithEvents btnAddLine As Button
    Friend WithEvents cboFormaPago As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboMoneda As ComboBox
    Friend WithEvents cboEstatus As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboProveedor As ComboBox
    Friend WithEvents txtOrdenCompra As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dateTimeFechaEntrega As DateTimePicker
    Friend WithEvents txtContacto As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtOrdenProveedor As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtVendorName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents PanelHeaderActions As Panel
    Friend WithEvents btnGuardarOC As Button
End Class
