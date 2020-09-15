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

using log4net;

namespace slf4net.log4net
{
    /// <summary>
    /// The log4net implementation of <see cref="IMdcAdapter"/>
    /// </summary>
    public class Log4netMdcAdapter : IMdcAdapter
    {
        /// <inheritdoc />
        public object Get(string key)
        {
            return ThreadContext.Properties[key];
        }

        /// <inheritdoc />
        public void Set(string key, object value)
        {
            ThreadContext.Properties[key] = value;
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            ThreadContext.Properties.Remove(key);
        }

        /// <inheritdoc />
        public void Clear()
        {
            ThreadContext.Properties.Clear();
        }

        /// <inheritdoc />
        public object LogicalGet(string key)
        {
            return LogicalThreadContext.Properties[key];
        }

        /// <inheritdoc />
        public void LogicalSet(string key, object value)
        {
            LogicalThreadContext.Properties[key] = value;
        }

        /// <inheritdoc />
        public void LogicalRemove(string key)
        {
            LogicalThreadContext.Properties.Remove(key);
        }

        /// <inheritdoc />
        public void LogicalClear()
        {
            LogicalThreadContext.Properties.Clear();
        }

        /// <inheritdoc />
        public object GlobalGet(string key)
        {
            return GlobalContext.Properties[key];
        }

        /// <inheritdoc />
        public void GlobalSet(string key, object value)
        {
            GlobalContext.Properties[key] = value;
        }

        /// <inheritdoc />
        public void GlobalRemove(string key)
        {
            GlobalContext.Properties.Remove(key);
        }

        /// <inheritdoc />
        public void GlobalClear()
        {
            GlobalContext.Properties.Clear();
        }
    }
}