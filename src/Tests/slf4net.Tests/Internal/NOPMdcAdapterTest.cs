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

using NUnit.Framework;
using slf4net.Internal;

namespace slf4net.Tests.Internal
{
    [TestFixture]
    public class NOPMdcAdapterTest
    {
        private static readonly string Key = "key";
        private static readonly object Value = new object();
        private readonly NOPMdcAdapter _adapter = NOPMdcAdapter.Instance;

        [Test]
        public void Get()
        {
            Assert.IsNull(_adapter.Get(Key));
            Assert.IsNull(_adapter.Get(null));
        }

        [Test]
        public void Set()
        {
            _adapter.Set(Key, Value);
            _adapter.Set(null, null);
        }

        [Test]
        public void Remove()
        {
            _adapter.Remove(Key);
            _adapter.Remove(null);
        }

        [Test]
        public void Clear()
        {
            _adapter.Clear();
        }

        [Test]
        public void LogicalGet()
        {
            Assert.IsNull(_adapter.LogicalGet(Key));
            Assert.IsNull(_adapter.LogicalGet(null));
        }

        [Test]
        public void LogicalSet()
        {
            _adapter.LogicalSet(Key, Value);
            _adapter.LogicalSet(null, null);
        }

        [Test]
        public void LogicalRemove()
        {
            _adapter.LogicalRemove(Key);
            _adapter.LogicalRemove(null);
        }

        [Test]
        public void LogicalClear()
        {
            _adapter.LogicalClear();
        }

        [Test]
        public void GlobalGet()
        {
            Assert.IsNull(_adapter.GlobalGet(Key));
            Assert.IsNull(_adapter.GlobalGet(null));
        }

        [Test]
        public void GlobalSet()
        {
            _adapter.GlobalSet(Key, Value);
            _adapter.GlobalSet(null, null);
        }

        [Test]
        public void GlobalRemove()
        {
            _adapter.GlobalRemove(Key);
            _adapter.GlobalRemove(null);
        }

        [Test]
        public void GlobalClear()
        {
            _adapter.GlobalClear();
        }
    }
}