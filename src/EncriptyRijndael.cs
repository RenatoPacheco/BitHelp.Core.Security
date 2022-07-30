using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace BitHelp.Core.Security
{
    public static class EncriptyRijndael
    {
        private static Rijndael InitRijndael(
            string key, string vector)
        {
            if (!(key != null &&
                  (key.Length == 16 ||
                   key.Length == 24 ||
                   key.Length == 32)))
            {
                throw new ArgumentException(
                    "The encryption key must have " +
                    "16, 24 or 32 characters.", nameof(key));
            }

            if (vector == null ||
                vector.Length != 16)
            {
                throw new ArgumentException(
                    "The initialization vector must have " +
                    "16 characters.", nameof(vector));
            }

            Rijndael algoritmo = Rijndael.Create();
            algoritmo.Key = Encoding.ASCII.GetBytes(key);
            algoritmo.IV = Encoding.ASCII.GetBytes(vector);

            return algoritmo;
        }

        public static string Crypt(
            string value,
            string vector,
            string key)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            using (Rijndael algorithm = InitRijndael(key, vector))
            {
                ICryptoTransform encryptor =
                    algorithm.CreateEncryptor(
                        algorithm.Key, algorithm.IV);

                using (MemoryStream streamResult = new MemoryStream())
                {
                    using (CryptoStream csStream = new CryptoStream(
                        streamResult, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(csStream))
                        {
                            writer.Write(value);
                        }
                    }

                    return ArrayBytesToHexString(streamResult.ToArray());
                }
            }
        }

        private static string ArrayBytesToHexString(byte[] content)
        {
            string[] arrayHex = Array.ConvertAll(
                content, b => b.ToString("X2"));
            return string.Concat(arrayHex);
        }

        public static string Decrypt(
            string value,
            string vector,
            string key)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            if (value.Length % 2 != 0)
            {
                return string.Empty;
            }

            string encryptedText = string.Empty;
            Rijndael algorithm = null;

            try
            {
                using (algorithm = InitRijndael(
                    key, vector))
                {
                    ICryptoTransform decryptor =
                        algorithm.CreateDecryptor(
                            algorithm.Key, algorithm.IV);

                    using (MemoryStream streamEncryptedText =
                        new MemoryStream(
                            HexStringToArrayBytes(value)))
                    {
                        using (CryptoStream csStream = new CryptoStream(
                            streamEncryptedText, decryptor,
                            CryptoStreamMode.Read))
                        {
                            using (StreamReader reader =
                                new StreamReader(csStream))
                            {
                                encryptedText =
                                    reader.ReadToEnd();
                            }
                        }
                    }

                }
            }
            catch
            {
                encryptedText = string.Empty;
            }
            finally
            {
                if (algorithm != null)
                    algorithm.Clear();
            }
            return encryptedText;
        }

        private static byte[] HexStringToArrayBytes(string content)
        {
            int countBytesEncript =
                content.Length / 2;
            byte[] arrayContentEncript =
                new byte[countBytesEncript];
            for (int i = 0; i < countBytesEncript; i++)
            {
                arrayContentEncript[i] = Convert.ToByte(
                    content.Substring(i * 2, 2), 16);
            }

            return arrayContentEncript;
        }
    }
}
