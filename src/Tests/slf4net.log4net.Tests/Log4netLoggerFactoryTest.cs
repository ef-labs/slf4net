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


using Microsoft.VisualStudio.TestTools.UnitTesting;
using slf4net.log4net;

namespace slf4net.Tests
{
    
    
    /// <summary>
    ///This is a test class for Log4netLoggerFactoryTest and is intended
    ///to contain all Log4netLoggerFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Log4netLoggerFactoryTest
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
        ///A test for CreateLogger
        ///</summary>
        [TestMethod()]
        [DeploymentItem("slf4net.log4net.dll")]
        public void Log4netLoggerFactory_CreateLoggerTest()
        {
            var target = new TestLog4netLoggerFactory();
            string name = "Test logger name";
            ILogger actual;
            
            actual = target.CreateLogger_ForTest(name);
            Assert.IsNotNull(actual);
            
        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [TestMethod()]
        public void Log4netLoggerFactory_Init_NullTest()
        {
            Log4netLoggerFactory target = new Log4netLoggerFactory();
            string factoryData;

            factoryData = null;
            target.Init(factoryData);

        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [TestMethod()]
        public void Log4netLoggerFactory_Init_EmptyTest()
        {
            Log4netLoggerFactory target = new Log4netLoggerFactory();
            string factoryData;

            factoryData = string.Empty;
            target.Init(factoryData);

        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [TestMethod()]
        public void Log4netLoggerFactory_Init_XmlTest()
        {
            Log4netLoggerFactory target = new Log4netLoggerFactory();
            string factoryData;

            factoryData = "<some-xml></some-xml>";
            target.Init(factoryData);

        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.Xml.XmlException))]
        public void Log4netLoggerFactory_Init_BadXmlTest()
        {
            Log4netLoggerFactory target = new Log4netLoggerFactory();
            string factoryData;

            factoryData = "<bad-xml></bad>";
            target.Init(factoryData);

        }

        /// <summary>
        ///A test for Init
        ///</summary>
        [TestMethod()]
        public void Log4netLoggerFactory_Init_ValidXmlTest()
        {
            Log4netLoggerFactory target = new Log4netLoggerFactory();
            string factoryData;

            factoryData = "<factory-data><configFile value=\"log4net.config\"/><watch value=\"true\"/></factory-data>";
            target.Init(factoryData);

        }

        private class TestLog4netLoggerFactory : Log4netLoggerFactory
        {

            public ILogger CreateLogger_ForTest(string name)
            {
                return base.CreateLogger(name);
            }

        }
    }
}
