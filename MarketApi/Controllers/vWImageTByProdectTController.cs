using MarketApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;


namespace MarketApi.Controllers
{
    [Authorize]
    public class vWImageTByProdectTController : ApiController
    {

        private GdgShopDBEntity db = new GdgShopDBEntity();

        // GET: api/vWImageTByProdectT
        public IQueryable<Models.vWImageTByProdectT> GetvWImageTByProdectT()
        {
            return db.vWImageTByProdectTs;
        }

        // GET: api/vWImageTByProdectT/5
        [ResponseType(typeof(Models.vWImageTByProdectT))]

        public async Task<IHttpActionResult> GetvWImageTByProdectT(int id)
        {

            var vWImageTByProdectT = db.vWImageTByProdectTs.Where(x => x.ProdectID == id).FirstOrDefault();

            if (vWImageTByProdectT == null)
            {
                return NotFound();
            }
            return Ok(vWImageTByProdectT);
        }

    }
}
