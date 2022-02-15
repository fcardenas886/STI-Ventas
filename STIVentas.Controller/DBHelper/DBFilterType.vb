''' <summary>
''' Enum con los operadores para el select
''' </summary>
''' <remarks>
''' 05.02.2021 jorge.nin92@gmail.com: Se crea la clase
''' 06.02.2021 jorge.nin92@gmail.com: Se crea agrega Contains y Between
''' </remarks>
Public Enum DBFilterType
    Equal
    NotEqual
    GreaterThan
    GreaterThanEqual
    LessThan
    LessThanEqual
    Contains
    Between
End Enum
