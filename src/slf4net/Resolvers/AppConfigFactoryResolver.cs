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
using slf4net.Configuration;
using slf4net.Factories;

namespace slf4net.Resolvers
{
    /// <summary>
    /// Resolves factories to be used for logger instantiation based
    /// on settings taken from the application's default configuration
    /// file (<c>App.config</c> or <c>Web.config</c>).
    /// </summary>
    public class AppConfigFactoryResolver : IFactoryResolver
    {

        /// <summary>
        /// The name of the SLF configuration section
        /// </summary>
        public const string CONFIG_SECTION_NAME = "slf4net";

        private string _sectionName;
        private ILoggerFactory _factory;

        #region Constructors

        /// <summary>
        /// Default constructor using the standard configuration section name <see cref="AppConfigFactoryResolver.CONFIG_SECTION_NAME"/>
        /// </summary>
        public AppConfigFactoryResolver() : this(CONFIG_SECTION_NAME)
        { }

        /// <summary>
        /// Constructor where a custom configuration section name is used.
        /// </summary>
        /// <param name="sectionName">The name of the configuration section</param>
        public AppConfigFactoryResolver(string sectionName)
        {
            _sectionName = sectionName;
            LoadConfiguration();
        }

        #endregion

        #region ILoggerFactory Implementation

        /// <summary>
        /// Returns the <see cref="ILoggerFactory"/> instance in use.
        /// </summary>
        /// <returns></returns>
        public ILoggerFactory GetFactory()
        {
            return _factory;
        }

        #endregion

        #region Non-Public Methods

        /// <summary>
        /// Loads the resolver configuration from the application's config file.
        /// </summary>
        protected virtual void LoadConfiguration()
        {
            object configSection = ConfigurationManager.GetSection(_sectionName);

            // Return if no section exists
            if (configSection == null)
            {
                return;
            }

            _factory = ReadConfiguration(configSection as SlfConfigurationSection);
        }

        /// <summary>
        /// Reads the <see cref="SlfConfigurationSection"/> and instantiates the ILoggerFactory defined in configuration.
        /// </summary>
        /// <param name="configSection"></param>
        protected virtual ILoggerFactory ReadConfiguration(SlfConfigurationSection configSection)
        {
            // Throw exception if section is not a SlfConfigurationSection
            if (configSection == null)
            {
                var msg = string.Format("Configuration section named {0} must be type {1}.", _sectionName, typeof(SlfConfigurationSection).FullName);
                throw new ConfigurationErrorsException(msg);
            }

            // Construct the factory
            return CreateFactoryInstance(configSection.Factory);
        }

        /// <summary>
        /// Creates a factory based on a given configuration.
        /// If the factory provides invalid information, an error is logged through
        /// the internal logger, and a <see cref="NOPLoggerFactory"/> returned.
        /// </summary>
        /// <param name="factoryConfiguration">The configuration that provides type
        /// information for the <see cref="ILoggerFactory"/> that is being created.</param>
        /// <returns>Factory instance.</returns>
        private ILoggerFactory CreateFactoryInstance(FactoryConfigurationElement factoryConfiguration)
        {
            ILoggerFactory factory = ActivatorUtils.Instantiate<ILoggerFactory>(factoryConfiguration.Type);
            IConfigurableLoggerFactory cf = factory as IConfigurableLoggerFactory;

            // If the factory is configurable, invoke its Init method
            if (cf != null)
            {
                cf.Init(factoryConfiguration.FactoryData);
            }
            else
            {
                if (!string.IsNullOrEmpty(factoryConfiguration.FactoryData))
                {
                    throw new ConfigurationErrorsException("Factory " + factoryConfiguration.Type + " does not implement IConfigurableLoggerFactory.");
                }
            }

            return factory;
        }

        #endregion

    }
}