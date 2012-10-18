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
  /// Provides common runtime validation functionality.
  /// </summary>
  internal static class Ensure
  {
    /// <summary>
    /// Makes sure a given argument is not null.
    /// </summary>
    /// <typeparam name="T">Type of the argument.</typeparam>
    /// <param name="argument">The submitted parameter value.</param>
    /// <param name="argumentName">The name of the argument.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="argument"/>
    /// is a null reference.</exception>
    public static void ArgumentNotNull<T>(T argument, string argumentName) where T : class
    {
      if (argument == null) throw new ArgumentNullException(argumentName);
    }

  }
}