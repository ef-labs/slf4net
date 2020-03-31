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


using NUnit.Framework;
using slf4net.Factories;

namespace slf4net.Tests.Factories
{
    
    
    /// <summary>
    ///This is a test class for NOPLoggerFactoryTest and is intended
    ///to contain all NOPLoggerFactoryTest Unit Tests
    ///</summary>
    [TestFixture]
    public class NOPLoggerFactoryTest
    {
        /// <summary>
        ///A test for GetLogger
        ///</summary>
        [Test]
        public void Factories_NOPLoggerFactory_GetLogger_ReturnsNOPLoggerSingleton()
        {
            var target = NOPLoggerFactory.Instance;
            string name = "foo";
            ILogger expected = NOPLogger.Instance;
            ILogger actual;

            actual = target.GetLogger(name);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetLogger
        ///</summary>
        [Test]
        public void Factories_NOPLoggerFactory_GetLogger_ReturnsSameLogger()
        {
            var target = NOPLoggerFactory.Instance;
            string name = "foo";
            ILogger expected = NOPLogger.Instance;
            ILogger actual;

            actual = target.GetLogger(name);
            Assert.AreEqual(expected, actual);

            string name2 = "other";
            var logger2 = target.GetLogger(name2);

            Assert.AreEqual(actual, logger2);
        }
        
    }
}
