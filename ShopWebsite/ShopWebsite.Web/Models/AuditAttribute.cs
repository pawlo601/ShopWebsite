using System.Web;
using System.Web.Mvc;

namespace ShopWebsite.Web.Models
{
    public class AuditAttribute : ActionFilterAttribute
    {

        public int AuditingLevel { get; set; }

        public string AdditionalInformation { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpResponseBase request = filterContext.RequestContext.HttpContext.Response;

        }
    }
}