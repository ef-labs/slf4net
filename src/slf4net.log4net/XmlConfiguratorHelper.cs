using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using log4net.Core;
using log4net.Repository;
using slf4net.Internal;
using slf4net.log4net.Internal;

namespace slf4net.log4net
{
    internal class XmlConfiguratorHelper
    {
        private const string CONFIG_FILE = "configFile";
        private const string WATCH = "watch";
        private const string VALUE = "value";

        private readonly IXmlConfigurator _configurator;
        private readonly IList<string> _configFiles = new List<string>();
        private bool _watch;

        private static readonly ILoggerRepository _repository =
            LoggerManager.CreateRepository(Log4netLoggerFactory.SLF4NET_REPOSITORY);


        public XmlConfiguratorHelper(string factoryData, IXmlConfigurator configurator)
        {
            _configurator = configurator;
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
                        switch (xr.Name)
                        {
                            case CONFIG_FILE:
                            {
                                if (xr.MoveToAttribute(VALUE) && !string.IsNullOrEmpty(xr.Value))
                                {
                                    _configFiles.Add(xr.Value);
                                }

                                break;
                            }
                            case WATCH:
                            {
                                if (xr.MoveToAttribute(VALUE))
                                {
                                    if (bool.TryParse(xr.Value, out var value))
                                    {
                                        _watch = value;
                                    }
                                }

                                break;
                            }
                        }
                    }
                }
            }
        }

        public void Configure()
        {
            var files = new List<FileInfo>();

            foreach (var configFile in _configFiles)
            {
                var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFile);
                var file = new FileInfo(fileName);

                if (file.Exists)
                {
                    files.Add(file);
                }
                else
                {
                    ConsoleHelper.WriteLine($"log4net config file {configFile} does not exist");
                }
            }

            switch (files.Count)
            {
                case 0:
                    _configurator.Configure(_repository);
                    break;
                case 1:
                {
                    ConfigureOne(files[0]);
                    break;
                }
                default:
                {
                    ConfigureMulti(files);
                    break;
                }
            }
        }

        private void ConfigureOne(FileInfo file)
        {
            if (_watch)
            {
                _configurator.ConfigureAndWatch(_repository, file);
            }
            else
            {
                _configurator.Configure(_repository, file);
            }
        }

        private void ConfigureMulti(IEnumerable<FileInfo> files)
        {
            // Need to combine multiple files
            XElement root = null;
            var name = "log4net";

            foreach (var file in files)
            {
                var doc = XDocument.Load(file.FullName);
                var element = doc.Element(name);

                if (element == null)
                {
                    ConsoleHelper.WriteLine($"log4net config file {file.FullName} missing root {name} element");
                    continue;
                }

                if (root == null)
                {
                    root = element;
                }
                else
                {
                    root.Add(element.Nodes());
                }
            }

            if (root == null)
            {
                _configurator.Configure(_repository);
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                XmlElement node = doc.ReadNode(root.CreateReader()) as XmlElement;
                _configurator.Configure(_repository, node);
            }
        }
    }
}