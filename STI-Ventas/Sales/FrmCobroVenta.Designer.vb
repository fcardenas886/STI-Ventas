<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCobroVenta
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtPropina = New System.Windows.Forms.TextBox()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.White
        Me.PanelContainer.Controls.Add(Me.TextBox1)
        Me.PanelContainer.Controls.Add(Me.Label1)
        Me.PanelContainer.Controls.Add(Me.btnOK)
        Me.PanelContainer.Controls.Add(Me.txtPropina)
        Me.PanelContainer.Controls.Add(Me.txtEfectivo)
        Me.PanelContainer.Controls.Add(Me.txtTotal)
        Me.PanelContainer.Controls.Add(Me.lblCambio)
        Me.PanelContainer.Controls.Add(Me.lblEfectivo)
        Me.PanelContainer.Controls.Add(Me.lblTotal)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(307, 345)
        Me.PanelContainer.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(72, 270)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(151, 44)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "Aceptar"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'txtPropina
        '
        Me.txtPropina.Location = New System.Drawing.Point(55, 225)
        Me.txtPropina.Name = "txtPropina"
        Me.txtPropina.Size = New System.Drawing.Size(183, 20)
        Me.txtPropina.TabIndex = 12
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Location = New System.Drawing.Point(55, 98)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(183, 20)
        Me.txtEfectivo.TabIndex = 11
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(55, 39)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(183, 20)
        Me.txtTotal.TabIndex = 10
        '
        'lblCambio
        '
        Me.lblCambio.AutoSize = True
        Me.lblCambio.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCambio.Location = New System.Drawing.Point(108, 203)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(73, 19)
        Me.lblCambio.TabIndex = 9
        Me.lblCambio.Text = "Propina:"
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEfectivo.Location = New System.Drawing.Point(108, 76)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(72, 19)
        Me.lblEfectivo.TabIndex = 8
        Me.lblEfectivo.Text = "Efectivo:"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(68, 17)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(155, 19)
        Me.lblTotal.TabIndex = 7
        Me.lblTotal.Text = "Cantidad a pagar:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(55, 162)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(183, 20)
        Me.TextBox1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(108, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Cambio:"
        '
        'FrmCobroVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 345)
        Me.Controls.Add(Me.PanelContainer)
        Me.Name = "FrmCobroVenta"
        Me.ShowInTaskbar = False
        Me.Text = "Cobros"
        Me.PanelContainer.ResumeLayout(False)
        Me.PanelContainer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelContainer As Panel
    Private WithEvents btnOK As Button
    Private WithEvents txtPropina As TextBox
    Private WithEvents txtEfectivo As TextBox
    Private WithEvents txtTotal As TextBox
    Private WithEvents lblCambio As Label
    Private WithEvents lblEfectivo As Label
    Private WithEvents lblTotal As Label
    Private WithEvents TextBox1 As TextBox
    Private WithEvents Label1 As Label
End Class
