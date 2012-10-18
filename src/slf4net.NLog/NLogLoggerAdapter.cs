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


using System;
using NLog;

namespace slf4net.NLog
{
    /// <summary>
    /// An implementation of the <see cref="ILogger"/>
    /// interface which logs messages via the NLog
    /// framework.
    /// </summary>
    [Serializable]
    public class NLogLoggerAdapter : NamedLoggerBase, ILogger
    {
        /// <summary>
        /// The NLog logger which this class wraps.
        /// </summary>
        private Logger _logger;
        private Type _wrapperType;

        #region Consturctors

        /// <summary>
        /// Constructs an instance of <see cref="NLogLoggerAdapter"/>
        /// by wrapping a NLog logger
        /// </summary>
        /// <param name="logger">The NLog logger to wrap</param>
        internal NLogLoggerAdapter(Logger logger)
        {
            _logger = logger;
            _wrapperType = this.GetType();
            this.Name = logger.Name;
        }

        #endregion

        #region Debug

        public bool IsDebugEnabled { get { return _logger.IsDebugEnabled; } }

        /// <summary>
        /// Logs a message at the DEBUG level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Debug(string message)
        {
            this.Log(LogLevel.Debug, message, null);
        }

        /// <summary>
        /// Logs a message at the DEBUG level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Debug(string format, params object[] args)
        {
            this.Log(LogLevel.Debug, null, format, args, null);
        }

        /// <summary>
        /// Logs a message at the DEBUG level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Debug(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Debug, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the DEBUG level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Debug(Exception exception, string message)
        {
            this.Log(LogLevel.Debug, message, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the DEBUG level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Debug(Exception exception, string format, params object[] args)
        {
            this.Log(LogLevel.Debug, null, format, args, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the DEBUG level
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Debug(Exception exception, IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Debug, provider, format, args, exception);
        }

        #endregion

        #region Trace

        public bool IsTraceEnabled { get { return _logger.IsTraceEnabled; } }

        /// <summary>
        /// Logs a message at the TRACE level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Trace(string message)
        {
            this.Log(LogLevel.Trace, message, null);
        }

        /// <summary>
        /// Logs a message at the TRACE level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Trace(string format, params object[] args)
        {
            this.Log(LogLevel.Trace, null, format, args, null);
        }

        /// <summary>
        /// Logs a message at the TRACE level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Trace(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Trace, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the TRACE level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Trace(Exception exception, string message)
        {
            this.Log(LogLevel.Trace, message, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the TRACE level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Trace(Exception exception, string format, params object[] args)
        {
            this.Log(LogLevel.Trace, null, format, args, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the TRACE level
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Trace(Exception exception, IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Trace, provider, format, args, exception);
        }

        #endregion

        #region Info

        public bool IsInfoEnabled { get { return _logger.IsInfoEnabled; } }

        /// <summary>
        /// Logs a message at the INFO level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Info(string message)
        {
            this.Log(LogLevel.Info, message, null);
        }

        /// <summary>
        /// Logs a message at the INFO level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Info(string format, params object[] args)
        {
            this.Log(LogLevel.Info, null, format, args, null);
        }

        /// <summary>
        /// Logs a message at the INFO level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Info(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Info, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the INFO level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Info(Exception exception, string message)
        {
            this.Log(LogLevel.Info, message, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the INFO level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Info(Exception exception, string format, params object[] args)
        {
            this.Log(LogLevel.Info, null, format, args, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the INFO level
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Info(Exception exception, IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Info, provider, format, args, exception);
        }

        #endregion

        #region Warn

        public bool IsWarnEnabled { get { return _logger.IsWarnEnabled; } }

        /// <summary>
        /// Logs a message at the WARN level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Warn(string message)
        {
            this.Log(LogLevel.Warn, message, null);
        }

        /// <summary>
        /// Logs a message at the WARN level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Warn(string format, params object[] args)
        {
            this.Log(LogLevel.Warn, null, format, args, null);
        }

        /// <summary>
        /// Logs a message at the WARN level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Warn(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Warn, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the WARN level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Warn(Exception exception, string message)
        {
            this.Log(LogLevel.Warn, message, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the WARN level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Warn(Exception exception, string format, params object[] args)
        {
            this.Log(LogLevel.Warn, null, format, args, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the WARN level
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Warn(Exception exception, IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Warn, provider, format, args, exception);
        }

        #endregion

        #region Error

        public bool IsErrorEnabled { get { return _logger.IsErrorEnabled; } }

        /// <summary>
        /// Logs a message at the ERROR level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Error(string message)
        {
            this.Log(LogLevel.Error, message, null);
        }

        /// <summary>
        /// Logs a message at the ERROR level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Error(string format, params object[] args)
        {
            this.Log(LogLevel.Error, null, format, args, null);
        }

        /// <summary>
        /// Logs a message at the ERROR level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Error(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Error, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the ERROR level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Error(Exception exception, string message)
        {
            this.Log(LogLevel.Error, message, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the ERROR level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Error(Exception exception, string format, params object[] args)
        {
            this.Log(LogLevel.Error, null, format, args, exception);
        }

        /// <summary>
        /// Logs an exception and an additional message at the ERROR level
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Error(Exception exception, IFormatProvider provider, string format, params object[] args)
        {
            this.Log(LogLevel.Error, provider, format, args, exception);
        }

        #endregion

        #region Log

        private void Log(LogLevel level, IFormatProvider provider, string format, object[] args, Exception exception)
        {
            if (_logger.IsEnabled(level))
            {
                var le = new LogEventInfo(level, this.Name, provider, format, args, exception);
                _logger.Log(_wrapperType, le);
            }
        }

        private void Log(LogLevel level, string message, Exception exception)
        {
            if (_logger.IsEnabled(level))
            {
                var le = LogEventInfo.Create(level, this.Name, message, exception);
                _logger.Log(_wrapperType, le);
            }
        }

        #endregion

    }
}
