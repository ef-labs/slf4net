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
using slf4net.Factories;
using slf4net.Moqs.Factories;

namespace slf4net.Tests.Factories
{
    [TestClass]
    public class NamedLoggerFactoryBaseTest
    {
        [TestMethod]
        public void Factories_NamedLoggerFactoryBase_GetLogger_ReturnsLoggerWithGivenName()
        {
            NamedLoggerFactoryBase target = new TestNamedLoggerFactory();

            ILogger logger = target.GetLogger("foo");
            Assert.AreEqual("foo", logger.Name);
        }
        
        [TestMethod]
        public void Factories_NamedLoggerFactoryBase_GetLogger_With_Null_Uses_Default_Name()
        {
            NamedLoggerFactoryBase target = new TestNamedLoggerFactory();

            var logger = target.GetLogger(null);
            Assert.AreEqual(string.Empty, logger.Name);
        }
        
        [TestMethod]
        public void Factories_NamedLoggerFactoryBase_GetLogger_WithSameName_ReturnsSameInstance()
        {
            NamedLoggerFactoryBase target = new TestNamedLoggerFactory();

            ILogger logger = target.GetLogger("foo");
            ILogger loggerTwo = target.GetLogger("foo");

            Assert.AreSame(logger, loggerTwo);
        }

        [TestMethod]
        public void Factories_NamedLoggerFactoryBase_GetLogger_WithSameNameCaseInsensitive_ReturnsSameInstance()
        {
            NamedLoggerFactoryBase target = new TestNamedLoggerFactory();

            ILogger logger = target.GetLogger("foo");
            ILogger loggerTwo = target.GetLogger("FOO");

            Assert.AreSame(logger, loggerTwo);
        }

        [TestMethod]
        public void Factories_NamedLoggerFactoryBase_Requesting_Loggers_By_Different_Names_Returns_Different_Instances()
        {
            NamedLoggerFactoryBase target = new TestNamedLoggerFactory();

            ILogger logger = target.GetLogger("foo");
            ILogger loggerTwo = target.GetLogger("foo.bar");

            Assert.AreNotSame(logger, loggerTwo);
        }

        [TestMethod]
        public void Factories_NamedLoggerFactoryBase_GetLogger_WithDifferentNames_ReturnsLoggerWithGivenNames()
        {
            NamedLoggerFactoryBase target = new TestNamedLoggerFactory();

            string name1 = "foo";
            string name2 = "foo.bar";

            ILogger logger1 = target.GetLogger(name1);
            ILogger logger2 = target.GetLogger(name2);

            Assert.AreEqual(name1, logger1.Name);
            Assert.AreEqual(name2, logger2.Name);

            logger2 = target.GetLogger(name1);
            Assert.AreEqual(logger1, logger2);

            logger1 = target.GetLogger(name2);
            logger2 = target.GetLogger(name2);
            Assert.AreEqual(logger1, logger2);
        }

    }
}
