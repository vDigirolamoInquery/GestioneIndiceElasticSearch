using log4net;
using System;

namespace FullTextElasticSearch.Log4Net
{
    public class Logger<T>
    {
        ILog logger;
        public Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
            logger = LogManager.GetLogger(typeof(T));
        }
        public void Info(string messaggio)
        {
            logger.Info(messaggio);
        }
        public void Error(string messaggio, Exception eccezione = null)
        {
            logger.Error(messaggio, eccezione);
        }
    }
}
