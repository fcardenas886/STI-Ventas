<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTransaccionInventarioListPage
    Inherits FrmListPageBase

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIdArticulo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkEnableStatusFilter = New System.Windows.Forms.CheckBox()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoTransaccion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkEnableTipoTransaccion = New System.Windows.Forms.CheckBox()
        Me.GroupBoxFilters.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxFilters
        '
        Me.GroupBoxFilters.Controls.Add(Me.Panel2)
        Me.GroupBoxFilters.Controls.Add(Me.Panel1)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtReferencia)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtIdArticulo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(308, 81)
        Me.Panel1.TabIndex = 32
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(116, 41)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(167, 20)
        Me.txtReferencia.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(51, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Referencia"
        '
        'txtIdArticulo
        '
        Me.txtIdArticulo.Location = New System.Drawing.Point(116, 13)
        Me.txtIdArticulo.Name = "txtIdArticulo"
        Me.txtIdArticulo.Size = New System.Drawing.Size(167, 20)
        Me.txtIdArticulo.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Código artículo"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkEnableTipoTransaccion)
        Me.Panel2.Controls.Add(Me.chkEnableStatusFilter)
        Me.Panel2.Controls.Add(Me.cboEstatus)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cboTipoTransaccion)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(309, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(288, 81)
        Me.Panel2.TabIndex = 33
        '
        'chkEnableStatusFilter
        '
        Me.chkEnableStatusFilter.AutoSize = True
        Me.chkEnableStatusFilter.Location = New System.Drawing.Point(84, 19)
        Me.chkEnableStatusFilter.Name = "chkEnableStatusFilter"
        Me.chkEnableStatusFilter.Size = New System.Drawing.Size(15, 14)
        Me.chkEnableStatusFilter.TabIndex = 33
        Me.chkEnableStatusFilter.UseVisualStyleBackColor = True
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Location = New System.Drawing.Point(100, 16)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(167, 21)
        Me.cboEstatus.TabIndex = 32
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Estatus"
        '
        'cboTipoTransaccion
        '
        Me.cboTipoTransaccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTransaccion.FormattingEnabled = True
        Me.cboTipoTransaccion.Location = New System.Drawing.Point(100, 43)
        Me.cboTipoTransaccion.Name = "cboTipoTransaccion"
        Me.cboTipoTransaccion.Size = New System.Drawing.Size(167, 21)
        Me.cboTipoTransaccion.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-3, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Tipo transacción"
        '
        'chkEnableTipoTransaccion
        '
        Me.chkEnableTipoTransaccion.AutoSize = True
        Me.chkEnableTipoTransaccion.Location = New System.Drawing.Point(84, 46)
        Me.chkEnableTipoTransaccion.Name = "chkEnableTipoTransaccion"
        Me.chkEnableTipoTransaccion.Size = New System.Drawing.Size(15, 14)
        Me.chkEnableTipoTransaccion.TabIndex = 34
        Me.chkEnableTipoTransaccion.UseVisualStyleBackColor = True
        '
        'FrmTransaccionInventarioListPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Name = "FrmTransaccionInventarioListPage"
        Me.Text = "Transacciones de Inventario"
        Me.GroupBoxFilters.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkEnableTipoTransaccion As CheckBox
    Friend WithEvents chkEnableStatusFilter As CheckBox
    Friend WithEvents cboEstatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboTipoTransaccion As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtIdArticulo As TextBox
    Friend WithEvents Label1 As Label
End Class
