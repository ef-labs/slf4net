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
using log4net;
using log4net.Core;
using log4net.Util;

namespace slf4net.log4net
{
    /// <summary>
    /// An implementation of the <see cref="ILogger"/>
    /// interface which logs messages via the log4net
    /// framework.
    /// </summary>
    [Serializable]
    public class Log4netLoggerAdapter : NamedLoggerBase, ILogger
    {
        /// <summary>
        /// The log4net logger which this class wraps.
        /// </summary>
        private readonly ILog _logger;
        /// <summary>
        /// The logger wrapper type
        /// </summary>
        private readonly Type _callerStackBoundaryDeclaringType;

        #region Constructors

        /// <summary>
        /// Constructs an instance of <see cref="Log4netLoggerAdapter"/>
        /// by wrapping a log4net logger
        /// </summary>
        /// <param name="logger">The log4net logger to wrap</param>
        internal Log4netLoggerAdapter(ILog logger)
        {
            _logger = logger;
            _callerStackBoundaryDeclaringType = this.GetType();
            this.Name = logger.Logger.Name;
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
            this.Log(Level.Debug, message, null);
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
            this.Log(Level.Debug, null, format, args, null);
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
            this.Log(Level.Debug, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the DEBUG level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Debug(Exception exception, string message)
        {
            this.Log(Level.Debug, message, exception);
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
            this.Log(Level.Debug, null, format, args, exception);
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
            this.Log(Level.Debug, provider, format, args, exception);
        }

        #endregion

        #region Trace

        public bool IsTraceEnabled { get { return _logger.Logger.IsEnabledFor(Level.Trace); } }

        /// <summary>
        /// Logs a message at the TRACE level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Trace(string message)
        {
            this.Log(Level.Trace, message, null);
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
            this.Log(Level.Trace, null, format, args, null);
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
            this.Log(Level.Trace, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the TRACE level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Trace(Exception exception, string message)
        {
            this.Log(Level.Trace, message, exception);
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
            this.Log(Level.Trace, null, format, args, exception);
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
            this.Log(Level.Trace, provider, format, args, exception);
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
            this.Log(Level.Info, message, null);
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
            this.Log(Level.Info, null, format, args, null);
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
            this.Log(Level.Info, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the INFO level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Info(Exception exception, string message)
        {
            this.Log(Level.Info, message, exception);
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
            this.Log(Level.Info, null, format, args, exception);
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
            this.Log(Level.Info, provider, format, args, exception);
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
            this.Log(Level.Warn, message, null);
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
            this.Log(Level.Warn, null, format, args, null);
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
            this.Log(Level.Warn, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the WARN level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Warn(Exception exception, string message)
        {
            this.Log(Level.Warn, message, exception);
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
            this.Log(Level.Warn, null, format, args, exception);
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
            this.Log(Level.Warn, provider, format, args, exception);
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
            this.Log(Level.Error, message, null);
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
            this.Log(Level.Error, null, format, args, null);
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
            this.Log(Level.Error, provider, format, args, null);
        }

        /// <summary>
        /// Logs an exception and an additional message at the ERROR level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Error(Exception exception, string message)
        {
            this.Log(Level.Error, message, exception);
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
            this.Log(Level.Error, null, format, args, exception);
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
            this.Log(Level.Error, provider, format, args, exception);
        }

        #endregion

        #region Log

        private void Log(Level level, IFormatProvider provider, string format, object[] args, Exception exception)
        {
            // Skip if logging is disabled for this level to avoid creating a SystemStringFormat unecessarily
            if (_logger.Logger.IsEnabledFor(level))
            {
                // Let log4net handle string formatting with the SystemStringFormat utility class
                Log(level, new SystemStringFormat(provider, format, args), exception);
            }
        }

        private void Log(Level level, object message, Exception exception)
        {
            // Pass the _callerStackBoundaryDeclaringType to allow correct stack trace logging
            _logger.Logger.Log(_callerStackBoundaryDeclaringType, level, message, exception);
        }

        #endregion

    }
}
