using Freetime.Configuration;
using Moq;
using NUnit.Framework;

namespace Test.Freetime.Configuration
{
    /// <summary>
    /// Unit Test for Freetime.Configuration.ConfigurationManager
    /// </summary>
    /// <Assembly>Freetime.Configuration</Assembly>
    /// <Class>Freetime.Configuration.ConfigurationManager</Class>
    [TestFixture]
    public class ConfigurationManagerTest
    {

        /// <summary>
        /// Expected : ConfigurationManager.FreetimeConfiguration not null
        /// </summary>
        [Test]
        public void FreetimeConfigNotNullTest()
        {
            var freetimeConfig = new Mock<FreetimeConfiguration>();
            ConfigurationManager.SetFreetimeConfig(freetimeConfig.Object);
            Assert.IsNotNull(ConfigurationManager.FreetimeConfiguration);
        }
    }
}
