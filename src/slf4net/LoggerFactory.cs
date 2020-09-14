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
using slf4net.Internal;
using slf4net.Resolvers;

namespace slf4net
{
    /// <summary>
    /// Provides a global repository that provides access to <see cref="ILogger"/>
    /// instances. This class ensures that both the <see cref="GetLogger(Type)"/>
    /// and <see cref="GetLogger(string)"/> methods always return a valid
    /// <see cref="ILogger"/> instance - if no matching logger can be resolved,
    /// the service automatically falls back to a <see cref="NOPLogger"/> instance.
    /// </summary>
    public static class LoggerFactory
    {
        /// <summary>
        /// LoggerFactory initialization states
        /// </summary>
        private enum InitializationState
        {
            /// <summary>
            /// Logger factory is not initialized
            /// </summary>
            Uninitialized = 0,

            /// <summary>
            /// Initialization is currently ongoing
            /// </summary>
            Ongoing = 1,

            /// <summary>
            /// Initialization failed
            /// </summary>
            Failed = 2,

            /// <summary>
            /// Initialization succeeded
            /// </summary>
            Initialized = 3,

            /// <summary>
            /// Fell back to a No Operation factory
            /// </summary>
            NOP_Fallback = 4,
        }

        /// <summary>
        /// The current initialization state
        /// </summary>
        private static InitializationState _initializationState = InitializationState.Uninitialized;

        /// <summary>
        /// A temporary factory that can be used during initialization
        /// </summary>
        private static SubstituteServiceProvider _tempProvider = new SubstituteServiceProvider();

        /// <summary>
        /// A fallback factory used when initialization fails
        /// </summary>
        private static readonly NOPSlf4netServiceProvider FallbackProvider = NOPSlf4netServiceProvider.Instance;

        /// <summary>
        /// Lock object
        /// </summary>
        private static readonly object Locker = new object();

        /// <summary>
        /// Provides access to the logger factory
        /// </summary>
        private static ISlf4netServiceProvider _provider;

        /// <summary>
        /// Resolver to get the slf4net service provider
        /// </summary>
        private static ISlf4netServiceProviderResolver _resolver;


        #region Public Methods

        /// <summary>
        /// Sets the factory resolver used to get the <see cref="ILoggerFactory"/>
        /// </summary>
        /// <param name="resolver">The resolver to use.  If null is passed, the <see cref="NOPLoggerFactoryResolver"/> will be used.</param>
        public static void SetFactoryResolver(IFactoryResolver resolver)
        {
            if (!(resolver is ISlf4netServiceProviderResolver providerResolver))
            {
                providerResolver = resolver == null ? null : new LegacyServiceProviderResolver(resolver);
            }

            SetServiceProviderResolver(providerResolver);
        }

        /// <summary>
        /// Sets the slf4net service provider resolver used to get the <see cref="ISlf4netServiceProvider"/>
        /// </summary>
        /// <param name="resolver">The resolver to use.  If null is passed, the <see cref="NOPLoggerFactoryResolver"/> will be used.</param>
        public static void SetServiceProviderResolver(ISlf4netServiceProviderResolver resolver)
        {
            lock (Locker)
            {
                _initializationState = InitializationState.Uninitialized;
                _resolver = resolver ?? NOPLoggerFactoryResolver.Instance;
            }
        }

        /// <summary>
        /// Discards customizations and resets the configured logger
        /// facilities to their defaults.
        /// </summary>
        public static void Reset()
        {
            lock (Locker)
            {
                _initializationState = InitializationState.Uninitialized;
                _tempProvider = new SubstituteServiceProvider();
                _resolver = null;
                _provider = null;
            }
        }

        /// <summary>
        /// Returns a logger named according to the name parameter using the <see cref="IFactoryResolver"/>.
        /// </summary>
        /// <param name="name">The name of the logger</param>
        /// <returns>logger</returns>
        public static ILogger GetLogger(string name)
        {
            var factory = GetILoggerFactory();
            return factory.GetLogger(name);
        }

        /// <summary>
        /// Returns a logger named according to the type parameter using the <see cref="IFactoryResolver"/>.
        /// </summary>
        /// <param name="type">The type of the logger</param>
        /// <returns>logger</returns>
        public static ILogger GetLogger(Type type)
        {
            Ensure.ArgumentNotNull(type, "type");
            return GetLogger(type.FullName);
        }

        /// <summary>
        /// Returns the <see cref="ILoggerFactory"/> instance in use.
        /// </summary>
        public static ILoggerFactory GetILoggerFactory()
        {
            return GetProvider().GetLoggerFactory();
        }

        #endregion

        #region Non-Public Methods

        internal static ISlf4netServiceProvider GetProvider()
        {
            if (_initializationState == InitializationState.Uninitialized)
            {
                lock (Locker)
                {
                    if (_initializationState == InitializationState.Uninitialized)
                    {
                        _initializationState = InitializationState.Ongoing;
                        PerformInitialization();
                    }
                }
            }

            switch (_initializationState)
            {
                case InitializationState.Initialized:
                    return _provider;

                case InitializationState.NOP_Fallback:
                    return FallbackProvider;

                case InitializationState.Ongoing:
                    return _tempProvider;

                case InitializationState.Failed:
                    // Not currently used, safer to use fallback instance
                    throw new InvalidOperationException(
                        "The slf4net LoggerFactory failed to initialize.  Check the event log for details.");

                default:
                    // Should never reach this code...
                    throw new InvalidOperationException(
                        $"_initializationState {_initializationState} is not recognized.");
            }
        }

        private static void PerformInitialization()
        {
            try
            {
                var resolver = _resolver ?? new AppConfigFactoryResolver();
                var provider = resolver.GetProvider();

                if (provider == null)
                {
                    _initializationState = InitializationState.NOP_Fallback;
                    EmitFactoryResolverError(resolver);
                    return;
                }

                _provider = provider;
                _initializationState = InitializationState.Initialized;
                EmitSubstituteLoggerWarning();
            }
            catch (Exception ex)
            {
                _initializationState = InitializationState.NOP_Fallback;

                try
                {
                    ConsoleHelper.WriteLine(
                        "Error initializing LoggerFactory.  Defaulting to no-operation (NOP) logger implementation.",
                        ex);
                }
                catch
                {
                    // Squash
                }
            }
        }

        private static void EmitFactoryResolverError(ISlf4netServiceProviderResolver resolver)
        {
            var msg = "The factory resolver " + resolver.GetType().Name
                                              + " returned null from GetProvider().  The fallback no operation logger factory will be used instead.";

            ConsoleHelper.WriteLine(msg);
        }

        private static void EmitSubstituteLoggerWarning()
        {
            var loggerNameList = _tempProvider.GetLoggerFactory().GetLoggerNameList();

            if (loggerNameList.Length == 0)
            {
                return;
            }

            var msg =
                "The following loggers will not work because the were created during the default configuration phase of the underlying logging system: "
                + string.Join(", ", loggerNameList);

            ConsoleHelper.WriteLine(msg);
        }

        #endregion
    }
}