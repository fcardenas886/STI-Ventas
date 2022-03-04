
Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para configuración del sistema
''' </summary>
''' <remarks>24.02.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ConfiguracionController : Inherits ControllerBase : Implements IDBOperations

    Private Const DescripcionTabla As String = "TblConfiguracion"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As ConfiguracionModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ConfiguracionModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblConfiguracion(IdClienteMostrador, Moneda, FormaPagoVentas) VALUES(@IdClienteMostrador, @Moneda, @FormaPagoVentas);"

            params.Add(BuildParameter("@IdClienteMostrador", table.IdClienteMostrador, DbType.Int32))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@FormaPagoVentas", table.FormaPagoVentas, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As ConfiguracionModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ConfiguracionModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblConfiguracion SET Moneda = @Moneda, IdClienteMostrador = @IdClienteMostrador, FormaPagoVentas = @FormaPagoVentas WHERE Id = @Id;"

            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@IdClienteMostrador", table.IdClienteMostrador, DbType.Int32))
            params.Add(BuildParameter("@Id", table.Id, DbType.Int32))
            params.Add(BuildParameter("@FormaPagoVentas", table.FormaPagoVentas, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of ConfiguracionModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdClienteMostrador, IFNULL(Moneda, ''), IFNULL(FormaPagoVentas, '') FROM TblConfiguracion LIMIT 1;"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New ConfiguracionModel With {
                            .Id = dataRow(0),
                            .IdClienteMostrador = dataRow(1),
                            .Moneda = dataRow(2),
                            .FormaPagoVentas = dataRow(3)
                            }
                        )
            Next

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Function Find() As ConfiguracionModel
        Dim ret As New ConfiguracionModel()
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim dataRow As DataRow

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdClienteMostrador, IFNULL(Moneda, ''), IFNULL(FormaPagoVentas, '') FROM TblConfiguracion LIMIT 1;"

            dataTable = dbConnector.ReadDataTable(sql)

            If dataTable.Rows.Count > 0 Then
                dataRow = dataTable.Rows.Item(0)

                ret.Id = dataRow(0)
                ret.IdClienteMostrador = dataRow(1)
                ret.Moneda = dataRow(2)
                ret.FormaPagoVentas = dataRow(3)
            End If

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overrides Function TableName() As String
        Return DescripcionTabla
    End Function

#End Region

End Class
