
Imports System.ComponentModel
''' <summary>
''' Modulo con helpers
''' </summary>
''' <remarks>31.01.2021 jorge.nin92@gmail.com: Se crea el modulo</remarks>
Public Module ModulePOS
    Public Function GetPOSName() As String

        Return "STI-Ventas"
    End Function

    Public Function GetEnumFromDescriptionAttribute(Of T)(ByVal description As String) As T
        Dim type = GetType(T)
        If Not type.IsEnum Then Throw New InvalidOperationException()

        For Each fieldInfo In type.GetFields()
            Dim descriptionAttribute = TryCast(Attribute.GetCustomAttribute(fieldInfo, GetType(DescriptionAttribute)), DescriptionAttribute)

            If descriptionAttribute IsNot Nothing Then
                If descriptionAttribute.Description <> description Then Continue For
                Return CType(fieldInfo.GetValue(Nothing), T)
            End If

            If fieldInfo.Name <> description Then Continue For
            Return CType(fieldInfo.GetValue(Nothing), T)
        Next

        Return Nothing
    End Function

    Public Function GetEnumDescription(ByVal EnumConstant As [Enum]) As String
        Dim attr() As DescriptionAttribute = DirectCast(EnumConstant.GetType().GetField(EnumConstant.ToString()).GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        Return If(attr.Length > 0, attr(0).Description, EnumConstant.ToString)
    End Function
End Module
