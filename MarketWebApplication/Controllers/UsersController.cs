
using MarketWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace MarketWebApplication.Controllers
{
    public class UsersController : ApiController
    {
        private GdgShopDBEntities db = new GdgShopDBEntities();

        // GET: api/Users
        public IQueryable<UserT> GetUserTs()
        {
            return db.UserTs;
        }

        // GET: api/Users/5
        [ResponseType(typeof(UserT))]
        public IHttpActionResult GetUserT(int id)
        {
            UserT userT = db.UserTs.Find(id);
            if (userT == null)
            {
                return NotFound();
            }

            return Ok(userT);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserT(int id, UserT userT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userT.UserID)
            {
                return BadRequest();
            }

            db.Entry(userT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(UserT))]
        public IHttpActionResult PostUserT(UserT userT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserTs.Add(userT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userT.UserID }, userT);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(UserT))]
        public IHttpActionResult DeleteUserT(int id)
        {
            UserT userT = db.UserTs.Find(id);
            if (userT == null)
            {
                return NotFound();
            }

            db.UserTs.Remove(userT);
            db.SaveChanges();

            return Ok(userT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserTExists(int id)
        {
            return db.UserTs.Count(e => e.UserID == id) > 0;
        }
    }
}