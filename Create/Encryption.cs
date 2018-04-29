using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

public static class Encryption
{
    public static string EncryptString(string Passphrase, string PlainText)
    {
        byte[] PlainBytes = Encoding.Unicode.GetBytes(PlainText);
        using (Aes aes = Aes.Create())
        {
            Rfc2898DeriveBytes DeriveBytes = new Rfc2898DeriveBytes(Passphrase, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            aes.Key = DeriveBytes.GetBytes(32);
            aes.IV = DeriveBytes.GetBytes(16);
            using (MemoryStream m = new MemoryStream())
            {
                using (CryptoStream c = new CryptoStream(m, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    c.Write(PlainBytes, 0, PlainBytes.Length);
                    c.Close();
                }
                PlainText = Convert.ToBase64String(m.ToArray());
            }
        }
        return PlainText;
    }
    public static string DecryptString(string Passphrase,string EncryptedText)
    {
        EncryptedText = EncryptedText.Replace(" ", "+");
        byte[] EncryptedBytes = Convert.FromBase64String(EncryptedText);
        using (Aes aes = Aes.Create())
        {
            Rfc2898DeriveBytes DeriveBytes = new Rfc2898DeriveBytes(Passphrase, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            aes.Key = DeriveBytes.GetBytes(32);
            aes.IV = DeriveBytes.GetBytes(16);
            using (MemoryStream m = new MemoryStream())
            {
                using (CryptoStream c = new CryptoStream(m, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    c.Write(EncryptedBytes, 0, EncryptedBytes.Length);
                    c.Close();
                }
                EncryptedText = Encoding.Unicode.GetString(m.ToArray());
            }
        }
        return EncryptedText;
    }
}