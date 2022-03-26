Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para las consultas de ventas a credito.
''' </summary>
''' <remarks>15.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class VentasCreditoController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblVentasCredito"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As VentasCreditoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, VentasCreditoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblCobrosCliente(IdVenta, IdCliente, CodigoCliente, Abono, CreadoPor, Estado, MontoPagado, MontoVenta, Fecha, Moneda) " &
                    "VALUES(@Id, @IdCliente, @CodigoCliente, @Abono, @CreadoPor, @Estado, @MontoPagado, @MontoVenta, @Fecha, @Moneda);"

            params.Add(BuildParameter("@Id", table.IdVenta, DbType.Int32))
            params.Add(BuildParameter("@IdCliente", table.IdCliente, DbType.Int32))
            params.Add(BuildParameter("@CodigoCliente", table.CodigoCliente, DbType.String))
            params.Add(BuildParameter("@Abono", table.Abono, DbType.Decimal))
            params.Add(BuildParameter("@CreadoPor", table.CreadoPor, DbType.Int32))
            params.Add(BuildParameter("@Estado", table.Estado, DbType.Int16))

            params.Add(BuildParameter("@MontoPagado", table.MontoPagado, DbType.Decimal))
            params.Add(BuildParameter("@MontoVenta", table.MontoVenta, DbType.Decimal))
            params.Add(BuildParameter("@Fecha", table.Fecha, DbType.DateTime))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As VentasCreditoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, VentasCreditoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblVentaDetalle WHERE Id = @Id;"

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
        Dim table As VentasCreditoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, VentasCreditoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblCobrosCliente SET Moneda = @Moneda, IdVenta= @IdVenta, IdCliente= @IdCliente, CodigoCliente= @CodigoCliente, " &
                    "Abono= @Abono, CreadoPor= @CreadoPor, Estado= @Estado, MontoPagado= @MontoPagado, MontoVenta= @MontoVenta, Fecha = @Fecha " &
                    "WHERE Id = @Id;"

            params.Add(BuildParameter("@Id", table.Id, DbType.String))
            params.Add(BuildParameter("@IdVenta", table.IdVenta, DbType.Int32))
            params.Add(BuildParameter("@IdCliente", table.IdCliente, DbType.Int32))
            params.Add(BuildParameter("@CodigoCliente", table.CodigoCliente, DbType.String))
            params.Add(BuildParameter("@Abono", table.Abono, DbType.Decimal))
            params.Add(BuildParameter("@CreadoPor", table.CreadoPor, DbType.Int32))
            params.Add(BuildParameter("@Estado", table.Estado, DbType.Int16))

            params.Add(BuildParameter("@MontoPagado", table.MontoPagado, DbType.Decimal))
            params.Add(BuildParameter("@MontoVenta", table.MontoVenta, DbType.Decimal))
            params.Add(BuildParameter("@Fecha", table.Fecha, DbType.DateTime))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of VentasCreditoModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id,IdVenta,IdCliente,CodigoCliente,MontoVenta,Abono,Estado,Moneda,Fecha,CreadoPor,MontoPagado FROM TblVentasCredito;"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New VentasCreditoModel With {
                            .Id = dataRow(0),
                            .IdVenta = dataRow(1),
                            .IdCliente = dataRow(2),
                            .CodigoCliente = dataRow(3),
                            .MontoVenta = dataRow(4),
                            .Abono = dataRow(5),
                            .Fecha = dataRow(6),
                            .Estado = dataRow(7),
                            .Moneda = dataRow(8),
                            .CreadoPor = dataRow(9),
                            .MontoPagado = dataRow(10)
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

    Public Overloads Function GetViewModel(dbSelect As DBSelect) As List(Of VentasCreditoViewModel)
        Dim ret As New List(Of VentasCreditoViewModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim params As List(Of MySqlParameter)

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, NumeroVenta, Nombre, CodigoCliente, MontoVenta, Abono, Estado, Moneda, Fecha, CreadoPor, MontoPagado, NumeroPagos FROM VentasAcreditoView " & dbSelect.GetSQLWhere()

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
                ret.Add(
                        New VentasCreditoViewModel With {
                            .Id = dataRow(0),
                            .NumeroVenta = dataRow(1),
                            .Nombre = dataRow(2),
                            .CodigoCliente = dataRow(3),
                            .MontoVenta = dataRow(4),
                            .Abono = dataRow(5),
                            .Estado = dataRow(6),
                            .Moneda = dataRow(7),
                            .Fecha = dataRow(8),
                            .CreadoPor = dataRow(9),
                            .MontoPagado = dataRow(10),
                            .NumeroPago = dataRow(11)
                            }
                        )
            Next

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Function CobrarVentaCredito(table As CobroVentaCreditoViewModel) As Boolean
        Dim ret As Boolean = False
        Dim iCounter As Integer
        Dim dbConnector As DBConnector
        Dim params As List(Of MySqlParameter)
        Dim paramResult As MySqlParameter

        Try

            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()

            params.Add(BuildParameter("@P_IdVenta", table.IdVentaCredito, DbType.Int32))
            params.Add(BuildParameter("@P_Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@P_Monto", table.MontoCobrado, DbType.Decimal))
            params.Add(BuildParameter("@P_IdCliente", table.IdCliente, DbType.Int32))
            params.Add(BuildParameter("@P_IdUsuario", table.CobradoPor, DbType.Int32))
            params.Add(BuildParameter("@P_MontoVenta", table.MontoVenta, DbType.Decimal))

            paramResult = BuildParameter("@P_IsOk", table.ResultadoSP, DbType.Decimal)

            iCounter = dbConnector.ExecuteStoreProcedure("SP_CobrarVentaCredito", params, paramResult)

            table.ResultadoSP = iCounter

            ret = iCounter > 0

            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Function GetTotalPorId(idVentaCredito As Integer) As CobroVentaCreditoViewModel
        Dim ret As New CobroVentaCreditoViewModel
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim params As List(Of MySqlParameter)
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            params = New List(Of MySqlParameter)

            sql = "SELECT Id, IdCliente, Moneda, MontoVenta, NumeroPagos, MontoPagado FROM VentasAcreditoView WHERE Id = @Id;"

            params.Add(BuildParameter("@Id", idVentaCredito))

            dataTable = dbConnector.ReadDataTable(sql, params)

            For Each dataRow As DataRow In dataTable.Rows
                ret =
                        New CobroVentaCreditoViewModel With {
                            .IdVentaCredito = dataRow(0),
                            .IdCliente = dataRow(1),
                            .Moneda = dataRow(2),
                            .MontoVenta = dataRow(3),
                            .NumeroPagos = dataRow(4),
                            .MontoPagado = dataRow(5)
                            }

                Exit For
            Next

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function


End Class
