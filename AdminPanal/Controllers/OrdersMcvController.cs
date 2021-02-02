using AdminPanal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace AdminPanal.Controllers
{
    public class OrdersMcvController : Controller
    {
        private ShopDBEntities db = new ShopDBEntities();

        // GET: OrdersMcv
       // [Authorize]
        public ActionResult Index(string searchBy, string search)
        {
            var users = db.UserTs.ToList();
            var AllUsers = users.Count();
            ViewBag.msg = AllUsers.ToString();
            var order = db.OrderTs.Include(o => o.ProdectT).Include(o => o.UserT);
            

            if (searchBy == "1")
            {
                return View(db.OrderTs.Where(x => x.ProdectT.ProdectName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "2")
            {
                return View(db.OrderTs.Where(x => x.ProdectT.Price.ToString().StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "3")
            {
                return View(db.OrderTs.Where(x => x.UserT.UserName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "4")
            {
                return View(db.OrderTs.Where(x => x.UserT.Email.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.OrderTs.Where(x => x.UserT.Phone.ToString().StartsWith(search) || search == null).ToList());
            }
            
        }

        // GET: OrdersMcv/Details/5
        public ActionResult Details(int? id)
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
            return View(orderT);
        }

        // GET: OrdersMcv/Create
        public ActionResult Create()
        {
            ViewBag.ProdectID = new SelectList(db.ProdectTs, "ProdectID", "ProdectName");
            ViewBag.UserID = new SelectList(db.UserTs, "UserID", "FullName");
            return View();
        }

        // POST: OrdersMcv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ProdectID,UserID")] OrderT orderT)
        {
            if (ModelState.IsValid)
            {
                db.OrderTs.Add(orderT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdectID = new SelectList(db.ProdectTs, "ProdectID", "ProdectName", orderT.ProdectID);
            ViewBag.UserID = new SelectList(db.UserTs, "UserID", "FullName", orderT.UserID);
            return View(orderT);
        }

        // GET: OrdersMcv/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.ProdectID = new SelectList(db.ProdectTs, "ProdectID", "ProdectName", orderT.ProdectID);
            ViewBag.UserID = new SelectList(db.UserTs, "UserID", "FullName", orderT.UserID);
            return View(orderT);
        }

        // POST: OrdersMcv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ProdectID,UserID")] OrderT orderT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdectID = new SelectList(db.ProdectTs, "ProdectID", "ProdectName", orderT.ProdectID);
            ViewBag.UserID = new SelectList(db.UserTs, "UserID", "FullName", orderT.UserID);
            return View(orderT);
        }

        // GET: OrdersMcv/Delete/5
        public ActionResult Delete(int? id)
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
            return View(orderT);
        }
        // POST: oldOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id,string msg)
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

        // GET: OrdersMcv/Delete/5
        public ActionResult Cancel(int? id)
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
            return View(orderT);
        }

        // GET: OrdersMcv/Delete/5
        public ActionResult CancelBTN(int id)
        {

            return RedirectToAction("Delete");
        }
        //public ViewResult GetView()
        //{
        //    var orderTs = db.OrderTs.Include(o => o.ProdectT).Include(o => o.UserT);
        //    var users = db.UserTs.ToList();
        //    var orders = orderTs.ToList();
        //    var AllUsers = users.Count();
        //    return View();
        //}


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
