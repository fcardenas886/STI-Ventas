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
        Me.txtOrdenCompraId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.PanelContainer.Size = New System.Drawing.Size(917, 482)
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
        Me.GroupBoxLine.Location = New System.Drawing.Point(0, 100)
        Me.GroupBoxLine.Name = "GroupBoxLine"
        Me.GroupBoxLine.Size = New System.Drawing.Size(917, 153)
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
        Me.PanelLineActions.Location = New System.Drawing.Point(755, 16)
        Me.PanelLineActions.Name = "PanelLineActions"
        Me.PanelLineActions.Size = New System.Drawing.Size(159, 134)
        Me.PanelLineActions.TabIndex = 9
        '
        'btnDeleteLine
        '
        Me.btnDeleteLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDeleteLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteLine.Location = New System.Drawing.Point(0, 47)
        Me.btnDeleteLine.Name = "btnDeleteLine"
        Me.btnDeleteLine.Size = New System.Drawing.Size(159, 42)
        Me.btnDeleteLine.TabIndex = 1
        Me.btnDeleteLine.Text = "Eliminar"
        Me.btnDeleteLine.UseVisualStyleBackColor = True
        '
        'btnEditLine
        '
        Me.btnEditLine.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnEditLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditLine.Location = New System.Drawing.Point(0, 89)
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
        Me.GroupBoxLineDetails.Location = New System.Drawing.Point(0, 253)
        Me.GroupBoxLineDetails.Name = "GroupBoxLineDetails"
        Me.GroupBoxLineDetails.Size = New System.Drawing.Size(917, 229)
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
        Me.dgvLines.Size = New System.Drawing.Size(911, 210)
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
        Me.GroupBoxHeader.Controls.Add(Me.txtOrdenCompraId)
        Me.GroupBoxHeader.Controls.Add(Me.Label1)
        Me.GroupBoxHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxHeader.Name = "GroupBoxHeader"
        Me.GroupBoxHeader.Size = New System.Drawing.Size(917, 100)
        Me.GroupBoxHeader.TabIndex = 0
        Me.GroupBoxHeader.TabStop = False
        Me.GroupBoxHeader.Text = "Encabezado"
        '
        'txtOrdenCompraId
        '
        Me.txtOrdenCompraId.Location = New System.Drawing.Point(75, 19)
        Me.txtOrdenCompraId.MaxLength = 20
        Me.txtOrdenCompraId.Name = "txtOrdenCompraId"
        Me.txtOrdenCompraId.Size = New System.Drawing.Size(104, 20)
        Me.txtOrdenCompraId.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Id orden"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.AccionesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(917, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem1, Me.EditarToolStripMenuItem, Me.EliminarToolStripMenuItem})
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
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
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
        Me.ConfirmarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ConfirmarToolStripMenuItem.Text = "Confirmar"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CancelarToolStripMenuItem.Text = "Cancelar"
        '
        'FrmOrdenCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 507)
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
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
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
End Class
