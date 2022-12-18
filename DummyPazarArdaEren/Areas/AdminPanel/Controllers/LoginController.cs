using DummyPazarArdaEren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyPazarArdaEren.Areas.AdminPanel.Controllers
{
    public class LoginController : Controller
    {
        DummyPazarModel db = new DummyPazarModel();
        // GET: AdminPanel/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string mail,string password)
        {
            if (ModelState.IsValid)
            {
                int sayi = db.Managers.Count(s => s.Mail == mail && s.Password == password);
                if (sayi >0)
                {
                    Manager m = db.Managers.First(s => s.Mail == mail && s.Password == password);
                    if (m.IsActive)
                    {
                        Session["adminSession"] = m;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.message = "Kullanıcı Aktif Değil";
                    }
                }
                else
                {
                    ViewBag.message = "Kullanıcı Bulunamadı";
                }
            }
            return View();
        }
    }
}