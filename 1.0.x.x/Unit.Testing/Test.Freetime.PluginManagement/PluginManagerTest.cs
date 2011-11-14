using Moq;
using Freetime.PluginManagement;
using NUnit.Framework;

namespace Test.Freetime.PluginManagement
{
    /// <summary>
    /// Unit Test for Freetime.PluginManagement.PluginManager
    /// </summary>
    /// <Assembly>Freetime.PluginManagement.</Assembly>
    /// <Class>Freetime.PluginManagement.PluginManager</Class>
    [TestFixture]
    public class PluginManagerTest
    {
        /// <summary>
        /// Expected : PluginManager Not Null
        /// </summary>
        [Test]
        public void PluginManagerNotNullTest()
        {
            var pluginManager = new Mock<IPluginManager>();
            PluginManager.SetPluginManager(pluginManager.Object);
            Assert.IsTrue(PluginManager.Current != null);
        }
    }
}
