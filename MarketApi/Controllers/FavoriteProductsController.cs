using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MarketApi.Models;

namespace MarketApi.Controllers
{
    public class FavoriteProductsController : ApiController
    {
        private GdgShopDBEntity db = new GdgShopDBEntity();
        #region Comment ----------------------
        //// GET: api/FavoriteProducts
        //public IQueryable<FavoriteProduct> GetFavoriteProducts()
        //{
        //    return db.FavoriteProducts;
        //}

        //// GET: api/FavoriteProducts/5
        //[ResponseType(typeof(FavoriteProduct))]
        //public IHttpActionResult GetFavoriteProduct(int id)
        //{
        //    FavoriteProduct favoriteProduct = db.FavoriteProducts.Find(id);
        //    if (favoriteProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(favoriteProduct);
        //}

        // PUT: api/FavoriteProducts/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutFavoriteProduct(int id, FavoriteProduct favoriteProduct)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != favoriteProduct.ProdectID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(favoriteProduct).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FavoriteProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        #endregion



        // POST: api/FavoriteProducts
        [ResponseType(typeof(FavoriteProduct))]
        public IHttpActionResult PostFavoriteProduct(FavoriteProduct favoriteProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FavoriteProducts.Add(favoriteProduct);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FavoriteProductExists(favoriteProduct.ProdectID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = favoriteProduct.ProdectID }, favoriteProduct);
        }

        // DELETE: api/FavoriteProducts/prodectid={prodectid}/userid={userid}

        [ResponseType(typeof(FavoriteProduct))]

        [Route("api/FavoriteProductscontroller/{prodectid}/{userid}")]
        public async Task<IHttpActionResult> DeleteFavoriteProduct(int prodectid, string userid)
        {
            //FavoriteProduct favoriteProduct = db.FavoriteProducts.Find(id);
            FavoriteProduct favoriteProduct = await db.FavoriteProducts.SingleOrDefaultAsync(x => x.ProdectID == prodectid && x.UserID == userid);
            if (favoriteProduct == null)
            {
                return NotFound();
            }

            db.FavoriteProducts.Remove(favoriteProduct);
            db.SaveChanges();

            return Ok(favoriteProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FavoriteProductExists(int id)
        {
            return db.FavoriteProducts.Count(e => e.ProdectID == id) > 0;
        }
    }
}