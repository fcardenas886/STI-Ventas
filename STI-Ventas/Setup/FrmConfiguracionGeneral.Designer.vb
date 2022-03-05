<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracionGeneral
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
        Me.PanelMainFill = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.cboIdCliente = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBoxActions = New System.Windows.Forms.GroupBox()
        Me.btnGuardarOC = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFormaPagoVentas = New System.Windows.Forms.ComboBox()
        Me.PanelContainer.SuspendLayout()
        Me.PanelMainFill.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBoxActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.White
        Me.PanelContainer.Controls.Add(Me.PanelMainFill)
        Me.PanelContainer.Controls.Add(Me.GroupBoxActions)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(800, 450)
        Me.PanelContainer.TabIndex = 0
        '
        'PanelMainFill
        '
        Me.PanelMainFill.Controls.Add(Me.GroupBox1)
        Me.PanelMainFill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMainFill.Location = New System.Drawing.Point(0, 0)
        Me.PanelMainFill.Name = "PanelMainFill"
        Me.PanelMainFill.Size = New System.Drawing.Size(800, 350)
        Me.PanelMainFill.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboFormaPagoVentas)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboMoneda)
        Me.GroupBox1.Controls.Add(Me.cboIdCliente)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 116)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ventas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(75, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Moneda"
        '
        'cboMoneda
        '
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(128, 48)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(155, 21)
        Me.cboMoneda.TabIndex = 35
        '
        'cboIdCliente
        '
        Me.cboIdCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIdCliente.FormattingEnabled = True
        Me.cboIdCliente.Location = New System.Drawing.Point(128, 22)
        Me.cboIdCliente.Name = "cboIdCliente"
        Me.cboIdCliente.Size = New System.Drawing.Size(252, 21)
        Me.cboIdCliente.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Cliente mostrador"
        '
        'GroupBoxActions
        '
        Me.GroupBoxActions.Controls.Add(Me.btnGuardarOC)
        Me.GroupBoxActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBoxActions.Location = New System.Drawing.Point(0, 350)
        Me.GroupBoxActions.Name = "GroupBoxActions"
        Me.GroupBoxActions.Size = New System.Drawing.Size(800, 100)
        Me.GroupBoxActions.TabIndex = 0
        Me.GroupBoxActions.TabStop = False
        Me.GroupBoxActions.Text = "Acciones"
        '
        'btnGuardarOC
        '
        Me.btnGuardarOC.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnGuardarOC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardarOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarOC.Location = New System.Drawing.Point(3, 16)
        Me.btnGuardarOC.Name = "btnGuardarOC"
        Me.btnGuardarOC.Size = New System.Drawing.Size(794, 47)
        Me.btnGuardarOC.TabIndex = 101
        Me.btnGuardarOC.Text = "Guardar"
        Me.btnGuardarOC.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Forma de pago ventas"
        '
        'cboFormaPagoVentas
        '
        Me.cboFormaPagoVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPagoVentas.FormattingEnabled = True
        Me.cboFormaPagoVentas.Location = New System.Drawing.Point(128, 75)
        Me.cboFormaPagoVentas.Name = "cboFormaPagoVentas"
        Me.cboFormaPagoVentas.Size = New System.Drawing.Size(155, 21)
        Me.cboFormaPagoVentas.TabIndex = 37
        '
        'FrmConfiguracionGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PanelContainer)
        Me.Name = "FrmConfiguracionGeneral"
        Me.Text = "Configuración"
        Me.PanelContainer.ResumeLayout(False)
        Me.PanelMainFill.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBoxActions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelContainer As Panel
    Friend WithEvents PanelMainFill As Panel
    Friend WithEvents GroupBoxActions As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboMoneda As ComboBox
    Friend WithEvents cboIdCliente As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnGuardarOC As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboFormaPagoVentas As ComboBox
End Class
