using MarketApi.Models;
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


namespace  MarketApi.Controllers
{
    [Authorize]
    public class OrdersController : ApiController
    {
        private GdgShopDBEntity db = new GdgShopDBEntity();

        // GET: api/Orders
        public IQueryable<OrderT> GetOrderTs()
        {
            return db.OrderTs;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrderT))]
        public IHttpActionResult GetOrderT(int id)
        {
            OrderT orderT = db.OrderTs.Find(id);
            if (orderT == null)
            {
                return NotFound();
            }

            return Ok(orderT);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderT(int id, OrderT orderT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderT.OrderID)
            {
                return BadRequest();
            }

            db.Entry(orderT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderTExists(id))
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

        // POST: api/Orders
        [ResponseType(typeof(OrderT))]
        public IHttpActionResult PostOrderT(OrderT orderT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderTs.Add(orderT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderT.OrderID }, orderT);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(OrderT))]
        public IHttpActionResult DeleteOrderT(int id)
        {
            OrderT orderT = db.OrderTs.Find(id);
            if (orderT == null)
            {
                return NotFound();
            }

            db.OrderTs.Remove(orderT);
            db.SaveChanges();

            return Ok(orderT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderTExists(int id)
        {
            return db.OrderTs.Count(e => e.OrderID == id) > 0;
        }
    }
}