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


using System.Collections.Generic;

namespace slf4net
{
    /// <summary>
    /// Represents a logging context
    /// </summary>
    public interface ILoggingContext
    {
        /// <summary>
        /// Gets a property
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetProperty(string key);
        
        /// <summary>
        /// Adds a property
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddProperty(string key, string value);

        /// <summary>
        /// Removes a property
        /// </summary>
        /// <param name="key"></param>
        void RemoveProperty(string key);

        /// <summary>
        /// Gets all the properties
        /// </summary>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, string>> GetProperties();
    }
}