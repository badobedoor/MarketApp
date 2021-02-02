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
    public class oldOrdersController : Controller
    {
        private ShopDBEntities db = new ShopDBEntities();

        // GET: oldOrders
        //[Authorize]
        public ActionResult Index(string searchBy, string search)
        {
            
            var oldOrders = db.oldOrders;

            if (searchBy == "1")
            {
                return View(db.oldOrders.Where(x => x.ProdectName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "2")
            {
                return View(db.oldOrders.Where(x => x.Price.ToString().StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "3")
            {
                return View(db.oldOrders.Where(x => x.UserName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "4")
            {
                return View(db.oldOrders.Where(x => x.Email.StartsWith(search) || search == null).ToList());
            }            
            else
            {
                return View(db.oldOrders.Where(x => x.Phone.ToString().StartsWith(search) || search == null).ToList());
            }

        }
        
        // GET: oldOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldOrder oldOrder = db.oldOrders.Find(id);
            if (oldOrder == null)
            {
                return HttpNotFound();
            }
            return View(oldOrder);
        }

        // GET: oldOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: oldOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderNumber,ProdectID,ProdectName,ProdectNameAR,Descriotion,DescriotionAR,Price,Rating,ImagePath,CategorieID,UserID,FullName,UserName,Email,Phone,Password,City,State,Country,Address")] oldOrder oldOrder)
        {
            if (ModelState.IsValid)
            {
                db.oldOrders.Add(oldOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oldOrder);
        }

        // GET: oldOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldOrder oldOrder = db.oldOrders.Find(id);
            if (oldOrder == null)
            {
                return HttpNotFound();
            }
            return View(oldOrder);
        }

        // POST: oldOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderNumber,ProdectID,ProdectName,ProdectNameAR,Descriotion,DescriotionAR,Price,Rating,ImagePath,CategorieID,UserID,FullName,UserName,Email,Phone,Password,City,State,Country,Address")] oldOrder oldOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oldOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oldOrder);
        }

        // GET: oldOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            oldOrder oldOrder = db.oldOrders.Find(id);
            if (oldOrder == null)
            {
                return HttpNotFound();
            }
            return View(oldOrder);
        }

        // POST: oldOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            oldOrder oldOrder = db.oldOrders.Find(id);
            db.oldOrders.Remove(oldOrder);
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
