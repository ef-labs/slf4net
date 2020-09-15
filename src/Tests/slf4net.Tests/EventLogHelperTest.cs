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
using System.Configuration;
using NUnit.Framework;
using slf4net.Internal;

namespace slf4net.Tests
{
    
    
    /// <summary>
    ///This is a test class for EventLogHelperTest and is intended
    ///to contain all EventLogHelperTest Unit Tests
    ///</summary>
    [TestFixture]
    public class EventLogHelperTest
    {
        /// <summary>
        ///A test for WriteEntry
        ///</summary>
        [Test]
        public void EventLogHelper_WriteEntry()
        {
            string message = "Test message";

            ConsoleHelper.WriteLine(message);

        }

        /// <summary>
        ///A test for WriteEntry
        ///</summary>
        [Test]
        public void EventLogHelper_WriteEntry_NoException()
        {
            string message = "Test message";
            Exception ex = null;

            ConsoleHelper.WriteLine(message, ex);

        }

        /// <summary>
        ///A test for WriteEntry
        ///</summary>
        [Test]
        public void EventLogHelper_WriteEntry_WithException()
        {
            string message = "Test message";

            try
            {
                ThrowException1();
            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteLine(message, ex);
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
