using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminPanal.Models;


namespace AdminPanal.Controllers
{
    public class CategoriesMcvController : Controller
    {
        private ShopDBEntities db = new ShopDBEntities();

        // GET: CategoriesMcv        
        //[Authorize]
        public ActionResult Index(string searchBy, string search)
        {
            
            var CategoriesTs = db.CategoriesTs;

            if (searchBy == "1")
            {
                return View(db.CategoriesTs.Where(x => x.CategorieName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.CategoriesTs.Where(x => x.CategorieNameAR.StartsWith(search) || search == null).ToList());
            }
        }
        public ActionResult Indexx()
        {
            return RedirectToAction("AddNewImage", "CategoriesImages");
        }
        // GET: CategoriesMcv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriesT categoriesT = db.CategoriesTs.Find(id);
            if (categoriesT == null)
            {
                return HttpNotFound();
            }
            return View(categoriesT);
        }

        // GET: CategoriesMcv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesMcv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategorieID,CategorieName,CategorieNameAR,ImagePath")] CategoriesT categoriesT)
        {
            if (ModelState.IsValid)
            {
                db.CategoriesTs.Add(categoriesT);
                db.SaveChanges();
                return RedirectToAction("Indexx");
            }

            return View(categoriesT);
        }

        // GET: CategoriesMcv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriesT categoriesT = db.CategoriesTs.Find(id);
            if (categoriesT == null)
            {
                return HttpNotFound();
            }
            return View(categoriesT);
        }

        // POST: CategoriesMcv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategorieID,CategorieName,CategorieNameAR,ImagePath")] CategoriesT categoriesT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriesT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriesT);
        }

        // GET: CategoriesMcv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriesT categoriesT = db.CategoriesTs.Find(id);
            if (categoriesT == null)
            {
                return HttpNotFound();
            }
            return View(categoriesT);
        }

        // POST: CategoriesMcv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriesT categoriesT = db.CategoriesTs.Find(id);
            db.CategoriesTs.Remove(categoriesT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
