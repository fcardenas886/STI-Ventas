''' <summary>
''' Interfaz para abstraer las operaciones
''' </summary>
''' <remarks>01.02.2021 jorge.nin92@gmail.com: Se crea la interfaz</remarks>
Public Interface IDBOperations

    ''' <summary>
    ''' Inserta un nuevo registro
    ''' </summary>
    ''' <param name="iTable">Registro a persistir en la BD</param>
    ''' <returns>True si la operación ocurre con exito.</returns>
    ''' <remarks>01.02.2021 jorge.nin92@gmail.com: Se crea la interfaz</remarks>
    Function Insert(ByVal iTable As IDBTable) As Boolean

    ''' <summary>
    ''' Elimina un nuevo registro
    ''' </summary>
    ''' <param name="iTable">Registro a persistir en la BD</param>
    ''' <returns>True si la operación ocurre con exito.</returns>
    ''' <remarks>01.02.2021 jorge.nin92@gmail.com: Se crea la interfaz</remarks>
    Function Delete(ByVal iTable As IDBTable) As Boolean

    ''' <summary>
    ''' Actualiza un nuevo registro
    ''' </summary>
    ''' <param name="iTable">Registro a persistir en la BD</param>
    ''' <returns>True si la operación ocurre con exito.</returns>
    ''' <remarks>01.02.2021 jorge.nin92@gmail.com: Se crea la interfaz</remarks>
    Function Update(ByVal iTable As IDBTable) As Boolean

    ''' <summary>
    ''' Obtiene una lista de los registros de la tabla que implementa
    ''' </summary>
    ''' <returns>Registros de la BD</returns>
    ''' <remarks>01.02.2021 jorge.nin92@gmail.com: Se crea la interfaz</remarks>
    Function GetList() As IEnumerable(Of IDBTable)

End Interface
