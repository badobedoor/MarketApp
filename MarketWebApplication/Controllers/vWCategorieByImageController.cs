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

    public class vWCategorieByImageController : ApiController
    {
        private GdgShopDBEntities db = new GdgShopDBEntities();

        // GET: api/Categories
        public IQueryable<Models.vWCategorieByImage> GetvWCategorieByImage()
        {
            return db.vWCategorieByImages;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Models.vWCategorieByImage))]
        public IHttpActionResult GetvWCategorieByImage(int id)
        {
            Models.vWCategorieByImage vWCategorieByImage = db.vWCategorieByImages.Find(id);
            if (vWCategorieByImage == null)
            {
                return NotFound();
            }

            return Ok(vWCategorieByImage);
        }



    }
}
