Imports System.Text
Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para transacciones de inventario
''' </summary>
''' <remarks>08.02.2022 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class TransaccionInventarioController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblTransaccionInventario"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As TransaccionInventarioModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, TransaccionInventarioModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblTransaccionInventario(IdArticulo, Moneda, FechaMovimiento, Costo, Estatus, TipoTransaccion, Referencia, NumeroReferencia, Cantidad, Unidad, IdTransaccion) " &
                                                "VALUES(@Id, @Moneda, @FechaMovimiento, @Costo, @Estatus, @TipoTransaccion, @Referencia, @NumeroReferencia, @Cantidad, @Unidad, @IdTransaccion);"

            params.Add(BuildParameter($"@Id", table.IdArticulo, DbType.Int32))
            params.Add(BuildParameter($"@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter($"@FechaMovimiento", table.FechaMovimiento, DbType.Date))
            params.Add(BuildParameter($"@Costo", table.Costo, DbType.Decimal))
            params.Add(BuildParameter($"@Estatus", table.Estatus, DbType.Int32))
            params.Add(BuildParameter($"@TipoTransaccion", table.TipoTransaccion, DbType.Int16))

            params.Add(BuildParameter($"@Referencia", table.Referencia, DbType.String))
            params.Add(BuildParameter($"@NumeroReferencia", table.NumeroReferencia, DbType.String))
            params.Add(BuildParameter($"@Cantidad", table.Cantidad, DbType.Decimal))
            params.Add(BuildParameter($"@Unidad", table.Unidad, DbType.String))
            params.Add(BuildParameter($"@IdTransaccion", table.IdTransaccion, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As TransaccionInventarioModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, TransaccionInventarioModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblTransaccionInventario WHERE Id = @Id;"

            params.Add(BuildParameter($"@Id", table.Id, DbType.Int32))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As TransaccionInventarioModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, TransaccionInventarioModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblTransaccionInventario SET IdArticulo = @IdArticulo, " &
                    "Moneda = @Moneda, FechaMovimiento = @FechaMovimiento, Costo = @Costo, Estatus = @Estatus, TipoTransaccion = @TipoTransaccion, " &
                    "Referencia = @Referencia, NumeroReferencia = @NumeroReferencia, Cantidad = @Cantidad, Unidad=@Unidad, IdTransaccion=@IdTransaccion " &
                    "WHERE Id = @Id;"

            params.Add(BuildParameter($"@Id", table.Id, DbType.Int32))
            params.Add(BuildParameter($"@IdArticulo", table.IdArticulo, DbType.Int32))
            params.Add(BuildParameter($"@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter($"@FechaMovimiento", table.FechaMovimiento, DbType.Date))
            params.Add(BuildParameter($"@Costo", table.Costo, DbType.Decimal))
            params.Add(BuildParameter($"@Estatus", table.Estatus, DbType.Int32))
            params.Add(BuildParameter($"@TipoTransaccion", table.TipoTransaccion, DbType.Int16))

            params.Add(BuildParameter($"@Referencia", table.Referencia, DbType.String))
            params.Add(BuildParameter($"@NumeroReferencia", table.NumeroReferencia, DbType.String))
            params.Add(BuildParameter($"@Cantidad", table.Cantidad, DbType.Decimal))
            params.Add(BuildParameter($"@Unidad", table.Unidad, DbType.String))
            params.Add(BuildParameter($"@IdTransaccion", table.IdTransaccion, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of TransaccionInventarioModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdArticulo, Moneda, FechaMovimiento, Costo, Estatus, TipoTransaccion, Referencia, NumeroReferencia, Cantidad, Unidad, IdTransaccion FROM TblTransaccionInventario"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New TransaccionInventarioModel With {
                            .Id = dataRow(0),
                            .IdArticulo = dataRow(1),
                            .Moneda = dataRow(2),
                            .FechaMovimiento = dataRow(3),
                            .Costo = dataRow(4),
                            .Estatus = dataRow(5),
                            .TipoTransaccion = dataRow(6),
                            .Referencia = dataRow(7),
                            .NumeroReferencia = dataRow(8),
                            .Cantidad = dataRow(9),
                            .Unidad = dataRow(10),
                            .IdTransaccion = dataRow(11)
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

    Public Function InsertTransaction(records As IEnumerable(Of IDBTable), additionalSQL As String) As Boolean
        Dim ret As Boolean = False
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim sBuilder As StringBuilder
        Dim iCounter As Integer

        Try
            If records Is Nothing Or records.Count < 1 Then
                LastError = "No se han especificado registros a insertar."
                Return ret
            End If

            iCounter = 1
            params = New List(Of MySqlParameter)
            sBuilder = New StringBuilder()
            sBuilder.Append("INSERT INTO TblTransaccionInventario(IdArticulo, Moneda, FechaMovimiento, Costo, Estatus, TipoTransaccion, Referencia, NumeroReferencia, Cantidad, Unidad, IdTransaccion) VALUES")

            For Each record As TransaccionInventarioModel In records

                If iCounter > 1 Then
                    sBuilder.AppendLine(",")
                End If

                sBuilder.AppendFormat("(@Id{0}, @Moneda{0}, @FechaMovimiento{0}, @Costo{0}, @Estatus{0}, @TipoTransaccion{0}, @Referencia{0}, @NumeroReferencia{0}, @Cantidad{0}, @Unidad{0}, @IdTransaccion{0})", iCounter)

                params.Add(BuildParameter($"@Id{iCounter}", record.IdArticulo, DbType.Int32))
                params.Add(BuildParameter($"@Moneda{iCounter}", record.Moneda, DbType.String))
                params.Add(BuildParameter($"@FechaMovimiento{iCounter}", record.FechaMovimiento, DbType.Date))
                params.Add(BuildParameter($"@Costo{iCounter}", record.Costo, DbType.Decimal))
                params.Add(BuildParameter($"@Estatus{iCounter}", record.Estatus, DbType.Int32))
                params.Add(BuildParameter($"@TipoTransaccion{iCounter}", record.TipoTransaccion, DbType.Int16))

                params.Add(BuildParameter($"@Referencia{iCounter}", record.Referencia, DbType.String))
                params.Add(BuildParameter($"@NumeroReferencia{iCounter}", record.NumeroReferencia, DbType.String))
                params.Add(BuildParameter($"@Cantidad{iCounter}", record.Cantidad, DbType.Decimal))
                params.Add(BuildParameter($"@Unidad{iCounter}", record.Unidad, DbType.String))
                params.Add(BuildParameter($"@IdTransaccion{iCounter}", record.IdTransaccion, DbType.String))

                iCounter += 1
            Next

            dbConnector = New DBConnector()

            sql = sBuilder.ToString()
            ret = dbConnector.InsertUpdateTransaction(sql, params, additionalSQL)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

#End Region

End Class
