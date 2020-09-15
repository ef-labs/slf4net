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


using System.Collections.Generic;
using NUnit.Framework;
using slf4net.Factories.Internal;

namespace slf4net.Tests.Factories.Internal
{
    
    
    /// <summary>
    ///This is a test class for SubstituteLoggerFactoryTest and is intended
    ///to contain all SubstituteLoggerFactoryTest Unit Tests
    ///</summary>
    [TestFixture]
    public class SubstituteLoggerFactoryTest
    {
        /// <summary>
        ///A test for GetLogger
        ///</summary>
        [Test]
        public void Factories_SubstituteLoggerFactory_GetLoggerTest()
        {
            SubstituteLoggerFactory target = new SubstituteLoggerFactory();
            string name = "foo";
            ILogger expected = NOPLogger.Instance;
            ILogger actual;

            actual = target.GetLogger(name);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetLoggerNameList
        ///</summary>
        [Test]
        public void Factories_SubstituteLoggerFactory_GetLoggerNameListTest()
        {
            SubstituteLoggerFactory target = new SubstituteLoggerFactory();
            string name = "foo";
            IList<string> actual;
            
            actual = target.GetLoggerNameList();
            Assert.AreEqual(0, actual.Count);

            target.GetLogger(name).Debug("test 1");

            actual = target.GetLoggerNameList();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(name, actual[0]);

            name = "bar";
            target.GetLogger(name).Debug("test 2");

            actual = target.GetLoggerNameList();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(name, actual[1]);
            
        }
    }
}
