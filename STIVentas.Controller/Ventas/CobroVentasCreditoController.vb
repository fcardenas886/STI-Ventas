Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para el cobro de las ventas a credito
''' </summary>
''' <remarks>15.03.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class CobroVentasCreditoController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblCobrosCliente"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As CobroVentasCreditoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CobroVentasCreditoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblCobrosCliente(IdCliente, CobradoPor, Estado, MontoPagado, Monto, IdVentaCredito, Fecha, Moneda) " &
                    "VALUES(@IdCliente, @CobradoPor, @Estado, @MontoPagado, @Monto, @IdVentaCredito, @Fecha, @Moneda);"

            params.Add(BuildParameter("@IdCliente", table.IdCliente, DbType.Int32))
            params.Add(BuildParameter("@CobradoPor", table.CobradoPor, DbType.Int32))
            params.Add(BuildParameter("@Estado", table.Estado, DbType.Int16))

            params.Add(BuildParameter("@MontoPagado", table.MontoPagado, DbType.Decimal))
            params.Add(BuildParameter("@Monto", table.Monto, DbType.Decimal))
            params.Add(BuildParameter("@IdVentaCredito", table.IdVentaCredito, DbType.Int32))
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
        Dim table As CobroVentasCreditoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CobroVentasCreditoModel)
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
        Dim table As CobroVentasCreditoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CobroVentasCreditoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblCobrosCliente SET Moneda = @Moneda, IdCliente= @IdCliente, " &
                    "CobradoPor= @CobradoPor, Estado= @Estado, MontoPagado= @MontoPagado, Monto= @Monto, IdVentaCredito = @IdVentaCredito, Fecha = @Fecha " &
                    "WHERE Id = @Id;"

            params.Add(BuildParameter("@Id", table.Id, DbType.String))
            params.Add(BuildParameter("@IdCliente", table.IdCliente, DbType.Int32))
            params.Add(BuildParameter("@CobradoPor", table.CobradoPor, DbType.Int32))
            params.Add(BuildParameter("@Estado", table.Estado, DbType.Int16))

            params.Add(BuildParameter("@MontoPagado", table.MontoPagado, DbType.Decimal))
            params.Add(BuildParameter("@Monto", table.Monto, DbType.Decimal))
            params.Add(BuildParameter("@IdVentaCredito", table.IdVentaCredito, DbType.Int32))
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
        Dim ret As New List(Of CobroVentasCreditoModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdCliente, Moneda, Fecha, Monto, Estado, MontoPagado, CobradoPor, IdVentaCredito FROM TblCobrosCliente;"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New CobroVentasCreditoModel With {
                            .Id = dataRow(0),
                            .IdCliente = dataRow(1),
                            .Moneda = dataRow(2),
                            .Fecha = dataRow(3),
                            .Monto = dataRow(4),
                            .Estado = dataRow(5),
                            .MontoPagado = dataRow(6),
                            .CobradoPor = dataRow(7),
                            .IdVentaCredito = dataRow(8)
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

#Region "Class Methods"

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

    Public Overloads Function GetCobrosPorVenta(dbSelect As DBSelect) As List(Of CobroVentasCreditoModel)
        Dim ret As New List(Of CobroVentasCreditoModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable
        Dim params As List(Of MySqlParameter)

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, Moneda, Fecha, Estado, MontoPagado, CobradoPor FROM TblCobrosCliente " & dbSelect.GetSQLWhere()

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
                        New CobroVentasCreditoModel With {
                            .Id = dataRow(0),
                            .Moneda = dataRow(1),
                            .Fecha = dataRow(2),
                            .MontoPagado = dataRow(3),
                            .CobradoPor = dataRow(4)
                            }
                        )
            Next

            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

#End Region
End Class
