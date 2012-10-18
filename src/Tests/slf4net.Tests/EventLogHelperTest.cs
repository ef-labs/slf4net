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

namespace slf4net.Tests
{
    
    
    /// <summary>
    ///This is a test class for EventLogHelperTest and is intended
    ///to contain all EventLogHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EventLogHelperTest
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
        ///A test for WriteEntry
        ///</summary>
        [TestMethod()]
        public void EventLogHelper_WriteEntry_NoException()
        {
            string message = "Test message";
            Exception ex = null;

            EventLogHelper.WriteEntry(message, ex);

        }

        /// <summary>
        ///A test for WriteEntry
        ///</summary>
        [TestMethod()]
        public void EventLogHelper_WriteEntry_WithException()
        {
            string message = "Test message";

            try
            {
                ThrowException1();
            }
            catch (Exception ex)
            {
                EventLogHelper.WriteEntry(message, ex);
            }

        }

        private void ThrowException1()
        {
            ThrowException2();
        }

        private void ThrowException2()
        {
            ThrowException3();
        }

        private void ThrowException3()
        {
            try
            {
                throw new Exception("Inner unit test exception");
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("Outer unit test exception", ex);
            }
        }
    }
}
