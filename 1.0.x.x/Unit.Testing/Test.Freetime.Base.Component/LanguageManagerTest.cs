using Freetime.Base.Component;
using NUnit.Framework;

namespace Test.Freetime.Base.Component
{
    /// <summary>
    /// Unit Test for Freetime.Base.Component.LanguageManager
    /// </summary>
    /// <Assembly>Freetime.Base.Component</Assembly>
    /// <Class>Freetime.Base.Component.LanguageManager</Class>
    [TestFixture]
    public class LanguageManagerTest
    {

        /// <summary>
        /// Expected : Current Lanaguae Manager Not Null
        /// </summary>
        [Test]
        public void LanguageManagerCurrentNotNullTest()
        {
            Assert.IsNotNull(LanguageManager.Current);
        }
    }
}
