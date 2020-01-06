using Xunit;

namespace BitHelp.Core.Security.Test.EncriptyRijndaelTest
{
    public class CryptAndDecryptTest
    {
        readonly string key = "7OuyFPj893UIVeGggcN3xC9qa6rbZrhJ";
        readonly string vector = "5Mz1gsShywajQFgz";

        [Fact]
        public void Get_hash_with_alpha_numeric()
        {
            string text = "5MkqSmxmux6eRVv17nfusWck98lHtc";
            string hash = EncriptyRijndael.Crypt(text, vector, key);

            Assert.NotEqual(text, hash);
            Assert.Equal(text, EncriptyRijndael.Decrypt(hash, vector, key));
        }

        [Fact]
        public void Get_hash_with_alpha_numeric_and_other_letters()
        {
            string text = "5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn";
            string hash = EncriptyRijndael.Crypt(text, vector, key);

            Assert.NotEqual(text, hash);
            Assert.Equal(text, EncriptyRijndael.Decrypt(hash, vector, key));
        }

        [Fact]
        public void Get_hash_with_for_email()
        {
            string text = "myName1205@mysite.com";
            string hash = EncriptyRijndael.Crypt(text, vector, key);

            Assert.NotEqual(text, hash);
            Assert.Equal(text, EncriptyRijndael.Decrypt(hash, vector, key));
        }

        [Fact]
        public void Get_hash_with_uppercase_compare()
        {
            string text = "5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn";
            string textUpper = text.ToUpper();
            string hash = EncriptyRijndael.Crypt(text, vector, key);
            string hashUpper = EncriptyRijndael.Crypt(textUpper, vector, key);

            Assert.NotEqual(text, hash);
            Assert.Equal(text, EncriptyRijndael.Decrypt(hash, vector, key));

            Assert.NotEqual(textUpper, hashUpper);
            Assert.Equal(textUpper, EncriptyRijndael.Decrypt(hashUpper, vector, key));

            Assert.NotEqual(textUpper, text);
            Assert.NotEqual(hashUpper, hash);
        }

        [Fact]
        public void Get_hash_with_lowercase_compare()
        {
            string text = "5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn";
            string textLower = text.ToLower();
            string hash = EncriptyRijndael.Crypt(text, vector, key);
            string hashLower = EncriptyRijndael.Crypt(textLower, vector, key);

            Assert.NotEqual(text, hash);
            Assert.Equal(text, EncriptyRijndael.Decrypt(hash, vector, key));

            Assert.NotEqual(textLower, hashLower);
            Assert.Equal(textLower, EncriptyRijndael.Decrypt(hashLower, vector, key));

            Assert.NotEqual(textLower, text);
            Assert.NotEqual(hashLower, hash);
        }
    }
}
