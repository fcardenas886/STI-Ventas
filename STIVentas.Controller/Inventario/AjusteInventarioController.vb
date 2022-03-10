Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para header de ajuste de inventario
''' </summary>
''' <remarks>06.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class AjusteInventarioController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblAjusteInventario"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As AjusteInventarioModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, AjusteInventarioModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblAjusteInventario(Numero, CreadoPor, Descripcion, Registrado) " &
                                                "VALUES(@Numero, @CreadoPor, @Descripcion, @Registrado);"

            params.Add(BuildParameter($"@Numero", table.Numero, DbType.String))
            params.Add(BuildParameter($"@CreadoPor", table.CreadoPor, DbType.String))
            params.Add(BuildParameter($"@Descripcion", table.Descripcion, DbType.String))
            params.Add(BuildParameter($"@Registrado", table.Registrado, DbType.Boolean))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As AjusteInventarioModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, AjusteInventarioModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblAjusteInventario WHERE Numero = @Id;"

            params.Add(BuildParameter($"@Id", table.Numero, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As AjusteInventarioModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, AjusteInventarioModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblAjusteInventario SET " &
                    "CreadoPor = @CreadoPor, FechaRegistro = @FechaRegistro, " &
                    "Descripcion = @Descripcion, Registrado = @Registrado " &
                    "WHERE Numero = @Numero;" ' , RegistradoPor = @RegistradoPor

            params.Add(BuildParameter($"@Numero", table.Numero, DbType.String))
            params.Add(BuildParameter($"@CreadoPor", table.CreadoPor, DbType.Int32))
            params.Add(BuildParameter($"@FechaRegistro", table.FechaRegistro, DbType.Date))

            params.Add(BuildParameter($"@Descripcion", table.Descripcion, DbType.String))
            params.Add(BuildParameter($"@Registrado", table.Registrado, DbType.Boolean))
            'params.Add(BuildParameter($"@RegistradoPor", table.RegistradoPor, DbType.Int32))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of AjusteInventarioModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, Numero, CreadoPor, FechaRegistro, Descripcion, Registrado, RegistradoPor FROM TblAjusteInventario"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New AjusteInventarioModel With {
                            .Id = dataRow(0),
                            .Numero = dataRow(1),
                            .CreadoPor = dataRow(2),
                            .FechaRegistro = dataRow(3),
                            .Descripcion = dataRow(4),
                            .Registrado = dataRow(5),
                            .RegistradoPor = dataRow(6)
                            }
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
#End Region

    Public Function GetAjusteInventarioViewList(dbSelect As DBSelect) As List(Of AjusteInventarioViewModel)
        Dim ret As List(Of AjusteInventarioViewModel) = Nothing
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim params As List(Of MySqlParameter)
        Dim model As AjusteInventarioViewModel

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, Numero, CreadoPor, FechaRegistro, Descripcion, Registrado, RegistradoPor FROM TblAjusteInventario "
            sql += dbSelect.GetSQLWhere()
            ret = New List(Of AjusteInventarioViewModel)
            params = New List(Of MySqlParameter)

            For Each param As DBFilterFields In dbSelect.FilterFields
                If param.FilterType = DBFilterType.Contains Then
                    params.Add(BuildParameter("?" & param.FieldName, param.FieldValue))
                Else
                    params.Add(BuildParameter("@" & param.FieldName, param.FieldValue))
                End If

            Next

            dataTable = dbConnector.ReadDataTable(sql, params)

            For Each dataRow As DataRow In dataTable.Rows
                model = New AjusteInventarioViewModel With {
                            .Id = dataRow(0),
                            .Numero = dataRow(1),
                            .CreadoPor = dataRow(2),
                            .Descripcion = dataRow(4),
                            .Registrado = dataRow(5)
                            }

                If dataRow(3) IsNot Nothing AndAlso Not (TypeOf dataRow(3) Is DBNull) Then
                    model.FechaRegistro = Convert.ToDateTime(dataRow(3))
                End If
                If dataRow(6) IsNot Nothing AndAlso Not (TypeOf dataRow(6) Is DBNull) Then
                    model.RegistradoPor = Convert.ToInt32(dataRow(6))
                End If

                ret.Add(model)

            Next

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Function RegistrarAjusteInventario(table As AjusteInventarioRegistroModel) As Boolean
        Dim ret As Boolean = False
        Dim iCounter As Integer
        Dim dbConnector As DBConnector
        Dim params As List(Of MySqlParameter)
        Dim paramResult As MySqlParameter

        Try

            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()

            params.Add(BuildParameter("@P_IdAjuste", table.Id, DbType.String))
            params.Add(BuildParameter("@P_Referencia", table.GetReference(), DbType.String))
            params.Add(BuildParameter("@P_IdUsuario", table.RegistradoPor, DbType.Int32))

            paramResult = BuildParameter("@P_IsOk", table.ResultadoSP, DbType.Decimal)

            iCounter = dbConnector.ExecuteStoreProcedure("SP_RegistraAjusteInventario", params, paramResult)

            table.ResultadoSP = iCounter

            ret = iCounter > 0

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

End Class
