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

        Return False
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of VentasCreditoModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdVenta, IdCliente, CodigoCliente, MontoVenta, Abono, Fecha, Estado, Moneda, CreadoPor, MontoPagado FROM TblVentasCredito"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New VentasCreditoModel With {
                            .Id = dataRow(0),
                            .IdVenta = dataRow(1),
                            .IdCliente = dataRow(2),
                            .CodigoCliente = dataRow(3),
                            .Monto = dataRow(4),
                            .Abono = dataRow(5),
                            .Fecha = dataRow(6),
                            .Estado = dataRow(7),
                            .Moneda = dataRow(8),
                            .CobradoPor = dataRow(9),
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


End Class
