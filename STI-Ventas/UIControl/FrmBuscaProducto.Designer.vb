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
        Me.GroupBoxDetails = New System.Windows.Forms.GroupBox()
        Me.dgvListPage = New System.Windows.Forms.DataGridView()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.GroupBoxFilters = New System.Windows.Forms.GroupBox()
        Me.GroupBoxButtonActions = New System.Windows.Forms.GroupBox()
        Me.btnSeleccionarRegistro = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.GroupBoxDetails.SuspendLayout()
        CType(Me.dgvListPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContainer.SuspendLayout()
        Me.GroupBoxButtonActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxDetails
        '
        Me.GroupBoxDetails.Controls.Add(Me.dgvListPage)
        Me.GroupBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxDetails.Location = New System.Drawing.Point(0, 100)
        Me.GroupBoxDetails.Name = "GroupBoxDetails"
        Me.GroupBoxDetails.Size = New System.Drawing.Size(800, 350)
        Me.GroupBoxDetails.TabIndex = 3
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
        Me.dgvListPage.Size = New System.Drawing.Size(794, 331)
        Me.dgvListPage.TabIndex = 0
        '
        'PanelContainer
        '
        Me.PanelContainer.Controls.Add(Me.GroupBoxFilters)
        Me.PanelContainer.Controls.Add(Me.GroupBoxButtonActions)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(800, 100)
        Me.PanelContainer.TabIndex = 2
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
        'GroupBoxButtonActions
        '
        Me.GroupBoxButtonActions.Controls.Add(Me.btnSeleccionarRegistro)
        Me.GroupBoxButtonActions.Controls.Add(Me.btnFiltrar)
        Me.GroupBoxButtonActions.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBoxButtonActions.Location = New System.Drawing.Point(600, 0)
        Me.GroupBoxButtonActions.Name = "GroupBoxButtonActions"
        Me.GroupBoxButtonActions.Size = New System.Drawing.Size(200, 100)
        Me.GroupBoxButtonActions.TabIndex = 0
        Me.GroupBoxButtonActions.TabStop = False
        Me.GroupBoxButtonActions.Text = "Opciones"
        '
        'btnSeleccionarRegistro
        '
        Me.btnSeleccionarRegistro.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSeleccionarRegistro.Location = New System.Drawing.Point(43, 50)
        Me.btnSeleccionarRegistro.Name = "btnSeleccionarRegistro"
        Me.btnSeleccionarRegistro.Size = New System.Drawing.Size(75, 23)
        Me.btnSeleccionarRegistro.TabIndex = 1
        Me.btnSeleccionarRegistro.Text = "Seleccionar"
        Me.btnSeleccionarRegistro.UseVisualStyleBackColor = True
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
        'FrmBuscaProducto
        '
        Me.AcceptButton = Me.btnFiltrar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSeleccionarRegistro
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBoxDetails)
        Me.Controls.Add(Me.PanelContainer)
        Me.Name = "FrmBuscaProducto"
        Me.Text = "Productos disponibles"
        Me.GroupBoxDetails.ResumeLayout(False)
        CType(Me.dgvListPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContainer.ResumeLayout(False)
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
End Class
