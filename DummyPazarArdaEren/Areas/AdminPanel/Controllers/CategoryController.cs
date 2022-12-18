using DummyPazarArdaEren.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DummyPazarArdaEren.Areas.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        DummyPazarModel db = new DummyPazarModel();
        // GET: AdminPanel/Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mesaj = "Düzenleme Yapınız";
            Categories c = db.Categories.Find(id);
            return View(c);

        }

        [HttpPost]
        public ActionResult Edit(Categories model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Mesaj = "Başarılı";
                }
                catch (Exception)
                {
                    ViewBag.Mesaj = "Hata";
                }
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Categories c = db.Categories.Find(id);
                db.Categories.Remove(c);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}