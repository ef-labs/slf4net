using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Config;
using System.IO;
using System.Xml;

namespace slf4net.log4net
{
    internal class XmlConfiguratorHelper
    {

        private const string CONFIG_FILE = "configFile";
        private const string WATCH = "watch";
        private const string VALUE = "value";

        private string _configFile;
        private string _watch;

        public XmlConfiguratorHelper(string factoryData)
        {
            if (string.IsNullOrEmpty(factoryData))
            {
                return;
            }

            var settings = new XmlReaderSettings()
            {
                ConformanceLevel = ConformanceLevel.Auto,
                IgnoreComments = true,
                IgnoreWhitespace = true,
            };

            using (var sr = new StringReader(factoryData))
            using (var xr = XmlReader.Create(sr, settings))
            {
                while (xr.Read())
                {
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        if (xr.Name == CONFIG_FILE)
                        {
                            if (xr.MoveToAttribute(VALUE))
                            {
                                _configFile = xr.Value;
                            }
                        }
                        else if (xr.Name == WATCH)
                        {
                            if (xr.MoveToAttribute(VALUE))
                            {
                                _watch = xr.Value;
                            }
                        }
                    }
                }
            }

        }

        public void Configure()
        {
            FileInfo fileInfo;

            if (string.IsNullOrEmpty(_configFile))
            {
                fileInfo = new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            }
            else
            {
                var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _configFile);
                fileInfo = new FileInfo(fileName);
            }

            bool watch;

            if (bool.TryParse(_watch, out watch) && watch)
            {
                XmlConfigurator.ConfigureAndWatch(fileInfo);
            }
            else
            {
                XmlConfigurator.Configure(fileInfo);
            }
        }


    }
}
