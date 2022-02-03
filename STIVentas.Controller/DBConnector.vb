
Imports MySql.Data.MySqlClient

''' <summary>
''' Conexión base para la BDs
''' </summary>
''' <remarks>02.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class DBConnector

    Private strLastError As String

    Public Property LastError() As String
        Get
            Return strLastError
        End Get
        Protected Set(ByVal value As String)
            strLastError = value
        End Set
    End Property

    ''' <summary>
    ''' Valida si la conexión es valida a la BDs
    ''' </summary>
    ''' <returns>True si es correcto</returns>
    ''' <remarks>02.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
    Public Function TestConnection() As Boolean
        Dim myConnectionString As String
        Dim ret As Boolean = False


        Try
            myConnectionString = GetConnectionString()
            '' charset=utf8
            Using connection As New MySqlConnection(myConnectionString)
                connection.Open()
                connection.Close()
            End Using

            ret = True
        Catch ex As MySqlException
            AppendError(ex)
        End Try

        Return ret
    End Function

    Public Function ReadDataTable(ByVal query As String) As DataTable
        Dim dataTable As DataTable
        Dim command As MySqlCommand
        Dim adaptor As MySqlDataAdapter

        dataTable = New DataTable()

        Try
            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                command = New MySqlCommand(query, connection)
                adaptor = New MySqlDataAdapter With {
                    .SelectCommand = command
                }

                adaptor.Fill(dataTable)

                connection.Close()
            End Using

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return dataTable
    End Function

    Public Function InsertUpdate(ByVal sql As String) As Boolean
        Dim command As MySqlCommand
        Dim success As Boolean = False
        Dim insertResult As Integer

        Try
            ResetLastError()

            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                command = New MySqlCommand(sql, connection)

                insertResult = command.ExecuteNonQuery()
                success = insertResult > 0

                connection.Close()
            End Using

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return success
    End Function

    Public Function InsertUpdate(ByVal sql As String, ByVal params As List(Of MySqlParameter)) As Boolean
        Dim command As MySqlCommand
        Dim success As Boolean = False
        Dim insertResult As Integer

        Try
            ResetLastError()

            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                command = New MySqlCommand(sql, connection)

                command.CommandType = CommandType.Text

                For Each param As MySqlParameter In params
                    command.Parameters.Add(param)
                Next

                insertResult = command.ExecuteNonQuery()
                success = insertResult > 0

                connection.Close()
            End Using

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return success
    End Function

    Public Function Delete(ByVal sql As String) As Boolean
        Dim command As MySqlCommand
        Dim success As Boolean = False
        Dim insertResult As Integer

        Try
            ResetLastError()

            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                command = New MySqlCommand(sql, connection)

                insertResult = command.ExecuteNonQuery()
                success = insertResult > 0

                connection.Close()
            End Using

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return success
    End Function

    Public Function Delete(ByVal sql As String, ByVal params As List(Of MySqlParameter)) As Boolean
        Dim command As MySqlCommand
        Dim success As Boolean = False
        Dim insertResult As Integer

        Try
            ResetLastError()

            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                command = New MySqlCommand(sql, connection)

                command.CommandType = CommandType.Text

                For Each param As MySqlParameter In params
                    command.Parameters.Add(param)
                Next

                insertResult = command.ExecuteNonQuery()
                success = insertResult > 0

                connection.Close()
            End Using

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return success
    End Function

    Protected Sub AppendError(ByVal exception As Exception)
        strLastError = exception.Message
        Dim innerException As Exception

        Try
            innerException = exception.InnerException

            While innerException IsNot Nothing
                strLastError &= vbCrLf & innerException.Message
                innerException = innerException.InnerException
            End While
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ResetLastError()
        strLastError = ""
    End Sub

    Private Function GetConnectionString() As String
        Dim connectionString As String ' = Configuration.ConfigurationManager.ConnectionStrings("POS").ConnectionString

        If Configuration.ConfigurationManager.ConnectionStrings("POS") IsNot Nothing Then
            connectionString = Configuration.ConfigurationManager.ConnectionStrings("POS").ConnectionString
        Else
            connectionString = "server=a2plcpnl0435.prod.iad2.secureserver.net;user=stiadmin;database=stiventas;port=3306;password=fc6543as;"
        End If

        Return connectionString
    End Function
End Class
