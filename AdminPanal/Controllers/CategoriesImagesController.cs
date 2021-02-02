using AdminPanal.Models;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanal.Controllers
{ 

    public class CategoriesImagesController : Controller
    {
        private ShopDBEntities db = new ShopDBEntities();


        public ActionResult AddNewImage()
        {
            return View();
        }
        public ActionResult SaveData(ImageT item)
        {
            //add the header
            //System.Net.WebClient Client = new System.Net.WebClient();
            //Client.Headers.Add("Content-Type", "binary/octet-streOpenWriteam");

            ////uploads the file and gets the result in a byte[]
            //byte[] resultbyte = Client.UploadFile("weburl/controller/actionmethod", "POST", "pathToFile");

            //converts the result[] to a string
            //دا الاسترينج الى عاوز اضيفه فى الداتا بيز عشان هو دا الى هيتحول تانى ويكون byte
            //string resultString = System.Text.Encoding.UTF8.GetString(resultbyte, 0, resultbyte.Length);

            //................................................
            //HttpPostedFileBase image = Request.Files[0];
            //var imagePath = "";
            //if (image != null)
            //{
            //    // save the image in the selected folder on the server
            //    imagePath = @"UploadedFiles\" + image.FileName;
            //    image.SaveAs(Server.MapPath(@"~\Views\" + imagePath));
            //}

                if (item.ImageTitle != null && item.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(item.ImageUpload.FileName);
                string extension = Path.GetExtension(item.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                item.ImagePath = fileName;
                item.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName ));
                item.ImagePath = "http://192.168.1.2:4444/UploadedFiles/" + fileName;
                //item.ImageUpload.SaveAs(Path.Combine(Server.MapPath("../../MarketApp/MarketApp.Android/Resources/drawable"), fileName));
                var lastRecord = (from c in db.CategoriesTs
                                  orderby c.CategorieID descending
                                  select c).First();

                lastRecord.ImageID = item.ImageID;                
                db.ImageTs.Add(item);
                db.SaveChanges();
            }
            var result = "Sussccessfully Added";

            return Json(result,JsonRequestBehavior.AllowGet);
        }
        
    }
}