Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para encabezado de orden de compra
''' </summary>
''' <remarks>05.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ComprasController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblCompraHeader"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As CompraHeaderModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CompraHeaderModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblCompraHeader(NumeroCompra, Moneda, Nombre, IdProveedor, Contacto, OrdenProveedor, Estado, FormaPago, FechaEntrega, Correo, Contacto) " &
                    "VALUES(@Id, @Moneda, @Name, @IdProveedor, @Contacto, @OrdenProveedor, @Estado, @FormaPago, @FechaEntrega, @Correo, @Contacto);"

            params.Add(BuildParameter("@Id", table.NumeroCompra, DbType.String))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@IdProveedor", table.IdProveedor, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))
            params.Add(BuildParameter("@OrdenProveedor", table.OrdenProveedor, DbType.String))

            params.Add(BuildParameter("@Estado", table.Estado, DbType.String))
            params.Add(BuildParameter("@FormaPago", table.FormaPago, DbType.String))
            params.Add(BuildParameter("@FechaEntrega", table.FechaEntrega, DbType.String))
            params.Add(BuildParameter("@Correo", table.Correo, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As CompraHeaderModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CompraHeaderModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblCompraHeader WHERE NumeroCompra = @Id;"

            params.Add(BuildParameter("@Id", table.NumeroCompra, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As CompraHeaderModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, CompraHeaderModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblCompraHeader SET Nombre = @Name " &
                    "Moneda = @Moneda, IdProveedor = @IdProveedor, Contacto = @Contacto, OrdenProveedor = @OrdenProveedor, " &
                    "Estado = @Estado, FormaPago = @FormaPago, FechaEntrega = @FechaEntrega, Correo = @Correo, Contacto = @Contacto" &
                    "WHERE NumeroCompra = @Id;"

            params.Add(BuildParameter("@Id", table.NumeroCompra, DbType.String))
            params.Add(BuildParameter("@Moneda", table.Moneda, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@IdProveedor", table.IdProveedor, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))
            params.Add(BuildParameter("@OrdenProveedor", table.OrdenProveedor, DbType.String))

            params.Add(BuildParameter("@Estado", table.Estado, DbType.String))
            params.Add(BuildParameter("@FormaPago", table.FormaPago, DbType.String))
            params.Add(BuildParameter("@FechaEntrega", table.FechaEntrega, DbType.String))
            params.Add(BuildParameter("@Correo", table.Correo, DbType.String))
            params.Add(BuildParameter("@Contacto", table.Contacto, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of CompraHeaderModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, NumeroCompra, Moneda, Nombre, IdProveedor, Contacto, OrdenProveedor, Estado, FormaPago, FechaEntrega, Correo, Contacto FROM TblCompraHeader"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New CompraHeaderModel With {
                            .Id = dataRow(0),
                            .NumeroCompra = dataRow(1),
                            .Moneda = dataRow(2),
                            .Nombre = dataRow(3),
                            .IdProveedor = dataRow(4),
                            .Contacto = dataRow(5),
                            .OrdenProveedor = dataRow(6),
                            .Estado = dataRow(7),
                            .FormaPago = dataRow(8),
                            .FechaEntrega = dataRow(9),
                            .Correo = dataRow(10)
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

End Class
