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


using System.Runtime.Serialization;
using System;

namespace slf4net
{
    /// <summary>
    /// Serves as base class for named logger implementations providing serialization capabilities.
    /// </summary>
    [Serializable]
    public abstract class NamedLoggerBase : ISerializable
    {

        private const string SERIALIZATION_INFO_NAME = "name";

        #region Constructors

        /// <summary>
        /// Constructs a logger instance with the given name.
        /// </summary>
        /// <param name="name">the logger name</param>
        protected NamedLoggerBase(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Constructs an un-named logger
        /// </summary>
        protected NamedLoggerBase()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// The name of this logger - typically this is written to the 
        /// log itself along with the formatted message.
        /// </summary>
        public string Name { get; protected set; }

        #endregion

        #region ISerializable

        /// <summary>
        /// Sets the object data into the serialization info using an IObjectReference serialization helper class
        /// </summary>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(NamedLoggerSerializationHelper));
            info.AddValue(SERIALIZATION_INFO_NAME, this.Name);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this.GetObjectData(info, context);
        }

        [Serializable]
        private class NamedLoggerSerializationHelper : IObjectReference, ISerializable
        {

            private string _name;

            /// <summary>
            /// Deserialization constructor
            /// </summary>
            protected NamedLoggerSerializationHelper(SerializationInfo info, StreamingContext context)
            {
                // Store the logger name
                _name = info.GetString(SERIALIZATION_INFO_NAME);
            }

            public object GetRealObject(StreamingContext context)
            {
                // Return the instance from the logger factory
                return LoggerFactory.GetLogger(_name);
            }


            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                // Do nothing, should not be called as the serialization helper is not serialized itself.
            }
        }

        #endregion

    }
}