using System;
using System.Data.Entity.Validation;

namespace ShopWebsite.Data.Services.Interfaces.Log
{
    public interface ILogService
    {
        void LogException(string clas, string method, DbEntityValidationException exc);

        void LogException(string clas, string method, string variables, string actionClass,
            string actionMethod, string msg, Exception exc);
    }
}