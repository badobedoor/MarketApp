using MarketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;


namespace MarketApi.Controllers
{
    [Authorize]
    public class vWProdectTByCategorieTController : ApiController
    {

        private GdgShopDBEntity db = new GdgShopDBEntity();

        // GET: api/Categories
        public IQueryable<Models.vWProdectTByCategorieT> GetvWProdectTByCategorieT()
        {
            return db.vWProdectTByCategorieTs;
        }

        [HttpGet]
        [Route("api/SearchProductsByCategorie/{id}")]
        [ResponseType(typeof(vWImageTByProdectT))]
        public async Task<IHttpActionResult> SearchProductsByCategorie(int id)
        {

            var SelectedCategorie = db.vWProdectTByCategorieTs.Where(x => x.CategorieID == id);

            if (SelectedCategorie == null)
            {
                return NotFound();
            }
            return Ok(SelectedCategorie);
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
