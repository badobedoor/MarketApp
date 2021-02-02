using MarketWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace MarketWebApplication.Controllers
{
    public class vWImageTByProdectTController : ApiController
    {

        private GdgShopDBEntities db = new GdgShopDBEntities();

        // GET: api/Categories
        public IQueryable<Models.vWImageTByProdectT> GetvWImageTByProdectT()
        {
            return db.vWImageTByProdectTs;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Models.vWImageTByProdectT))]
        public IHttpActionResult GetvWImageTByProdectT(int id)
        {
            Models.vWImageTByProdectT vWImageTByProdectT = db.vWImageTByProdectTs.Find(id);
            if (vWImageTByProdectT == null)
            {
                return NotFound();
            }

            return Ok(vWImageTByProdectT);
        }

    }
}
