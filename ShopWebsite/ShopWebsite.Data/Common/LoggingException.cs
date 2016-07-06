using System;
using System.Data;
using System.Globalization;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace ShopWebsite.Data.Common
{
    public class LoggingException
    {
        private static readonly Logger logger;

        static LoggingException()
        {
            var config = new LoggingConfiguration();
            var dbT = new DatabaseTarget();

            config.AddTarget("datal", dbT);

            dbT.CommandText =
                @"INSERT INTO [dbo].[LogEntries](TimeStamp, Message, Level, Variables, ErrorSource, ErrorClass, ErrorMethod, ErrorMessage, ErrorInnerMessage, ActionClass, ActionMethod) VALUES(@time, @msg, @level, @variables, @error_source, @error_class, @error_method, @error_message, @error_inner_message, @action_class, @action_method)";
            dbT.CommandType = CommandType.Text;
            dbT.ConnectionString = Configuration.Configuration.ConnectionString;
            dbT.DBProvider = @"System.Data.SqlClient";

            dbT.Parameters.Add(new DatabaseParameterInfo("@msg", "m11"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@level", "m12"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@variables", "m13"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_source", "m14"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_class", "m15"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_method", "m16"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_message", "m17"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@error_inner_message", "m18"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@action_class", "m19"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@action_method", "m110"));
            dbT.Parameters.Add(new DatabaseParameterInfo("@time", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture)));

            var rule1 = new LoggingRule("*", LogLevel.Debug, dbT);
            config.LoggingRules.Add(rule1);
            LogManager.Configuration = config;

            logger = LogManager.GetLogger("datal");
        }

        public static Logger GetLogger()
        {
            return logger;
        }

        public static void Log()
        {
            
        }
    }
}