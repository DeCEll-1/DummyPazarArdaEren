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
    public class ModeratorAuthenticationFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        DummyPazarModel db = new DummyPazarModel()
;        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["moderator"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            List<Manager> managers = db.Managers.ToList();
            foreach (var item in managers)
            {
                if (item.ManagerType_ID == )
                {

                }
            }
        }
    }
}