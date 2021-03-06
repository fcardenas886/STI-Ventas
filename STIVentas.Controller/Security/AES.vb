Imports System.IO
Imports System.Security.Cryptography

''' <summary>
''' Se agrega clase como helper para encriptar-desencriptar
''' </summary>
''' <remarks>20.02.2022 jorge.nin92@gmail.com: Se crea clase</remarks>
Public Class AES

    Private Shared ReadOnly AesInstance As AES = New AES()

    Private Function Encrypt(ByVal clearData As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
        Dim ms As New MemoryStream()
        Dim alg As Rijndael = Rijndael.Create()
        alg.Key = Key
        alg.IV = IV
        Dim cs As New CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write)
        cs.Write(clearData, 0, clearData.Length)
        cs.Close()
        Dim encryptedData As Byte() = ms.ToArray()
        Return encryptedData
    End Function

    Public Function Encrypt(ByVal Data As String, ByVal Password As String, ByVal Bits As Integer) As String
        Dim clearBytes As Byte() = Text.Encoding.Unicode.GetBytes(Data)
        Dim pdb As New Rfc2898DeriveBytes(Password, New Byte() {&H0, &H1, &H2, &H1C, &H1D, &H1E, &H3, &H4, &H5, &HF, &H20, &H21, &HAD, &HAF, &HA4})

        If Bits = 128 Then
            Dim encryptedData As Byte() = Encrypt(clearBytes, pdb.GetBytes(16), pdb.GetBytes(16))
            Return Convert.ToBase64String(encryptedData)
        ElseIf Bits = 192 Then
            Dim encryptedData As Byte() = Encrypt(clearBytes, pdb.GetBytes(24), pdb.GetBytes(16))
            Return Convert.ToBase64String(encryptedData)
        ElseIf Bits = 256 Then
            Dim encryptedData As Byte() = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16))
            Return Convert.ToBase64String(encryptedData)
        Else
            Return String.Concat(Bits)
        End If
    End Function

    Private Function Decrypt(ByVal cipherData As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
        Dim ms As MemoryStream = New MemoryStream()
        Dim alg As Rijndael = Rijndael.Create()
        alg.Key = Key
        alg.IV = IV
        Dim cs As CryptoStream = New CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write)
        cs.Write(cipherData, 0, cipherData.Length)
        cs.Close()
        Dim decryptedData As Byte() = ms.ToArray()
        Return decryptedData
    End Function

    Public Function Decrypt(ByVal Data As String, ByVal Password As String, ByVal Bits As Integer) As String
        Try
            Dim cipherBytes As Byte() = Convert.FromBase64String(Data)
            Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(Password, New Byte() {&H0, &H1, &H2, &H1C, &H1D, &H1E, &H3, &H4, &H5, &HF, &H20, &H21, &HAD, &HAF, &HA4})

            If Bits = 128 Then
                Dim decryptedData As Byte() = Decrypt(cipherBytes, pdb.GetBytes(16), pdb.GetBytes(16))
                Return Text.Encoding.Unicode.GetString(decryptedData)
            ElseIf Bits = 192 Then
                Dim decryptedData As Byte() = Decrypt(cipherBytes, pdb.GetBytes(24), pdb.GetBytes(16))
                Return Text.Encoding.Unicode.GetString(decryptedData)
            ElseIf Bits = 256 Then
                Dim decryptedData As Byte() = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16))
                Return Text.Encoding.Unicode.GetString(decryptedData)
            Else
                Return String.Concat(Bits)
            End If

        Catch ex As Exception
            Return String.Concat(Bits)
        End Try
    End Function

    Public Shared Function Encrypt256(data As String) As String
        Dim encryptedText As String

        encryptedText = AesInstance.Encrypt(data, DBSettings.appPwdUnique, 256)

        Return encryptedText
    End Function

    Public Shared Function Decrypt256(data As String) As String
        Dim encryptedText As String

        encryptedText = AesInstance.Decrypt(data, DBSettings.appPwdUnique, 256)

        Return encryptedText
    End Function
End Class
