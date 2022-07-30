using Xunit;

namespace BitHelp.Core.Security.Test.EncriptyTest
{
    public class CryptAndDecryptTest
    {
        readonly string key = "7u9TYVhESY1koXZTCpEpZDnRDLtN2lJL5SixTB9FIjge2eUELc";
        readonly string password = "2cXXMGfV81ATvSoEDaunfrlJLwXQ9Q5Il80YQKf9H2qJUjnZwh";

        [Theory]
        [InlineData("myName1205@mysite.com")]
        [InlineData("5MkqSmxmux6eRVv17nfusWck98lHtc")]
        [InlineData("5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn")]
        public void Check_crypt_and_decrypt(string text)
        {
            string crypt = Encripty.Crypt(text, password, key);
            string decrypt = Encripty.Decrypt(crypt, password, key);

            Assert.NotEqual(text, crypt);
            Assert.Equal(text, decrypt);

            crypt = Encripty.Crypt(text.ToUpper(), password, key);
            decrypt = Encripty.Decrypt(crypt, password, key);

            Assert.NotEqual(text, crypt);
            Assert.NotEqual(text, decrypt);

            crypt = Encripty.Crypt(text, password, key);
            decrypt = Encripty.Decrypt(crypt, password.ToUpper(), key);

            Assert.NotEqual(text, crypt);
            Assert.NotEqual(text, decrypt);

            crypt = Encripty.Crypt(text, password, key);
            decrypt = Encripty.Decrypt(crypt, password, key.ToUpper());

            Assert.NotEqual(text, crypt);
            Assert.NotEqual(text, decrypt);
        }
    }
}
