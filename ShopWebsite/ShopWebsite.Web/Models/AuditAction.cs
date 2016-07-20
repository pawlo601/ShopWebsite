using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
using ShopWebsite.Data.Services.Interfaces.Audit;
using ShopWebsite.Model.Entities;
using ShopWebsite.Model.Entities.Audit;
using Action = ShopWebsite.Model.Entities.Audit.Action;

namespace ShopWebsite.Web.Models
{
    public class AuditAction
    {
        private IAuditService AuditService { get; set; }

        public AuditAction(IAuditService auditService)
        {
            AuditService = auditService;
        }

        public void Report(HttpContextBase httpContextBase, int level, Action action, 
            string propertyname, string additionalInformation)
        {
            HttpRequestBase request = httpContextBase.Request;
            string sessionIdentifier = string.Join("",
                MD5.Create()
                    .ComputeHash(Encoding.ASCII.GetBytes(request.Cookies[FormsAuthentication.FormsCookieName].Value))
                    .Select(s => s.ToString("x2")));

            Audit audit = new Audit()
            {
                UserName = (request.IsAuthenticated) ? httpContextBase.User.Identity.Name : "Anonymous",
                Data = SerializeRequest(request, level),
                AdditionalInformation = additionalInformation,
                AddressIP = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                URLAccessed = request.RawUrl,
                TimeAccessed = DateTime.UtcNow,
                SessionId = sessionIdentifier,
                PropertyName = propertyname,
                Action = action
            };
            TransactionalInformation tr;
            AuditService.AddNewAudit(audit, out tr);
        }

        private string SerializeRequest(HttpRequestBase request, int level)
        {
            switch (level)
            {
                default:
                    return "";
                case 1:
                    return JsonConvert.SerializeObject(new { request.Cookies });
                case 2:
                    return JsonConvert.SerializeObject(new { request.Cookies, request.Headers, request.Files });
                case 3:
                    return JsonConvert.SerializeObject(new { request.Cookies, request.Headers, request.Files, request.Form, request.QueryString, request.Params });
            }
        }
    }
}