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
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace slf4net.Tests
{
    /// <summary>
    /// A class that performs exploratory tests on classes  
    /// </summary>
    public static class ExploratoryTester
    {
        /// <summary>
        /// Performs exploratory testing on an ILogger instance. This
        /// test for robustness against null values being passed for
        /// all method arguments
        /// </summary>
        /// <param name="logger"></param>
        /// <returns>A list of failures</returns>
        public static List<string> TestILogger(ILogger logger)
        {
            List<string> failures = new List<string>();

            // obtain all the methods
            Type iLoggerType = typeof(ILogger);
            MethodInfo[] methods = iLoggerType.GetMethods();

            foreach (MethodInfo method in methods)
            {
                // skip the Log method, it does not accept null (should it?)
                if (method.Name == "Log")
                    continue;

                string result = TestILoggerMethod(logger, method);
                if (result != null)
                {
                    failures.Add(result);
                }
            }

            return failures;
        }

        /// <summary>
        /// Creates an argument list suitabel for invocation of the 
        /// given ILogger method
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static List<object> CreateArgumentList(MethodInfo method)
        {
            // construct a null argument list
            List<object> argumentList = new List<object>();
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                // currenlty the xxxFormat methods delegate to String.Format
                // for formatting. This method will throw an exception if either
                // the format string or argument list is null. Therefore, we 
                // ensure that this does not happen here.
                if (parameter.Name == "format")
                {
                    argumentList.Add("");
                }
                else if (parameter.Name == "args")
                {
                    argumentList.Add(new object[] {""});
                }
                else
                {
                    argumentList.Add(null);
                }
            }

            return argumentList;
        }

        /// <summary>
        /// Tests an individual ILogger method
        /// </summary>
        /// <returns>Details of the failure - if one occured.
        /// Or null otherwise</returns>
        private static string TestILoggerMethod(ILogger logger, MethodInfo method)
        {
            List<object> argumentList = CreateArgumentList(method);

            // invoke the method and ensure that it does not throw an expcetion.
            try
            {
                Debug.WriteLine("Invoking method: " + method.ToString());
                method.Invoke(logger, argumentList.ToArray());
            }
            catch (Exception e)
            {
                return string.Format("The method {0} failed with exception {1}",
                    method, e.InnerException);
            }

            return null;
        }
    }
}