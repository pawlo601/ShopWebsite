using System;
using log4net;

namespace ShopWebsite.Data
{
    public class Logging
    {

        private  ILog log = LogManager.GetLogger("SQLAppender");

        public Logging()
        {
            log4net.Config.XmlConfigurator.Configure();
            log = log4net.LogManager.GetLogger(typeof(Logging));
            //XmlConfigurator.Configure();
        }

        public void DoSomeLogs()
        {
            MDC.Set("inner", "qwerqwerqwer");
            Exception ex = new ArgumentNullException("1qqwerqwer3");
            log.Fatal("fqwerqwerqwerqw!", ex);
        }
    }
}