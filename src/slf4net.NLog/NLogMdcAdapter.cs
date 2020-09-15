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

using NLog;

namespace slf4net.NLog
{
    /// <summary>
    /// The NLog implementation of <see cref="IMdcAdapter"/>
    /// </summary>
    public class NLogMdcAdapter : IMdcAdapter
    {
        /// <inheritdoc />
        public object Get(string key)
        {
            return MappedDiagnosticsContext.Get(key);
        }

        /// <inheritdoc />
        public void Set(string key, object value)
        {
            MappedDiagnosticsContext.Set(key, value);
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            MappedDiagnosticsContext.Remove(key);
        }

        /// <inheritdoc />
        public void Clear()
        {
            MappedDiagnosticsContext.Clear();
        }

        /// <inheritdoc />
        public object LogicalGet(string key)
        {
            return MappedDiagnosticsLogicalContext.Get(key);
        }

        /// <inheritdoc />
        public void LogicalSet(string key, object value)
        {
            MappedDiagnosticsLogicalContext.Set(key, value);
        }

        /// <inheritdoc />
        public void LogicalRemove(string key)
        {
            MappedDiagnosticsLogicalContext.Remove(key);
        }

        /// <inheritdoc />
        public void LogicalClear()
        {
            MappedDiagnosticsLogicalContext.Clear();
        }

        /// <inheritdoc />
        public object GlobalGet(string key)
        {
            return GlobalDiagnosticsContext.Get(key);
        }

        /// <inheritdoc />
        public void GlobalSet(string key, object value)
        {
            GlobalDiagnosticsContext.Set(key, value);
        }

        /// <inheritdoc />
        public void GlobalRemove(string key)
        {
            GlobalDiagnosticsContext.Remove(key);
        }

        /// <inheritdoc />
        public void GlobalClear()
        {
            GlobalDiagnosticsContext.Clear();
        }
    }
}