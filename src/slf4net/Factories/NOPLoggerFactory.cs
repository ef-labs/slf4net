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


namespace slf4net.Factories
{
    /// <summary>
    /// A no operation implementation of the <see cref="ILoggerFactory"/>
    /// which simply returns a <see cref="NOPLogger"/> instance.
    /// </summary>
    public class NOPLoggerFactory : ILoggerFactory
    {

        #region Singleton

        /// <summary>
        /// Singleton instance.
        /// </summary>
        private static readonly NOPLoggerFactory _instance = new NOPLoggerFactory();

        /// <summary>
        /// Provides access to the singleton instance of
        /// the class.
        /// </summary>
        public static NOPLoggerFactory Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Private constructor. A reference to the Singleton
        /// instance of this class is available through the
        /// static <see cref="Instance"/> property.
        /// </summary>
        private NOPLoggerFactory()
        {
        }

        #endregion

        #region ILoggerFactory Implementation

        /// <summary>
        /// Obtains an <see cref="ILogger"/> instance that is identified by
        /// the given name.
        /// </summary>
        /// <param name="name">The logger name.</param>
        /// <returns>An <see cref="ILogger"/> instance</returns>
        public ILogger GetLogger(string name)
        {
            return NOPLogger.Instance;
        }

        #endregion

    }
}