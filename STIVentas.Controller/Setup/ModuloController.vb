Imports MySql.Data.MySqlClient
Imports STIVentas.Model

Public Class ModuloController : Inherits ControllerBase : Implements IDBOperations

    Private Const NombreTabla As String = "TblModulo"




    Public Overloads Function GetList() As IEnumerable(Of IDBTable) Implements IDBOperations.GetList
        Dim ret As New List(Of ModuloModel)
        Dim dbConnector As DBConnector
        Dim sql As String
        Dim dataTable As DataTable

        Try
            dbConnector = New DBConnector()
            sql = "SELECT Id, IdModulo, Nombre FROM TblModulo"


            dataTable = dbConnector.ReadDataTable(sql)

            For Each dataRow As DataRow In dataTable.Rows

                ret.Add(
                        New ModuloModel With {
                            .Id = dataRow(0),
                            .Idmodulo = dataRow(1),
                            .Nombre = dataRow(2)
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

End Class
