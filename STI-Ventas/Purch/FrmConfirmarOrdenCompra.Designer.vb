<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfirmarOrdenCompra
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBoxDetails = New System.Windows.Forms.GroupBox()
        Me.PanelDetailsHeader = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtMontoLinea = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtNumeroLineas = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.PanelDetailsTotals = New System.Windows.Forms.Panel()
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
        Me.GroupBoxActions = New System.Windows.Forms.GroupBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBoxDetails.SuspendLayout()
        Me.PanelDetailsHeader.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelDetailsTotals.SuspendLayout()
        Me.GroupBoxActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBoxDetails)
        Me.Panel1.Controls.Add(Me.GroupBoxActions)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 289)
        Me.Panel1.TabIndex = 0
        '
        'GroupBoxDetails
        '
        Me.GroupBoxDetails.Controls.Add(Me.PanelDetailsHeader)
        Me.GroupBoxDetails.Controls.Add(Me.PanelDetailsTotals)
        Me.GroupBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxDetails.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxDetails.Name = "GroupBoxDetails"
        Me.GroupBoxDetails.Size = New System.Drawing.Size(800, 233)
        Me.GroupBoxDetails.TabIndex = 0
        Me.GroupBoxDetails.TabStop = False
        Me.GroupBoxDetails.Text = "Detalles"
        '
        'PanelDetailsHeader
        '
        Me.PanelDetailsHeader.Controls.Add(Me.Panel3)
        Me.PanelDetailsHeader.Controls.Add(Me.Panel2)
        Me.PanelDetailsHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDetailsHeader.Location = New System.Drawing.Point(3, 186)
        Me.PanelDetailsHeader.Name = "PanelDetailsHeader"
        Me.PanelDetailsHeader.Size = New System.Drawing.Size(794, 44)
        Me.PanelDetailsHeader.TabIndex = 67
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtMontoLinea)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(412, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(3, 8, 3, 3)
        Me.Panel3.Size = New System.Drawing.Size(382, 44)
        Me.Panel3.TabIndex = 41
        '
        'txtMontoLinea
        '
        Me.txtMontoLinea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMontoLinea.Location = New System.Drawing.Point(48, 8)
        Me.txtMontoLinea.MaxLength = 20
        Me.txtMontoLinea.Name = "txtMontoLinea"
        Me.txtMontoLinea.ReadOnly = True
        Me.txtMontoLinea.Size = New System.Drawing.Size(331, 20)
        Me.txtMontoLinea.TabIndex = 37
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(3, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 17)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Total"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtNumeroLineas)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(3, 8, 3, 3)
        Me.Panel2.Size = New System.Drawing.Size(409, 44)
        Me.Panel2.TabIndex = 40
        '
        'txtNumeroLineas
        '
        Me.txtNumeroLineas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNumeroLineas.Location = New System.Drawing.Point(138, 8)
        Me.txtNumeroLineas.MaxLength = 20
        Me.txtNumeroLineas.Name = "txtNumeroLineas"
        Me.txtNumeroLineas.ReadOnly = True
        Me.txtNumeroLineas.Size = New System.Drawing.Size(268, 20)
        Me.txtNumeroLineas.TabIndex = 39
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(3, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(135, 17)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Número de líneas"
        '
        'PanelDetailsTotals
        '
        Me.PanelDetailsTotals.Controls.Add(Me.Label13)
        Me.PanelDetailsTotals.Controls.Add(Me.dateTimeFechaEntrega)
        Me.PanelDetailsTotals.Controls.Add(Me.txtContacto)
        Me.PanelDetailsTotals.Controls.Add(Me.Label12)
        Me.PanelDetailsTotals.Controls.Add(Me.txtEmail)
        Me.PanelDetailsTotals.Controls.Add(Me.Label11)
        Me.PanelDetailsTotals.Controls.Add(Me.txtOrdenProveedor)
        Me.PanelDetailsTotals.Controls.Add(Me.Label10)
        Me.PanelDetailsTotals.Controls.Add(Me.txtVendorName)
        Me.PanelDetailsTotals.Controls.Add(Me.Label9)
        Me.PanelDetailsTotals.Controls.Add(Me.cboFormaPago)
        Me.PanelDetailsTotals.Controls.Add(Me.Label7)
        Me.PanelDetailsTotals.Controls.Add(Me.Label5)
        Me.PanelDetailsTotals.Controls.Add(Me.cboMoneda)
        Me.PanelDetailsTotals.Controls.Add(Me.cboEstatus)
        Me.PanelDetailsTotals.Controls.Add(Me.Label4)
        Me.PanelDetailsTotals.Controls.Add(Me.cboProveedor)
        Me.PanelDetailsTotals.Controls.Add(Me.txtOrdenCompra)
        Me.PanelDetailsTotals.Controls.Add(Me.Label6)
        Me.PanelDetailsTotals.Controls.Add(Me.Label8)
        Me.PanelDetailsTotals.Controls.Add(Me.txtOrdenCompraId)
        Me.PanelDetailsTotals.Controls.Add(Me.Label1)
        Me.PanelDetailsTotals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDetailsTotals.Location = New System.Drawing.Point(3, 16)
        Me.PanelDetailsTotals.Name = "PanelDetailsTotals"
        Me.PanelDetailsTotals.Size = New System.Drawing.Size(794, 214)
        Me.PanelDetailsTotals.TabIndex = 66
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(537, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Fecha entrega"
        '
        'dateTimeFechaEntrega
        '
        Me.dateTimeFechaEntrega.Enabled = False
        Me.dateTimeFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTimeFechaEntrega.Location = New System.Drawing.Point(619, 14)
        Me.dateTimeFechaEntrega.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dateTimeFechaEntrega.Name = "dateTimeFechaEntrega"
        Me.dateTimeFechaEntrega.Size = New System.Drawing.Size(167, 20)
        Me.dateTimeFechaEntrega.TabIndex = 82
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(619, 65)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.ReadOnly = True
        Me.txtContacto.Size = New System.Drawing.Size(167, 20)
        Me.txtContacto.TabIndex = 86
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(524, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 13)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Nombre contacto"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(619, 40)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(167, 20)
        Me.txtEmail.TabIndex = 84
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(536, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "Email contacto"
        '
        'txtOrdenProveedor
        '
        Me.txtOrdenProveedor.Location = New System.Drawing.Point(355, 91)
        Me.txtOrdenProveedor.Name = "txtOrdenProveedor"
        Me.txtOrdenProveedor.ReadOnly = True
        Me.txtOrdenProveedor.Size = New System.Drawing.Size(155, 20)
        Me.txtOrdenProveedor.TabIndex = 79
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(262, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 81
        Me.Label10.Text = "Orden proveedor"
        '
        'txtVendorName
        '
        Me.txtVendorName.Location = New System.Drawing.Point(83, 91)
        Me.txtVendorName.Name = "txtVendorName"
        Me.txtVendorName.ReadOnly = True
        Me.txtVendorName.Size = New System.Drawing.Size(167, 20)
        Me.txtVendorName.TabIndex = 73
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(33, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 80
        Me.Label9.Text = "Nombre"
        '
        'cboFormaPago
        '
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(355, 64)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(155, 21)
        Me.cboFormaPago.TabIndex = 76
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(285, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Forma Pago"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(303, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(355, 40)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(155, 21)
        Me.cboMoneda.TabIndex = 75
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Location = New System.Drawing.Point(355, 14)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(155, 21)
        Me.cboEstatus.TabIndex = 74
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(307, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Estatus"
        '
        'cboProveedor
        '
        Me.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Location = New System.Drawing.Point(83, 64)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(167, 21)
        Me.cboProveedor.TabIndex = 71
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.Location = New System.Drawing.Point(83, 40)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.ReadOnly = True
        Me.txtOrdenCompra.Size = New System.Drawing.Size(167, 20)
        Me.txtOrdenCompra.TabIndex = 70
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Proveedor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Orden compra"
        '
        'txtOrdenCompraId
        '
        Me.txtOrdenCompraId.Cursor = System.Windows.Forms.Cursors.Help
        Me.txtOrdenCompraId.Location = New System.Drawing.Point(83, 14)
        Me.txtOrdenCompraId.MaxLength = 20
        Me.txtOrdenCompraId.Name = "txtOrdenCompraId"
        Me.txtOrdenCompraId.ReadOnly = True
        Me.txtOrdenCompraId.Size = New System.Drawing.Size(167, 20)
        Me.txtOrdenCompraId.TabIndex = 67
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Consecutivo"
        '
        'GroupBoxActions
        '
        Me.GroupBoxActions.Controls.Add(Me.btnConfirm)
        Me.GroupBoxActions.Controls.Add(Me.btnCancel)
        Me.GroupBoxActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBoxActions.Location = New System.Drawing.Point(0, 233)
        Me.GroupBoxActions.Name = "GroupBoxActions"
        Me.GroupBoxActions.Size = New System.Drawing.Size(800, 56)
        Me.GroupBoxActions.TabIndex = 0
        Me.GroupBoxActions.TabStop = False
        Me.GroupBoxActions.Text = "Acciones"
        '
        'btnConfirm
        '
        Me.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConfirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Location = New System.Drawing.Point(479, 16)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(159, 37)
        Me.btnConfirm.TabIndex = 103
        Me.btnConfirm.Text = "Confirmar"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(638, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(159, 37)
        Me.btnCancel.TabIndex = 102
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FrmConfirmarOrdenCompra
        '
        Me.AcceptButton = Me.btnConfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(800, 289)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmConfirmarOrdenCompra"
        Me.Text = "Confirmar Orden de Compra"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBoxDetails.ResumeLayout(False)
        Me.PanelDetailsHeader.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelDetailsTotals.ResumeLayout(False)
        Me.PanelDetailsTotals.PerformLayout()
        Me.GroupBoxActions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBoxActions As GroupBox
    Friend WithEvents GroupBoxDetails As GroupBox
    Friend WithEvents PanelDetailsHeader As Panel
    Friend WithEvents PanelDetailsTotals As Panel
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
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtNumeroLineas As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtMontoLinea As TextBox
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtOrdenCompraId As TextBox
End Class
