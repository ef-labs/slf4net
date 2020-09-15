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

using System;
using Moq;
using NUnit.Framework;
using slf4net.Factories;
using slf4net.Internal;
using slf4net.Resolvers;

namespace slf4net.Tests.Resolvers
{
    [TestFixture]
    public class LegacyServiceProviderResolverTest
    {
        [Test]
        public void Ctor_Null()
        {
            try
            {
                var resolver = new LegacyServiceProviderResolver(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                // Expected
            }
        }

        [Test]
        public void Ctor_Null_LoggerFactory()
        {
            var factoryResolver = Mock.Of<IFactoryResolver>();
            var resolver = new LegacyServiceProviderResolver(factoryResolver);
            var provider = resolver.GetProvider();

            Assert.NotNull(provider);
            Assert.That(provider.GetLoggerFactory(), Is.InstanceOf<NOPLoggerFactory>());
            Assert.That(provider.GetMdcAdapter(), Is.InstanceOf<NOPMdcAdapter>());
        }

        [Test]
        public void Ctor_FactoryResolver()
        {
            var factoryResolver = Mock.Of<IFactoryResolver>();
            var loggerFactory = Mock.Of<ILoggerFactory>();

            Mock.Get(factoryResolver).Setup(r => r.GetFactory()).Returns(loggerFactory);

            var resolver = new LegacyServiceProviderResolver(factoryResolver);
            var provider = resolver.GetProvider();

            Assert.NotNull(provider);
            Assert.AreSame(loggerFactory, provider.GetLoggerFactory());
            Assert.That(provider.GetMdcAdapter(), Is.InstanceOf<NOPMdcAdapter>());
        }

        [Test]
        public void Ctor_ServiceProvider()
        {
            var mock = new Mock<ILoggerFactory>();
            mock.As<ISlf4netServiceProvider>();
            var serviceProvider = mock.Object;
            var factoryResolver = Mock.Of<IFactoryResolver>();

            Mock.Get(factoryResolver).Setup(r => r.GetFactory()).Returns(serviceProvider);

            var resolver = new LegacyServiceProviderResolver(factoryResolver);
            var provider = resolver.GetProvider();

            Assert.NotNull(provider);
            Assert.AreSame(serviceProvider, provider);
        }
    }
}