Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para productos
''' </summary>
''' <remarks>09.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class ProductosController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblProductos"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As ProductoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ProductoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblProductos(IdArticulo, Nombre, Descripcion, IdUnidad, IdCategoria, Marca, UnidadPorCaja, PrecioVenta, PrecioCompra) " &
                    "VALUES(@Id, @Name, @Descripcion, @IdUnidad, @IdCategoria, @Marca, @UnidadPorCaja, @PrecioVenta, @PrecioCompra);"

            params.Add(BuildParameter("@Id", table.IdArticulo, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Descripcion", table.Descripcion, DbType.String))
            params.Add(BuildParameter("@IdUnidad", table.IdUnidad, DbType.String))
            params.Add(BuildParameter("@IdCategoria", table.IdCategoria, DbType.String))
            params.Add(BuildParameter("@Marca", table.Marca, DbType.String))
            params.Add(BuildParameter("@UnidadPorCaja", table.UnidadPorCaja, DbType.Decimal))
            params.Add(BuildParameter("@PrecioVenta", table.PrecioVenta, DbType.Decimal))
            params.Add(BuildParameter("@PrecioCompra", table.PrecioCompra, DbType.Decimal))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As ProductoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ProductoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblProductos WHERE IdArticulo = @Id;"

            params.Add(BuildParameter("@Id", table.IdArticulo, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As ProductoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, ProductoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblProductos SET Nombre = @Name, Descripcion = @Descripcion, IdUnidad = @IdUnidad, IdCategoria = @IdCategoria, Marca = @Marca, " &
                    "UnidadPorCaja = @UnidadPorCaja, PrecioVenta = @PrecioVenta, PrecioCompra = @PrecioCompra " &
                    "WHERE IdArticulo = @Id;"

            params.Add(BuildParameter("@Id", table.IdArticulo, DbType.String))
            params.Add(BuildParameter("@Name", table.Nombre, DbType.String))
            params.Add(BuildParameter("@Descripcion", table.Descripcion, DbType.String))
            params.Add(BuildParameter("@IdUnidad", table.IdUnidad, DbType.String))
            params.Add(BuildParameter("@IdCategoria", table.IdCategoria, DbType.String))
            params.Add(BuildParameter("@Marca", table.Marca, DbType.String))
            params.Add(BuildParameter("@UnidadPorCaja", table.UnidadPorCaja, DbType.Decimal))
            params.Add(BuildParameter("@PrecioVenta", table.PrecioVenta, DbType.Decimal))
            params.Add(BuildParameter("@PrecioCompra", table.PrecioCompra, DbType.Decimal))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of ProductoModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdArticulo, IFNULL(Nombre, '') Nombre, IFNULL(Descripcion, '') Descripcion, IFNULL(IdUnidad, '') IdUnidad, IFNULL(IdCategoria, '') IdCategoria, Marca, UnidadPorCaja, PrecioVenta, PrecioCompra FROM TblProductos"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows

                ret.Add(
                        New ProductoModel With {
                            .Id = dataRow(0),
                            .IdArticulo = dataRow(1),
                            .Nombre = dataRow(2),
                            .Descripcion = dataRow(3),
                            .IdUnidad = dataRow(4),
                            .IdCategoria = dataRow(5),
                            .Marca = dataRow(6),
                            .UnidadPorCaja = dataRow(7),
                            .PrecioVenta = dataRow(8),
                            .PrecioCompra = dataRow(9)}
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
        Dim ProductoModel As ProductoModel

        Try
            ProductoModel = objectToReturn

            If ProductoModel Is Nothing Then
                Return
            End If

            Select Case propertyName.ToUpper()
                Case "Descripcion"
                    ProductoModel.Descripcion = dataRow("Descripcion")
            End Select

            objectToReturn = ProductoModel
        Catch
            Return
        End Try
    End Sub

#End Region

End Class
