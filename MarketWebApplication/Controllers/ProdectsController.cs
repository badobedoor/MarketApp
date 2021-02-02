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
    public class ProdectsController : ApiController
    {
        private GdgShopDBEntities db = new GdgShopDBEntities();

        // GET: api/Prodects
        public IQueryable<ProdectT> GetProdectTs()
        {
            return db.ProdectTs;
        }

        // GET: api/Prodects/5
        [ResponseType(typeof(ProdectT))]
        public IHttpActionResult GetProdectT(int id)
        {
            ProdectT prodectT = db.ProdectTs.Find(id);
            if (prodectT == null)
            {
                return NotFound();
            }

            return Ok(prodectT);
        }

        // PUT: api/Prodects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProdectT(int id, ProdectT prodectT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prodectT.ProdectID)
            {
                return BadRequest();
            }

            db.Entry(prodectT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdectTExists(id))
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

        // POST: api/Prodects
        [ResponseType(typeof(ProdectT))]
        public IHttpActionResult PostProdectT(ProdectT prodectT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProdectTs.Add(prodectT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prodectT.ProdectID }, prodectT);
        }

        // DELETE: api/Prodects/5
        [ResponseType(typeof(ProdectT))]
        public IHttpActionResult DeleteProdectT(int id)
        {
            ProdectT prodectT = db.ProdectTs.Find(id);
            if (prodectT == null)
            {
                return NotFound();
            }

            db.ProdectTs.Remove(prodectT);
            db.SaveChanges();

            return Ok(prodectT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdectTExists(int id)
        {
            return db.ProdectTs.Count(e => e.ProdectID == id) > 0;
        }
    }
}