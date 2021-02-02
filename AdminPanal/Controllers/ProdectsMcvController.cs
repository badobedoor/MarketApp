using AdminPanal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;



namespace AdminPanal.Controllers
{
    public class ProdectsMcvController : Controller
    {
        private ShopDBEntities db = new ShopDBEntities();



        // GET: ProdectsMcv
        //[Authorize]
        public ActionResult Index(string searchBy , string search)
        {

            var prodectTs = db.ProdectTs.Include(p => p.CategorieID);
            
            if (searchBy == "1")
            {
                return View(db.ProdectTs.Where(x => x.ProdectName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "2")
            {
                return View(db.ProdectTs.Where(x => x.ProdectNameAR.StartsWith(search) || search == null).ToList());
            }
            else 
            {
                return View(db.ProdectTs.Where(x => x.Price.ToString().StartsWith(search) || search == null).ToList());
            }                        

        }
        public ActionResult Indexx()
        {           
            return RedirectToAction("AddNewImage", "ProdetesImages");                                  
        }

        // GET: ProdectsMcv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdectT prodectT = db.ProdectTs.Find(id);
            if (prodectT == null)
            {
                return HttpNotFound();
            }
            return View(prodectT);
        }

        // GET: ProdectsMcv/Create
        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(db.CategoriesTs, "CategorieID", "CategorieName");
            return View();
        }

        // POST: ProdectsMcv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdectID,ProdectName,ProdectNameAR,Descriotion,DescriotionAR,Price,Rating,ImagePath,CategorieID")] ProdectT prodectT)
        {


            //string FileName = Path.GetFileNameWithoutExtension(prodectT.)
            if (ModelState.IsValid)
            {                
                db.ProdectTs.Add(prodectT);                
                db.SaveChanges();
                
                
                return RedirectToAction("Indexx");
            }

            ViewBag.CategorieID = new SelectList(db.CategoriesTs, "CategorieID", "CategorieName", prodectT.CategorieID);
            return View(prodectT);
        }


        //[HttpPost,ActionName("Upload")]
        //public ActionResult UploadFiles(HttpPostedFileBase file ,ProdectT prodect )
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {

        //            if (file != null)
        //            {
        //                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
        //                string extension = Path.GetExtension(file.FileName);
        //                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //                prodect.ImagePath = "~/UploadedFiles/" + fileName;
        //                fileName = "C:\"Users\"Ans\"source\"repos\"MarketApp2\"AdminPanal" + "~/UploadedFiles/" + fileName;
        //                file.SaveAs(fileName)
        //                //string path = "C:\"Users\"Ans\"source\"repos\"MarketApp2\"AdminPanal\"UploadedFiles" + Path.GetFileName(file.FileName);
        //                //string path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file.FileName));
        //                 /*file.SaveAs(path)*/;
        //                db.ProdectTs.Add(prodect);
        //                db.SaveChanges();


        //            }
                 
                    
        //            ViewBag.FileStatus = "File uploaded successfully.";
        //        }
        //        catch (Exception)
        //        {

        //            ViewBag.FileStatus = "Error while file uploading.";
        //        }

        //    }
        //    ModelState.Clear();
        //    return View();
            
        //}

        // GET: ProdectsMcv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdectT prodectT = db.ProdectTs.Find(id);
            if (prodectT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieID = new SelectList(db.CategoriesTs, "CategorieID", "CategorieName", prodectT.CategorieID);
            return View(prodectT);
        }

        // POST: ProdectsMcv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdectID,ProdectName,ProdectNameAR,Descriotion,DescriotionAR,Price,Rating,ImagePath,CategorieID")] ProdectT prodectT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodectT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieID = new SelectList(db.CategoriesTs, "CategorieID", "CategorieName", prodectT.CategorieID);
            return View(prodectT);
        }

        // GET: ProdectsMcv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdectT prodectT = db.ProdectTs.Find(id);
            if (prodectT == null)
            {
                return HttpNotFound();
            }
            return View(prodectT);
        }

        // POST: ProdectsMcv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdectT prodectT = db.ProdectTs.Find(id);
            db.ProdectTs.Remove(prodectT);
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
