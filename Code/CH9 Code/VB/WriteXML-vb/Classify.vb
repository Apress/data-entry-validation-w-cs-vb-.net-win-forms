Option Strict On

Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class Classify

#Region "class local variables"

  Private Shared EncryptKey As String = "CryptoManiac"
  Private Shared hashmd5 As MD5CryptoServiceProvider
  Private Shared des As TripleDESCryptoServiceProvider
  Private Shared pwdhash() As Byte

#End Region

  Shared Sub New()
    hashmd5 = New MD5CryptoServiceProvider()
    pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(EncryptKey))

    'implement DES3 encryption
    des = New TripleDESCryptoServiceProvider()
    des.Key = pwdhash
    des.Mode = CipherMode.ECB
  End Sub

  Public Shared Function Encrypt(ByVal OriginalString As String) As String
    Dim buff() As Byte = ASCIIEncoding.ASCII.GetBytes(OriginalString)
    Return Convert.ToBase64String(des.CreateEncryptor(). _
                                      TransformFinalBlock(buff, 0, _
                                      buff.Length))
  End Function

  Public Shared Function Decrypt(ByVal EncryptedString As String) As String
    Dim buff() As Byte = Convert.FromBase64String(EncryptedString)
    Return ASCIIEncoding.ASCII.GetString(des.CreateDecryptor(). _
                                             TransformFinalBlock(buff, 0, _
                                             buff.Length))
  End Function

End Class
