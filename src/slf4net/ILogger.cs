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

namespace slf4net
{
    /// <summary>
    /// Common interface of an arbitrary implementation that provides
    /// logging capabilities.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Gets this logger's name.
        /// </summary>
        string Name { get; }

        #region Debug

        /// <summary>
        /// Is the logger instance enabled for the DEBUG level?
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Logs a message at the DEBUG level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Debug(string message);

        /// <summary>
        /// Logs a message at the DEBUG level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Debug(string format, params object[] args);

        /// <summary>
        /// Logs a message at the DEBUG level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Debug(IFormatProvider provider, string format, params object[] args);

        /// <summary>
        /// Logs an exception and an additional message at the DEBUG level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Debug(Exception exception, string message);

        /// <summary>
        /// Logs an exception and an additional message at the DEBUG level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Debug(Exception exception, string format, params object[] args);

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
        void Debug(Exception exception, IFormatProvider provider, string format, params object[] args);

        #endregion

        #region Trace

        /// <summary>
        /// Is the logger instance enabled for the TRACE level?
        /// </summary>
        bool IsTraceEnabled { get; }

        /// <summary>
        /// Logs a message at the TRACE level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Trace(string message);

        /// <summary>
        /// Logs a message at the TRACE level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Trace(string format, params object[] args);

        /// <summary>
        /// Logs a message at the TRACE level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Trace(IFormatProvider provider, string format, params object[] args);

        /// <summary>
        /// Logs an exception and an additional message at the TRACE level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Trace(Exception exception, string message);

        /// <summary>
        /// Logs an exception and an additional message at the TRACE level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Trace(Exception exception, string format, params object[] args);

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
        void Trace(Exception exception, IFormatProvider provider, string format, params object[] args);

        #endregion

        #region Info

        /// <summary>
        /// Is the logger instance enabled for the INFO level?
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Logs a message at the INFO level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Info(string message);

        /// <summary>
        /// Logs a message at the INFO level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Info(string format, params object[] args);

        /// <summary>
        /// Logs a message at the INFO level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Info(IFormatProvider provider, string format, params object[] args);

        /// <summary>
        /// Logs an exception and an additional message at the INFO level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Info(Exception exception, string message);

        /// <summary>
        /// Logs an exception and an additional message at the INFO level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Info(Exception exception, string format, params object[] args);

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
        void Info(Exception exception, IFormatProvider provider, string format, params object[] args);

        #endregion

        #region Warn

        /// <summary>
        /// Is the logger instance enabled for the WARN level?
        /// </summary>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Logs a message at the WARN level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Warn(string message);

        /// <summary>
        /// Logs a message at the WARN level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Warn(string format, params object[] args);

        /// <summary>
        /// Logs a message at the WARN level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Warn(IFormatProvider provider, string format, params object[] args);

        /// <summary>
        /// Logs an exception and an additional message at the WARN level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Warn(Exception exception, string message);

        /// <summary>
        /// Logs an exception and an additional message at the WARN level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Warn(Exception exception, string format, params object[] args);

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
        void Warn(Exception exception, IFormatProvider provider, string format, params object[] args);

        #endregion

        #region Error

        /// <summary>
        /// Is the logger instance enabled for the ERROR level?
        /// </summary>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Logs a message at the ERROR level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Error(string message);

        /// <summary>
        /// Logs a message at the ERROR level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Error(string format, params object[] args);

        /// <summary>
        /// Logs a message at the ERROR level according to the specified <paramref name="format"/> and <paramref name="args"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/> which provides
        /// culture-specific formatting capabilities.</param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Error(IFormatProvider provider, string format, params object[] args);

        /// <summary>
        /// Logs an exception and an additional message at the ERROR level.
        /// </summary>
        /// <param name="exception"> The exception to log.</param>
        /// <param name="message">Additional information regarding the
        /// logged exception.</param>
        void Error(Exception exception, string message);

        /// <summary>
        /// Logs an exception and an additional message at the ERROR level
        /// </summary>
        /// <param name="exception">The exception to log </param>
        /// <param name="format">A composite format string that contains placeholders for the
        /// arguments.</param>
        /// <param name="args">An <see cref="object"/> array containing zero or more objects
        /// to format.</param>
        void Error(Exception exception, string format, params object[] args);

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
        void Error(Exception exception, IFormatProvider provider, string format, params object[] args);

        #endregion

    }
}