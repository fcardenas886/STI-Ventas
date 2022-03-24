<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCobrarVentaCredito
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
        Me.components = New System.ComponentModel.Container()
        Me.txtPendientePago = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtMontoPagar = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtEfectivo = New System.Windows.Forms.NumericUpDown()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.CobroErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.txtMontoPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CobroErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPendientePago
        '
        Me.txtPendientePago.BackColor = System.Drawing.Color.White
        Me.txtPendientePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPendientePago.Location = New System.Drawing.Point(34, 161)
        Me.txtPendientePago.Name = "txtPendientePago"
        Me.txtPendientePago.ReadOnly = True
        Me.txtPendientePago.Size = New System.Drawing.Size(239, 26)
        Me.txtPendientePago.TabIndex = 20
        Me.txtPendientePago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Location = New System.Drawing.Point(34, 266)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(239, 44)
        Me.btnCancelar.TabIndex = 27
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'txtMontoPagar
        '
        Me.txtMontoPagar.BackColor = System.Drawing.SystemColors.Info
        Me.txtMontoPagar.CausesValidation = False
        Me.txtMontoPagar.DecimalPlaces = 2
        Me.txtMontoPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoPagar.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMontoPagar.Location = New System.Drawing.Point(34, 40)
        Me.txtMontoPagar.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.txtMontoPagar.Name = "txtMontoPagar"
        Me.txtMontoPagar.ReadOnly = True
        Me.txtMontoPagar.Size = New System.Drawing.Size(239, 26)
        Me.txtMontoPagar.TabIndex = 18
        Me.txtMontoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMontoPagar.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(73, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 19)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Pendiente de pago:"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(34, 216)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(239, 44)
        Me.btnOK.TabIndex = 26
        Me.btnOK.Text = "&Aceptar"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'txtEfectivo
        '
        Me.txtEfectivo.DecimalPlaces = 2
        Me.txtEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.Location = New System.Drawing.Point(34, 99)
        Me.txtEfectivo.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(239, 26)
        Me.txtEfectivo.TabIndex = 19
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEfectivo.ThousandsSeparator = True
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEfectivo.Location = New System.Drawing.Point(113, 77)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(72, 19)
        Me.lblEfectivo.TabIndex = 22
        Me.lblEfectivo.Text = "Efectivo:"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(73, 18)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(155, 19)
        Me.lblTotal.TabIndex = 21
        Me.lblTotal.Text = "Cantidad a pagar:"
        '
        'CobroErrorProvider
        '
        Me.CobroErrorProvider.BlinkRate = 350
        Me.CobroErrorProvider.ContainerControl = Me
        '
        'FrmCobrarVentaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(307, 322)
        Me.Controls.Add(Me.txtPendientePago)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtMontoPagar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtEfectivo)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.lblTotal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCobrarVentaCredito"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobrar Venta Credito"
        CType(Me.txtMontoPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CobroErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents txtPendientePago As TextBox
    Private WithEvents btnCancelar As Button
    Private WithEvents txtMontoPagar As NumericUpDown
    Private WithEvents Label1 As Label
    Private WithEvents btnOK As Button
    Private WithEvents txtEfectivo As NumericUpDown
    Private WithEvents lblEfectivo As Label
    Private WithEvents lblTotal As Label
    Friend WithEvents CobroErrorProvider As ErrorProvider
End Class
