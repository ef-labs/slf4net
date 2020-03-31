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
using Moq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

namespace slf4net.Tests
{


    /// <summary>
    ///This is a test class for NamedLoggerBaseTest and is intended
    ///to contain all NamedLoggerBaseTest Unit Tests
    ///</summary>
    [TestFixture]
    public class NamedLoggerBaseTest
    {
        /// <summary>
        ///A test for Name
        ///</summary>
        [Test]
        public void NamedLoggerBase_ConstructorTest()
        {
            NamedLoggerBase target = new TestNamedLogger();
            string expected = null;
            string actual;

            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [Test]
        public void NamedLoggerBase_ConstructorWithNameTest()
        {
            string expected = "test name";
            NamedLoggerBase target = new TestNamedLogger(expected);
            string actual;

            actual = target.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for serialization
        ///</summary>
        [Test]
        public void NamedLoggerBase_SerializationTest()
        {
            string name = "test name";
            var factory = new Mock<ILoggerFactory>();
            factory.Setup(m => m.GetLogger(It.IsAny<string>())).Returns(new TestNamedLogger(name));
            var resolver = new Mock<IFactoryResolver>();
            resolver.Setup(m => m.GetFactory()).Returns(factory.Object);

            LoggerFactory.SetFactoryResolver(resolver.Object);

            NamedLoggerBase actual = (NamedLoggerBase)LoggerFactory.GetLogger(name);

            var serializer = new BinaryFormatter();
            byte[] bytes;

            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, actual);
                bytes = ms.ToArray();
            }

            NamedLoggerBase deserialized;

            using (var ms = new MemoryStream(bytes))
            {
               deserialized = (NamedLoggerBase)serializer.Deserialize(ms);
            }

            Assert.AreEqual(actual, deserialized);

        }

        [Serializable]
        private class TestNamedLogger : NamedLoggerBase, ILogger
        {

            public TestNamedLogger() : base() { }

            public TestNamedLogger(string name) : base(name) { }



            public bool IsDebugEnabled
            {
                get { throw new System.NotImplementedException(); }
            }

            public void Debug(string message)
            {
                throw new System.NotImplementedException();
            }

            public void Debug(string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Debug(System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Debug(System.Exception exception, string message)
            {
                throw new System.NotImplementedException();
            }

            public void Debug(System.Exception exception, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Debug(System.Exception exception, System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public bool IsTraceEnabled
            {
                get { throw new System.NotImplementedException(); }
            }

            public void Trace(string message)
            {
                throw new System.NotImplementedException();
            }

            public void Trace(string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Trace(System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Trace(System.Exception exception, string message)
            {
                throw new System.NotImplementedException();
            }

            public void Trace(System.Exception exception, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Trace(System.Exception exception, System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public bool IsInfoEnabled
            {
                get { throw new System.NotImplementedException(); }
            }

            public void Info(string message)
            {
                throw new System.NotImplementedException();
            }

            public void Info(string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Info(System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Info(System.Exception exception, string message)
            {
                throw new System.NotImplementedException();
            }

            public void Info(System.Exception exception, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Info(System.Exception exception, System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public bool IsWarnEnabled
            {
                get { throw new System.NotImplementedException(); }
            }

            public void Warn(string message)
            {
                throw new System.NotImplementedException();
            }

            public void Warn(string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Warn(System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Warn(System.Exception exception, string message)
            {
                throw new System.NotImplementedException();
            }

            public void Warn(System.Exception exception, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Warn(System.Exception exception, System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public bool IsErrorEnabled
            {
                get { throw new System.NotImplementedException(); }
            }

            public void Error(string message)
            {
                throw new System.NotImplementedException();
            }

            public void Error(string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Error(System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Error(System.Exception exception, string message)
            {
                throw new System.NotImplementedException();
            }

            public void Error(System.Exception exception, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }

            public void Error(System.Exception exception, System.IFormatProvider provider, string format, params object[] args)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
