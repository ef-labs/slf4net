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

namespace slf4net
{
    /// <summary>
    /// A no operation implementation of the <see cref="ILogger"/>
    /// interface, which doesn't log anything. Use this implementation
    /// in order not to have to check for null references when
    /// using an <see cref="ILogger"/>.<br/>
    /// This logger implementation is a Singleton. You can get the singleton
    /// instance through the <see cref="Instance"/> property.
    /// </summary>
    public class NOPLogger : ILogger
    {

        #region Singleton

        /// <summary>
        /// Singleton instance.
        /// </summary>
        private static readonly NOPLogger _instance = new NOPLogger();

        /// <summary>
        /// Provides access to the singleton instance of
        /// the class.
        /// </summary>
        public static NOPLogger Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Private constructor. A reference to the Singleton
        /// instance of this class is available through the
        /// static <see cref="Instance"/> property.
        /// </summary>
        private NOPLogger()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Always returns "NOP".
        /// </summary>
        public string Name
        {
            get { return "NOP"; }
        }

        #endregion

        #region Debug

        /// <summary>
        /// Is the logger instance enabled for the DEBUG level?
        /// </summary>
        public bool IsDebugEnabled { get { return false; } }

        /// <summary>
        /// Logs a message at the DEBUG level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Debug(string message)
        { }

        /// <summary>
        /// Logs a message at the DEBUG level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Debug(string format, params object[] args)
        { }

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
        { }

        /// <summary>
        /// Logs an exception and an additional message at the DEBUG level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Debug(Exception exception, string message)
        { }

        /// <summary>
        /// Logs an exception and an additional message at the DEBUG level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Debug(Exception exception, string format, params object[] args)
        { }

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
        { }

        #endregion

        #region Trace

        /// <summary>
        /// Is the logger instance enabled for the TRACE level?
        /// </summary>
        public bool IsTraceEnabled { get { return false; } }

        /// <summary>
        /// Logs a message at the TRACE level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Trace(string message)
        { }

        /// <summary>
        /// Logs a message at the TRACE level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Trace(string format, params object[] args)
        { }

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
        { }

        /// <summary>
        /// Logs an exception and an additional message at the TRACE level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Trace(Exception exception, string message)
        { }

        /// <summary>
        /// Logs an exception and an additional message at the TRACE level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Trace(Exception exception, string format, params object[] args)
        { }

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
        { }

        #endregion

        #region Info

        /// <summary>
        /// Is the logger instance enabled for the INFO level?
        /// </summary>
        public bool IsInfoEnabled { get { return false; } }

        /// <summary>
        /// Logs a message at the INFO level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Info(string message)
        { }

        /// <summary>
        /// Logs a message at the INFO level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Info(string format, params object[] args)
        { }

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
        { }

        /// <summary>
        /// Logs an exception and an additional message at the INFO level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Info(Exception exception, string message)
        { }

        /// <summary>
        /// Logs an exception and an additional message at the INFO level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Info(Exception exception, string format, params object[] args)
        { }

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
        { }

        #endregion

        #region Warn

        /// <summary>
        /// Is the logger instance enabled for the WARN level?
        /// </summary>
        public bool IsWarnEnabled { get { return false; } }

        /// <summary>
        /// Logs a message at the WARN level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Warn(string message)
        { }

        /// <summary>
        /// Logs a message at the WARN level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Warn(string format, params object[] args)
        { }

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
        { }

        /// <summary>
        /// Logs an exception and an additional message at the WARN level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Warn(Exception exception, string message)
        { }

        /// <summary>
        /// Logs an exception and an additional message at the WARN level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Warn(Exception exception, string format, params object[] args)
        { }

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
        { }

        #endregion

        #region Error

        /// <summary>
        /// Is the logger instance enabled for the ERROR level?
        /// </summary>
        public bool IsErrorEnabled { get { return false; } }

        /// <summary>
        /// Logs a message at the ERROR level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Error(string message)
        { }

        /// <summary>
        /// Logs a message at the ERROR level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Error(string format, params object[] args)
        { }

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
        { }

        /// <summary>
        /// Logs an exception and an additional message at the ERROR level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        public void Error(Exception exception, string message)
        { }

        /// <summary>
        /// Logs an exception and an additional message at the ERROR level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        public void Error(Exception exception, string format, params object[] args)
        { }

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
        { }

        #endregion

    }
}