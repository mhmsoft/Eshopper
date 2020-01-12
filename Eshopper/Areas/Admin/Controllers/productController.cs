using Eshopper.Areas.Admin.Models.Entites;
using Eshopper.Areas.Admin.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshopper.Areas.Admin.Controllers
{
    public class productController : Controller
    {
        private productRepository mngr;
        public productController()
        {
            mngr = new productRepository(new Models.AppDbContext.Context());
        }
        // GET: Admin/category
        public ActionResult Index()
        {
            return View(mngr.getAll());
        }
        public ActionResult Create()
        {
            return View();
        }
        // Kaydetme 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
                mngr.Save(model);
            return RedirectToAction("/");
        }
        public ActionResult Edit(int id)
        {
            return View(mngr.Get(id));
        }
        //değiştirme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
                mngr.Update(model);
            return RedirectToAction("/");
        }
        public ActionResult Delete(int id)
        {
            return View(mngr.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            if (ModelState.IsValid)
                mngr.Delete(mngr.Get(id));
            return RedirectToAction("/");
        }
    }
}