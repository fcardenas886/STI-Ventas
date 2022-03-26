Imports STIVentas.Controller
Imports STIVentas.Model

''' <summary>
''' 'Form para asignación de permisos a usuarios.
''' </summary>
''' <remarks>14.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class FrmGestionPermisos

#Region "Class methods"

    Protected Friend Sub ClearFields()

        txtEmail.Clear()
        txtName().Clear()
        txtUsername.Clear()

        LoadUsuarioRecords()
    End Sub

    Protected Sub OnFormLoaded()

        LoadUsuarioRecords()
        SetupDataGridView(dgvPermisos)
        SetupDataGridView(dgvUsuarios)
        LoadPermisosRecords()

    End Sub

    Public Function GetCurrentUsuarioModel() As UsuarioModel
        Dim dbTable As New UsuarioModel With {
            .Id = 0
        }

        Return dbTable
    End Function

    Protected Sub LoadUsuarioRecords()
        Dim controller As UsuarioController
        Dim records As List(Of UsuarioModel)

        Try
            Cursor = Cursors.WaitCursor

            If dgvUsuarios.Columns().Count < 1 Then
                dgvUsuarios.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})
                dgvUsuarios.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Username", .HeaderText = "Nombre de usuario", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})
                dgvUsuarios.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Nombre", .HeaderText = "Nombre completo", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})
                dgvUsuarios.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Alias", .HeaderText = "Alias"})
                dgvUsuarios.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Email", .HeaderText = "Email", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})
                dgvUsuarios.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Estatus", .HeaderText = "Estatus"})
            End If

            controller = New UsuarioController()
            records = CType(controller.GetList(), List(Of UsuarioModel))

            'dgvUsuarios.DataSource = records
            dgvUsuarios.Rows.Clear()

            For Each model As UsuarioModel In records
                dgvUsuarios.Rows().Add(model.Id, model.Username, model.Nombre, model.AliasName,
                                         model.Email, model.Status = EstadoUsuario.Activo)
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Protected Sub LoadPermisosRecords()

        Dim controller As ModuloController
        Dim records As List(Of ModuloModel)
        Try
            Cursor = Cursors.WaitCursor

            If dgvPermisos.Columns().Count < 1 Then
                dgvPermisos.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Id", .HeaderText = "Id"})
                dgvPermisos.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Asignar", .HeaderText = "Asignar"})
                dgvPermisos.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "NombrePermiso", .HeaderText = "Permiso", .MinimumWidth = 400})
                dgvPermisos.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Agregar", .HeaderText = "Agregar"})
                dgvPermisos.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Editar", .HeaderText = "Editar"})
                dgvPermisos.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "Eliminar", .HeaderText = "Eliminar"})
            End If

            dgvPermisos.Rows().Clear()

            controller = New ModuloController()
            records = CType(controller.GetList(), List(Of ModuloModel))

            'dgvUsuarios.DataSource = records
            dgvPermisos.Rows.Clear()

            For Each model As ModuloModel In records
                dgvPermisos.Rows().Add(model.Id, model.Idmodulo, model.Nombre)
            Next

            If records.Count < 1 And Not String.IsNullOrEmpty(controller.LastError) Then
                HandleException(controller.LastError)
            End If
        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub

    Protected Sub FiltraUsuarios()

    End Sub

    Protected Sub GuardaPermisos()

        InsertRecord()


    End Sub


    Protected Friend Function InsertRecord() As Boolean
        Dim ret As Boolean = False
        Dim uomController As PermisosController

        Try


            Cursor = Cursors.WaitCursor
            uomController = New PermisosController()
            ret = uomController.Insert(GetCurrentTable())

            If Not ret Then
                HandleException(uomController.LastError)
            End If

        Catch ex As Exception
            HandleException(ex)
        Finally
            Cursor = Cursors.Default
        End Try

        Return ret
    End Function


    Public Function GetCurrentTable() As IDBTable
        Dim row As DataGridViewRow = dgvUsuarios.CurrentRow
        Dim row2 As DataGridViewRow = dgvPermisos.CurrentRow
        Dim idu As Integer
        idu = CInt(row.Cells("Id").Value)
        Dim dbTable As New PermisosModel With {
            .Id = 0,
            .IdUsuario = idu,
            .IdModulo = CInt(row2.Cells("Id").Value),
            .Insertar = CBool(row2.Cells("Agregar").Value),
            .Editar = CBool(row2.Cells("Editar").Value),
            .Eliminar = CBool(row2.Cells("Eliminar").Value)
        }

        ' dbTable.Password = IIf(String.IsNullOrEmpty(txtPassword.Text), txtPassword.Text, New AES().Encrypt(txtPassword.Text, DBSettings.appPwdUnique, 256))
        'dbTable.Status = IIf(chkEnabled.Checked, EstadoUsuario.Activo, EstadoUsuario.Inactivo)

        Return dbTable
    End Function

    Private Sub CierraForm()
        Close()
    End Sub

#End Region
#Region "Events"
    Private Sub FrmGestionPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OnFormLoaded()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        FiltraUsuarios()
    End Sub

    Private Sub btnBorrarFiltro_Click(sender As Object, e As EventArgs) Handles btnBorrarFiltro.Click
        ClearFields()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardaPermisos()
        Console.WriteLine("entro al boton")
        Console.WriteLine("")
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        CierraForm()
    End Sub

    Private Sub dgvUsuarios_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUsuarios.SelectionChanged
        LoadPermisosRecords()
    End Sub

#End Region
End Class