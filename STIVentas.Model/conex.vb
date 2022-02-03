

Imports MySql.Data.MySqlClient

Module conex

    Public strcon As String = "DataSource=a2plcpnl0435.prod.iad2.secureserver.net;" &
    "Database=stiventas;" &
    "Uid=freddyc;" &
    "Pwd=fc6543as;"

    Public myconx As MySqlConnection = New MySqlConnection(strcon)


End Module
