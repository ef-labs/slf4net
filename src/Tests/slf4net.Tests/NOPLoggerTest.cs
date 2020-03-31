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


using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace slf4net.Tests
{
    [TestFixture]
    public class NOPLoggerTest
    {

        [Test]
        public void NOPLogger_NameTest()
        {
            NOPLogger logger = NOPLogger.Instance;
            string actual;
            string expected = "NOP";

            actual = logger.Name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NOPLogger_AllLogMethodsTest()
        {
            NOPLogger logger = NOPLogger.Instance;

            List<string> failures = ExploratoryTester.TestILogger(logger);

            Assert.AreEqual(0, failures.Count,
              failures.Count != 0 ? failures.Aggregate((s1, s2) => s1 + System.Environment.NewLine + s2) : "");

        }
    }
}
