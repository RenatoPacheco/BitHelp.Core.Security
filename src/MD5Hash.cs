using System.Security.Cryptography;
using System.Text;

namespace BitHelp.Core.Security
{
    public static class MD5Hash
    {
        public static string Crypt(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(value);
                byte[] hash = md5.ComputeHash(inputBytes);

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
            }
            return sb.ToString().ToLower();
        }
    }
}