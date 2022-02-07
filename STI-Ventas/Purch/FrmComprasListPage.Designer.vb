<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComprasListPage
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
        Me.cboProveedor = New System.Windows.Forms.ComboBox()
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkEnableStatusFilter = New System.Windows.Forms.CheckBox()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.GroupBoxFilters.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxFilters
        '
        Me.GroupBoxFilters.Controls.Add(Me.cboFormaPago)
        Me.GroupBoxFilters.Controls.Add(Me.Label7)
        Me.GroupBoxFilters.Controls.Add(Me.Label5)
        Me.GroupBoxFilters.Controls.Add(Me.cboMoneda)
        Me.GroupBoxFilters.Controls.Add(Me.chkEnableStatusFilter)
        Me.GroupBoxFilters.Controls.Add(Me.cboEstatus)
        Me.GroupBoxFilters.Controls.Add(Me.Label3)
        Me.GroupBoxFilters.Controls.Add(Me.cboProveedor)
        Me.GroupBoxFilters.Controls.Add(Me.txtOrdenCompra)
        Me.GroupBoxFilters.Controls.Add(Me.Label2)
        Me.GroupBoxFilters.Controls.Add(Me.Label1)
        '
        'cboProveedor
        '
        Me.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Location = New System.Drawing.Point(94, 39)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(167, 21)
        Me.cboProveedor.TabIndex = 7
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Location = New System.Drawing.Point(94, 15)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(167, 20)
        Me.txtOrdenCompra.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Orden compra"
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Location = New System.Drawing.Point(355, 15)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(155, 21)
        Me.cboEstatus.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(291, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Estatus"
        '
        'chkEnableStatusFilter
        '
        Me.chkEnableStatusFilter.AutoSize = True
        Me.chkEnableStatusFilter.Location = New System.Drawing.Point(339, 18)
        Me.chkEnableStatusFilter.Name = "chkEnableStatusFilter"
        Me.chkEnableStatusFilter.Size = New System.Drawing.Size(15, 14)
        Me.chkEnableStatusFilter.TabIndex = 10
        Me.chkEnableStatusFilter.UseVisualStyleBackColor = True
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(355, 63)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(155, 21)
        Me.cboFormaPago.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(285, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Forma Pago"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(303, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(355, 39)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(155, 21)
        Me.cboMoneda.TabIndex = 19
        '
        'FrmComprasListPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Name = "FrmComprasListPage"
        Me.Text = "Ordenes de compra"
        Me.GroupBoxFilters.ResumeLayout(False)
        Me.GroupBoxFilters.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboProveedor As ComboBox
    Friend WithEvents txtOrdenCompra As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboEstatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkEnableStatusFilter As CheckBox
    Friend WithEvents cboFormaPago As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboMoneda As ComboBox
End Class
