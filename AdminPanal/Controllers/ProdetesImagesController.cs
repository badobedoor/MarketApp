using AdminPanal.Models;

using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanal.Controllers
{ 

    public class ProdetesImagesController : Controller
    {
        private ShopDBEntities db = new ShopDBEntities();


        public ActionResult AddNewImage()
        {
            return View();
        }
        public ActionResult SaveData(ImageT item)
        {

            if (item.ImageTitle != null && item.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(item.ImageUpload.FileName);
                string extension = Path.GetExtension(item.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                item.ImagePath = fileName;
                item.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName ));
                item.ImagePath = "http://192.168.1.2:4444/UploadedFiles/" + fileName;
                var lastRecord = (from c in db.ProdectTs
                                  orderby c.ProdectID descending
                                  select c).First();

                item.ProdectID = lastRecord.ProdectID;
                db.ImageTs.Add(item);
                db.SaveChanges();
            }
            var result = "Sussccessfully Added";

            return Json(result,JsonRequestBehavior.AllowGet);
        }
        
    }
}