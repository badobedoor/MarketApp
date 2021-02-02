using MarketWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



//الكنتروب دا انا كاتب الكود فيه باديا ومعايا كورس ان ازاى اكتب الكلام دا عشان لو احتجت انى اعدل فى اى كونترول من الى انا ضفتهم
namespace MarketWebApplication.Controllers
{
    public class EmtyController : ApiController
    {
        private GdgShopDBEntities db = new GdgShopDBEntities();

        public HttpResponseMessage Get(string name = "All")
        {
                                       
                switch (name.ToLower())
                {

                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, db.UserTs.ToList());
                    case "ans":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            db.UserTs.Where(e => e.UserName.ToLower() == "ans").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                         "Value For Name Must be all or ans . " + name + " is invalid.");
                }
                // return costomarEntity.CostomarTables.ToList();
            
        }
        public HttpResponseMessage Get(int id)
        {

                var entity = db.UserTs.FirstOrDefault(e => e.UserID == id);

                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Costomar with Id = " + id.ToString() + " Not Fond");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);

                }
            
        }
        public HttpResponseMessage Post([FromBody] UserT TBUser)
        {
            try
            {

                    db.UserTs.Add(TBUser);
                    db.SaveChanges();

                    var massage = Request.CreateResponse(HttpStatusCode.Created, TBUser);
                    massage.Headers.Location = new Uri(Request.RequestUri + TBUser.UserID.ToString());
                    return massage;
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        public HttpResponseMessage Put(int id, [FromBody]UserT TBUser)
        {
            try
            {

                    var entity = db.UserTs.FirstOrDefault(e => e.UserID == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Costomar with Id = " + id.ToString() + " Not Fond to Update");
                    }
                    else
                    {
                        entity.FullName = TBUser.FullName;
                        entity.UserName = TBUser.UserName;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);

                    }
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {

                var entity = db.UserTs.FirstOrDefault(e => e.UserID == id);

                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Costomar with Id = " + id.ToString() + " Not Fond to Delete");
                }
                else
                {
                    db.UserTs.Remove(entity);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);

                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
