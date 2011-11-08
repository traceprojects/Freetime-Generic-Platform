using Freetime.Base.Framework;
using NUnit.Framework;

namespace Test.Freetime.Base.Framework
{
    /// <summary>
    /// Unit Test for Freetime.Base.Framework.Crypto
    /// </summary>
    /// <Assembly>Freetime.Base.Framework</Assembly>
    /// <Class>Freetime.Base.Framework.Crypto</Class>
    [TestFixture]
    public class CryptoTest
    {

        /// <summary>
        /// Expected : Crypto should not be null
        /// </summary>
        [Test]
        public void CryptoNullTest()
        {
            var provider = Crypto.Md5CryptoServiceProvider;
            Assert.IsNotNull(provider);
        }
    }
}
