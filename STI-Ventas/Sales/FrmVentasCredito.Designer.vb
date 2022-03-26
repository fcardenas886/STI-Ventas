<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVentasCredito
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBoxLineDetails = New System.Windows.Forms.GroupBox()
        Me.dgvLineas = New System.Windows.Forms.DataGridView()
        Me.GroupBoxLineDetails.SuspendLayout()
        CType(Me.dgvLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxLineDetails
        '
        Me.GroupBoxLineDetails.Controls.Add(Me.dgvLineas)
        Me.GroupBoxLineDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxLineDetails.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxLineDetails.Name = "GroupBoxLineDetails"
        Me.GroupBoxLineDetails.Size = New System.Drawing.Size(800, 450)
        Me.GroupBoxLineDetails.TabIndex = 3
        Me.GroupBoxLineDetails.TabStop = False
        Me.GroupBoxLineDetails.Text = "Detalle de línea"
        '
        'dgvLineas
        '
        Me.dgvLineas.AllowUserToAddRows = False
        Me.dgvLineas.AllowUserToDeleteRows = False
        Me.dgvLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLineas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLineas.Location = New System.Drawing.Point(3, 16)
        Me.dgvLineas.Name = "dgvLineas"
        Me.dgvLineas.ReadOnly = True
        Me.dgvLineas.Size = New System.Drawing.Size(794, 431)
        Me.dgvLineas.TabIndex = 0
        '
        'FrmVentasCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBoxLineDetails)
        Me.Name = "FrmVentasCredito"
        Me.Text = "Detalles Ventas a Credito"
        Me.GroupBoxLineDetails.ResumeLayout(False)
        CType(Me.dgvLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBoxLineDetails As GroupBox
    Friend WithEvents dgvLineas As DataGridView
End Class
