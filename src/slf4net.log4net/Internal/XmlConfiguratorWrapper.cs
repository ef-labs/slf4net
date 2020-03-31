using System.Collections;
using System.IO;
using System.Xml;
using log4net.Config;
using log4net.Repository;

namespace slf4net.log4net.Internal
{
    internal class XmlConfiguratorWrapper : IXmlConfigurator
    {
        public ICollection Configure(ILoggerRepository repository)
        {
            return XmlConfigurator.Configure(repository);
        }

        public ICollection Configure(ILoggerRepository repository, XmlElement element)
        {
            return XmlConfigurator.Configure(repository, element);
        }

        public ICollection Configure(ILoggerRepository repository, FileInfo configFile)
        {
            return XmlConfigurator.Configure(repository, configFile);
        }

        public ICollection ConfigureAndWatch(ILoggerRepository repository, FileInfo configFile)
        {
            return XmlConfigurator.ConfigureAndWatch(repository, configFile);
        }
    }
}