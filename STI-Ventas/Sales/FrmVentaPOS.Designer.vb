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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.GroupBoxMainData = New System.Windows.Forms.GroupBox()
        Me.PanelMaindData = New System.Windows.Forms.Panel()
        Me.PanelMainGrid = New System.Windows.Forms.Panel()
        Me.PanelMainDataFooter = New System.Windows.Forms.Panel()
        Me.txtDetailsTotalLinea = New System.Windows.Forms.TextBox()
        Me.txtDetailsDescuento = New System.Windows.Forms.TextBox()
        Me.txtDetailsPrecio = New System.Windows.Forms.TextBox()
        Me.txtDetailsCantidad = New System.Windows.Forms.TextBox()
        Me.txtDetailsDescripcion = New System.Windows.Forms.TextBox()
        Me.txtDetailsCodigoBarras = New System.Windows.Forms.TextBox()
        Me.dgvLineas = New System.Windows.Forms.DataGridView()
        Me.CodigoBarra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalLinea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdLineaVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineaVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelMainDetails = New System.Windows.Forms.Panel()
        Me.btnGuardarLinea = New System.Windows.Forms.Button()
        Me.GroupBoxAcciones = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnTicketPreventa = New System.Windows.Forms.Button()
        Me.btnPedido = New System.Windows.Forms.Button()
        Me.btnSupervisor = New System.Windows.Forms.Button()
        Me.btnAnularProducto = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCobrarOV = New System.Windows.Forms.Button()
        Me.GroupBoxHeader = New System.Windows.Forms.GroupBox()
        Me.PanelHeaderSearchAndTittle = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.PanelBusqueda = New System.Windows.Forms.Panel()
        Me.txtCantidadBusqueda = New System.Windows.Forms.NumericUpDown()
        Me.txtBuscaProducto = New System.Windows.Forms.TextBox()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.PanelHeaderItemsDetails = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.LabelNombreProducto = New System.Windows.Forms.Label()
        Me.ErrorProviderSTI = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PanelContainer.SuspendLayout()
        Me.GroupBoxMainData.SuspendLayout()
        Me.PanelMaindData.SuspendLayout()
        Me.PanelMainGrid.SuspendLayout()
        Me.PanelMainDataFooter.SuspendLayout()
        CType(Me.dgvLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMainDetails.SuspendLayout()
        Me.GroupBoxAcciones.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBoxHeader.SuspendLayout()
        Me.PanelHeaderSearchAndTittle.SuspendLayout()
        Me.PanelBusqueda.SuspendLayout()
        CType(Me.txtCantidadBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelHeaderItemsDetails.SuspendLayout()
        CType(Me.ErrorProviderSTI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.White
        Me.PanelContainer.Controls.Add(Me.GroupBoxMainData)
        Me.PanelContainer.Controls.Add(Me.GroupBoxAcciones)
        Me.PanelContainer.Controls.Add(Me.GroupBoxHeader)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(1145, 804)
        Me.PanelContainer.TabIndex = 0
        '
        'GroupBoxMainData
        '
        Me.GroupBoxMainData.Controls.Add(Me.PanelMaindData)
        Me.GroupBoxMainData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxMainData.Location = New System.Drawing.Point(0, 115)
        Me.GroupBoxMainData.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBoxMainData.Name = "GroupBoxMainData"
        Me.GroupBoxMainData.Padding = New System.Windows.Forms.Padding(1)
        Me.GroupBoxMainData.Size = New System.Drawing.Size(1145, 589)
        Me.GroupBoxMainData.TabIndex = 1
        Me.GroupBoxMainData.TabStop = False
        '
        'PanelMaindData
        '
        Me.PanelMaindData.Controls.Add(Me.PanelMainGrid)
        Me.PanelMaindData.Controls.Add(Me.PanelMainDetails)
        Me.PanelMaindData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMaindData.Location = New System.Drawing.Point(1, 14)
        Me.PanelMaindData.Name = "PanelMaindData"
        Me.PanelMaindData.Size = New System.Drawing.Size(1143, 574)
        Me.PanelMaindData.TabIndex = 2
        '
        'PanelMainGrid
        '
        Me.PanelMainGrid.Controls.Add(Me.PanelMainDataFooter)
        Me.PanelMainGrid.Controls.Add(Me.dgvLineas)
        Me.PanelMainGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMainGrid.Location = New System.Drawing.Point(0, 0)
        Me.PanelMainGrid.Name = "PanelMainGrid"
        Me.PanelMainGrid.Size = New System.Drawing.Size(1143, 474)
        Me.PanelMainGrid.TabIndex = 1
        '
        'PanelMainDataFooter
        '
        Me.PanelMainDataFooter.Controls.Add(Me.txtDetailsTotalLinea)
        Me.PanelMainDataFooter.Controls.Add(Me.txtDetailsDescuento)
        Me.PanelMainDataFooter.Controls.Add(Me.txtDetailsPrecio)
        Me.PanelMainDataFooter.Controls.Add(Me.txtDetailsCantidad)
        Me.PanelMainDataFooter.Controls.Add(Me.txtDetailsDescripcion)
        Me.PanelMainDataFooter.Controls.Add(Me.txtDetailsCodigoBarras)
        Me.PanelMainDataFooter.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PanelMainDataFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelMainDataFooter.Location = New System.Drawing.Point(0, 420)
        Me.PanelMainDataFooter.Name = "PanelMainDataFooter"
        Me.PanelMainDataFooter.Size = New System.Drawing.Size(1143, 54)
        Me.PanelMainDataFooter.TabIndex = 1
        '
        'txtDetailsTotalLinea
        '
        Me.txtDetailsTotalLinea.BackColor = System.Drawing.Color.White
        Me.txtDetailsTotalLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDetailsTotalLinea.Location = New System.Drawing.Point(938, 14)
        Me.txtDetailsTotalLinea.Name = "txtDetailsTotalLinea"
        Me.txtDetailsTotalLinea.ReadOnly = True
        Me.txtDetailsTotalLinea.Size = New System.Drawing.Size(203, 26)
        Me.txtDetailsTotalLinea.TabIndex = 5
        Me.txtDetailsTotalLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDetailsDescuento
        '
        Me.txtDetailsDescuento.BackColor = System.Drawing.Color.White
        Me.txtDetailsDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDetailsDescuento.Location = New System.Drawing.Point(820, 14)
        Me.txtDetailsDescuento.Name = "txtDetailsDescuento"
        Me.txtDetailsDescuento.ReadOnly = True
        Me.txtDetailsDescuento.Size = New System.Drawing.Size(117, 26)
        Me.txtDetailsDescuento.TabIndex = 4
        Me.txtDetailsDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDetailsPrecio
        '
        Me.txtDetailsPrecio.BackColor = System.Drawing.Color.White
        Me.txtDetailsPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDetailsPrecio.Location = New System.Drawing.Point(700, 14)
        Me.txtDetailsPrecio.Name = "txtDetailsPrecio"
        Me.txtDetailsPrecio.ReadOnly = True
        Me.txtDetailsPrecio.Size = New System.Drawing.Size(118, 26)
        Me.txtDetailsPrecio.TabIndex = 3
        Me.txtDetailsPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDetailsCantidad
        '
        Me.txtDetailsCantidad.BackColor = System.Drawing.Color.White
        Me.txtDetailsCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDetailsCantidad.Location = New System.Drawing.Point(550, 14)
        Me.txtDetailsCantidad.Name = "txtDetailsCantidad"
        Me.txtDetailsCantidad.ReadOnly = True
        Me.txtDetailsCantidad.Size = New System.Drawing.Size(145, 26)
        Me.txtDetailsCantidad.TabIndex = 2
        Me.txtDetailsCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDetailsDescripcion
        '
        Me.txtDetailsDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDetailsDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDetailsDescripcion.Location = New System.Drawing.Point(186, 14)
        Me.txtDetailsDescripcion.Name = "txtDetailsDescripcion"
        Me.txtDetailsDescripcion.ReadOnly = True
        Me.txtDetailsDescripcion.Size = New System.Drawing.Size(358, 26)
        Me.txtDetailsDescripcion.TabIndex = 1
        '
        'txtDetailsCodigoBarras
        '
        Me.txtDetailsCodigoBarras.BackColor = System.Drawing.Color.White
        Me.txtDetailsCodigoBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDetailsCodigoBarras.Location = New System.Drawing.Point(2, 14)
        Me.txtDetailsCodigoBarras.Name = "txtDetailsCodigoBarras"
        Me.txtDetailsCodigoBarras.ReadOnly = True
        Me.txtDetailsCodigoBarras.Size = New System.Drawing.Size(178, 26)
        Me.txtDetailsCodigoBarras.TabIndex = 0
        '
        'dgvLineas
        '
        Me.dgvLineas.AllowUserToAddRows = False
        Me.dgvLineas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvLineas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLineas.BackgroundColor = System.Drawing.Color.White
        Me.dgvLineas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvLineas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal
        Me.dgvLineas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLineas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLineas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoBarra, Me.Descripcion, Me.Cantidad, Me.Precio, Me.Descuento, Me.TotalLinea, Me.IdProducto, Me.Unidad, Me.IdLineaVenta, Me.LineaVenta})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLineas.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvLineas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLineas.GridColor = System.Drawing.Color.White
        Me.dgvLineas.Location = New System.Drawing.Point(0, 0)
        Me.dgvLineas.MultiSelect = False
        Me.dgvLineas.Name = "dgvLineas"
        Me.dgvLineas.ReadOnly = True
        Me.dgvLineas.RowHeadersVisible = False
        Me.dgvLineas.RowHeadersWidth = 10
        Me.dgvLineas.RowTemplate.DividerHeight = 2
        Me.dgvLineas.RowTemplate.Height = 25
        Me.dgvLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLineas.Size = New System.Drawing.Size(1143, 474)
        Me.dgvLineas.TabIndex = 0
        '
        'CodigoBarra
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.CodigoBarra.DefaultCellStyle = DataGridViewCellStyle3
        Me.CodigoBarra.DividerWidth = 2
        Me.CodigoBarra.HeaderText = "Cod.Barra"
        Me.CodigoBarra.MinimumWidth = 10
        Me.CodigoBarra.Name = "CodigoBarra"
        Me.CodigoBarra.ReadOnly = True
        Me.CodigoBarra.Width = 210
        '
        'Descripcion
        '
        Me.Descripcion.DividerWidth = 2
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.MinimumWidth = 10
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 340
        '
        'Cantidad
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cantidad.DividerWidth = 2
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 130
        '
        'Precio
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.Precio.DefaultCellStyle = DataGridViewCellStyle5
        Me.Precio.DividerWidth = 2
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Width = 130
        '
        'Descuento
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.Descuento.DefaultCellStyle = DataGridViewCellStyle6
        Me.Descuento.DividerWidth = 2
        Me.Descuento.HeaderText = "Descuento"
        Me.Descuento.Name = "Descuento"
        Me.Descuento.ReadOnly = True
        Me.Descuento.Width = 120
        '
        'TotalLinea
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.TotalLinea.DefaultCellStyle = DataGridViewCellStyle7
        Me.TotalLinea.DividerWidth = 2
        Me.TotalLinea.HeaderText = "Total Línea"
        Me.TotalLinea.Name = "TotalLinea"
        Me.TotalLinea.ReadOnly = True
        Me.TotalLinea.Width = 200
        '
        'IdProducto
        '
        Me.IdProducto.HeaderText = "IdProducto"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.ReadOnly = True
        Me.IdProducto.Visible = False
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.ReadOnly = True
        Me.Unidad.Visible = False
        '
        'IdLineaVenta
        '
        Me.IdLineaVenta.HeaderText = "IdLineaVenta"
        Me.IdLineaVenta.Name = "IdLineaVenta"
        Me.IdLineaVenta.ReadOnly = True
        Me.IdLineaVenta.Visible = False
        '
        'LineaVenta
        '
        Me.LineaVenta.HeaderText = "LineaVenta"
        Me.LineaVenta.Name = "LineaVenta"
        Me.LineaVenta.ReadOnly = True
        Me.LineaVenta.Visible = False
        '
        'PanelMainDetails
        '
        Me.PanelMainDetails.Controls.Add(Me.btnGuardarLinea)
        Me.PanelMainDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelMainDetails.Location = New System.Drawing.Point(0, 474)
        Me.PanelMainDetails.Name = "PanelMainDetails"
        Me.PanelMainDetails.Size = New System.Drawing.Size(1143, 100)
        Me.PanelMainDetails.TabIndex = 0
        '
        'btnGuardarLinea
        '
        Me.btnGuardarLinea.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardarLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarLinea.Location = New System.Drawing.Point(3, 35)
        Me.btnGuardarLinea.Name = "btnGuardarLinea"
        Me.btnGuardarLinea.Size = New System.Drawing.Size(200, 47)
        Me.btnGuardarLinea.TabIndex = 103
        Me.btnGuardarLinea.Text = "Guardar"
        Me.btnGuardarLinea.UseVisualStyleBackColor = True
        '
        'GroupBoxAcciones
        '
        Me.GroupBoxAcciones.Controls.Add(Me.Panel2)
        Me.GroupBoxAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBoxAcciones.Location = New System.Drawing.Point(0, 704)
        Me.GroupBoxAcciones.Name = "GroupBoxAcciones"
        Me.GroupBoxAcciones.Size = New System.Drawing.Size(1145, 100)
        Me.GroupBoxAcciones.TabIndex = 0
        Me.GroupBoxAcciones.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.btnTicketPreventa)
        Me.Panel2.Controls.Add(Me.btnPedido)
        Me.Panel2.Controls.Add(Me.btnSupervisor)
        Me.Panel2.Controls.Add(Me.btnAnularProducto)
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.btnCobrarOV)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1139, 81)
        Me.Panel2.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1139, 25)
        Me.Panel1.TabIndex = 108
        '
        'btnTicketPreventa
        '
        Me.btnTicketPreventa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTicketPreventa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTicketPreventa.Location = New System.Drawing.Point(770, 3)
        Me.btnTicketPreventa.Name = "btnTicketPreventa"
        Me.btnTicketPreventa.Size = New System.Drawing.Size(148, 47)
        Me.btnTicketPreventa.TabIndex = 107
        Me.btnTicketPreventa.Text = "Ticket preventa"
        Me.btnTicketPreventa.UseVisualStyleBackColor = True
        '
        'btnPedido
        '
        Me.btnPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPedido.Location = New System.Drawing.Point(616, 3)
        Me.btnPedido.Name = "btnPedido"
        Me.btnPedido.Size = New System.Drawing.Size(148, 47)
        Me.btnPedido.TabIndex = 106
        Me.btnPedido.Text = "Pedido"
        Me.btnPedido.UseVisualStyleBackColor = True
        '
        'btnSupervisor
        '
        Me.btnSupervisor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupervisor.Location = New System.Drawing.Point(462, 3)
        Me.btnSupervisor.Name = "btnSupervisor"
        Me.btnSupervisor.Size = New System.Drawing.Size(148, 47)
        Me.btnSupervisor.TabIndex = 105
        Me.btnSupervisor.Text = "Supervisor"
        Me.btnSupervisor.UseVisualStyleBackColor = True
        '
        'btnAnularProducto
        '
        Me.btnAnularProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAnularProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnularProducto.Location = New System.Drawing.Point(308, 3)
        Me.btnAnularProducto.Name = "btnAnularProducto"
        Me.btnAnularProducto.Size = New System.Drawing.Size(148, 47)
        Me.btnAnularProducto.TabIndex = 104
        Me.btnAnularProducto.Text = "Anular producto"
        Me.btnAnularProducto.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(154, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(148, 47)
        Me.btnCerrar.TabIndex = 103
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCobrarOV
        '
        Me.btnCobrarOV.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCobrarOV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCobrarOV.Location = New System.Drawing.Point(0, 3)
        Me.btnCobrarOV.Name = "btnCobrarOV"
        Me.btnCobrarOV.Size = New System.Drawing.Size(148, 47)
        Me.btnCobrarOV.TabIndex = 102
        Me.btnCobrarOV.Text = "Cobrar"
        Me.btnCobrarOV.UseVisualStyleBackColor = True
        '
        'GroupBoxHeader
        '
        Me.GroupBoxHeader.Controls.Add(Me.PanelHeaderSearchAndTittle)
        Me.GroupBoxHeader.Controls.Add(Me.PanelHeaderItemsDetails)
        Me.GroupBoxHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxHeader.Name = "GroupBoxHeader"
        Me.GroupBoxHeader.Size = New System.Drawing.Size(1145, 115)
        Me.GroupBoxHeader.TabIndex = 1
        Me.GroupBoxHeader.TabStop = False
        '
        'PanelHeaderSearchAndTittle
        '
        Me.PanelHeaderSearchAndTittle.Controls.Add(Me.lblTitle)
        Me.PanelHeaderSearchAndTittle.Controls.Add(Me.PanelBusqueda)
        Me.PanelHeaderSearchAndTittle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelHeaderSearchAndTittle.Location = New System.Drawing.Point(3, 16)
        Me.PanelHeaderSearchAndTittle.Name = "PanelHeaderSearchAndTittle"
        Me.PanelHeaderSearchAndTittle.Size = New System.Drawing.Size(1139, 44)
        Me.PanelHeaderSearchAndTittle.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(107, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(130, 26)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "STI-Ventas"
        '
        'PanelBusqueda
        '
        Me.PanelBusqueda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelBusqueda.Controls.Add(Me.txtCantidadBusqueda)
        Me.PanelBusqueda.Controls.Add(Me.txtBuscaProducto)
        Me.PanelBusqueda.Controls.Add(Me.btnBuscarProducto)
        Me.PanelBusqueda.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelBusqueda.Location = New System.Drawing.Point(441, 0)
        Me.PanelBusqueda.Margin = New System.Windows.Forms.Padding(10)
        Me.PanelBusqueda.Name = "PanelBusqueda"
        Me.PanelBusqueda.Padding = New System.Windows.Forms.Padding(5, 8, 5, 5)
        Me.PanelBusqueda.Size = New System.Drawing.Size(698, 44)
        Me.PanelBusqueda.TabIndex = 0
        '
        'txtCantidadBusqueda
        '
        Me.txtCantidadBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadBusqueda.DecimalPlaces = 2
        Me.txtCantidadBusqueda.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtCantidadBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.ErrorProviderSTI.SetIconPadding(Me.txtCantidadBusqueda, 2)
        Me.txtCantidadBusqueda.Location = New System.Drawing.Point(130, 8)
        Me.txtCantidadBusqueda.Margin = New System.Windows.Forms.Padding(10, 3, 10, 3)
        Me.txtCantidadBusqueda.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
        Me.txtCantidadBusqueda.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCantidadBusqueda.Name = "txtCantidadBusqueda"
        Me.txtCantidadBusqueda.Size = New System.Drawing.Size(140, 27)
        Me.txtCantidadBusqueda.TabIndex = 105
        Me.txtCantidadBusqueda.ThousandsSeparator = True
        Me.txtCantidadBusqueda.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtBuscaProducto
        '
        Me.txtBuscaProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscaProducto.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtBuscaProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtBuscaProducto.Location = New System.Drawing.Point(270, 8)
        Me.txtBuscaProducto.MaxLength = 1000
        Me.txtBuscaProducto.Name = "txtBuscaProducto"
        Me.txtBuscaProducto.Size = New System.Drawing.Size(423, 27)
        Me.txtBuscaProducto.TabIndex = 106
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarProducto.Location = New System.Drawing.Point(5, 8)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(119, 31)
        Me.btnBuscarProducto.TabIndex = 103
        Me.btnBuscarProducto.Text = "Buscar"
        Me.btnBuscarProducto.UseVisualStyleBackColor = True
        '
        'PanelHeaderItemsDetails
        '
        Me.PanelHeaderItemsDetails.Controls.Add(Me.lblTotal)
        Me.PanelHeaderItemsDetails.Controls.Add(Me.LabelNombreProducto)
        Me.PanelHeaderItemsDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelHeaderItemsDetails.Location = New System.Drawing.Point(3, 60)
        Me.PanelHeaderItemsDetails.Name = "PanelHeaderItemsDetails"
        Me.PanelHeaderItemsDetails.Size = New System.Drawing.Size(1139, 52)
        Me.PanelHeaderItemsDetails.TabIndex = 1
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(930, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(209, 52)
        Me.lblTotal.TabIndex = 1
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelNombreProducto
        '
        Me.LabelNombreProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelNombreProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelNombreProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LabelNombreProducto.ForeColor = System.Drawing.Color.Blue
        Me.LabelNombreProducto.Location = New System.Drawing.Point(0, 0)
        Me.LabelNombreProducto.Name = "LabelNombreProducto"
        Me.LabelNombreProducto.Size = New System.Drawing.Size(1139, 52)
        Me.LabelNombreProducto.TabIndex = 0
        Me.LabelNombreProducto.Text = "Nombre producto"
        Me.LabelNombreProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ErrorProviderSTI
        '
        Me.ErrorProviderSTI.BlinkRate = 300
        Me.ErrorProviderSTI.ContainerControl = Me
        '
        'FrmVentaPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 804)
        Me.Controls.Add(Me.PanelContainer)
        Me.Name = "FrmVentaPOS"
        Me.Text = "Ventas"
        Me.PanelContainer.ResumeLayout(False)
        Me.GroupBoxMainData.ResumeLayout(False)
        Me.PanelMaindData.ResumeLayout(False)
        Me.PanelMainGrid.ResumeLayout(False)
        Me.PanelMainDataFooter.ResumeLayout(False)
        Me.PanelMainDataFooter.PerformLayout()
        CType(Me.dgvLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMainDetails.ResumeLayout(False)
        Me.GroupBoxAcciones.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBoxHeader.ResumeLayout(False)
        Me.PanelHeaderSearchAndTittle.ResumeLayout(False)
        Me.PanelHeaderSearchAndTittle.PerformLayout()
        Me.PanelBusqueda.ResumeLayout(False)
        Me.PanelBusqueda.PerformLayout()
        CType(Me.txtCantidadBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelHeaderItemsDetails.ResumeLayout(False)
        CType(Me.ErrorProviderSTI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelContainer As Panel
    Friend WithEvents GroupBoxAcciones As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCobrarOV As Button
    Friend WithEvents GroupBoxHeader As GroupBox
    Friend WithEvents PanelHeaderSearchAndTittle As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents PanelBusqueda As Panel
    Friend WithEvents txtBuscaProducto As TextBox
    Friend WithEvents btnBuscarProducto As Button
    Friend WithEvents PanelMaindData As Panel
    Friend WithEvents PanelMainGrid As Panel
    Friend WithEvents dgvLineas As DataGridView
    Friend WithEvents PanelMainDetails As Panel
    Friend WithEvents PanelHeaderItemsDetails As Panel
    Friend WithEvents GroupBoxMainData As GroupBox
    Friend WithEvents btnGuardarLinea As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents LabelNombreProducto As Label
    Friend WithEvents btnTicketPreventa As Button
    Friend WithEvents btnPedido As Button
    Friend WithEvents btnSupervisor As Button
    Friend WithEvents btnAnularProducto As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents PanelMainDataFooter As Panel
    Friend WithEvents txtDetailsTotalLinea As TextBox
    Friend WithEvents txtDetailsDescuento As TextBox
    Friend WithEvents txtDetailsPrecio As TextBox
    Friend WithEvents txtDetailsCantidad As TextBox
    Friend WithEvents txtDetailsDescripcion As TextBox
    Friend WithEvents txtDetailsCodigoBarras As TextBox
    Friend WithEvents Panel1 As Panel
    Protected WithEvents ErrorProviderSTI As ErrorProvider
    Friend WithEvents txtCantidadBusqueda As NumericUpDown
    Friend WithEvents CodigoBarra As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Precio As DataGridViewTextBoxColumn
    Friend WithEvents Descuento As DataGridViewTextBoxColumn
    Friend WithEvents TotalLinea As DataGridViewTextBoxColumn
    Friend WithEvents IdProducto As DataGridViewTextBoxColumn
    Friend WithEvents Unidad As DataGridViewTextBoxColumn
    Friend WithEvents IdLineaVenta As DataGridViewTextBoxColumn
    Friend WithEvents LineaVenta As DataGridViewTextBoxColumn
End Class
