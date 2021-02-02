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
    public class UsermcvController : Controller
    {
        private ShopDBEntities db = new ShopDBEntities();

        // GET: Usermcv
        //[Authorize]
        public ActionResult Index(string searchBy, string search)
        {
            
            var user = db.UserTs.Include(p => p.OrderTs);

            if (searchBy == "1")
            {
                return View(db.UserTs.Where(x => x.FullName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "2")
            {
                return View(db.UserTs.Where(x => x.Email.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.UserTs.Where(x => x.Phone.ToString().StartsWith(search) || search == null).ToList());
            }
        }

        // GET: Usermcv/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserT userT = db.UserTs.Find(id);
            if (userT == null)
            {
                return HttpNotFound();
            }
            return View(userT);
        }

        // GET: Usermcv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usermcv/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FullName,UserName,Email,Phone,Password,City,State,Country,Address")] UserT userT)
        {
            if (ModelState.IsValid)
            {
                db.UserTs.Add(userT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userT);
        }

        // GET: Usermcv/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserT userT = db.UserTs.Find(id);
            if (userT == null)
            {
                return HttpNotFound();
            }
            return View(userT);
        }

        // POST: Usermcv/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FullName,UserName,Email,Phone,Password,City,State,Country,Address")] UserT userT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userT);
        }

        // GET: Usermcv/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserT userT = db.UserTs.Find(id);
            if (userT == null)
            {
                return HttpNotFound();
            }
            return View(userT);
        }

        // POST: Usermcv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserT userT = db.UserTs.Find(id);
            db.UserTs.Remove(userT);
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
