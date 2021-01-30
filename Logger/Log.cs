using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace Logger
{
    public static class Log
    {
        public static ILog GetLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            return LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}
