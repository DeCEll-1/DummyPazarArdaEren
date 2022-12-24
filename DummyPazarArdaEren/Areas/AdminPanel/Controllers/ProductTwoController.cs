using DummyPazarArdaEren.Areas.AdminPanel.Filters;
using DummyPazarArdaEren.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace DummyPazarArdaEren.Areas.AdminPanel.Controllers
{
    [AdminAuthenticationFilter]
    public class ProductTwoController : Controller
    {
        DummyPazarModel db = new DummyPazarModel();
        // GET: AdminPanel/ProductTwo
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        [ModeratorAuthenticationFilter]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase imageBig, HttpPostedFileBase imageIcon)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageIcon != null)
                    {
                        FileInfo fi = new FileInfo(imageIcon.FileName);
                        string name = Guid.NewGuid().ToString() + fi.Extension;
                        model.ImageIconPath = name;
                        imageIcon.SaveAs(Server.MapPath($"~/Assets/ProductImages/ImageIcon/{name}"));
                    }
                    else { model.ImageIconPath = "Sad.png"; }

                    if (imageBig != null)
                    {
                        FileInfo fi = new FileInfo(imageIcon.FileName);
                        string name = Guid.NewGuid().ToString() + fi.Extension;
                        model.ImageIconPath = name;
                        imageIcon.SaveAs(Server.MapPath($"~/Assets/ProductImages/ImageBig/{name}"));
                    }
                    else { model.ImageIconPath = "Sad.png"; }
                    db.Products.Add(model);
                    db.SaveChanges();
                    ViewBag.message = "Ürün Ekleme Başarılı";
                    db.Products.Add(model);
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.message = "Ürün Ekleme Başarısız";
                }

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
            Product p = new Product();
            return View(p);
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Product p = new Product();
                p = db.Products.Find(id);
                db.Products.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}