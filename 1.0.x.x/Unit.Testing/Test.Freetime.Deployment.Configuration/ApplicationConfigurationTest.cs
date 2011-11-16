using System.Xml.Serialization;
using NUnit.Framework;
using ApplicationConfiguration = Freetime.Deployment.Configuration.ApplicationConfiguration.ApplicationConfiguration;

namespace Test.Freetime.Deployment.Configuration
{
    [TestFixture]
    public class ApplicationConfigurationTest
    {
        [Test]
        public void LoadApplicationConfigurationDefaultsValuesTest()
        {
            var serializer = new XmlSerializer(typeof(ApplicationConfiguration));
            var stream = new System.IO.StreamReader(@"D:\TekWorc\Freetime-G-Business-Platform\1.0.x.x\Freetime.Deployment.Configuration\ApplicationConfiguration\ApplicationConfigurationDefaults.xml");

            var appConfig = serializer.Deserialize(stream) as ApplicationConfiguration;

        }
    }
}
