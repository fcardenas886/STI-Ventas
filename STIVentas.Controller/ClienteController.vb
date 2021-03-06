Imports MySql.Data.MySqlClient
Imports STIVentas.Model

Public Class ClienteController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblCliente"

    '' nuevo codi

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As ClienteModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ClienteModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblCliente(Rut, Nombre, Direccion, Cupo) VALUES (@Rut, @Nombre, @Direccion, @Cupo);"



            params.Add(BuildParameter("@Rut", table.Rut, DbType.String))
            params.Add(BuildParameter("@Nombre", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Direccion", table.Direccion, DbType.String))
            params.Add(BuildParameter("@Cupo", table.Cupo, DbType.Int32))


            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As ClienteModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ClienteModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblCliente WHERE Id = @Id;"

            params.Add(BuildParameter("@Id", table.Id, DbType.Int32))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As ClienteModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ClienteModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            'jsql = "UPDATE TblCliente SET Nombre = @Name, Descripcion = @Descripcion, " _
            '  & "Simbolo = @Simbolo, CodigoISO = @CodigoISO, " _
            '  & "Redondear = @Redondear, TipoRedondeo = @TipoRedondeo, " _
            '  & "RedondeoVentas = @RedondeoVentas, RedondeoCompras = @RedondeoCompras, " _
            ' ¿  & "RedondeoInventario = @RedondeoInventario, RedondearCompras = @RedondearCompras, " _
            '  & "RedondearVentas = @RedondearVentas, RedondearInventario = @RedondearInventario " _
            '   & "WHERE CodigoMoneda = @Id;"
            sql = "Update TblCliente SET Rut = @Rut,Nombre = @Nombre, Direccion = @Dir,Cupo = @Cupo
                    WHERE Id = @Id;"

            ' CheckNullValues(table)

            params.Add(BuildParameter("@Id", table.Id, DbType.Int16))
            params.Add(BuildParameter("@Rut", table.Rut, DbType.String))
            params.Add(BuildParameter("@Nombre", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Dir", table.Direccion, DbType.String))
            params.Add(BuildParameter("@Cupo", table.Cupo, DbType.Int16))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function


    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of ClienteModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim dbTable As New ClienteModel
        'Dim redondeoType As Type

        Try
            dbConnector = New DBConnector()
            sql = "Select Id, Rut, Nombre, Direccion, Cupo FROM TblCliente;"

            dataTable = dbConnector.ReadDataTable(sql)
            'redondeoType = GetType(TipoRedondeoMoneda)

            For Each dataRow As DataRow In dataTable.Rows
                dbTable =
                        New ClienteModel With {
                            .Id = dataRow(0),
                            .Rut = dataRow(1),
                            .Nombre = dataRow(2),
                            .Direccion = dataRow(3),
                            .Cupo = dataRow(4)
                            }
                'CheckNullValues(dbTable)

                ret.Add(dbTable)
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

#End Region

#Region "Helpers"

    ''' <summary>
    ''' Regresa el cliente mostrador configurado
    ''' </summary>
    ''' <returns>Cliente mostrador</returns>
    Public Function GetClienteMostrador() As ClienteViewModel
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim dbTable As New ClienteViewModel

        Try
            dbConnector = New DBConnector()
            sql = "select TblConfiguracion.Moneda, TblCliente.Id, TblCliente.Nombre, TblCliente.Rut, TblConfiguracion.FormaPagoVentas from TblConfiguracion left join TblCliente on TblCliente.Id = TblConfiguracion.IdClienteMostrador;"

            dataTable = dbConnector.ReadDataTable(sql)

            If dataTable.Rows.Count > 0 Then
                dbTable = New ClienteViewModel() With {
                    .Moneda = dataTable.Rows().Item(0).Item(0),
                    .Id = dataTable.Rows().Item(0).Item(1),
                    .Nombre = dataTable.Rows().Item(0).Item(2),
                    .Rut = dataTable.Rows().Item(0).Item(3),
                    .FormaPago = dataTable.Rows().Item(0).Item(4)
                }
            Else
                Throw New Exception("Error recuperando el cliente mostrador.\n" + dbConnector.LastError)
            End If

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return dbTable
    End Function

    Public Function GetClienteById(id As Integer) As ClienteModel
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim dbTable As New ClienteModel
        Dim params As List(Of MySqlParameter)

        Try
            dbConnector = New DBConnector()
            params = New List(Of MySqlParameter)
            sql = "SELECT Id, Rut, Nombre FROM TblCliente WHERE Id = @Id LIMIT 1;"

            params.Add(BuildParameter("@Id", id, DbType.Int16))
            dataTable = dbConnector.ReadDataTable(sql, params)

            If dataTable.Rows.Count > 0 Then
                dbTable = New ClienteModel() With {
                    .Id = dataTable.Rows().Item(0).Item(0),
                    .Nombre = dataTable.Rows().Item(0).Item(2),
                    .Rut = dataTable.Rows().Item(0).Item(1)
                }
            End If

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return dbTable
    End Function
#End Region
End Class


