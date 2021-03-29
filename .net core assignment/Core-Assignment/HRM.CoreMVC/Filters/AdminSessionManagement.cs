using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.CoreMVC.Filters
{
    /// <summary>
    /// Manage admin session to restrict authorized view to show
    /// </summary>
    public class AdminSessionManagement : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("user") == null)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Login");
                redirectTargetDictionary.Add("controller", "Authentication");
                redirectTargetDictionary.Add("area", "");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
