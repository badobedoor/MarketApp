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
using MarketApi.Models;


namespace MarketApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private GdgShopDBEntities db = new GdgShopDBEntities();

        // GET: api/Categories
        public IQueryable<Models.CategoriesT> GetCategoriesTs()
        {
            return db.CategoriesTs;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Models.CategoriesT))]
        public IHttpActionResult GetCategoriesT(int id)
        {
            Models.CategoriesT categoriesT = db.CategoriesTs.Find(id);
            if (categoriesT == null)
            {
                return NotFound();
            }

            return Ok(categoriesT);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoriesT(int id, Models.CategoriesT categoriesT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriesT.CategorieID)
            {
                return BadRequest();
            }

            db.Entry(categoriesT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesTExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Models.CategoriesT))]
        public IHttpActionResult PostCategoriesT(Models.CategoriesT categoriesT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoriesTs.Add(categoriesT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoriesT.CategorieID }, categoriesT);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Models.CategoriesT))]
        public IHttpActionResult DeleteCategoriesT(int id)
        {
            Models.CategoriesT categoriesT = db.CategoriesTs.Find(id);
            if (categoriesT == null)
            {
                return NotFound();
            }

            db.CategoriesTs.Remove(categoriesT);
            db.SaveChanges();

            return Ok(categoriesT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriesTExists(int id)
        {
            return db.CategoriesTs.Count(e => e.CategorieID == id) > 0;
        }
    }
}