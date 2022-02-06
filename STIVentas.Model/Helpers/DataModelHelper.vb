Public Class DataModelHelper
    Public Shared Function GetDescriptionAttribute(ByVal constanteEnumeracion As [Enum]) As String
        ' Obtener la informacion de la constante enumerada
        Dim fieldInfo As Reflection.FieldInfo
        fieldInfo = constanteEnumeracion.GetType.GetField(constanteEnumeracion.ToString)

        ' Obtener la escripcion del atributo
        Dim attributes() As ComponentModel.DescriptionAttribute = CType(fieldInfo.GetCustomAttributes(GetType(ComponentModel.DescriptionAttribute), False), ComponentModel.DescriptionAttribute())

        Dim resultado As String
        If (attributes.Length > 0) Then
            ' El atributo [DescriptionAttribute] existe, devolverlo
            resultado = attributes(0).Description
        Else
            ' No existe, devolver el nombre de la constante enumerada
            resultado = constanteEnumeracion.ToString
        End If

        Return resultado
    End Function

    Public Shared Function GetDescriptionAttributes(ByVal enumType As Type) As String()

        If enumType Is Nothing Then
            Throw New ArgumentNullException(NameOf(enumType), "La Enumeración recibida tiene un valor nothing")
        End If

        If Not (GetType(System.Enum) = enumType.BaseType) Then
            Throw New ArgumentException("El parámetro enumType no es Enum", NameOf(enumType))
        End If

        '-----------------------------------------
        Dim listaDeDescriptionAttributes As New Collections.ArrayList
        Dim enumValores As Reflection.FieldInfo() = enumType.GetFields()
        Dim fieldInfo As Reflection.FieldInfo

        For Each fieldInfo In enumValores
            If Not fieldInfo.IsSpecialName Then
                ' Recuperar el nombre del elemento
                Dim nombre As String = fieldInfo.Name
                ' ----
                ' Recuperar los atributos de este elemento
                Dim attributes() As ComponentModel.DescriptionAttribute = CType(fieldInfo.GetCustomAttributes(GetType(ComponentModel.DescriptionAttribute), False), ComponentModel.DescriptionAttribute())

                If (attributes.Length > 0) Then
                    listaDeDescriptionAttributes.Add(attributes(0).Description)
                Else
                    listaDeDescriptionAttributes.Add(nombre)
                End If

            End If
        Next

        ' convertir la lista en un array
        Dim resultado As String()
        resultado = CType(listaDeDescriptionAttributes.ToArray(GetType(String)), String())

        Return resultado
    End Function

    Private Shared Function ValueOf(ByVal enumType As Type, ByVal value As String, ByVal ignoreCase As Boolean) As Object

        If enumType Is Nothing Then
            Throw New ArgumentNullException(NameOf(enumType), "La Enumeración recibida tiene un valor nothing")
        End If

        If Not (GetType(System.Enum) = enumType.BaseType) Then
            Throw New ArgumentException("El parámetro enumType no es Enum", NameOf(enumType))
        End If

        If value Is Nothing Then
            Throw New ArgumentNullException(NameOf(value), " La cadena especificada tiene el valor Nothing ")
        End If
        If String.IsNullOrWhiteSpace(value) = True Then
            Throw New ArgumentException(" La cadena especificada es una cadena vacía o sólo contiene un espacio en blanco", NameOf(value))
        End If

        Dim nombres() As String = System.Enum.GetNames(enumType)

        Dim formaDeComparacion As StringComparison = StringComparison.CurrentCultureIgnoreCase
        If ignoreCase = False Then
            formaDeComparacion = StringComparison.CurrentCulture
        End If


        For Each name As String In nombres
            Dim atributo As String
            atributo = GetDescriptionAttribute(CType(System.Enum.Parse(enumType, name), System.Enum))
            If atributo.Equals(value, formaDeComparacion) Then
                ' ¡Encontrado! ----> Salir de la función
                Return System.Enum.Parse(enumType, name)
            End If
        Next

        For Each name As String In nombres
            If name.Equals(value, formaDeComparacion) = True Then
                ' ¡Encontrado! ----> Salir de la función
                Return System.Enum.Parse(enumType, name)
            End If
        Next

        Throw New ArgumentException(" La cadena especificada[" & value & "] no coincide con ningún valor de los descritos" & Environment.NewLine &
        " en los atributos [DescriptionAttribute] de la enumeración." & Environment.NewLine & " y tampoco es una de las constantes con nombre" & Environment.NewLine &
        " definidas para la enumeración.", "value")
    End Function

    Public Shared Function Parse(ByVal enumType As Type, ByVal value As String, ByVal ignoreCase As Boolean) As Object

        Return ValueOf(enumType, value, ignoreCase)
    End Function

    Public Overloads Shared Function TryParse(ByVal enumType As Type, ByVal value As String, ByVal ignoreCase As Boolean,
        <Runtime.InteropServices.Out()> ByRef outputConstanteEnumeracion As Object, <Runtime.InteropServices.Out()> ByRef outputMensajeError As String) As Boolean

        Dim resultadoConversion As Boolean
        outputMensajeError = String.Empty
        outputConstanteEnumeracion = Nothing

        Try
            outputConstanteEnumeracion = ValueOf(enumType, value, ignoreCase)
            resultadoConversion = True
            outputMensajeError = String.Empty

        Catch ex As ArgumentNullException
            outputConstanteEnumeracion = Nothing
            resultadoConversion = False
            outputMensajeError = ex.Message
        Catch ex As ArgumentException
            outputConstanteEnumeracion = Nothing
            resultadoConversion = False
            outputMensajeError = ex.Message
        Catch ex As OverflowException
            outputConstanteEnumeracion = Nothing
            resultadoConversion = False
            outputMensajeError = ex.Message
#Disable Warning CA1031 ' Do not catch general exception types
        Catch ex As Exception
            outputConstanteEnumeracion = Nothing
            resultadoConversion = False
            outputMensajeError = ex.Message
#Enable Warning CA1031 ' Do not catch general exception types
        End Try

        Return resultadoConversion

    End Function
End Class
