<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGestionPermisos
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
        Me.GroupBoxPermisos = New System.Windows.Forms.GroupBox()
        Me.dgvPermisos = New System.Windows.Forms.DataGridView()
        Me.GroupBoxUsuarios = New System.Windows.Forms.GroupBox()
        Me.PanelUsuariosContenedor = New System.Windows.Forms.Panel()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.PanelFiltrosUsuario = New System.Windows.Forms.Panel()
        Me.GroupBoxFiltrarUsuario = New System.Windows.Forms.GroupBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxAccionesUsuario = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBorrarFiltro = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.PanelContainer.SuspendLayout()
        Me.GroupBoxPermisos.SuspendLayout()
        CType(Me.dgvPermisos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxUsuarios.SuspendLayout()
        Me.PanelUsuariosContenedor.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelFiltrosUsuario.SuspendLayout()
        Me.GroupBoxFiltrarUsuario.SuspendLayout()
        Me.GroupBoxAccionesUsuario.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.White
        Me.PanelContainer.Controls.Add(Me.GroupBoxPermisos)
        Me.PanelContainer.Controls.Add(Me.GroupBoxUsuarios)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(1087, 597)
        Me.PanelContainer.TabIndex = 0
        '
        'GroupBoxPermisos
        '
        Me.GroupBoxPermisos.Controls.Add(Me.dgvPermisos)
        Me.GroupBoxPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxPermisos.Location = New System.Drawing.Point(0, 334)
        Me.GroupBoxPermisos.Name = "GroupBoxPermisos"
        Me.GroupBoxPermisos.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBoxPermisos.Size = New System.Drawing.Size(1087, 263)
        Me.GroupBoxPermisos.TabIndex = 1
        Me.GroupBoxPermisos.TabStop = False
        Me.GroupBoxPermisos.Text = "Permisos disponibles"
        '
        'dgvPermisos
        '
        Me.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPermisos.Location = New System.Drawing.Point(5, 18)
        Me.dgvPermisos.Name = "dgvPermisos"
        Me.dgvPermisos.Size = New System.Drawing.Size(1077, 240)
        Me.dgvPermisos.TabIndex = 0
        '
        'GroupBoxUsuarios
        '
        Me.GroupBoxUsuarios.Controls.Add(Me.PanelUsuariosContenedor)
        Me.GroupBoxUsuarios.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GroupBoxUsuarios.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxUsuarios.Name = "GroupBoxUsuarios"
        Me.GroupBoxUsuarios.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBoxUsuarios.Size = New System.Drawing.Size(1087, 334)
        Me.GroupBoxUsuarios.TabIndex = 0
        Me.GroupBoxUsuarios.TabStop = False
        Me.GroupBoxUsuarios.Text = "Usuarios"
        '
        'PanelUsuariosContenedor
        '
        Me.PanelUsuariosContenedor.Controls.Add(Me.dgvUsuarios)
        Me.PanelUsuariosContenedor.Controls.Add(Me.PanelFiltrosUsuario)
        Me.PanelUsuariosContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelUsuariosContenedor.Location = New System.Drawing.Point(5, 21)
        Me.PanelUsuariosContenedor.Name = "PanelUsuariosContenedor"
        Me.PanelUsuariosContenedor.Size = New System.Drawing.Size(1077, 308)
        Me.PanelUsuariosContenedor.TabIndex = 0
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsuarios.Location = New System.Drawing.Point(0, 100)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.Size = New System.Drawing.Size(1077, 208)
        Me.dgvUsuarios.TabIndex = 1
        '
        'PanelFiltrosUsuario
        '
        Me.PanelFiltrosUsuario.Controls.Add(Me.GroupBoxFiltrarUsuario)
        Me.PanelFiltrosUsuario.Controls.Add(Me.GroupBoxAccionesUsuario)
        Me.PanelFiltrosUsuario.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelFiltrosUsuario.Location = New System.Drawing.Point(0, 0)
        Me.PanelFiltrosUsuario.Name = "PanelFiltrosUsuario"
        Me.PanelFiltrosUsuario.Size = New System.Drawing.Size(1077, 100)
        Me.PanelFiltrosUsuario.TabIndex = 0
        '
        'GroupBoxFiltrarUsuario
        '
        Me.GroupBoxFiltrarUsuario.Controls.Add(Me.txtEmail)
        Me.GroupBoxFiltrarUsuario.Controls.Add(Me.Label9)
        Me.GroupBoxFiltrarUsuario.Controls.Add(Me.txtName)
        Me.GroupBoxFiltrarUsuario.Controls.Add(Me.txtUsername)
        Me.GroupBoxFiltrarUsuario.Controls.Add(Me.Label2)
        Me.GroupBoxFiltrarUsuario.Controls.Add(Me.Label1)
        Me.GroupBoxFiltrarUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxFiltrarUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBoxFiltrarUsuario.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxFiltrarUsuario.Name = "GroupBoxFiltrarUsuario"
        Me.GroupBoxFiltrarUsuario.Size = New System.Drawing.Size(641, 100)
        Me.GroupBoxFiltrarUsuario.TabIndex = 38
        Me.GroupBoxFiltrarUsuario.TabStop = False
        Me.GroupBoxFiltrarUsuario.Text = "Filtrar por"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(164, 68)
        Me.txtEmail.MaxLength = 255
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(295, 21)
        Me.txtEmail.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label9.Location = New System.Drawing.Point(93, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 17)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Email"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(164, 42)
        Me.txtName.MaxLength = 100
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(295, 21)
        Me.txtName.TabIndex = 50
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(164, 16)
        Me.txtUsername.MaxLength = 40
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(207, 21)
        Me.txtUsername.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(39, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 17)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Nombre completo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(33, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Nombre de usuario"
        '
        'GroupBoxAccionesUsuario
        '
        Me.GroupBoxAccionesUsuario.Controls.Add(Me.btnSalir)
        Me.GroupBoxAccionesUsuario.Controls.Add(Me.btnGuardar)
        Me.GroupBoxAccionesUsuario.Controls.Add(Me.btnBorrarFiltro)
        Me.GroupBoxAccionesUsuario.Controls.Add(Me.btnFiltrar)
        Me.GroupBoxAccionesUsuario.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBoxAccionesUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBoxAccionesUsuario.Location = New System.Drawing.Point(641, 0)
        Me.GroupBoxAccionesUsuario.Margin = New System.Windows.Forms.Padding(10)
        Me.GroupBoxAccionesUsuario.Name = "GroupBoxAccionesUsuario"
        Me.GroupBoxAccionesUsuario.Padding = New System.Windows.Forms.Padding(20)
        Me.GroupBoxAccionesUsuario.Size = New System.Drawing.Size(436, 100)
        Me.GroupBoxAccionesUsuario.TabIndex = 37
        Me.GroupBoxAccionesUsuario.TabStop = False
        Me.GroupBoxAccionesUsuario.Text = "Acciones"
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.SystemColors.Control
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSalir.FlatAppearance.BorderSize = 2
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Location = New System.Drawing.Point(320, 34)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(10)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Padding = New System.Windows.Forms.Padding(3)
        Me.btnSalir.Size = New System.Drawing.Size(100, 46)
        Me.btnSalir.TabIndex = 18
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Location = New System.Drawing.Point(220, 34)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(100, 46)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnBorrarFiltro
        '
        Me.btnBorrarFiltro.BackColor = System.Drawing.SystemColors.Control
        Me.btnBorrarFiltro.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBorrarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBorrarFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnBorrarFiltro.ForeColor = System.Drawing.Color.Black
        Me.btnBorrarFiltro.Location = New System.Drawing.Point(120, 34)
        Me.btnBorrarFiltro.Name = "btnBorrarFiltro"
        Me.btnBorrarFiltro.Size = New System.Drawing.Size(100, 46)
        Me.btnBorrarFiltro.TabIndex = 16
        Me.btnBorrarFiltro.Text = "&Borrar filtro"
        Me.btnBorrarFiltro.UseVisualStyleBackColor = False
        '
        'btnFiltrar
        '
        Me.btnFiltrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnFiltrar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnFiltrar.ForeColor = System.Drawing.Color.Black
        Me.btnFiltrar.Location = New System.Drawing.Point(20, 34)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Padding = New System.Windows.Forms.Padding(5)
        Me.btnFiltrar.Size = New System.Drawing.Size(100, 46)
        Me.btnFiltrar.TabIndex = 15
        Me.btnFiltrar.Text = "&Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = False
        '
        'FrmGestionPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 597)
        Me.Controls.Add(Me.PanelContainer)
        Me.Name = "FrmGestionPermisos"
        Me.Text = "Administración de seguridad"
        Me.PanelContainer.ResumeLayout(False)
        Me.GroupBoxPermisos.ResumeLayout(False)
        CType(Me.dgvPermisos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxUsuarios.ResumeLayout(False)
        Me.PanelUsuariosContenedor.ResumeLayout(False)
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelFiltrosUsuario.ResumeLayout(False)
        Me.GroupBoxFiltrarUsuario.ResumeLayout(False)
        Me.GroupBoxFiltrarUsuario.PerformLayout()
        Me.GroupBoxAccionesUsuario.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelContainer As Panel
    Friend WithEvents GroupBoxPermisos As GroupBox
    Friend WithEvents dgvPermisos As DataGridView
    Friend WithEvents GroupBoxUsuarios As GroupBox
    Friend WithEvents PanelUsuariosContenedor As Panel
    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents PanelFiltrosUsuario As Panel
    Friend WithEvents GroupBoxAccionesUsuario As GroupBox
    Friend WithEvents GroupBoxFiltrarUsuario As GroupBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Private WithEvents btnSalir As Button
    Private WithEvents btnGuardar As Button
    Private WithEvents btnBorrarFiltro As Button
    Private WithEvents btnFiltrar As Button
End Class
