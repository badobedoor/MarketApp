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
    [Authorize]
    public class vWCartsController : ApiController
    {
        private GdgShopDBEntity db = new GdgShopDBEntity();

        // GET: api/vWCartsController/UserID
        [Route("api/vWCartsController/{UserID}")]
        [HttpGet]
        public IQueryable<vWCart> GetCarts(string UserID)
        {
            var cart = db.vWCarts.Where(x => x.UserID == UserID);

            if (cart == null )
            {
                return null;
            }
            return cart;
        }
        #region Comment
        //// GET: api/vWFavoriteProducts
        //public IQueryable<vWFavoriteProduct> GetvWFavoriteProducts()
        //{
        //    return db.vWFavoriteProducts;
        //}

        //// GET: api/vWFavoriteProducts/5
        //[ResponseType(typeof(vWFavoriteProduct))]
        //public IHttpActionResult GetvWFavoriteProduct(string id)
        //{
        //    vWFavoriteProduct vWFavoriteProduct = db.vWFavoriteProducts.Find(id);
        //    if (vWFavoriteProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(vWFavoriteProduct);
        //}


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool vWFavoriteProductExists(string id)
        //{
        //    return db.vWFavoriteProducts.Count(e => e.UserID == id) > 0;
        //}
        #endregion


    }
}