using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyPazarArdaEren.Areas.AdminPanel.Controllers
{
    public class ErrorController : Controller
    {
        // GET: AdminPanel/Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthorizationError()
        {
            return View();
        }
    }
}