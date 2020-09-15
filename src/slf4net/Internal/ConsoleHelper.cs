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
using System.Diagnostics;
using System.Text;

namespace slf4net.Internal
{
    /// <summary>
    /// Console helper class
    /// </summary>
    public static class ConsoleHelper
    {

        /// <summary>
        /// Writes details to console out (or error if there's an exception) 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void WriteLine(string message, Exception ex = null)
        {
            var sb = new StringBuilder()
                .Append("slf4net: ")
                .Append(message);

            try
            {
                WriteAppDomainInfo(sb);
                WriteExceptionInfo(ex, sb);
            }
            catch
            {
                // ignored
            }

            message = sb.ToString();
            Debug.WriteLine(message);

            if (ex == null)
            {
                Console.Out.WriteLine(message);
            }
            else
            {
                Console.Error.WriteLine(message);
            }
        }

        private static void WriteAppDomainInfo(StringBuilder sb)
        {
            var ad = AppDomain.CurrentDomain;

            if (ad == null)
            {
                return;
            }

            sb.AppendLine()
                    .AppendLine()
                    .Append("Application information:")
                    .AppendLine()
                    .AppendFormat("    Application domain: {0}", ad.FriendlyName)
                    .AppendLine()
                    .AppendFormat("    Application path: {0}", ad.BaseDirectory)
                    .AppendLine()
                    .AppendFormat("    Machine name: {0}", Environment.MachineName);

        }

        private static void WriteExceptionInfo(Exception ex, StringBuilder sb)
        {

            while (ex != null)
            {
                sb.AppendLine()
                    .AppendLine()
                    .Append("Exception information:")
                    .AppendLine()
                    .AppendFormat("    Exception type: {0}", ex.GetType().Name)
                    .AppendLine()
                    .AppendFormat("    Exception message: {0}", ex.Message)
                    .AppendLine()
                    .AppendLine()
                    .Append(ex.StackTrace);

                ex = ex.InnerException;
            }

        }

    }
}
