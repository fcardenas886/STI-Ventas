<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMoneda
    Inherits FrmBase

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
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtCodigoMoneda = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.groupBoxIdentification = New System.Windows.Forms.GroupBox()
        Me.txtSimbolo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigoIso = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.groupBoxRedondeo = New System.Windows.Forms.GroupBox()
        Me.lblTipoRedondeoGral = New System.Windows.Forms.Label()
        Me.cboTipoRedondeoGral = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkBoxRedondeoGral = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTipoRedondeoInvent = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkBoxRedondeoInvent = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBoxCompras = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboTipoRedondeoPurch = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkBoxRedondeoPurch = New System.Windows.Forms.CheckBox()
        Me.GroupBoxVentas = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboTipoRedondeoSales = New System.Windows.Forms.ComboBox()
        Me.chkBoxRedondeoSales = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.groupBoxIdentification.SuspendLayout()
        Me.groupBoxRedondeo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBoxCompras.SuspendLayout()
        Me.GroupBoxVentas.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.groupBoxIdentification)
        Me.GroupBox1.Size = New System.Drawing.Size(805, 174)
        Me.GroupBox1.Text = ""
        '
        'txtAlias
        '
        Me.txtAlias.Location = New System.Drawing.Point(73, 71)
        Me.txtAlias.MaxLength = 100
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(224, 20)
        Me.txtAlias.TabIndex = 11
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(73, 45)
        Me.txtName.MaxLength = 60
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(224, 20)
        Me.txtName.TabIndex = 10
        '
        'txtCodigoMoneda
        '
        Me.txtCodigoMoneda.Location = New System.Drawing.Point(73, 19)
        Me.txtCodigoMoneda.MaxLength = 20
        Me.txtCodigoMoneda.Name = "txtCodigoMoneda"
        Me.txtCodigoMoneda.Size = New System.Drawing.Size(104, 20)
        Me.txtCodigoMoneda.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Código"
        '
        'groupBoxIdentification
        '
        Me.groupBoxIdentification.Controls.Add(Me.txtSimbolo)
        Me.groupBoxIdentification.Controls.Add(Me.Label4)
        Me.groupBoxIdentification.Controls.Add(Me.txtCodigoIso)
        Me.groupBoxIdentification.Controls.Add(Me.Label5)
        Me.groupBoxIdentification.Controls.Add(Me.txtCodigoMoneda)
        Me.groupBoxIdentification.Controls.Add(Me.txtAlias)
        Me.groupBoxIdentification.Controls.Add(Me.Label1)
        Me.groupBoxIdentification.Controls.Add(Me.txtName)
        Me.groupBoxIdentification.Controls.Add(Me.Label2)
        Me.groupBoxIdentification.Controls.Add(Me.Label3)
        Me.groupBoxIdentification.Dock = System.Windows.Forms.DockStyle.Left
        Me.groupBoxIdentification.Location = New System.Drawing.Point(3, 16)
        Me.groupBoxIdentification.Name = "groupBoxIdentification"
        Me.groupBoxIdentification.Size = New System.Drawing.Size(318, 155)
        Me.groupBoxIdentification.TabIndex = 12
        Me.groupBoxIdentification.TabStop = False
        Me.groupBoxIdentification.Text = "Identificación"
        '
        'txtSimbolo
        '
        Me.txtSimbolo.Location = New System.Drawing.Point(73, 95)
        Me.txtSimbolo.MaxLength = 5
        Me.txtSimbolo.Name = "txtSimbolo"
        Me.txtSimbolo.Size = New System.Drawing.Size(104, 20)
        Me.txtSimbolo.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Simbolo"
        '
        'txtCodigoIso
        '
        Me.txtCodigoIso.Location = New System.Drawing.Point(73, 121)
        Me.txtCodigoIso.MaxLength = 3
        Me.txtCodigoIso.Name = "txtCodigoIso"
        Me.txtCodigoIso.Size = New System.Drawing.Size(104, 20)
        Me.txtCodigoIso.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Código ISO"
        '
        'groupBoxRedondeo
        '
        Me.groupBoxRedondeo.Controls.Add(Me.lblTipoRedondeoGral)
        Me.groupBoxRedondeo.Controls.Add(Me.cboTipoRedondeoGral)
        Me.groupBoxRedondeo.Controls.Add(Me.Label6)
        Me.groupBoxRedondeo.Controls.Add(Me.chkBoxRedondeoGral)
        Me.groupBoxRedondeo.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBoxRedondeo.Location = New System.Drawing.Point(0, 0)
        Me.groupBoxRedondeo.Name = "groupBoxRedondeo"
        Me.groupBoxRedondeo.Size = New System.Drawing.Size(236, 81)
        Me.groupBoxRedondeo.TabIndex = 13
        Me.groupBoxRedondeo.TabStop = False
        Me.groupBoxRedondeo.Text = "Redondeo general"
        '
        'lblTipoRedondeoGral
        '
        Me.lblTipoRedondeoGral.AutoSize = True
        Me.lblTipoRedondeoGral.Location = New System.Drawing.Point(2, 48)
        Me.lblTipoRedondeoGral.Name = "lblTipoRedondeoGral"
        Me.lblTipoRedondeoGral.Size = New System.Drawing.Size(76, 13)
        Me.lblTipoRedondeoGral.TabIndex = 3
        Me.lblTipoRedondeoGral.Text = "Tipo redondeo"
        '
        'cboTipoRedondeoGral
        '
        Me.cboTipoRedondeoGral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRedondeoGral.FormattingEnabled = True
        Me.cboTipoRedondeoGral.Location = New System.Drawing.Point(84, 44)
        Me.cboTipoRedondeoGral.Name = "cboTipoRedondeoGral"
        Me.cboTipoRedondeoGral.Size = New System.Drawing.Size(136, 21)
        Me.cboTipoRedondeoGral.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Redondear"
        '
        'chkBoxRedondeoGral
        '
        Me.chkBoxRedondeoGral.AutoSize = True
        Me.chkBoxRedondeoGral.Location = New System.Drawing.Point(84, 19)
        Me.chkBoxRedondeoGral.Name = "chkBoxRedondeoGral"
        Me.chkBoxRedondeoGral.Size = New System.Drawing.Size(15, 14)
        Me.chkBoxRedondeoGral.TabIndex = 0
        Me.chkBoxRedondeoGral.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(321, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(481, 155)
        Me.Panel1.TabIndex = 14
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Controls.Add(Me.groupBoxRedondeo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(236, 155)
        Me.Panel3.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cboTipoRedondeoInvent)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.chkBoxRedondeoInvent)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 81)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(236, 74)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Redondeo inventarios"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Tipo redondeo"
        '
        'cboTipoRedondeoInvent
        '
        Me.cboTipoRedondeoInvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRedondeoInvent.FormattingEnabled = True
        Me.cboTipoRedondeoInvent.Location = New System.Drawing.Point(84, 43)
        Me.cboTipoRedondeoInvent.Name = "cboTipoRedondeoInvent"
        Me.cboTipoRedondeoInvent.Size = New System.Drawing.Size(136, 21)
        Me.cboTipoRedondeoInvent.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Redondear"
        '
        'chkBoxRedondeoInvent
        '
        Me.chkBoxRedondeoInvent.AutoSize = True
        Me.chkBoxRedondeoInvent.Location = New System.Drawing.Point(84, 18)
        Me.chkBoxRedondeoInvent.Name = "chkBoxRedondeoInvent"
        Me.chkBoxRedondeoInvent.Size = New System.Drawing.Size(15, 14)
        Me.chkBoxRedondeoInvent.TabIndex = 4
        Me.chkBoxRedondeoInvent.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBoxCompras)
        Me.Panel2.Controls.Add(Me.GroupBoxVentas)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(236, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(245, 155)
        Me.Panel2.TabIndex = 0
        '
        'GroupBoxCompras
        '
        Me.GroupBoxCompras.Controls.Add(Me.Label11)
        Me.GroupBoxCompras.Controls.Add(Me.cboTipoRedondeoPurch)
        Me.GroupBoxCompras.Controls.Add(Me.Label12)
        Me.GroupBoxCompras.Controls.Add(Me.chkBoxRedondeoPurch)
        Me.GroupBoxCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxCompras.Location = New System.Drawing.Point(0, 81)
        Me.GroupBoxCompras.Name = "GroupBoxCompras"
        Me.GroupBoxCompras.Size = New System.Drawing.Size(245, 74)
        Me.GroupBoxCompras.TabIndex = 15
        Me.GroupBoxCompras.TabStop = False
        Me.GroupBoxCompras.Text = "Redondeo compras"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Tipo redondeo"
        '
        'cboTipoRedondeoPurch
        '
        Me.cboTipoRedondeoPurch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRedondeoPurch.FormattingEnabled = True
        Me.cboTipoRedondeoPurch.Location = New System.Drawing.Point(91, 43)
        Me.cboTipoRedondeoPurch.Name = "cboTipoRedondeoPurch"
        Me.cboTipoRedondeoPurch.Size = New System.Drawing.Size(136, 21)
        Me.cboTipoRedondeoPurch.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Redondear"
        '
        'chkBoxRedondeoPurch
        '
        Me.chkBoxRedondeoPurch.AutoSize = True
        Me.chkBoxRedondeoPurch.Location = New System.Drawing.Point(91, 18)
        Me.chkBoxRedondeoPurch.Name = "chkBoxRedondeoPurch"
        Me.chkBoxRedondeoPurch.Size = New System.Drawing.Size(15, 14)
        Me.chkBoxRedondeoPurch.TabIndex = 4
        Me.chkBoxRedondeoPurch.UseVisualStyleBackColor = True
        '
        'GroupBoxVentas
        '
        Me.GroupBoxVentas.Controls.Add(Me.Label9)
        Me.GroupBoxVentas.Controls.Add(Me.cboTipoRedondeoSales)
        Me.GroupBoxVentas.Controls.Add(Me.chkBoxRedondeoSales)
        Me.GroupBoxVentas.Controls.Add(Me.Label10)
        Me.GroupBoxVentas.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxVentas.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxVentas.Name = "GroupBoxVentas"
        Me.GroupBoxVentas.Size = New System.Drawing.Size(245, 81)
        Me.GroupBoxVentas.TabIndex = 14
        Me.GroupBoxVentas.TabStop = False
        Me.GroupBoxVentas.Text = "Redondeo ventas"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Tipo redondeo"
        '
        'cboTipoRedondeoSales
        '
        Me.cboTipoRedondeoSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRedondeoSales.FormattingEnabled = True
        Me.cboTipoRedondeoSales.Location = New System.Drawing.Point(91, 44)
        Me.cboTipoRedondeoSales.Name = "cboTipoRedondeoSales"
        Me.cboTipoRedondeoSales.Size = New System.Drawing.Size(136, 21)
        Me.cboTipoRedondeoSales.TabIndex = 10
        '
        'chkBoxRedondeoSales
        '
        Me.chkBoxRedondeoSales.AutoSize = True
        Me.chkBoxRedondeoSales.Location = New System.Drawing.Point(91, 19)
        Me.chkBoxRedondeoSales.Name = "chkBoxRedondeoSales"
        Me.chkBoxRedondeoSales.Size = New System.Drawing.Size(15, 14)
        Me.chkBoxRedondeoSales.TabIndex = 8
        Me.chkBoxRedondeoSales.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Redondear"
        '
        'FrmMoneda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 450)
        Me.Name = "FrmMoneda"
        Me.Text = "Monedas"
        Me.GroupBox1.ResumeLayout(False)
        Me.groupBoxIdentification.ResumeLayout(False)
        Me.groupBoxIdentification.PerformLayout()
        Me.groupBoxRedondeo.ResumeLayout(False)
        Me.groupBoxRedondeo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBoxCompras.ResumeLayout(False)
        Me.GroupBoxCompras.PerformLayout()
        Me.GroupBoxVentas.ResumeLayout(False)
        Me.GroupBoxVentas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtAlias As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtCodigoMoneda As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents groupBoxIdentification As GroupBox
    Friend WithEvents groupBoxRedondeo As GroupBox
    Friend WithEvents txtSimbolo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCodigoIso As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTipoRedondeoGral As Label
    Friend WithEvents cboTipoRedondeoGral As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents chkBoxRedondeoGral As CheckBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboTipoRedondeoInvent As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chkBoxRedondeoInvent As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBoxCompras As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cboTipoRedondeoPurch As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents chkBoxRedondeoPurch As CheckBox
    Friend WithEvents GroupBoxVentas As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboTipoRedondeoSales As ComboBox
    Friend WithEvents chkBoxRedondeoSales As CheckBox
    Friend WithEvents Label10 As Label
End Class
