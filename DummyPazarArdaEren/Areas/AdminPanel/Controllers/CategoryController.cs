using DummyPazarArdaEren.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DummyPazarArdaEren.Areas.AdminPanel.Filters;

namespace DummyPazarArdaEren.Areas.AdminPanel.Controllers
{
    public class CategoryController : Controller
    {
        DummyPazarModel db = new DummyPazarModel();
        // GET: AdminPanel/Category
        public ActionResult Index()
        {
            return View(db.Categories.OrderBy(s=>s.TopCategory_ID).ToList());
        }


        [ModeratorAuthenticationFilter]
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Text = "Üst Kategori", Value = "0", Selected = true });


            foreach (Categories item in db.Categories.Where(s=>s.TopCategory_ID == null))
            {
                categories.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString(),Selected = false });
            }


            ViewBag.TopCategory_ID = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories model)
        {
            if (ModelState.IsValid)
            {

                if (model.TopCategory_ID==0)
                {
                    model.TopCategory_ID = null;
                }

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