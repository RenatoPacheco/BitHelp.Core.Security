using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace BitHelp.Core.Security
{
    public static class Encripty
    {
        public static string Crypt(string value, string password, string key)
        {
            try
            {
                using (Aes aes = new AesManaged())
                {
                    Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(key));
                    aes.Key = deriveBytes.GetBytes(128 / 8);
                    aes.IV = aes.Key;

                    using (MemoryStream encryptionStream = new MemoryStream())
                    {
                        using (CryptoStream encrypt = new CryptoStream(encryptionStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(value);
                            encrypt.Write(utfD1, 0, utfD1.Length);
                            encrypt.FlushFinalBlock();
                        }

                        return Convert.ToBase64String(encryptionStream.ToArray());
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static string Decrypt(string texto, string senha, string chave)
        {
            try
            {
                using (Aes aes = new AesManaged())
                {
                    Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(senha, Encoding.UTF8.GetBytes(chave));

                    aes.Key = deriveBytes.GetBytes(128 / 8);
                    aes.IV = aes.Key;

                    using (MemoryStream decryptionStream = new MemoryStream())
                    {
                        using (CryptoStream decrypt = new CryptoStream(decryptionStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            byte[] encryptedData = Convert.FromBase64String(texto);

                            decrypt.Write(encryptedData, 0, encryptedData.Length);
                            decrypt.Flush();
                        }

                        byte[] decryptedData = decryptionStream.ToArray();

                        return UTF8Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
