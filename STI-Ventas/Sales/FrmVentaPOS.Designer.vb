<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVentaPOS
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
        Me.GroupBoxAcciones = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCobrarOV = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBoxAcciones.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBoxAcciones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 450)
        Me.Panel1.TabIndex = 0
        '
        'GroupBoxAcciones
        '
        Me.GroupBoxAcciones.Controls.Add(Me.Panel2)
        Me.GroupBoxAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBoxAcciones.Location = New System.Drawing.Point(0, 350)
        Me.GroupBoxAcciones.Name = "GroupBoxAcciones"
        Me.GroupBoxAcciones.Size = New System.Drawing.Size(800, 100)
        Me.GroupBoxAcciones.TabIndex = 0
        Me.GroupBoxAcciones.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCobrarOV)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 81)
        Me.Panel2.TabIndex = 0
        '
        'btnCobrarOV
        '
        Me.btnCobrarOV.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCobrarOV.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCobrarOV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCobrarOV.Location = New System.Drawing.Point(0, 0)
        Me.btnCobrarOV.Name = "btnCobrarOV"
        Me.btnCobrarOV.Size = New System.Drawing.Size(200, 47)
        Me.btnCobrarOV.TabIndex = 102
        Me.btnCobrarOV.Text = "Cobrar"
        Me.btnCobrarOV.UseVisualStyleBackColor = True
        '
        'FrmVentaPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmVentaPOS"
        Me.Text = "Ventas"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBoxAcciones.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBoxAcciones As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCobrarOV As Button
End Class
