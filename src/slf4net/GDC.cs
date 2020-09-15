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

namespace slf4net
{
    /// <summary>
    /// A facade for the underlying logging framework's Global Diagnostic Context implementation.
    /// </summary>
    public static class GDC
    {
        /// <summary>
        /// Get the diagnostic context identified by the key parameter from the global diagnostic context map.
        /// </summary>
        /// <param name="key">The property key</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return MDC.GetMdcAdapter().GlobalGet(key);
        }

        /// <summary>
        /// Set a diagnostic context value (the val parameter) as identified with the key parameter into the global diagnostic context map.
        /// </summary>
        /// <param name="key">The property key</param>
        /// <param name="value">The property value</param>
        public static void Set(string key, object value)
        {
            MDC.GetMdcAdapter().GlobalSet(key, value);
        }

        /// <summary>
        /// Remove the diagnostic context identified by the key parameter from the global diagnostic context map.
        /// </summary>
        /// <param name="key">The property key</param>
        public static void Remove(string key)
        {
            MDC.GetMdcAdapter().GlobalRemove(key);
        }

        /// <summary>
        /// Clear all entries in the global diagnostic context map.
        /// </summary>
        public static void Clear()
        {
            MDC.GetMdcAdapter().GlobalClear();
        }
    }
}