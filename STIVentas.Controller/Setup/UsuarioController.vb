
Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para usuarios del sistema
''' </summary>
''' <remarks>20.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class UsuarioController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblUsuario"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As UsuarioModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, UsuarioModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblUsuario(Username, Nombre, Alias, Password, Status, Email) " &
                    "VALUES(@Id, @Name, @Alias, @Password, @Status, @Email);"

            params.Add(BuildParameter("@Id", table.Username, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Alias", table.AliasName, DbType.String))
            params.Add(BuildParameter("@Password", table.Password, DbType.String))
            params.Add(BuildParameter("@Status", table.Status, DbType.SByte))
            params.Add(BuildParameter("@Email", table.Email, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As UsuarioModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, UsuarioModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            ''sql = "DELETE FROM TblUsuario WHERE Username = @Id;"
            sql = "UPDATE TblUsuario SET Status = " & CType(EstadoUsuario.Eliminado, Integer).ToString() &
                  " WHERE Username = @Id;"

            params.Add(BuildParameter("@Id", table.Username, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As UsuarioModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, UsuarioModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblUsuario SET Nombre = @Name, Alias = @Alias, Password = @Password, Status = @Status, Email = @Email " &
                    "WHERE Username = @Id;"

            params.Add(BuildParameter("@Id", table.Username, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Alias", table.AliasName, DbType.String))
            params.Add(BuildParameter("@Password", table.Password, DbType.String))
            params.Add(BuildParameter("@Status", table.Status, DbType.SByte))
            params.Add(BuildParameter("@Email", table.Email, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of UsuarioModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, Username, IFNULL(Nombre, '') Nombre, IFNULL(Alias, '') Alias, Password, Status, Email FROM TblUsuario WHERE Status<>" & CType(EstadoUsuario.Eliminado, Integer).ToString()


            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows

                ret.Add(
                        New UsuarioModel With {
                            .Id = dataRow(0),
                            .Username = dataRow(1),
                            .Nombre = dataRow(2),
                            .AliasName = dataRow(3),
                            .Password = dataRow(4),
                            .Status = dataRow(5),
                            .Email = dataRow(6)
                            }
                        )
            Next

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Function GetUsuario(ByVal username As String, ByVal pass As String) As Integer
        Dim ret As Integer
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim params As List(Of MySqlParameter)

        Try
            dbConnector = New DBConnector()
            params = New List(Of MySqlParameter)
            sql = "SELECT Id, Username, IFNULL(Nombre, '') Nombre, IFNULL(Alias, '') Alias, Password, Status, Email FROM TblUsuario WHERE Username= @user and  Password= @pass;"

            params.Add(BuildParameter("@user", username, DbType.String))
            params.Add(BuildParameter("@pass", pass, DbType.String))
            dataTable = dbConnector.ReadDataTable(sql)
            ret = dataTable.Rows.Count
            MsgBox(ret)
            For Each dataRow As DataRow In dataTable.Rows


            Next

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overrides Function TableName() As String
        Return NombreTabla
    End Function

    Protected Overrides Sub HandleCustomRowForQueryToList(ByRef objectToReturn As Object, ByVal dataRow As DataRow, propertyName As String)
        Dim UsuarioModel As UsuarioModel

        Try
            UsuarioModel = objectToReturn

            If UsuarioModel Is Nothing Then
                Return
            End If

            Select Case propertyName.ToUpper()
                Case "ALIASNAME"
                    UsuarioModel.AliasName = dataRow("Alias")
            End Select

            objectToReturn = UsuarioModel
        Catch
            Return
        End Try
    End Sub

    Public Function ExistUsername(username As String) As Boolean
        Dim ret As Boolean
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim params As List(Of MySqlParameter)

        Try
            dbConnector = New DBConnector()

            params = New List(Of MySqlParameter)
            sql = "SELECT Id FROM TblUsuario WHERE Username = @Username LIMIT 1;"

            params.Add(BuildParameter("@Username", username, DbType.String))

            dataTable = dbConnector.ReadDataTable(sql, params)
            LastError = dbConnector.LastError

            ret = dataTable.Rows.Count = 0 And String.IsNullOrEmpty(dbConnector.LastError)

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function


#End Region

    Public Overloads Function GetListuser(ByVal u As String) As UsuarioModel
        Dim ret As String
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim dbTable As New UsuarioModel
        Dim params As List(Of MySqlParameter)

        Try
            dbConnector = New DBConnector()
            params = New List(Of MySqlParameter)
            sql = "SELECT Id, Username, IFNULL(Nombre, '') Nombre, IFNULL(Alias, '') Alias, Password, Status, Email FROM TblUsuario WHERE Username=@usuario;"

            params.Add(BuildParameter("@usuario", u, DbType.String))
            dataTable = dbConnector.ReadDataTable(sql, params)

            If dataTable.Rows.Count > 0 Then
                dbTable = New UsuarioModel() With {
                    .Id = dataTable.Rows().Item(0).Item(0),
                    .Username = dataTable.Rows().Item(0).Item(1),
                    .Nombre = dataTable.Rows().Item(0).Item(2),
                    .AliasName = dataTable.Rows().Item(0).Item(3),
                    .Password = dataTable.Rows().Item(0).Item(4)
                }
            End If


            ' ret = New UsuarioModel(dataTable.Rows.Item(0), dataTable.Rows(1), dataTable.Rows(2), dataTable.Rows(3), dataTable.Rows(4), dataTable.Rows(5), dataTable.Rows(6))
            '.Username = DataRow(1),
            '                .Nombre = DataRow(2),
            '                .AliasName = DataRow(3),
            '                .Password = DataRow(4),
            '                .Status = DataRow(5),
            '                .Email = DataRow(6)

            '            )


            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)

        End Try

        Return dbTable
    End Function

End Class
