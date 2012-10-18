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
    /// Provides helper methods that supplement the 
    /// <see cref="System.Activator"/>.
    /// </summary>
    internal static class ActivatorUtils
    {
        /// <summary>
        /// Instantiates an object of the given type.
        /// </summary>
        /// <typeparam name="T">The type being instantiated</typeparam>
        /// <param name="typeName">The full type name</param>
        /// <returns></returns>
        internal static T Instantiate<T>(string typeName) where T : class
        {
            Type type = Type.GetType(typeName, throwOnError: true, ignoreCase: false);
            T obj = Activator.CreateInstance(type) as T;

            if (obj == null)
            {
                var msg = string.Format("The item [type={0}], is not of type {1}.", type, typeof(T));
                throw new InvalidCastException(msg);
            }

            return obj;
        }
    }
}
