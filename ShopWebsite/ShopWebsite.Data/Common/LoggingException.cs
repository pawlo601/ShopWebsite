using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace ShopWebsite.Data.Common
{
    public class LoggingException
    {//todo delete static 1
        private static readonly Logger logger;
        private static readonly DatabaseTarget dbT;

        static LoggingException()
        {
            var config = new LoggingConfiguration();
            dbT = new DatabaseTarget();

            config.AddTarget("dataLogger", dbT);

            dbT.CommandText = Configuration.Configuration.InsertToTableExceptionLogsCommand;
            dbT.CommandType = CommandType.Text;
            dbT.ConnectionString = Configuration.Configuration.ConnectionString;
            dbT.DBProvider = Configuration.Configuration.DbProvider;

            var rule1 = new LoggingRule("*", LogLevel.Trace, dbT);
            config.LoggingRules.Add(rule1);
            LogManager.Configuration = config;

            logger = LogManager.GetLogger("dataLogger");
        }

        public static void LogException(string clas, string method, DbEntityValidationException exc)
        {
            StringBuilder st = new StringBuilder();            
            foreach (var eve in exc.EntityValidationErrors)
            {
                st.AppendFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    st.AppendFormat("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }
            LogException(clas, method, string.Empty, string.Empty, string.Empty, st.ToString(), exc);
        }

        public static void LogException(string clas, string method, string variables, string actionClass,
            string actionMethod, string msg, Exception exc)
        {
            dbT.Parameters.Clear();
            dbT.Parameters.Add(new DatabaseParameterInfo("@msg", msg));
            dbT.Parameters.Add(new DatabaseParameterInfo("@variables", variables));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_source", exc.Source));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_class", clas));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_method", method));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_message", exc.Message));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_inner_message", exc.InnerException?.Message ?? ""));
            dbT.Parameters.Add(new DatabaseParameterInfo("@action_class", actionClass));
            dbT.Parameters.Add(new DatabaseParameterInfo("@action_method", actionMethod));
            dbT.Parameters.Add(new DatabaseParameterInfo("@time", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture)));
            logger.Error("");
        }
    }
}