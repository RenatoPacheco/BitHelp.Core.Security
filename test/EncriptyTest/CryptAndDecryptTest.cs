using Xunit;

namespace BitHelp.Core.Security.Test.EncriptyTest
{
    public class CryptAndDecryptTest
    {
        readonly string key = "7u9TYVhESY1koXZTCpEpZDnRDLtN2lJL5SixTB9FIjge2eUELc";
        readonly string password = "2cXXMGfV81ATvSoEDaunfrlJLwXQ9Q5Il80YQKf9H2qJUjnZwh";

        [Fact]
        public void Get_hash_with_alpha_numeric()
        {
            string text = "5MkqSmxmux6eRVv17nfusWck98lHtc";
            string hash = Encripty.Crypt(text, password, key);


            Assert.NotEqual(text, hash);
            Assert.Equal(text, Encripty.Decrypt(hash, password, key));
        }

        [Fact]
        public void Get_hash_with_alpha_numeric_and_other_letters()
        {
            string text = "5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn";
            string hash = Encripty.Crypt(text, password, key);

            Assert.NotEqual(text, hash);
            Assert.Equal(text, Encripty.Decrypt(hash, password, key));
        }

        [Fact]
        public void Get_hash_with_for_email()
        {
            string text = "myName1205@mysite.com";
            string hash = Encripty.Crypt(text, password, key);

            Assert.NotEqual(text, hash);
            Assert.Equal(text, Encripty.Decrypt(hash, password, key));
        }

        [Fact]
        public void Get_hash_with_uppercase_compare()
        {
            string text = "5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn";
            string textUpper = text.ToUpper();
            string hash = Encripty.Crypt(text, password, key);
            string hashUpper = Encripty.Crypt(textUpper, password, key);

            Assert.NotEqual(text, hash);
            Assert.Equal(text, Encripty.Decrypt(hash, password, key));

            Assert.NotEqual(textUpper, hashUpper);
            Assert.Equal(textUpper, Encripty.Decrypt(hashUpper, password, key));

            Assert.NotEqual(textUpper, text);
            Assert.NotEqual(hashUpper, hash);
        }

        [Fact]
        public void Get_hash_with_lowercase_compare()
        {
            string text = "5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn";
            string textLower = text.ToLower();
            string hash = Encripty.Crypt(text, password, key);
            string hashLower = Encripty.Crypt(textLower, password, key);

            Assert.NotEqual(text, hash);
            Assert.Equal(text, Encripty.Decrypt(hash, password, key));

            Assert.NotEqual(textLower, hashLower);
            Assert.Equal(textLower, Encripty.Decrypt(hashLower, password, key));

            Assert.NotEqual(textLower, text);
            Assert.NotEqual(hashLower, hash);
        }
    }
}
