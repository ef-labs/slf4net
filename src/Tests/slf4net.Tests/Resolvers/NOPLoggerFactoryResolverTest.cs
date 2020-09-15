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


using NUnit.Framework;
using slf4net.Factories;
using slf4net.Resolvers;

namespace slf4net.Tests
{
    
    
    /// <summary>
    ///This is a test class for NOPLoggerFactoryResolverTest and is intended
    ///to contain all NOPLoggerFactoryResolverTest Unit Tests
    ///</summary>
    [TestFixture]
    public class NOPLoggerFactoryResolverTest
    {

        /// <summary>
        ///A test for GetFactory
        ///</summary>
        [Test]
        public void Resolvers_NOPLoggerFactoryResolver_GetFactoryTest()
        {
            NOPLoggerFactoryResolver target = NOPLoggerFactoryResolver.Instance;
            ILoggerFactory expected = NOPLoggerFactory.Instance;
            ILoggerFactory actual;

            actual = target.GetFactory();
            Assert.AreEqual(expected, actual);

        }

    }
}
