<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVentasCreditoListPage
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
        Me.GroupBoxFilters.Controls.Add(Me.Label5)
        Me.GroupBoxFilters.Controls.Add(Me.cboMoneda)
        Me.GroupBoxFilters.Controls.Add(Me.chkEnableStatusFilter)
        Me.GroupBoxFilters.Controls.Add(Me.cboEstatus)
        Me.GroupBoxFilters.Controls.Add(Me.Label3)
        Me.GroupBoxFilters.Controls.Add(Me.cboCliente)
        Me.GroupBoxFilters.Controls.Add(Me.txtOrdenVenta)
        Me.GroupBoxFilters.Controls.Add(Me.Label2)
        Me.GroupBoxFilters.Controls.Add(Me.Label1)
        Me.GroupBoxFilters.Size = New System.Drawing.Size(941, 100)
        '
        'PanelContainer
        '
        Me.PanelContainer.Size = New System.Drawing.Size(1141, 100)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(437, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(489, 50)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(155, 21)
        Me.cboMoneda.TabIndex = 40
        '
        'chkEnableStatusFilter
        '
        Me.chkEnableStatusFilter.AutoSize = True
        Me.chkEnableStatusFilter.Location = New System.Drawing.Point(473, 29)
        Me.chkEnableStatusFilter.Name = "chkEnableStatusFilter"
        Me.chkEnableStatusFilter.Size = New System.Drawing.Size(15, 14)
        Me.chkEnableStatusFilter.TabIndex = 39
        Me.chkEnableStatusFilter.UseVisualStyleBackColor = True
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Location = New System.Drawing.Point(489, 26)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(155, 21)
        Me.cboEstatus.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(425, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Estatus"
        '
        'cboCliente
        '
        Me.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(111, 50)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(245, 21)
        Me.cboCliente.TabIndex = 36
        '
        'txtOrdenVenta
        '
        Me.txtOrdenVenta.Location = New System.Drawing.Point(111, 26)
        Me.txtOrdenVenta.Name = "txtOrdenVenta"
        Me.txtOrdenVenta.Size = New System.Drawing.Size(245, 20)
        Me.txtOrdenVenta.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Orden venta"
        '
        'FrmVentasCreditoListPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 450)
        Me.Name = "FrmVentasCreditoListPage"
        Me.Text = "Todas las Ventas a Credito"
        Me.GroupBoxFilters.ResumeLayout(False)
        Me.GroupBoxFilters.PerformLayout()
        Me.PanelContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
