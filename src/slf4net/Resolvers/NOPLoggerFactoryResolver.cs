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


using slf4net.Factories;

namespace slf4net.Resolvers
{
    /// <summary>
    /// A resolver that always returns a <see cref="NOPLoggerFactory"/>,
    /// which in turn creates a <see cref="NOPLogger"/> instance.
    /// </summary>
    public class NOPLoggerFactoryResolver : IFactoryResolver
    {
        /// <summary>
        /// The logger factory instance.
        /// </summary>
        private readonly ILoggerFactory _factory = NOPLoggerFactory.Instance;

        #region Singleton

        /// <summary>
        /// Singleton instance.
        /// </summary>
        private static readonly NOPLoggerFactoryResolver _instance = new NOPLoggerFactoryResolver();

        /// <summary>
        /// Provides access to the singleton instance of
        /// the class.
        /// </summary>
        public static NOPLoggerFactoryResolver Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Private constructor. A reference to the Singleton
        /// instance of this class is available through the
        /// static <see cref="Instance"/> property.
        /// </summary>
        private NOPLoggerFactoryResolver()
        {
        }

        #endregion

        #region IFactoryResolver Implementation

        /// <summary>
        /// Determines a factory which cab create an
        /// <see cref="ILogger"/> instance based on a
        /// request for a named logger.
        /// </summary>
        /// <returns>A factory which in turn is responsible for creating
        /// a given <see cref="ILogger"/> implementation.</returns>
        public ILoggerFactory GetFactory()
        {
            return _factory;
        }

        #endregion

    }
}
