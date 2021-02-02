using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AdminPanal.Models;

namespace AdminPanal.Controllers
{
    public class SendEmailController : Controller
    {
        private ShopDBEntities db = new ShopDBEntities();
        //[Authorize]
        public ActionResult index()
        {
            var users = db.UserTs.ToList();
            var AllUsers = users.Count();
            ViewBag.msg = AllUsers.ToString();
            var order = db.oldOrders;
            var neworder = db.OrderTs;

            
            return View();

        }
        

        public ActionResult SendEmail(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderT orderT = db.OrderTs.Find(id);
            if (orderT == null)
            {
                return HttpNotFound();
            }
            var Prodectid = db.OrderTs.Find(id).ProdectID;
            ProdectT Prodect = db.ProdectTs.Find(Prodectid);
            var UserTid = db.OrderTs.Find(id).UserID;
            UserT UserT = db.UserTs.Find(UserTid);

            var FullName = UserT.FullName;            
            var ProdectName = Prodect.ProdectName;
            var Price = Prodect.Price;
            var Phone = UserT.Phone;
            var Address = UserT.Address;
            var Country = UserT.Country;
            var City = UserT.City;            
            var Email = UserT.Email;


            ViewBag.msg = "Hi Plese diver the Prodect :- " + ProdectName  +  " To the Cotomar :- " + FullName + " ,the Prodect Price is :- " + Price + " ,the Cotomar Phone :- " + Phone+ " ,the Cotomar Email is:- " + Email+ " and the Cotomar Address is:- " + Address+ " , " + Country+ " , " + City ;

            return View(orderT);
        }
        //public ActionResult SendEmail()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message,string orderId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("ansbedoor@gmail.com", "AnsBedoor");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "bxxarmbmpsurcplg";
                    var sub = subject;
                    var body = message;

                    SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);
                    Client.EnableSsl = true;
                    Client.Timeout = 100000;
                    Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    Client.UseDefaultCredentials = false;
                    Client.Credentials = new NetworkCredential(senderEmail.Address, password);

                    MailMessage mailMessage = new MailMessage(senderEmail.Address, receiverEmail.Address, subject, message);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                    


                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        Client.Send(mailMessage);
                    }
                    var i = Convert.ToInt32(orderId);
                    OrderT orderT = db.OrderTs.Find(i);
                    ProdectT prodect = db.ProdectTs.Find(orderT.ProdectID);
                    UserT user = db.UserTs.Find(orderT.UserID);
                    CategoriesT categories = db.CategoriesTs.Find(prodect.CategorieID);

                    oldOrder old = new oldOrder();
                    old.OrderNumber = orderT.OrderID;

                    old.UserID = user.UserID;
                    old.FullName = user.FullName;
                    old.UserName = user.UserName;
                    old.Password = user.Password;
                    old.Email = user.Email;
                    old.Phone = user.Phone;
                    old.Address = user.Address;
                    old.City = user.City;
                    old.State = user.State;
                    old.Country = user.Country;


                    old.CategorieID = categories.CategorieName;
                    old.ProdectID = prodect.ProdectID;
                    old.ProdectName = prodect.ProdectName;
                    old.ProdectNameAR = prodect.ProdectNameAR;
                    old.Descriotion = prodect.Descriotion;
                    old.DescriotionAR = prodect.DescriotionAR;
                    old.Price = prodect.Price;
                    old.Rating = prodect.Rating;



                    

                    db.oldOrders.Add(old);
                    db.OrderTs.Remove(orderT);
                    db.SaveChanges();
                    return RedirectToAction("Index", "OrdersMcv", null);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string msg)
        {
            OrderT orderT = db.OrderTs.Find(id);
            ProdectT prodect = db.ProdectTs.Find(orderT.ProdectID);
            UserT user = db.UserTs.Find(orderT.UserID);
            CategoriesT categories = db.CategoriesTs.Find(prodect.CategorieID);

            oldOrder old = new oldOrder();
            old.OrderNumber = orderT.OrderID;

            old.UserID = user.UserID;
            old.FullName = user.FullName;
            old.UserName = user.UserName;
            old.Password = user.Password;
            old.Email = user.Email;
            old.Phone = user.Phone;
            old.Address = user.Address;
            old.City = user.City;
            old.State = user.State;
            old.Country = user.Country;


            old.CategorieID = categories.CategorieName;
            old.ProdectID = prodect.ProdectID;
            old.ProdectName = prodect.ProdectName;
            old.ProdectNameAR = prodect.ProdectNameAR;
            old.Descriotion = prodect.Descriotion;
            old.DescriotionAR = prodect.DescriotionAR;
            old.Price = prodect.Price;
            old.Rating = prodect.Rating;



            old.CancelMassage = msg;

            db.oldOrders.Add(old);
            db.OrderTs.Remove(orderT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public JsonResult SendEmailtouser()
        //{
        //    bool result = false;
        //    result = sendEmail("ansbedoor@gmail.com","masag Header","Massag Body");
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        //public bool sendEmail(string ToEmail, string subject, string EmailBody)
        //{
        //    try
        //    {

        //        string senderEmail = "Ansbedoor@gmail.com"; /*System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString(); */
        //        string senderpassword = "bxxarmbmpsurcplg"; /*System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();*/

        //        SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);
        //        Client.EnableSsl = true;
        //        Client.Timeout = 100000;
        //        Client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        //Client.UseDefaultCredentials = false;
        //        Client.Credentials = new NetworkCredential(senderEmail, senderpassword);

        //        MailMessage mailMessage = new MailMessage(senderEmail, ToEmail, subject, EmailBody);
        //        mailMessage.IsBodyHtml = true;
        //        mailMessage.BodyEncoding = UTF8Encoding.UTF8;
        //        Client.Send(mailMessage);
        //        return true;



        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //    }

    }
}



