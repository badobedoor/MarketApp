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
    public class vWProdectTByCategorieTController : ApiController
    {

        private GdgShopDBEntities db = new GdgShopDBEntities();

        // GET: api/Categories
        public IQueryable<Models.vWProdectTByCategorieT> GetvWProdectTByCategorieT()
        {
            return db.vWProdectTByCategorieTs;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Models.vWProdectTByCategorieT))]
        public IHttpActionResult GetvWProdectTByCategorieT(int id)
        {
            Models.vWProdectTByCategorieT vWProdectTByCategorieT = db.vWProdectTByCategorieTs.Find(id);
            if (vWProdectTByCategorieT == null)
            {
                return NotFound();
            }

            return Ok(vWProdectTByCategorieT);
        }
    }
}
