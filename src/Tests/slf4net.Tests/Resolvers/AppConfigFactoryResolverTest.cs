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


using System;
using System.Configuration;
using NUnit.Framework;
using slf4net.Moqs.Factories;
using slf4net.Resolvers;

namespace slf4net.Tests
{
    /// <summary>
    ///This is a test class for AppConfigFactoryResolverTest and is intended
    ///to contain all AppConfigFactoryResolverTest Unit Tests
    ///</summary>
    [TestFixture]
    public class AppConfigFactoryResolverTest
    {
        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_MissingSection()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver();

            var factory = target.GetFactory();
            Assert.IsNull(factory);
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_InvalidSection()
        {
            try
            {
                AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-wrong-type");
                Assert.Fail();
            }
            catch (ConfigurationErrorsException)
            {
                // Expected
            }
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_AltSectionName1()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-alt-name1");

            var factory = target.GetFactory();
            Assert.IsNotNull(factory);
            Assert.IsInstanceOf<TestLoggerFactory>(factory);
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_AltSectionName2()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-alt-name2");

            var factory = target.GetFactory();
            Assert.IsNotNull(factory);
            Assert.IsInstanceOf<TestNamedLoggerFactory>(factory);
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_InvalidType()
        {
            try
            {
                AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-invalid");
                Assert.Fail();
            }
            catch (TypeLoadException)
            {
                // Expected
            }
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_MissingType()
        {
            try
            {
                AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-missing");
                Assert.Fail();
            }
            catch (TypeLoadException)
            {
                // Expected
            }
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_WrongType()
        {
            try
            {
                AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-wrong-factory-type");
                Assert.Fail();
            }
            catch (InvalidCastException)
            {
                // Expected
            }
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_ConfigurableFactory()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-configurable");

            var factory = target.GetFactory();
            Assert.IsNotNull(factory);
            Assert.IsInstanceOf<TestConfigurableLoggerFactory>(factory);

            var cf = (TestConfigurableLoggerFactory)factory;
            Assert.AreEqual("factory configuration data", cf.FactoryData);
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_ConfigurableFactoryNoData()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-configurable-no-data");

            var factory = target.GetFactory();
            Assert.IsNotNull(factory);
            Assert.IsInstanceOf<TestConfigurableLoggerFactory>(factory);

            var cf = (TestConfigurableLoggerFactory)factory;
            Assert.AreEqual(null, cf.FactoryData);
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [Test]
        public void Resolvers_AppConfigFactoryResolver_ConfigurableFactoryInvalid()
        {
            try
            {
                AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-configurable-invalid");
                Assert.Fail();
            }
            catch (ConfigurationErrorsException)
            {
                // Expected
            }
        }

        public class TestConfigurationSection : ConfigurationSection
        {
        }

    }
}
