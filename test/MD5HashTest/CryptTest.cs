using Xunit;

namespace BitHelp.Core.Security.Test.MD5HashTest
{
    public class CryptTest
    {
        [Fact]
        public void Get_hash_with_alpha_numeric()
        {
            string hash = MD5Hash.Crypt("5MkqSmxmux6eRVv17nfusWck98lHtc");
            Assert.Equal("677a50f0f7ec7843b27ac876ecffab93", hash);
        }

        [Fact]
        public void Get_hash_with_alpha_numeric_and_other_letters()
        {
            string hash = MD5Hash.Crypt("5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn");
            Assert.Equal("d41560e106cafb5fe194320ba3404c6e", hash);
        }

        [Fact]
        public void Get_hash_with_for_email()
        {
            string hash = MD5Hash.Crypt("myName1205@mysite.com");
            Assert.Equal("c9a0bb7a4ba63eb172dc499639097745", hash);
        }

        [Fact]
        public void Get_hash_with_uppercase_compare()
        {
            string text = "5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn";
            
            Assert.Equal("d41560e106cafb5fe194320ba3404c6e", MD5Hash.Crypt(text));
            Assert.Equal("b1ef44d44a4f240b8605a1a6ffda27f9", MD5Hash.Crypt(text.ToUpper()));
        }

        [Fact]
        public void Get_hash_with_lowercase_compare()
        {
            string text = "5uPms(o0t!7kT~hxgP=xTtj-*6rSvdhI]hV^9tsx1S,*i_0!cn";
            
            Assert.Equal("d41560e106cafb5fe194320ba3404c6e", MD5Hash.Crypt(text));
            Assert.Equal("a026b40ba305ec7b2cb09a071c3a0ac3", MD5Hash.Crypt(text.ToLower()));
        }
    }
}
