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
    public class ImageTsController : ApiController
    {
        private GdgShopDBEntities db = new GdgShopDBEntities();

        // GET: api/ImageTs
        public IQueryable<ImageT> GetImageTs()
        {
            return db.ImageTs;
        }

        // GET: api/ImageTs/5
        [ResponseType(typeof(ImageT))]
        public IHttpActionResult GetImageT(int id)
        {
            ImageT imageT = db.ImageTs.Find(id);
            if (imageT == null)
            {
                return NotFound();
            }

            return Ok(imageT);
        }

        // PUT: api/ImageTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImageT(int id, ImageT imageT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageT.ImageID)
            {
                return BadRequest();
            }

            db.Entry(imageT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageTExists(id))
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

        // POST: api/ImageTs
        [ResponseType(typeof(ImageT))]
        public IHttpActionResult PostImageT(ImageT imageT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImageTs.Add(imageT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imageT.ImageID }, imageT);
        }

        // DELETE: api/ImageTs/5
        [ResponseType(typeof(ImageT))]
        public IHttpActionResult DeleteImageT(int id)
        {
            ImageT imageT = db.ImageTs.Find(id);
            if (imageT == null)
            {
                return NotFound();
            }

            db.ImageTs.Remove(imageT);
            db.SaveChanges();

            return Ok(imageT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageTExists(int id)
        {
            return db.ImageTs.Count(e => e.ImageID == id) > 0;
        }
    }
}