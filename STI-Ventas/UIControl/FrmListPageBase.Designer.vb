<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmListPageBase
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
        Me.GroupBoxFilters = New System.Windows.Forms.GroupBox()
        Me.GroupBoxDetails = New System.Windows.Forms.GroupBox()
        Me.dgvListPage = New System.Windows.Forms.DataGridView()
        Me.MenuStripMainActions = New System.Windows.Forms.MenuStrip()
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.GroupBoxButtonActions = New System.Windows.Forms.GroupBox()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.GroupBoxDetails.SuspendLayout()
        CType(Me.dgvListPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStripMainActions.SuspendLayout()
        Me.PanelContainer.SuspendLayout()
        Me.GroupBoxButtonActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxFilters
        '
        Me.GroupBoxFilters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxFilters.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxFilters.Name = "GroupBoxFilters"
        Me.GroupBoxFilters.Size = New System.Drawing.Size(600, 100)
        Me.GroupBoxFilters.TabIndex = 0
        Me.GroupBoxFilters.TabStop = False
        Me.GroupBoxFilters.Text = "Filtros"
        '
        'GroupBoxDetails
        '
        Me.GroupBoxDetails.Controls.Add(Me.dgvListPage)
        Me.GroupBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxDetails.Location = New System.Drawing.Point(0, 125)
        Me.GroupBoxDetails.Name = "GroupBoxDetails"
        Me.GroupBoxDetails.Size = New System.Drawing.Size(800, 325)
        Me.GroupBoxDetails.TabIndex = 1
        Me.GroupBoxDetails.TabStop = False
        Me.GroupBoxDetails.Text = "Detalles"
        '
        'dgvListPage
        '
        Me.dgvListPage.AllowUserToAddRows = False
        Me.dgvListPage.AllowUserToDeleteRows = False
        Me.dgvListPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListPage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvListPage.Location = New System.Drawing.Point(3, 16)
        Me.dgvListPage.Name = "dgvListPage"
        Me.dgvListPage.ReadOnly = True
        Me.dgvListPage.Size = New System.Drawing.Size(794, 306)
        Me.dgvListPage.TabIndex = 0
        '
        'MenuStripMainActions
        '
        Me.MenuStripMainActions.AllowMerge = False
        Me.MenuStripMainActions.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStripMainActions.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStripMainActions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.AccionesToolStripMenuItem})
        Me.MenuStripMainActions.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripMainActions.Name = "MenuStripMainActions"
        Me.MenuStripMainActions.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStripMainActions.Size = New System.Drawing.Size(800, 25)
        Me.MenuStripMainActions.TabIndex = 2
        Me.MenuStripMainActions.Text = "Menú"
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
        Me.NuevoToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.NuevoToolStripMenuItem1.Text = "Nuevo"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'AccionesToolStripMenuItem
        '
        Me.AccionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.AccionesToolStripMenuItem.Name = "AccionesToolStripMenuItem"
        Me.AccionesToolStripMenuItem.Size = New System.Drawing.Size(73, 21)
        Me.AccionesToolStripMenuItem.Text = "Acciones"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'PanelContainer
        '
        Me.PanelContainer.Controls.Add(Me.GroupBoxFilters)
        Me.PanelContainer.Controls.Add(Me.GroupBoxButtonActions)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelContainer.Location = New System.Drawing.Point(0, 25)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(800, 100)
        Me.PanelContainer.TabIndex = 0
        '
        'GroupBoxButtonActions
        '
        Me.GroupBoxButtonActions.Controls.Add(Me.btnCerrar)
        Me.GroupBoxButtonActions.Controls.Add(Me.btnFiltrar)
        Me.GroupBoxButtonActions.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBoxButtonActions.Location = New System.Drawing.Point(600, 0)
        Me.GroupBoxButtonActions.Name = "GroupBoxButtonActions"
        Me.GroupBoxButtonActions.Size = New System.Drawing.Size(200, 100)
        Me.GroupBoxButtonActions.TabIndex = 0
        Me.GroupBoxButtonActions.TabStop = False
        Me.GroupBoxButtonActions.Text = "Opciones"
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(43, 50)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(43, 20)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btnFiltrar.TabIndex = 0
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'FrmListPageBase
        '
        Me.AcceptButton = Me.btnFiltrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBoxDetails)
        Me.Controls.Add(Me.PanelContainer)
        Me.Controls.Add(Me.MenuStripMainActions)
        Me.Name = "FrmListPageBase"
        Me.Text = "Lista de datos"
        Me.GroupBoxDetails.ResumeLayout(False)
        CType(Me.dgvListPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStripMainActions.ResumeLayout(False)
        Me.MenuStripMainActions.PerformLayout()
        Me.PanelContainer.ResumeLayout(False)
        Me.GroupBoxButtonActions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBoxDetails As GroupBox
    Friend WithEvents dgvListPage As DataGridView
    Protected Friend WithEvents AccionesToolStripMenuItem As ToolStripMenuItem
    Protected Friend WithEvents GroupBoxFilters As GroupBox
    Protected Friend WithEvents MenuStripMainActions As MenuStrip
    Friend WithEvents GroupBoxButtonActions As GroupBox
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnFiltrar As Button
    Protected Friend WithEvents PanelContainer As Panel
    Protected Friend WithEvents NuevoToolStripMenuItem As ToolStripMenuItem
    Protected Friend WithEvents NuevoToolStripMenuItem1 As ToolStripMenuItem
    Protected Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Protected Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Protected Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
End Class
