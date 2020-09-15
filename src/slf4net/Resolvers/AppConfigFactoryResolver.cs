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
using slf4net.Internal;

namespace slf4net.Resolvers
{
    /// <summary>
    /// Resolves factories to be used for logger instantiation based
    /// on settings taken from the application's default configuration
    /// file (<c>App.config</c> or <c>Web.config</c>).
    /// </summary>
    public class AppConfigFactoryResolver : IFactoryResolver, ISlf4netServiceProviderResolver
    {
        /// <summary>
        /// The name of the SLF configuration section
        /// </summary>
        public const string CONFIG_SECTION_NAME = "slf4net";

        private readonly string _sectionName;
        private ISlf4netServiceProvider _provider;

        #region Constructors

        /// <summary>
        /// Default constructor using the standard configuration section name <see cref="AppConfigFactoryResolver.CONFIG_SECTION_NAME"/>
        /// </summary>
        public AppConfigFactoryResolver() : this(CONFIG_SECTION_NAME)
        {
        }

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

        #region ISlf4netServiceProviderResolver/IFactoryResolver Implementation

        /// <summary>
        /// Returns the <see cref="ISlf4netServiceProvider"/> instance to use.
        /// </summary>
        /// <returns></returns>
        public ISlf4netServiceProvider GetProvider()
        {
            return _provider;
        }

        /// <summary>
        /// Returns the <see cref="ILoggerFactory"/> instance from the slf4net service provider.
        /// </summary>
        /// <returns></returns>
        public ILoggerFactory GetFactory()
        {
            return GetProvider()?.GetLoggerFactory();
        }

        #endregion

        #region Non-Public Methods

        /// <summary>
        /// Loads the resolver configuration from the application's config file.
        /// </summary>
        protected virtual void LoadConfiguration()
        {
            var configSection = ConfigurationManager.GetSection(_sectionName);

            // Return if no section exists
            if (configSection == null)
            {
                return;
            }

            var factory = ReadConfiguration(configSection as SlfConfigurationSection);

            if (factory is ISlf4netServiceProvider provider)
            {
                _provider = provider;
            }
            else
            {
                _provider = new BasicSlf4netServiceProvider(factory, NOPMdcAdapter.Instance);
            }
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
                var msg =
                    $"Configuration section named {_sectionName} must be type {typeof(SlfConfigurationSection).FullName}.";
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
            var factory = ActivatorUtils.Instantiate<ILoggerFactory>(factoryConfiguration.Type);

            // If the factory is configurable, invoke its Init method
            if (factory is IConfigurableLoggerFactory cf)
            {
                cf.Init(factoryConfiguration.FactoryData);
            }
            else
            {
                if (!string.IsNullOrEmpty(factoryConfiguration.FactoryData))
                {
                    throw new ConfigurationErrorsException("Factory " + factoryConfiguration.Type +
                                                           " does not implement IConfigurableLoggerFactory.");
                }
            }

            return factory;
        }

        #endregion
    }
}