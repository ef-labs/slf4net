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


using log4net;
using slf4net.Factories;
using slf4net.log4net.Internal;

namespace slf4net.log4net
{
    /// <summary>
    /// An implementation of the <see cref="ILoggerFactory"/>
    /// interface which creates <see cref="ILogger"/> instances
    /// that use the log4net framework as the underlying logging
    /// mechanism.
    /// </summary>
    public class Log4netLoggerFactory : NamedLoggerFactoryBase, IConfigurableLoggerFactory, ISlf4netServiceProvider
    {
        private readonly IXmlConfigurator _configurator;
        private readonly Log4netMdcAdapter _mdcAdapter = new Log4netMdcAdapter();
        private static bool _isInitialized;
        private static readonly object Locker = new object();

        /// <summary>
        /// The slf4net repository name
        /// </summary>
        public static readonly string SLF4NET_REPOSITORY = "slf4net-repository";

        /// <summary>
        /// Default constructor
        /// </summary>
        public Log4netLoggerFactory() : this(new XmlConfiguratorWrapper())
        {
        }

        /// <summary>
        /// Injection constructor
        /// </summary>
        /// <param name="configurator"></param>
        public Log4netLoggerFactory(IXmlConfigurator configurator)
        {
            _configurator = configurator;
        }

        /// <inheritdoc />
        protected override ILogger CreateLogger(string name)
        {
            EnsureInitialized();
            var log4netLogger = LogManager.GetLogger(SLF4NET_REPOSITORY, name);
            return new Log4netLoggerAdapter(log4netLogger);
        }

        /// <inheritdoc />
        public void Init(string factoryData)
        {
            lock (Locker)
            {
                var helper = new XmlConfiguratorHelper(factoryData, _configurator);
                helper.Configure();
                _isInitialized = true;
            }
        }

        private void EnsureInitialized()
        {
            if (!_isInitialized)
            {
                lock (Locker)
                {
                    if (!_isInitialized)
                    {
                        Init(null);
                    }
                }
            }
        }

        /// <inheritdoc />
        public ILoggerFactory GetLoggerFactory()
        {
            return this;
        }

        /// <inheritdoc />
        public IMdcAdapter GetMdcAdapter()
        {
            return _mdcAdapter;
        }
    }
}