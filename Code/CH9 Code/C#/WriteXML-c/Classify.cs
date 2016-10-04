using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace WriteXML_c
{
	/// <summary>
	/// Summary description for Classify.
	/// </summary>
  public class Classify
  {

    #region class local variables

    private static string EncryptKey = "CryptoManiac";
    private static MD5CryptoServiceProvider hashmd5;
    private static TripleDESCryptoServiceProvider des;
    private static byte[] pwdhash;

    #endregion

    static Classify()
    {
      hashmd5 = new MD5CryptoServiceProvider();
      pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(EncryptKey));

      //implement DES3 encryption
      des = new TripleDESCryptoServiceProvider();
      des.Key = pwdhash;
      des.Mode = CipherMode.ECB; //CBC, CFB
    }

    public static string Encrypt(string OriginalString)
    {
      byte[] buff = ASCIIEncoding.ASCII.GetBytes(OriginalString);
      return Convert.ToBase64String(des.CreateEncryptor().
                                        TransformFinalBlock(buff, 0, 
                                        buff.Length));
    }

    public static string Decrypt(string EncryptedString)
    {
      byte[] buff = Convert.FromBase64String(EncryptedString);
      return ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().
                                               TransformFinalBlock(buff, 0, 
                                               buff.Length));
    }

  }
}

