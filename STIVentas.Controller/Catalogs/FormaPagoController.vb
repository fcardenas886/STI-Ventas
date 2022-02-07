
Imports MySql.Data.MySqlClient
Imports STIVentas.Model

''' <summary>
''' Controller para formas de pago
''' </summary>
''' <remarks>06.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class FormaPagoController : Inherits ControllerBase : Implements IDBOperations

    Private Const DescripcionTabla As String = "TblFormaPago"

#Region "DB Methods"
    Public Overloads Function Insert(iTable As IDBTable) As Boolean Implements IDBOperations.Insert
        Dim ret As Boolean = False
        Dim table As FormaPagoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, FormaPagoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "INSERT INTO TblFormaPago(IdFormaPago, Descripcion) VALUES(@Id, @Name);"

            params.Add(BuildParameter("@Id", table.IdFormaPago, DbType.String))
            params.Add(BuildParameter("@Name", table.Descripcion, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError
        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Delete(iTable As IDBTable) As Boolean Implements IDBOperations.Delete
        Dim ret As Boolean = False
        Dim table As FormaPagoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, FormaPagoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "DELETE FROM TblFormaPago WHERE IdFormaPago = @Id;"

            params.Add(BuildParameter("@Id", table.IdFormaPago, DbType.String))

            ret = dbConnector.Delete(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function Update(iTable As IDBTable) As Boolean Implements IDBOperations.Update
        Dim ret As Boolean = False
        Dim table As FormaPagoModel
        Dim params As List(Of MySqlParameter)
        Dim dbConnector As DBConnector
        Dim sql As String

        Try
            table = CType(iTable, FormaPagoModel)
            params = New List(Of MySqlParameter)
            dbConnector = New DBConnector()
            sql = "UPDATE TblFormaPago SET Descripcion = @Name WHERE IdFormaPago = @Id;"

            params.Add(BuildParameter("@Name", table.Descripcion, DbType.String))
            params.Add(BuildParameter("@Id", table.IdFormaPago, DbType.String))

            ret = dbConnector.InsertUpdate(sql, params)
            LastError = dbConnector.LastError

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of FormaPagoModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdFormaPago, IFNULL(Descripcion, '') FROM TblFormaPago"

            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows
                ret.Add(
                        New FormaPagoModel With {
                            .Id = dataRow(0),
                            .IdFormaPago = dataRow(1),
                            .Descripcion = dataRow(2)
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
        Return DescripcionTabla
    End Function

#End Region

End Class
