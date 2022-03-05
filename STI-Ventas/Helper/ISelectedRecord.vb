''' <summary>
''' Interfaz para utilizar en los formularios de selección
''' </summary>
''' <remarks>
''' 06.02.2021 jorge.nin92@gmail.com: Se agrega el metodo selectedRecord
''' </remarks>
Public Interface ISelectedRecord
    Function SelectedRecord() As STIVentas.Model.IDBTable

End Interface
