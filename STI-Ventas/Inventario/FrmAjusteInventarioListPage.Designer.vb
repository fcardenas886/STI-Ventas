<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjusteInventarioListPage
    Inherits FrmListPageBase

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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboUsuario = New System.Windows.Forms.ComboBox()
        Me.chkEnableStatusFilter = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.RegistrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBoxFilters.SuspendLayout()
        Me.PanelContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxFilters
        '
        Me.GroupBoxFilters.Controls.Add(Me.txtDescripcion)
        Me.GroupBoxFilters.Controls.Add(Me.Label5)
        Me.GroupBoxFilters.Controls.Add(Me.cboUsuario)
        Me.GroupBoxFilters.Controls.Add(Me.chkEnableStatusFilter)
        Me.GroupBoxFilters.Controls.Add(Me.cboEstatus)
        Me.GroupBoxFilters.Controls.Add(Me.Label3)
        Me.GroupBoxFilters.Controls.Add(Me.txtOrdenCompra)
        Me.GroupBoxFilters.Controls.Add(Me.Label2)
        Me.GroupBoxFilters.Controls.Add(Me.Label1)
        Me.GroupBoxFilters.Size = New System.Drawing.Size(600, 89)
        '
        'PanelContainer
        '
        Me.PanelContainer.Size = New System.Drawing.Size(800, 89)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(361, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Creado por"
        '
        'cboUsuario
        '
        Me.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsuario.FormattingEnabled = True
        Me.cboUsuario.Location = New System.Drawing.Point(426, 52)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(155, 21)
        Me.cboUsuario.TabIndex = 30
        '
        'chkEnableStatusFilter
        '
        Me.chkEnableStatusFilter.AutoSize = True
        Me.chkEnableStatusFilter.Location = New System.Drawing.Point(410, 31)
        Me.chkEnableStatusFilter.Name = "chkEnableStatusFilter"
        Me.chkEnableStatusFilter.Size = New System.Drawing.Size(15, 14)
        Me.chkEnableStatusFilter.TabIndex = 29
        Me.chkEnableStatusFilter.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(362, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Estatus"
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Location = New System.Drawing.Point(94, 28)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(167, 20)
        Me.txtOrdenCompra.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Número ajuste"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(94, 52)
        Me.txtDescripcion.MaxLength = 150
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(249, 20)
        Me.txtDescripcion.TabIndex = 34
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Items.AddRange(New Object() {"No registrado", "Registrado"})
        Me.cboEstatus.Location = New System.Drawing.Point(426, 28)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(155, 21)
        Me.cboEstatus.TabIndex = 28
        '
        'RegistrarToolStripMenuItem
        '
        Me.RegistrarToolStripMenuItem.Name = "RegistrarToolStripMenuItem"
        Me.RegistrarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RegistrarToolStripMenuItem.Text = "Registrar"
        '
        'FrmAjusteInventarioListPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Name = "FrmAjusteInventarioListPage"
        Me.Text = "Ajustes de Inventario"
        Me.GroupBoxFilters.ResumeLayout(False)
        Me.GroupBoxFilters.PerformLayout()
        Me.PanelContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboUsuario As ComboBox
    Friend WithEvents chkEnableStatusFilter As CheckBox
    Friend WithEvents cboEstatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtOrdenCompra As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents RegistrarToolStripMenuItem As ToolStripMenuItem
End Class
