//The MIT License (MIT)
//Copyright © 2012 Englishtown <opensource@englishtown.com>

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the “Software”), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.


using System.Configuration;
using System.IO;
using System.Xml;
using NUnit.Framework;
using slf4net.Configuration;

namespace slf4net.Tests
{
    
    
    /// <summary>
    ///This is a test class for SlfConfigurationSectionTest and is intended
    ///to contain all SlfConfigurationSectionTest Unit Tests
    ///</summary>
    [TestFixture]
    public class SlfConfigurationSectionTest
    {
        private static System.Configuration.Configuration _configuration;

        [OneTimeSetUp]
        public static void MyClassInitialize()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Configuration", "ConfigurationTests.config");
            var fileMap = new System.Configuration.ConfigurationFileMap(path);
            _configuration = System.Configuration.ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
        }
        
        //Use ClassCleanup to run code after all tests in a class have run
        [OneTimeTearDown]
        public static void MyClassCleanup()
        {
            _configuration = null;
        }
        
        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_NoSectionTest()
        {
            Assert.IsNotNull(_configuration);
            var section = _configuration.GetSection("slf4net-no-section");

            Assert.IsNull(section);
        }

        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_WrongSectionTypeTest()
        {
            Assert.IsNotNull(_configuration);
            var section = _configuration.GetSection("slf4net-wrong-type");

            Assert.IsNotNull(section);
            Assert.IsNotInstanceOf<SlfConfigurationSection>(section);
        }

        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_NoFactoryTest()
        {
            Assert.IsNotNull(_configuration);
            var section = _configuration.GetSection("slf4net-no-factory") as SlfConfigurationSection;

            Assert.IsNotNull(section);
            Assert.IsNotNull(section.Factory);
            Assert.IsTrue(string.IsNullOrEmpty(section.Factory.Type));
            Assert.IsTrue(string.IsNullOrEmpty(section.Factory.FactoryData));
        }

        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_ValidFactoryTest()
        {
            Assert.IsNotNull(_configuration);
            var section = _configuration.GetSection("slf4net-valid-factory") as SlfConfigurationSection;

            Assert.IsNotNull(section);
            Assert.IsNotNull(section.Factory);

            Assert.IsFalse(string.IsNullOrEmpty(section.Factory.Type));
            Assert.AreEqual("slf4net.Factories.SimpleLoggerFactory, slf4net.Simple", section.Factory.Type);
            Assert.IsTrue(string.IsNullOrEmpty(section.Factory.FactoryData));

            string expected = "test.factory.type";
            string actual;

            section.Factory.Type = expected;
            actual = section.Factory.Type;
            Assert.AreEqual(expected, actual);

            FactoryConfigurationElement expectedFactory = new FactoryConfigurationElement();
            FactoryConfigurationElement actualFactory;

            actualFactory = section.Factory;
            Assert.AreNotEqual(expectedFactory, actualFactory);

            section.Factory = expectedFactory;
            actualFactory = section.Factory;
            Assert.AreEqual(expectedFactory, actualFactory);

        }

        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_ExtraFactoriesTest()
        {
            Assert.IsNotNull(_configuration);
            try
            {
                _configuration.GetSection("slf4net-multi-factory");
                Assert.Fail();
            }
            catch (ConfigurationErrorsException)
            {
                // Expected
            }
        }

        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_NoFactoryTypeTest()
        {
            Assert.IsNotNull(_configuration);
            var section = _configuration.GetSection("slf4net-no-factory-type") as SlfConfigurationSection;

            Assert.IsNotNull(section);
            Assert.IsNotNull(section.Factory);

            Assert.IsTrue(string.IsNullOrEmpty(section.Factory.Type));
            Assert.IsTrue(string.IsNullOrEmpty(section.Factory.FactoryData));
        }

        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_ExtraAttributesTest()
        {
            Assert.IsNotNull(_configuration);
            var section = _configuration.GetSection("slf4net-extra-attributes");

            Assert.IsNotNull(section);
            Assert.IsNotInstanceOf<SlfConfigurationSection>(section);
        }

        //slf4net-valid-factory-extra-attributes

        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_FactoryDataTest()
        {
            Assert.IsNotNull(_configuration);
            var section = _configuration.GetSection("slf4net-factory-data") as SlfConfigurationSection;

            Assert.IsNotNull(section);
            Assert.IsNotNull(section.Factory);

            Assert.IsFalse(string.IsNullOrEmpty(section.Factory.Type));
            Assert.AreEqual("slf4net.Factories.SimpleLoggerFactory, slf4net.Simple", section.Factory.Type);

            Assert.IsFalse(string.IsNullOrEmpty(section.Factory.FactoryData));

            var xml = new XmlDocument();
            xml.LoadXml(section.Factory.FactoryData);

            var attribute = xml.SelectSingleNode("logger/@type") as XmlAttribute;
            Assert.IsNotNull(attribute);
            Assert.IsFalse(string.IsNullOrEmpty(attribute.Value));

            Assert.AreEqual("slf4net.ConsoleLogger, slf4net.Simple", attribute.Value);
        }

        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_FactorySimpleDataTest()
        {
            Assert.IsNotNull(_configuration);
            var section = _configuration.GetSection("slf4net-factory-data-simple") as SlfConfigurationSection;

            Assert.IsNotNull(section);
            Assert.IsNotNull(section.Factory);
            Assert.IsFalse(string.IsNullOrEmpty(section.Factory.Type));
            Assert.IsFalse(string.IsNullOrEmpty(section.Factory.FactoryData));

            Assert.AreEqual("simple factory data", section.Factory.FactoryData);
        }

        /// <summary>
        ///A test for SlfConfigurationSection Constructor
        ///</summary>
        [Test]
        public void Configuration_SlfConfigurationSection_FactoryInvalidDataTest()
        {
            Assert.IsNotNull(_configuration);
            try
            {
                var section = _configuration.GetSection("slf4net-factory-data-invalid") as SlfConfigurationSection;
                Assert.Fail("Expected a ConfigurationErrorsException to be thrown.");
            }
            catch (ConfigurationErrorsException)
            {
                // Expected
            }
        }
        
    }
}
