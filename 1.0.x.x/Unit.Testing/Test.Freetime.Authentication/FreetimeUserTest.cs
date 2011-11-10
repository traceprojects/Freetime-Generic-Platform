using Freetime.Authentication;
using NUnit.Framework;

namespace Test.Freetime.Authentication
{
    /// <summary>
    /// Unit Test for Freetime.Base.Framework.Crypto
    /// </summary>
    /// <Assembly>Freetime.Base.Framework</Assembly>
    /// <Class>Freetime.Base.Framework.Crypto</Class>
    [TestFixture]
    public class FreetimeUserTest
    {

        /// <summary>
        /// Expected : Initialized FreetimeUser
        /// </summary>
        [Test]
        public void InitiateFreetimeUserTest()
        {
            var user = new FreetimeUser(1, 1, "Test User", true, "DefaultTheme");
            Assert.IsNotNull(user);
        }
    }
}
