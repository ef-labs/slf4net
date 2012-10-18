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


using System.Configuration;
using System.Xml;

namespace slf4net.Configuration
{
    /// <summary>
    /// The factory element within the application
    /// configuration.
    /// </summary>
    public class FactoryConfigurationElement : ConfigurationElement
    {

        private const string TYPE_ATTRIBUTE = "type";
        private const string FACTORY_DATA_ELEMENT = "factory-data";

        /// <summary>
        /// Gets custom factory data, if available. This is data of the factory
        /// element, that is wrapped into an element named <c>factory-data</c>.
        /// The contents of the <c>factory-data</c> element can be as simple as
        /// a literal, or a complex XML element.
        /// Defaults to null.
        /// </summary>
        /// <example>
        /// The following example shows two possible configurations - one with
        /// a literal as custom configuration data, one with XML based configuration:
        /// <code>
        /// &lt;slf>
        ///   &lt;!-- a factory configuration with literal content -->
        ///   &lt;factory name="simple">
        ///     &lt;factory-data>
        ///       simple data
        ///     &lt;/factory-data>
        ///   &lt;/factory>
        /// 
        ///   &lt;!-- a factory configuration with XML sub elements -->
        ///   &lt;factory name="complex">
        ///     &lt;factory-data>
        ///       &lt;child foo="bar">
        ///         &lt;subchild>foobar&lt;/subchild>
        ///       &lt;/child>
        ///     &lt;/factory-data>
        ///   &lt;/factory>
        /// &lt;/slf>
        /// </code>
        /// </example>
        public string FactoryData { get; set; }

        /// <summary>
        /// Indicates the <see cref="ILoggerFactory"/> factory Type
        /// </summary>
        [ConfigurationProperty(TYPE_ATTRIBUTE, IsRequired = false)]
        public string Type
        {
            get
            {
                return (string)this[TYPE_ATTRIBUTE];
            }
            set
            {
                this[TYPE_ATTRIBUTE] = value;
            }
        }


        /// <summary>
        /// Parses custom factory data into the <see cref="FactoryData"/> property,
        /// if <paramref name="elementName"/> refers to a <c>factory-data</c> element.
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="reader"></param>
        /// <returns>True if the element is a (supported) <c>factory-data</c> element.
        /// If it's an other unexpected element, this method returns false.</returns>
        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
        {
            if (elementName != FACTORY_DATA_ELEMENT)
            {
                //we really don't know that element - delegate to base class (just returns false)
                return base.OnDeserializeUnrecognizedElement(elementName, reader);
            }

            //parse the contents of the element
            //(the string does not contain the "factory-data" element markup)
            FactoryData = reader.ReadInnerXml().Trim();
            return true;
        }
    }
}
