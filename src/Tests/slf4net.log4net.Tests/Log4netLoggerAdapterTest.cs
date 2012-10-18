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


using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using slf4net.log4net;
using Core = log4net.Core;

namespace slf4net.Tests
{
    
    
    /// <summary>
    ///This is a test class for Log4netLoggerAdapterTest and is intended
    ///to contain all Log4netLoggerAdapterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Log4netLoggerAdapterTest
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
        ///A test for Log4netLoggerAdapter Constructor
        ///</summary>
        [TestMethod()]
        public void Log4netLoggerAdapter_Test()
        {
            var log = new Mock<Core.ILogger>();
            log.SetupGet(m => m.Name).Returns("Test logger name");
            log.Setup(m => m.IsEnabledFor(It.IsAny<Core.Level>())).Returns(true);

            var logger = new Mock<ILog>();
            logger.SetupGet(m => m.Logger).Returns(log.Object);

            Log4netLoggerAdapter target = new Log4netLoggerAdapter(logger.Object);
            ExploratoryTester.TestILogger(target);

        }
    }
}
