using System.Collections;
using System.IO;
using System.Xml;
using log4net.Repository;

namespace slf4net.log4net.Internal
{
    /// <summary>
    /// Wrapper for slf4net XmlConfigurator
    /// </summary>
    public interface IXmlConfigurator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        ICollection Configure(ILoggerRepository repository);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        ICollection Configure(ILoggerRepository repository, XmlElement element);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="configFile"></param>
        /// <returns></returns>
        ICollection Configure(ILoggerRepository repository, FileInfo configFile);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="configFile"></param>
        /// <returns></returns>
        ICollection ConfigureAndWatch(ILoggerRepository repository, FileInfo configFile);
    }
}