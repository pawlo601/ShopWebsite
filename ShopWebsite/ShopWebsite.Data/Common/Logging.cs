using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using log4net.Config;

namespace ShopWebsite.Data.Common
{
    public class Logging
    {
        private static readonly ILog log = LogManager.GetLogger("SQLAppender");

        public static void LogException(string message, Exception exc, DateTime time, string methodName, IList<Tuple<string, string, object>> parameters)
        {
            try
            {
                //MDC.Set("date", time.ToLongTimeString());
                //MDC.Set("method_name", methodName);
                //StringBuilder paramss = new StringBuilder();
                //foreach (Tuple<string, string, object> parameter in parameters)
                //{
                //    paramss.Append(parameter.Item1);
                //    paramss.Append(" ");
                //    paramss.Append(parameter.Item2);
                //    paramss.Append(" ");
                //    paramss.Append(parameter.Item3);
                //    paramss.Append("; ");
                //}
                //MDC.Set("method_params", paramss.ToString());
                //MDC.Set("stack_trace", exc.StackTrace);
                //MDC.Set("inner_exception", exc.InnerException?.Message ?? "null");
                //log.Error(message, exc);  
                log4net.Config.XmlConfigurator.Configure();
                Exception ex = new ArgumentNullException("1qqwerqwer3");
                log.Fatal("fqwerqwerqwerqw!", ex);
            }
            catch (Exception excc)
            {
                string a = excc.Message;
            }
        }
    }
}
