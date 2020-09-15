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
using System.Threading;
using NUnit.Framework;
using Moq;
using slf4net.Factories;
using slf4net.Factories.Internal;
using slf4net.Internal;
using slf4net.Moqs;

namespace slf4net.Tests
{
    /// <summary>
    ///This is a test class for LoggerFactoryTest and is intended
    ///to contain all LoggerFactoryTest Unit Tests
    ///</summary>
    [TestFixture]
    public class LoggerFactoryTest
    {
        /// <summary>
        ///A test for GetILoggerFactory
        ///</summary>
        [Test]
        public void LoggerFactory_GetILoggerFactoryTest()
        {
            ILoggerFactory expected = NOPLoggerFactory.Instance;
            ILoggerFactory actual;

            LoggerFactory.Reset();
            actual = LoggerFactory.GetILoggerFactory();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetILoggerFactory
        ///</summary>
        [Test]
        public void LoggerFactory_GetILoggerFactory_TempFactory()
        {
            var resolver = new Mock<IFactoryResolver>();
            resolver.Setup(m => m.GetFactory()).Returns(() =>
            {
                // Sleep to block the current thread
                Thread.Sleep(300);
                return MoqFactory.LoggerFactory().Object;
            });

            ILoggerFactory actual;

            // Set resolver to mocked instance with delay
            LoggerFactory.SetFactoryResolver(resolver.Object);

            // Start in separate thread
            var thread1 = new Thread(() => LoggerFactory.GetILoggerFactory());
            thread1.Start();

            // Current thread should receive the temp version
            Thread.Sleep(100);
            actual = LoggerFactory.GetILoggerFactory();
            Assert.IsInstanceOf<SubstituteLoggerFactory>(actual);

            actual.GetLogger("unit.test.logger").Debug("Hello");

            Thread.Sleep(250);
            actual = LoggerFactory.GetILoggerFactory();
            Assert.IsInstanceOf(MoqFactory.LoggerFactory().Object.GetType(), actual);
        }

        /// <summary>
        ///A test for GetILoggerFactory
        ///</summary>
        [Test]
        public void LoggerFactory_GetILoggerFactory_FactoryResolverThrowsException()
        {
            var resolver = new Mock<IFactoryResolver>();
            resolver.Setup(m => m.GetFactory()).Returns(() =>
            {
                throw new Exception("Unit test: factory resolver fails.");
            });

            LoggerFactory.SetFactoryResolver(resolver.Object);

            ILoggerFactory actual;
            ILoggerFactory expected = NOPLoggerFactory.Instance;

            actual = LoggerFactory.GetILoggerFactory();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetILoggerFactory
        ///</summary>
        [Test]
        public void LoggerFactory_GetILoggerFactory_FactoryReturnsNull()
        {
            var resolver = new Mock<IFactoryResolver>();
            resolver.Setup(m => m.GetFactory()).Returns(() => null);

            LoggerFactory.SetFactoryResolver(resolver.Object);

            ILoggerFactory actual;
            ILoggerFactory expected = NOPLoggerFactory.Instance;

            actual = LoggerFactory.GetILoggerFactory();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetLogger
        ///</summary>
        [Test]
        public void LoggerFactory_GetLoggerTest()
        {
            Type type = this.GetType();
            ILogger expected = NOPLogger.Instance;
            ILogger actual;

            LoggerFactory.Reset();
            actual = LoggerFactory.GetLogger(type);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetLogger
        ///</summary>
        [Test]
        public void LoggerFactory_GetLoggerTest1()
        {
            string name = "foo.bar";
            ILogger expected = NOPLogger.Instance;
            ILogger actual;

            LoggerFactory.Reset();
            actual = LoggerFactory.GetLogger(name);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Reset
        ///</summary>
        [Test]
        public void LoggerFactory_ResetTest()
        {
            var resolver = MoqFactory.FactoryResolver().Object;
            LoggerFactory.SetFactoryResolver(resolver);
            ILoggerFactory factory1;
            ILoggerFactory factory2;

            factory1 = LoggerFactory.GetILoggerFactory();
            Assert.IsInstanceOf(resolver.GetFactory().GetType(), factory1);

            LoggerFactory.Reset();
            factory2 = LoggerFactory.GetILoggerFactory();

            Assert.AreNotEqual(factory1, factory2);
            Assert.IsInstanceOf<NOPLoggerFactory>(factory2);
        }

        /// <summary>
        ///A test for SetFactoryResolver
        ///</summary>
        [Test]
        public void LoggerFactory_SetFactoryResolverTest()
        {
            IFactoryResolver resolver = MoqFactory.FactoryResolver().Object;
            LoggerFactory.SetFactoryResolver(resolver);

            var provider = LoggerFactory.GetProvider();
            Assert.That(provider, Is.InstanceOf<BasicSlf4netServiceProvider>());

            var factory = LoggerFactory.GetILoggerFactory();
            Assert.IsInstanceOf(resolver.GetFactory().GetType(), factory);
        }

        /// <summary>
        ///A test for SetFactoryResolver
        ///</summary>
        [Test]
        public void LoggerFactory_SetFactoryResolver_ServiceProviderTest()
        {
            var resolver = Mock.Of<IFactoryResolver>();
            var factoryMoq = new Mock<ILoggerFactory>();
            var providerMoq = factoryMoq.As<ISlf4netServiceProvider>();
            Mock.Get(resolver).Setup(r => r.GetFactory()).Returns(factoryMoq.Object);

            LoggerFactory.SetFactoryResolver(resolver);

            var provider = LoggerFactory.GetProvider();
            Assert.AreSame(providerMoq.Object, provider);
        }

        /// <summary>
        ///A test for SetFactoryResolver
        ///</summary>
        [Test]
        public void LoggerFactory_SetFactoryResolver_NullTest()
        {
            LoggerFactory.SetFactoryResolver(null);

            var provider = LoggerFactory.GetProvider();
            Assert.That(provider, Is.InstanceOf<NOPSlf4netServiceProvider>());
        }

        /// <summary>
        ///A test for SetServiceProviderResolver
        ///</summary>
        [Test]
        public void LoggerFactory_SetServiceProviderResolverTest()
        {
            var resolver = Mock.Of<ISlf4netServiceProviderResolver>();
            var expected = Mock.Of<ISlf4netServiceProvider>();
            Mock.Get(resolver).Setup(r => r.GetProvider()).Returns(expected);

            LoggerFactory.SetServiceProviderResolver(resolver);

            var actual = LoggerFactory.GetProvider();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SetServiceProviderResolver
        ///</summary>
        [Test]
        public void LoggerFactory_SetServiceProviderResolver_NullTest()
        {
            LoggerFactory.SetServiceProviderResolver(null);

            var provider = LoggerFactory.GetProvider();
            Assert.That(provider, Is.InstanceOf<NOPSlf4netServiceProvider>());
        }
    }
}