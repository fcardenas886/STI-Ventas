<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVentasListPage
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
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.chkEnableStatusFilter = New System.Windows.Forms.CheckBox()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.txtOrdenVenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxFilters.SuspendLayout()
        Me.PanelContainer.SuspendLayout()
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
        Me.GroupBoxFilters.Controls.Add(Me.cboCliente)
        Me.GroupBoxFilters.Controls.Add(Me.txtOrdenVenta)
        Me.GroupBoxFilters.Controls.Add(Me.Label2)
        Me.GroupBoxFilters.Controls.Add(Me.Label1)
        Me.GroupBoxFilters.Size = New System.Drawing.Size(985, 100)
        '
        'PanelContainer
        '
        Me.PanelContainer.Size = New System.Drawing.Size(1185, 100)
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(459, 64)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(155, 21)
        Me.cboFormaPago.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(389, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Forma Pago"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(407, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(459, 40)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(155, 21)
        Me.cboMoneda.TabIndex = 30
        '
        'chkEnableStatusFilter
        '
        Me.chkEnableStatusFilter.AutoSize = True
        Me.chkEnableStatusFilter.Location = New System.Drawing.Point(443, 19)
        Me.chkEnableStatusFilter.Name = "chkEnableStatusFilter"
        Me.chkEnableStatusFilter.Size = New System.Drawing.Size(15, 14)
        Me.chkEnableStatusFilter.TabIndex = 29
        Me.chkEnableStatusFilter.UseVisualStyleBackColor = True
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Location = New System.Drawing.Point(459, 16)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(155, 21)
        Me.cboEstatus.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(395, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Estatus"
        '
        'cboCliente
        '
        Me.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(108, 40)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(245, 21)
        Me.cboCliente.TabIndex = 26
        '
        'txtOrdenVenta
        '
        Me.txtOrdenVenta.Location = New System.Drawing.Point(108, 16)
        Me.txtOrdenVenta.Name = "txtOrdenVenta"
        Me.txtOrdenVenta.Size = New System.Drawing.Size(245, 20)
        Me.txtOrdenVenta.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Orden venta"
        '
        'FrmVentasListPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1185, 586)
        Me.Name = "FrmVentasListPage"
        Me.Text = "FrmVentasListPage"
        Me.GroupBoxFilters.ResumeLayout(False)
        Me.GroupBoxFilters.PerformLayout()
        Me.PanelContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboFormaPago As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboMoneda As ComboBox
    Friend WithEvents chkEnableStatusFilter As CheckBox
    Friend WithEvents cboEstatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents txtOrdenVenta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
