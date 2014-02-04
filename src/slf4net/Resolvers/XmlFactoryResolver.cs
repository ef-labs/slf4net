using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace slf4net.Resolvers
{
    public class XmlFactoryResolver : IFactoryResolver
    {
        private const string FILE_NAME = "slf4net.xml";

        private const string ROOT_NAME = "slf4net";
        private const string FACTORY_ELEMENT = "factory";
        private const string FACTORY_TYPE = "type";
        private const string FACTORY_DATA = "factory-data";

        private readonly string filePath;
        private readonly ILoggerFactory factory;

        private static readonly string DEFAULT_PATH = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().GetName().CodeBase), FILE_NAME);

        #region Constructors

        public XmlFactoryResolver()
            : this(DEFAULT_PATH)
        { }

        public XmlFactoryResolver(string filePath)
        {
            this.filePath = filePath;
            this.factory = LoadConfiguration();
        }

        private ILoggerFactory LoadConfiguration()
        {
            string factoryType = null;
            string factoryData = null;

            try
            {
                XmlReaderSettings settings = new XmlReaderSettings()
                {
                    ConformanceLevel = ConformanceLevel.Auto,
                    IgnoreComments = true,
                    IgnoreWhitespace = true,
                };

                using (XmlReader xr = XmlReader.Create(this.filePath, settings))
                {
                    while (xr.Read())
                    {
                        if (xr.NodeType == XmlNodeType.Element)
                        {
                            if (xr.Name == FACTORY_ELEMENT)
                            {
                                if (xr.MoveToAttribute(FACTORY_TYPE))
                                {
                                    factoryType = xr.Value;
                                    xr.MoveToElement();
                                }

                                using (XmlReader subTree = xr.ReadSubtree())
                                {
                                    while (subTree.Read())
                                    {
                                        if (subTree.Name == FACTORY_DATA)
                                        {
                                            factoryData = subTree.ReadInnerXml();
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                }

                if (factoryType == null)
                    return null;

                ILoggerFactory factory = ActivatorUtils.Instantiate<ILoggerFactory>(factoryType);

                if (factory is IConfigurableLoggerFactory && factoryData != null)
                {
                    ((IConfigurableLoggerFactory)factory).Init(factoryData);
                }

                return factory;
            }
            catch
            { }
            throw new FormatException("Unable to load xml config file, or it doesn't contain valid slf4net configuration information");
        }

        #endregion

        #region IFactoryResolver Members

        public ILoggerFactory GetFactory()
        {
            return this.factory;
        }

        #endregion
    }
}
