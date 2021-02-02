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
    [Authorize]
    public class CartsController : ApiController
    {
        private GdgShopDBEntity db = new GdgShopDBEntity();

        #region Comment ----------------------
        //// GET: api/Carts
        //public IQueryable<Cart> GetCarts()
        //{
        //    return db.Carts;
        //}

        //// GET: api/Carts/5
        //[ResponseType(typeof(Cart))]
        //public IHttpActionResult GetCart(int id)
        //{
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cart);
        //}


        #endregion


        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public IHttpActionResult PostCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carts.Add(cart);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CartExists(cart.ProdectID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cart.ProdectID }, cart);
        }
        // DELETE: api/Cartscontroller/prodectid={prodectid}/userid={userid}

        [ResponseType(typeof(Cart))]

        [Route("api/Cartscontroller/{prodectid}/{userid}")]
        public async Task<IHttpActionResult> DeleteCart(int prodectid, string userid)
        {           
            Cart cartProdect = await db.Carts.SingleOrDefaultAsync(x => x.ProdectID == prodectid && x.UserID == userid);
            if (cartProdect == null)
            {
                return NotFound();
            }

            db.Carts.Remove(cartProdect);
            db.SaveChanges();

            return Ok(cartProdect);
        }


        // PUT: api/Carts/5        
        [Route("api/PutCartscontroller/{prodectid}/{userid}")]
        [ResponseType(typeof(Cart))]
        public IHttpActionResult PutCart(int prodectid, string userid, Cart cart)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (prodectid != cart.ProdectID && userid != cart.UserID)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(prodectid))
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.ProdectID == id) > 0;
        }
    }
}