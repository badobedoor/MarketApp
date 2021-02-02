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
using AdminPanal.Models;
using MySql.Data.MySqlClient.Memcached;

namespace AdminPanal.Controllers
{
    public class ImageController : Controller
    {
        private ShopDBEntities db = new ShopDBEntities();

        // GET: Image
        public ActionResult Index()
        {
            var imageTs = db.ImageTs.Include(i => i.ProdectT);
            return View(imageTs.ToList());
        }


        public ActionResult Indexx(string Image)
        {
            //add the header
            System.Net.WebClient Client = new System.Net.WebClient();            
            Client.Headers.Add("Content-Type", "binary/octet-streOpenWriteam");

            //uploads the file and gets the result in a byte[]
            byte[] resultbyte =Client.UploadFile("weburl/controller/actionmethod", "POST", "pathToFile");

            //converts the result[] to a string
            //دا الاسترينج الى عاوز اضيفه فى الداتا بيز عشان هو دا الى هيتحول تانى ويكون byte
            string resultString = System.Text.Encoding.UTF8.GetString(resultbyte, 0, resultbyte.Length);
            

            //WebImage photo = null;
            //var newFileName = "";
            //photo = WebImage.GetImageFromRequest();

            //get the image from the request
            HttpPostedFileBase image = Request.Files[0];
            var imagePath = "";
            if (image != null)
            {
               // save the image in the selected folder on the server
               imagePath = @"UploadedFiles\" + image.FileName;                        
               image.SaveAs(Server.MapPath(@"~\" + imagePath));


                //newFileName = DateTime.Now.ToString("yymmssfff") + "_" + Path.GetFileName(photo.FileName);
               // imagePath = @"UploadedFiles\" + photo.FileName;
               // photo.Save(@"~\" + imagePath);

            }
                
            
            return View();
        }




        // GET: Image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageT imageT = db.ImageTs.Find(id);
            if (imageT == null)
            {
                return HttpNotFound();
            }
            return View(imageT);
        }

        // GET: Image/Create
        public ActionResult Create()
        {
            ViewBag.ProdectID = new SelectList(db.ProdectTs, "ProdectID", "ProdectName");
            var lastRecord = (from c in db.ProdectTs
                              orderby c.ProdectID descending
                              select c).First();

            ViewBag.user = lastRecord.ProdectID.ToString();
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageID,ImagePath,ImageTitle,ProdectID")] ImageT imageT)
        {
            if (ModelState.IsValid)
            {
                db.ImageTs.Add(imageT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdectID = new SelectList(db.ProdectTs, "ProdectID", "ProdectName", imageT.ProdectID);
            return View(imageT);
        }

        // GET: Image/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageT imageT = db.ImageTs.Find(id);
            if (imageT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdectID = new SelectList(db.ProdectTs, "ProdectID", "ProdectName", imageT.ProdectID);
            return View(imageT);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageID,ImagePath,ImageTitle,ProdectID")] ImageT imageT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdectID = new SelectList(db.ProdectTs, "ProdectID", "ProdectName", imageT.ProdectID);
            return View(imageT);
        }

        // GET: Image/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageT imageT = db.ImageTs.Find(id);
            if (imageT == null)
            {
                return HttpNotFound();
            }
            return View(imageT);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageT imageT = db.ImageTs.Find(id);
            db.ImageTs.Remove(imageT);
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
