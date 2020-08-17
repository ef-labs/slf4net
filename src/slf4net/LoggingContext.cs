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


using System.Collections.Concurrent;
using System.Collections.Generic;
#if NETSTANDARD
using System.Threading;
#else
using System.Runtime.Remoting.Messaging;
#endif

namespace slf4net
{
    /// <summary>
    /// A no operation implementation of the <see cref="ILoggingContext"/>
    /// interface, which doesn't log anything. Use this implementation
    /// in order not to have to check for null references when
    /// using an <see cref="ILoggingContext"/>.<br/>
    /// This logger context implementation is a Singleton. You can get the singleton
    /// instance through the <see cref="Instance"/> property.
    /// </summary>

    public class LoggingContext : ILoggingContext
    {
#if NETSTANDARD
        private static readonly AsyncLocal<ConcurrentDictionary<string, string>> _propertiesAsyncLocal = new AsyncLocal<ConcurrentDictionary<string, string>>();
#else
        private const string LoggingContextCallContextKey = "slf4net_logging_context";
#endif
        private readonly object _lock = new object();

        #region Singleton

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static readonly LoggingContext Instance = new LoggingContext();
        
        /// <summary>
        /// Private constructor. A reference to the Singleton
        /// instance of this class is available through the
        /// static <see cref="Instance"/> property.
        /// </summary>
        private LoggingContext()
        {
        }

        #endregion
        
        #region IThreadContext Implementation
        
        /// <inheritdoc />
        public string GetProperty(string key)
        {
            return GetOrCreateProperties().TryGetValue(key, out string val) ? val : null;
        }
        
        /// <inheritdoc />
        public void AddProperty(string key, string value)
        {
            // Reason for cloning the dictionary below: object instances set on the CallContext
            // need to be immutable to correctly flow through async/await
            var cloneProperties = new ConcurrentDictionary<string, string>(GetOrCreateProperties());
            cloneProperties[key] = value;
            SetProperties(cloneProperties);
        }

        /// <inheritdoc />
        public void RemoveProperty(string key)
        {
            // Reason for cloning the dictionary below: object instances set on the CallContext
            // need to be immutable to correctly flow through async/await
            var cloneProperties = new ConcurrentDictionary<string, string>(GetOrCreateProperties());
            cloneProperties.TryRemove(key, out _);
            SetProperties(cloneProperties);
        }

        /// <inheritdoc />
        public IEnumerable<KeyValuePair<string, string>> GetProperties()
        {
            foreach (var keyValue in GetOrCreateProperties())
            {
                yield return keyValue;
            }
        }
        
        #endregion
        
        #region Private Methods

        private ConcurrentDictionary<string, string> GetOrCreateProperties()
        {
#if NETSTANDARD
            var properties = _propertiesAsyncLocal.Value;
#else
            var properties = CallContext.LogicalGetData(LoggingContextCallContextKey) as ConcurrentDictionary<string, string>;
#endif
            if (properties == null)
            {
                lock (_lock)
                {
#if NETSTANDARD
                    properties = _propertiesAsyncLocal.Value;
#else
                    properties = CallContext.LogicalGetData(LoggingContextCallContextKey) as ConcurrentDictionary<string, string>;
#endif
                    if (properties == null)
                    {
                        properties = new ConcurrentDictionary<string, string>();
#if NETSTANDARD
                        _propertiesAsyncLocal.Value = properties;
#else
                        CallContext.LogicalSetData(LoggingContextCallContextKey, properties);
#endif
                    }
                }
            }
            return properties;
        }

        private void SetProperties(ConcurrentDictionary<string, string> properties)
        {
#if NETSTANDARD
            _propertiesAsyncLocal.Value = properties;
#else
            CallContext.LogicalSetData(LoggingContextCallContextKey, properties);
#endif
        }
        
        #endregion
    }
}