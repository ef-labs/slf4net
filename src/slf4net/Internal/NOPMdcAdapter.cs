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

namespace slf4net.Internal
{
    /// <summary>
    /// A NOP implementation of the <see cref="IMdcAdapter"/> for logging frameworks that don't implement MDC
    /// </summary>
    public class NOPMdcAdapter : IMdcAdapter
    {
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static readonly NOPMdcAdapter Instance = new NOPMdcAdapter();

        private NOPMdcAdapter()
        {
        }

        /// <inheritdoc />
        public object Get(string key)
        {
            return null;
        }

        /// <inheritdoc />
        public void Set(string key, object value)
        {
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
        }

        /// <inheritdoc />
        public void Clear()
        {
        }

        /// <inheritdoc />
        public object LogicalGet(string key)
        {
            return null;
        }

        /// <inheritdoc />
        public void LogicalSet(string key, object value)
        {
        }

        /// <inheritdoc />
        public void LogicalRemove(string key)
        {
        }

        /// <inheritdoc />
        public void LogicalClear()
        {
        }

        /// <inheritdoc />
        public object GlobalGet(string key)
        {
            return null;
        }

        /// <inheritdoc />
        public void GlobalSet(string key, object value)
        {
        }

        /// <inheritdoc />
        public void GlobalRemove(string key)
        {
        }

        /// <inheritdoc />
        public void GlobalClear()
        {
        }
    }
}