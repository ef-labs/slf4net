// The MIT License (MIT)
//
// Copyright © 2020 EF Learning Labs <labs.oss@EF.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the “Software”), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using log4net.Repository;
using Moq;
using NUnit.Framework;
using slf4net.log4net;
using slf4net.log4net.Internal;

namespace slf4net.Tests
{
    /// <summary>
    ///This is a test class for Log4netLoggerFactoryTest and is intended
    ///to contain all Log4netLoggerFactoryTest Unit Tests
    ///</summary>
    [TestFixture]
    public class Log4netLoggerFactoryTest
    {
        private Mock<IXmlConfigurator> _configurator;
        private TestLog4netLoggerFactory _target;

        [SetUp]
        public void SetUp()
        {
            _configurator = new Mock<IXmlConfigurator>();
            _target = new TestLog4netLoggerFactory(_configurator.Object);
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

        /// <summary>
        ///A test for CreateLogger
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_CreateLoggerTest()
        {
            var name = "Test logger name";

            var actual = _target.CreateLogger_ForTest(name);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<Log4netLoggerAdapter>(actual);
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_Init_NullTest()
        {
            _target.Init(null);
            _configurator.Verify(mock => mock.Configure(It.IsAny<ILoggerRepository>()), Times.Once);
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_Init_EmptyTest()
        {
            _target.Init(string.Empty);
            _configurator.Verify(mock => mock.Configure(It.IsAny<ILoggerRepository>()), Times.Once);
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_Init_XmlTest()
        {
            string factoryData;

            factoryData = "<some-xml></some-xml>";
            _target.Init(factoryData);
            _configurator.Verify(mock => mock.Configure(It.IsAny<ILoggerRepository>()), Times.Once);
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_Init_BadXmlTest()
        {
            var factoryData = "<bad-xml></bad>";

            try
            {
                _target.Init(factoryData);
                Assert.Fail();
            }
            catch (XmlException)
            {
                // Expected
            }
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_Init_ValidXmlTest()
        {
            var captures = new List<FileInfo>();
            _configurator.Setup(x => x.Configure(It.IsAny<ILoggerRepository>(), Capture.In(captures)));

            var factoryData =
                "<factory-data><configFile value=\"log4net.config\"/></factory-data>";
            _target.Init(factoryData);

            _configurator.Verify(mock => mock.Configure(It.IsAny<ILoggerRepository>(), It.IsAny<FileInfo>()),
                Times.Once);

            Assert.AreEqual(1, captures.Count);
            Assert.AreEqual(Path.Combine(TestContext.CurrentContext.TestDirectory, "log4net.config"),
                captures[0].FullName);
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_Init_ValidXml_Missing_Test()
        {
            var factoryData =
                "<factory-data><configFile value=\"log4net.missing.config\"/></factory-data>";
            _target.Init(factoryData);

            _configurator.Verify(mock => mock.Configure(It.IsAny<ILoggerRepository>()),
                Times.Once);
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_Init_ValidXml_Watch_Test()
        {
            var captures = new List<FileInfo>();
            _configurator.Setup(x => x.ConfigureAndWatch(It.IsAny<ILoggerRepository>(), Capture.In(captures)));

            var factoryData =
                "<factory-data><configFile value=\"log4net.config\"/><watch value=\"true\"/></factory-data>";
            _target.Init(factoryData);

            _configurator.Verify(mock => mock.ConfigureAndWatch(It.IsAny<ILoggerRepository>(), It.IsAny<FileInfo>()),
                Times.Once);

            Assert.AreEqual(1, captures.Count);
            Assert.AreEqual(Path.Combine(TestContext.CurrentContext.TestDirectory, "log4net.config"),
                captures[0].FullName);
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_Init_ValidXml_MultiConfig_Test()
        {
            var factoryData =
                "<factory-data><configFile value=\"log4net.config\"/><configFile value=\"log4net.extra.config\"/></factory-data>";
            _target.Init(factoryData);
            _configurator.Verify(mock => mock.Configure(It.IsAny<ILoggerRepository>(), It.IsAny<XmlElement>()),
                Times.Once);
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [Test]
        public void Log4netLoggerFactory_Init_ValidXml_MultiConfig_Missing_Test()
        {
            var factoryData =
                "<factory-data><configFile value=\"log4net.config\"/><configFile value=\"log4net.missing.config\"/></factory-data>";
            _target.Init(factoryData);
            _configurator.Verify(mock => mock.Configure(It.IsAny<ILoggerRepository>(), It.IsAny<FileInfo>()),
                Times.Once);
        }

        private class TestLog4netLoggerFactory : Log4netLoggerFactory
        {
            public TestLog4netLoggerFactory(IXmlConfigurator configurator) : base(configurator)
            {
            }

            public ILogger CreateLogger_ForTest(string name)
            {
                return base.CreateLogger(name);
            }
        }
    }
}