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
    public class vWFavoriteProductsController : ApiController
    {
        private GdgShopDBEntity db = new GdgShopDBEntity();

        // GET: api/vWFavoriteProductsController/UserID
        [Route("api/vWFavoriteProductsController/{UserID}")]
        [HttpGet]
        public IQueryable<vWFavoriteProduct> GetFavoriteproducts(string UserID)
        {
            var Favoriteproducts = db.vWFavoriteProducts.Where(x => x.UserID == UserID);

            if (Favoriteproducts == null)
            {
                return null;
            }
            return Favoriteproducts;
        }


        // GET: api/vWFavoriteProducts
        public IQueryable<vWFavoriteProduct> GetvWFavoriteProducts()
        {
            return db.vWFavoriteProducts;
        }

        // GET: api/vWFavoriteProducts/5
        [ResponseType(typeof(vWFavoriteProduct))]
        public IHttpActionResult GetvWFavoriteProduct(string id)
        {
            vWFavoriteProduct vWFavoriteProduct = db.vWFavoriteProducts.Find(id);
            if (vWFavoriteProduct == null)
            {
                return NotFound();
            }

            return Ok(vWFavoriteProduct);
        }

     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vWFavoriteProductExists(string id)
        {
            return db.vWFavoriteProducts.Count(e => e.UserID == id) > 0;
        }
    }
}