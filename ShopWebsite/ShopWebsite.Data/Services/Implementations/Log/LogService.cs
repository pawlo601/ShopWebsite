using ShopWebsite.Data.Common;
using ShopWebsite.Data.Services.Interfaces.Log;

namespace ShopWebsite.Data.Services.Implementations.Log
{
    public class LogService : ILogService
    {
        public void Log()
        {
            LoggingException.Log();
        }
    }
}