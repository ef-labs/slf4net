using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using slf4net;

namespace TestLogging
{
    public class Program
    {
        private static readonly ILogger log = LoggerFactory.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            log.Info("Starting application");
            log.Debug("Testing application");
            log.Info("Stopping application");
        }
    }
}
