using System;
using System.Data.Entity.Validation;
using ShopWebsite.Data.Common;
using ShopWebsite.Data.Services.Interfaces.Log;

namespace ShopWebsite.Data.Services.Implementations.Log
{
    public class LogService : ILogService
    {
        public void LogException(string clas, string method, DbEntityValidationException exc)
        {
            LoggingException.LogException(clas, method, exc);
        }

        void ILogService.LogException(string clas, string method, string variables, string actionClass, string actionMethod, string msg,
            Exception exc)
        {
            LoggingException.LogException(clas, method, variables, actionClass, actionMethod, msg, exc);
        }
    }
}