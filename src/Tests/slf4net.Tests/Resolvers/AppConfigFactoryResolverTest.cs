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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using slf4net.Moqs.Factories;
using slf4net.Resolvers;

namespace slf4net.Tests
{


    /// <summary>
    ///This is a test class for AppConfigFactoryResolverTest and is intended
    ///to contain all AppConfigFactoryResolverTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AppConfigFactoryResolverTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        public void Resolvers_AppConfigFactoryResolver_MissingSection()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver();

            var factory = target.GetFactory();
            Assert.IsNull(factory);
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void Resolvers_AppConfigFactoryResolver_InvalidSection()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-wrong-type");
            Assert.Fail();
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        public void Resolvers_AppConfigFactoryResolver_AltSectionName1()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-alt-name1");

            var factory = target.GetFactory();
            Assert.IsNotNull(factory);
            Assert.IsInstanceOfType(factory, typeof(TestLoggerFactory));
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        public void Resolvers_AppConfigFactoryResolver_AltSectionName2()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-alt-name2");

            var factory = target.GetFactory();
            Assert.IsNotNull(factory);
            Assert.IsInstanceOfType(factory, typeof(TestNamedLoggerFactory));
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(TypeLoadException))]
        public void Resolvers_AppConfigFactoryResolver_InvalidType()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-invalid");
            Assert.Fail();
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(TypeLoadException))]
        public void Resolvers_AppConfigFactoryResolver_MissingType()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-missing");
            Assert.Fail();
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void Resolvers_AppConfigFactoryResolver_WrongType()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-wrong-factory-type");
            Assert.Fail();
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        public void Resolvers_AppConfigFactoryResolver_ConfigurableFactory()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-configurable");

            var factory = target.GetFactory();
            Assert.IsNotNull(factory);
            Assert.IsInstanceOfType(factory, typeof(TestConfigurableLoggerFactory));

            var cf = (TestConfigurableLoggerFactory)factory;
            Assert.AreEqual("factory configuration data", cf.FactoryData);
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        public void Resolvers_AppConfigFactoryResolver_ConfigurableFactoryNoData()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-configurable-no-data");

            var factory = target.GetFactory();
            Assert.IsNotNull(factory);
            Assert.IsInstanceOfType(factory, typeof(TestConfigurableLoggerFactory));

            var cf = (TestConfigurableLoggerFactory)factory;
            Assert.AreEqual(null, cf.FactoryData);
        }

        /// <summary>
        ///A test for AppConfigFactoryResolver Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void Resolvers_AppConfigFactoryResolver_ConfigurableFactoryInvalid()
        {
            AppConfigFactoryResolver target = new AppConfigFactoryResolver("slf4net-configurable-invalid");
            Assert.Fail();
        }

        public class TestConfigurationSection : ConfigurationSection
        {
        }

    }
}
