
Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para proveedores
''' </summary>
''' <remarks>05.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ProveedorController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblProveedor"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As ProveedorModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ProveedorModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblProveedor(IdProveedor, Nombre, Alias, Contacto, Direccion, Email, FormaPago, Grupo, Moneda, RUT, Telefono) " &
                    "VALUES(@Id, @Name, @Alias, @Contacto, @Direccion, @Email, @FormaPago, @Grupo, @Moneda, @RUT, @Telefono);"

            params.Add(BuildParameter("@Id", table.IdProveedor, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Alias", table.AliasName, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))
            params.Add(BuildParameter("@Direccion", table.Direccion, DbType.String))
            params.Add(BuildParameter("@Email", table.Email, DbType.String))
            params.Add(BuildParameter("@FormaPago", table.FormaPago, DbType.String))
            params.Add(BuildParameter("@Grupo", table.Grupo, DbType.String))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@RUT", table.RUT, DbType.String))
            params.Add(BuildParameter("@Telefono", table.Telefono, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As ProveedorModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ProveedorModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblProveedor WHERE IdProveedor = @Id;"

            params.Add(BuildParameter("@Id", table.IdProveedor, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As ProveedorModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ProveedorModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblProveedor SET Nombre = @Name, Alias = @Alias, Contacto = @Contacto, Direccion = @Direccion, Email = @Email, " &
                    "FormaPago = @FormaPago, Grupo = @Grupo, Moneda = @Moneda, RUT = @RUT, Telefono = @Telefono " &
                    "WHERE IdProveedor = @Id;"

            params.Add(BuildParameter("@Id", table.IdProveedor, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Alias", table.AliasName, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))
            params.Add(BuildParameter("@Direccion", table.Direccion, DbType.String))
            params.Add(BuildParameter("@Email", table.Email, DbType.String))
            params.Add(BuildParameter("@FormaPago", table.FormaPago, DbType.String))
            params.Add(BuildParameter("@Grupo", table.Grupo, DbType.String))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@RUT", table.RUT, DbType.String))
            params.Add(BuildParameter("@Telefono", table.Telefono, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of ProveedorModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdProveedor, IFNULL(Nombre, '') Nombre, IFNULL(Alias, '') Alias, Contacto, Direccion, Email, FormaPago, Grupo, Moneda, RUT, Telefono FROM TblProveedor"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows

                ret.Add(
                        New ProveedorModel With {
                            .Id = dataRow(0),
                            .IdProveedor = dataRow(1),
                            .Nombre = dataRow(2),
                            .AliasName = dataRow(3),
                            .Contacto = dataRow(4),
                            .Direccion = dataRow(5),
                            .Email = dataRow(6),
                            .FormaPago = dataRow(7),
                            .Grupo = dataRow(8),
                            .Moneda = dataRow(9),
                            .RUT = dataRow(10),
                            .Telefono = dataRow(11)}
                        )
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
        Dim proveedorModel As ProveedorModel

        Try
            proveedorModel = objectToReturn

            If proveedorModel Is Nothing Then
                Return
            End If

            Select Case propertyName.ToUpper()
                Case "ALIASNAME"
                    proveedorModel.AliasName = dataRow("Alias")
            End Select

            objectToReturn = proveedorModel
        Catch
            Return
        End Try
    End Sub

#End Region

End Class
