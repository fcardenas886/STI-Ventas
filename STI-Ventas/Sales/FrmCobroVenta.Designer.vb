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
        Me.components = New System.ComponentModel.Container()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.txtCambio = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtMontoPagar = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtPropina = New System.Windows.Forms.NumericUpDown()
        Me.txtEfectivo = New System.Windows.Forms.NumericUpDown()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.CobroErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelContainer.SuspendLayout()
        CType(Me.txtMontoPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CobroErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.White
        Me.PanelContainer.Controls.Add(Me.txtCambio)
        Me.PanelContainer.Controls.Add(Me.btnCancelar)
        Me.PanelContainer.Controls.Add(Me.txtMontoPagar)
        Me.PanelContainer.Controls.Add(Me.Label1)
        Me.PanelContainer.Controls.Add(Me.btnOK)
        Me.PanelContainer.Controls.Add(Me.txtPropina)
        Me.PanelContainer.Controls.Add(Me.txtEfectivo)
        Me.PanelContainer.Controls.Add(Me.lblCambio)
        Me.PanelContainer.Controls.Add(Me.lblEfectivo)
        Me.PanelContainer.Controls.Add(Me.lblTotal)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Padding = New System.Windows.Forms.Padding(5)
        Me.PanelContainer.Size = New System.Drawing.Size(307, 324)
        Me.PanelContainer.TabIndex = 0
        '
        'txtCambio
        '
        Me.txtCambio.BackColor = System.Drawing.Color.White
        Me.txtCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambio.Location = New System.Drawing.Point(34, 159)
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.ReadOnly = True
        Me.txtCambio.Size = New System.Drawing.Size(239, 26)
        Me.txtCambio.TabIndex = 7
        Me.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Location = New System.Drawing.Point(155, 263)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(146, 44)
        Me.btnCancelar.TabIndex = 16
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
        Me.txtMontoPagar.Location = New System.Drawing.Point(34, 38)
        Me.txtMontoPagar.Maximum = New Decimal(New Integer() {-727379968, 232, 0, 0})
        Me.txtMontoPagar.Name = "txtMontoPagar"
        Me.txtMontoPagar.ReadOnly = True
        Me.txtMontoPagar.Size = New System.Drawing.Size(239, 26)
        Me.txtMontoPagar.TabIndex = 2
        Me.txtMontoPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMontoPagar.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(113, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Cambio:"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(5, 263)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(146, 44)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Text = "&Aceptar"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'txtPropina
        '
        Me.txtPropina.DecimalPlaces = 2
        Me.txtPropina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPropina.Location = New System.Drawing.Point(34, 220)
        Me.txtPropina.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.txtPropina.Name = "txtPropina"
        Me.txtPropina.Size = New System.Drawing.Size(239, 26)
        Me.txtPropina.TabIndex = 13
        Me.txtPropina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPropina.ThousandsSeparator = True
        '
        'txtEfectivo
        '
        Me.txtEfectivo.DecimalPlaces = 2
        Me.txtEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.Location = New System.Drawing.Point(34, 97)
        Me.txtEfectivo.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(239, 26)
        Me.txtEfectivo.TabIndex = 5
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtEfectivo.ThousandsSeparator = True
        '
        'lblCambio
        '
        Me.lblCambio.AutoSize = True
        Me.lblCambio.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCambio.Location = New System.Drawing.Point(113, 198)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(73, 19)
        Me.lblCambio.TabIndex = 9
        Me.lblCambio.Text = "Propina:"
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEfectivo.Location = New System.Drawing.Point(113, 75)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(72, 19)
        Me.lblEfectivo.TabIndex = 8
        Me.lblEfectivo.Text = "Efectivo:"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(73, 16)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(155, 19)
        Me.lblTotal.TabIndex = 7
        Me.lblTotal.Text = "Cantidad a pagar:"
        '
        'CobroErrorProvider
        '
        Me.CobroErrorProvider.BlinkRate = 300
        Me.CobroErrorProvider.ContainerControl = Me
        '
        'FrmCobroVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(307, 324)
        Me.Controls.Add(Me.PanelContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCobroVenta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobros"
        Me.PanelContainer.ResumeLayout(False)
        Me.PanelContainer.PerformLayout()
        CType(Me.txtMontoPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CobroErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelContainer As Panel
    Private WithEvents btnOK As Button
    Private WithEvents txtPropina As NumericUpDown
    Private WithEvents txtEfectivo As NumericUpDown
    Private WithEvents lblCambio As Label
    Private WithEvents lblEfectivo As Label
    Private WithEvents lblTotal As Label
    Private WithEvents txtMontoPagar As NumericUpDown
    Private WithEvents Label1 As Label
    Private WithEvents btnCancelar As Button
    Private WithEvents txtCambio As TextBox
    Friend WithEvents CobroErrorProvider As ErrorProvider
End Class
