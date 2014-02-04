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
using slf4net.Factories;
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
            /// Intialization succeeded
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
        private static SubstituteLoggerFactory _tempFactory = new SubstituteLoggerFactory();
        /// <summary>
        /// A fallback factory used when initialization fails
        /// </summary>
        private static ILoggerFactory _fallbackFactory = NOPLoggerFactory.Instance;
        /// <summary>
        /// Lock object
        /// </summary>
        private readonly static object _locker = new object();
        /// <summary>
        /// Provides access to the logger factory
        /// </summary>
        private static IFactoryResolver _factoryResolver;


        #region Public Methods

        /// <summary>
        /// Sets the factory resolver used to get the <see cref="ILoggerFactory"/>
        /// </summary>
        /// <param name="resolver">The resolver to use.  If null is passed, the <see cref="NOPLoggerFactoryResolver"/> will be used.</param>
        public static void SetFactoryResolver(IFactoryResolver resolver)
        {
            lock (_locker)
            {
                _initializationState = InitializationState.Uninitialized;
                _factoryResolver = resolver ?? NOPLoggerFactoryResolver.Instance;
            }
        }

        /// <summary>
        /// Discards customizations and resets the configured logger
        /// facilities to their defaults.
        /// </summary>
        public static void Reset()
        {
            lock (_locker)
            {
                _initializationState = InitializationState.Uninitialized;
                _tempFactory = new SubstituteLoggerFactory();
                _factoryResolver = null;
            }
        }

        /// <summary>
        /// Returns a logger named according to the name parameter using the <see cref="IFactoryResolver"/>.
        /// </summary>
        /// <param name="name">The name of the logger</param>
        /// <returns>logger</returns>
        public static ILogger GetLogger(string name)
        {
            ILoggerFactory factory = GetILoggerFactory();
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
            if (_initializationState == InitializationState.Uninitialized)
            {
                lock (_locker)
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
                    return _factoryResolver.GetFactory();

                case InitializationState.NOP_Fallback:
                    return _fallbackFactory;

                case InitializationState.Ongoing:
                    return _tempFactory;

                case InitializationState.Failed:
                    // Not currently used, safer to use fallback instance
                    throw new InvalidOperationException("The slf4net LoggerFactory failed to initialize.  Check the event log for details.");

                default:
                    // Should never reach this code...
                    throw new InvalidOperationException("_initializationState " + _initializationState + " is not recognized.");
            }
        }

        #endregion

        #region Non-Public Methods

        private static void PerformInitialization()
        {
            try
            {
                if (_factoryResolver == null)
                {
#if PocketPC
                    _factoryResolver = new XmlFactoryResolver();
#else
                    _factoryResolver = new AppConfigFactoryResolver();
#endif
                }

                var factory = _factoryResolver.GetFactory();

                if (factory == null)
                {
                    _initializationState = InitializationState.NOP_Fallback;
#if !PocketPC
                    EmitFactoryResolverError(_factoryResolver);
#endif
                    return;
                }

                _initializationState = InitializationState.Initialized;
#if !PocketPC
                EmitSubstituteLoggerWarning();
#endif

            }
#if PocketPC
            catch
#else
            catch (Exception ex)
#endif
            {
                _initializationState = InitializationState.NOP_Fallback;
#if !PocketPC
                try
                {
                    EventLogHelper.WriteEntry("Error initializing LoggerFactory.  Defaulting to no-operation (NOP) logger implementation.", ex);
                }
                catch { }
#endif
            }

        }

 #if !PocketPC       
        private static void EmitFactoryResolverError(IFactoryResolver resolver)
        {
            var msg = "The factory resolver " + resolver.GetType().Name
                + " returned null from GetFactory().  The fallback no operation logger factory will be used instead.";

            EventLogHelper.WriteEntry(msg, null);

        }

        private static void EmitSubstituteLoggerWarning()
        {
            var loggerNameList = _tempFactory.GetLoggerNameList();

            if (loggerNameList.Length == 0)
            {
                return;
            }

            var msg = "The following loggers will not work because the were created during the default configuration phase of the underlying logging system: "
                + string.Join(", ", loggerNameList);

            EventLogHelper.WriteEntry(msg, null);


        }
#endif
#endregion

    }
}
