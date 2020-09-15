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

using Moq;
using NUnit.Framework;

namespace slf4net.Tests
{
    [TestFixture]
    public class GDCTest
    {
        private readonly IMdcAdapter _mockAdapter = Mock.Of<IMdcAdapter>();

        [SetUp]
        public void SetUp()
        {
            var resolver = Mock.Of<ISlf4netServiceProviderResolver>();
            var provider = Mock.Of<ISlf4netServiceProvider>();

            Mock.Get(resolver).Setup(r => r.GetProvider()).Returns(provider);
            Mock.Get(provider).Setup(p => p.GetMdcAdapter()).Returns(_mockAdapter);

            LoggerFactory.SetServiceProviderResolver(resolver);
        }

        [Test]
        public void Get()
        {
            const string key = "key1";
            var expected = new object();

            Mock.Get(_mockAdapter).Setup(a => a.GlobalGet(key)).Returns(expected);

            var actual = GDC.Get(key);

            Assert.AreEqual(expected, actual);
            Mock.Get(_mockAdapter).Verify(a => a.GlobalGet(key), Times.Once);
        }

        [Test]
        public void Set()
        {
            const string key = "key1";
            var expected = new object();

            GDC.Set(key, expected);
            Mock.Get(_mockAdapter).Verify(a => a.GlobalSet(key, expected), Times.Once);
        }

        [Test]
        public void Remove()
        {
            const string key = "key1";

            GDC.Remove(key);
            Mock.Get(_mockAdapter).Verify(a => a.GlobalRemove(key), Times.Once);
        }

        [Test]
        public void Clear()
        {
            GDC.Clear();
            Mock.Get(_mockAdapter).Verify(a => a.GlobalClear(), Times.Once);
        }
    }
}