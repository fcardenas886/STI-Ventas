
Imports MySql.Data.MySqlClient

''' <summary>
''' Conexión base para la BDs
''' </summary>
''' <remarks>02.02.2021 jorge.nin92@gmail.com: Se crea la clase</remarks>
Public Class DBConnector

    Private strLastError As String
    Private RecordId As Long
    Public Property LastId() As Long
        Get
            Return RecordId
        End Get
        Protected Set(value As Long)
            RecordId = value
        End Set
    End Property

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

                If success Then
                    LastId = command.LastInsertedId
                End If

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

                If success Then
                    LastId = command.LastInsertedId
                End If

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

    Protected Sub AppendInnerError(ByVal exception As Exception)
        Dim innerException As Exception

        If Not String.IsNullOrEmpty(strLastError) Then
            strLastError &= strLastError & vbCrLf
        Else
            strLastError = exception.Message
        End If

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
            connectionString = "server=a2plcpnl0435.prod.iad2.secureserver.net;user=stiadmin;database=stiventas;port=3306;password=fc6543as;Convert Zero Datetime=True;Treat Tiny As Boolean=false;"
        End If

        Return connectionString
    End Function

    Public Function ReadDataTable(ByVal query As String, ByVal params As List(Of MySqlParameter)) As DataTable
        Dim dataTable As DataTable
        Dim command As MySqlCommand
        Dim adaptor As MySqlDataAdapter

        dataTable = New DataTable()

        Try
            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                command = New MySqlCommand(query, connection)

                For Each param As MySqlParameter In params
                    command.Parameters.Add(param)
                Next

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

    Public Function InsertUpdateTransaction(ByVal sql As String, ByVal params As List(Of MySqlParameter), Optional additionalSQL As String = "") As Boolean
        Dim command As MySqlCommand
        Dim success As Boolean = False
        Dim insertResult As Integer
        Dim transaction As MySqlTransaction

        Try
            ResetLastError()

            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                transaction = connection.BeginTransaction(IsolationLevel.Serializable)
                command = New MySqlCommand(sql, connection, transaction)

                Try
                    command.CommandType = CommandType.Text

                    For Each param As MySqlParameter In params
                        command.Parameters.Add(param)
                    Next

                    insertResult = command.ExecuteNonQuery()

                    If success Then
                        LastId = command.LastInsertedId
                    End If

                    If Not String.IsNullOrEmpty(additionalSQL) Then
                        command = New MySqlCommand(additionalSQL, connection, transaction)
                        command.CommandType = CommandType.Text
                        insertResult = command.ExecuteNonQuery()
                    End If

                    transaction.Commit()
                    success = insertResult > 0
                Catch commitException As Exception
                    AppendInnerError(commitException)
                    Try
                        transaction.Rollback()
                    Catch ex As Exception
                        If transaction.Connection IsNot Nothing Then
                            Throw New Exception("An exception of type " & ex.GetType().ToString() & " was encountered while attempting to roll back the transaction.")
                        End If
                    End Try
                End Try

                connection.Close()
            End Using

        Catch ex As Exception
            AppendInnerError(ex)
        End Try

        Return success
    End Function

#Region "Store procedure Region"
    Public Function ExecuteStoreProcedure(sql As String, Optional params As List(Of MySqlParameter) = Nothing, Optional outputParams As MySqlParameter = Nothing) As Integer
        Dim command As MySqlCommand
        Dim insertResult As Integer

        Try
            ResetLastError()

            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                command = New MySqlCommand(sql, connection) With {
                    .CommandType = CommandType.StoredProcedure
                }

                If params IsNot Nothing Then
                    For Each param As MySqlParameter In params
                        command.Parameters.Add(param)
                    Next
                End If
                If outputParams IsNot Nothing Then
                    outputParams.Direction = ParameterDirection.Output
                    command.Parameters.Add(outputParams)
                End If

                insertResult = command.ExecuteNonQuery()

                If outputParams IsNot Nothing AndAlso outputParams.Value IsNot Nothing Then
                    insertResult = CType(outputParams.Value, Integer)
                End If

                connection.Close()
            End Using

        Catch ex As Exception
            AppendError(ex)
            insertResult = -1
        End Try

        Return insertResult
    End Function

    Public Function ExecuteStoreProcedure(sql As String, Optional params As List(Of MySqlParameter) = Nothing) As DataTable
        Dim command As MySqlCommand
        Dim dataAdapter As MySqlDataAdapter
        Dim ret As DataTable = New DataTable()

        Try
            ResetLastError()

            Using connection As New MySqlConnection(GetConnectionString())
                connection.Open()

                command = New MySqlCommand(sql, connection) With {
                    .CommandType = CommandType.StoredProcedure
                }

                If params IsNot Nothing Then
                    For Each param As MySqlParameter In params
                        command.Parameters.Add(param)
                    Next
                End If

                dataAdapter = New MySqlDataAdapter With {
                    .SelectCommand = command
                }

                dataAdapter.Fill(ret)

                connection.Close()
            End Using

        Catch ex As Exception
            AppendError(ex)
        End Try

        Return ret

    End Function
#End Region

End Class
