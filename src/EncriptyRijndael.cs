using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace BitHelp.Core.Security
{
    public class EncriptyRijndael
    {
        private static Rijndael InitRijndael(
            string key, string vector)
        {
            if (!(key != null &&
                  (key.Length == 16 ||
                   key.Length == 24 ||
                   key.Length == 32)))
            {
                throw new Exception(
                    "A chave de criptografia deve possuir " +
                    "16, 24 ou 32 caracteres.");
            }

            if (vector == null ||
                vector.Length != 16)
            {
                throw new Exception(
                    "O vetor de inicialização deve possuir " +
                    "16 caracteres.");
            }

            Rijndael algoritmo = Rijndael.Create();
            algoritmo.Key = Encoding.ASCII.GetBytes(key);
            algoritmo.IV = Encoding.ASCII.GetBytes(vector);

            return algoritmo;
        }

        public static string Encode(
            string key,
            string vector,
            string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                /*throw new Exception(
                    "O conteúdo a ser encriptado não pode " +
                    "ser uma string vazia.");*/

                return string.Empty;
            }

            using (Rijndael algoritmo = InitRijndael(
                key, vector))
            {
                ICryptoTransform encryptor =
                    algoritmo.CreateEncryptor(
                        algoritmo.Key, algoritmo.IV);

                using (MemoryStream streamResultado =
                       new MemoryStream())
                {
                    using (CryptoStream csStream = new CryptoStream(
                        streamResultado, encryptor,
                        CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer =
                            new StreamWriter(csStream))
                        {
                            writer.Write(value);
                        }
                    }

                    return ArrayBytesToHexString(
                        streamResultado.ToArray());
                }
            }
        }

        private static string ArrayBytesToHexString(byte[] content)
        {
            string[] arrayHex = Array.ConvertAll(
                content, b => b.ToString("X2"));
            return string.Concat(arrayHex);
        }

        public static string Decode(
            string key,
            string vector,
            string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                /*throw new Exception(
                    "O conteúdo a ser decriptado não pode " +
                    "ser uma string vazia.");*/
                return string.Empty;
            }

            if (value.Length % 2 != 0)
            {
                /*throw new Exception(
                    "O conteúdo a ser decriptado é inválido.");*/
                return string.Empty;
            }

            string textoDecriptografado = string.Empty;
            Rijndael algoritmo = null;

            try
            {
                using (algoritmo = InitRijndael(
                    key, vector))
                {
                    ICryptoTransform decryptor =
                        algoritmo.CreateDecryptor(
                            algoritmo.Key, algoritmo.IV);

                    using (MemoryStream streamTextoEncriptado =
                        new MemoryStream(
                            HexStringToArrayBytes(value)))
                    {
                        using (CryptoStream csStream = new CryptoStream(
                            streamTextoEncriptado, decryptor,
                            CryptoStreamMode.Read))
                        {
                            using (StreamReader reader =
                                new StreamReader(csStream))
                            {
                                textoDecriptografado =
                                    reader.ReadToEnd();
                            }
                        }
                    }

                }
            }
            catch
            {
                textoDecriptografado = string.Empty;
            }
            finally
            {
                if (algoritmo != null)
                    algoritmo.Clear();
            }
            return textoDecriptografado;
        }

        private static byte[] HexStringToArrayBytes(string content)
        {
            int qtdeBytesEncriptados =
                content.Length / 2;
            byte[] arrayConteudoEncriptado =
                new byte[qtdeBytesEncriptados];
            for (int i = 0; i < qtdeBytesEncriptados; i++)
            {
                arrayConteudoEncriptado[i] = Convert.ToByte(
                    content.Substring(i * 2, 2), 16);
            }

            return arrayConteudoEncriptado;
        }
    }
}
