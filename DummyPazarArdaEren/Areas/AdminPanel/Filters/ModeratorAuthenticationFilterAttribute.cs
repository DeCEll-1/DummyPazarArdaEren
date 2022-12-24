using DummyPazarArdaEren.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace DummyPazarArdaEren.Areas.AdminPanel.Filters
{
    public class ModeratorAuthenticationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Manager m = (Manager)filterContext.RequestContext.HttpContext.Session["adminSession"];
            if (m.ManagerType_ID!=1)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect("~/AdminPanel/Views/Error/AuthorizationError.cshtml");
            }

            base.OnActionExecuted(filterContext);
        }
    }
}