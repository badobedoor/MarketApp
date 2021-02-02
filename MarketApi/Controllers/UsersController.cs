
using MarketApi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;


namespace MarketApi.Controllers
{
    [Authorize]
    public class UsersController : ApiController
    {

        private GdgShopDBEntity db = new GdgShopDBEntity();
        private HashSet<String> lines = new HashSet<String>();

        [HttpGet]
        
        [Route("api/GetUserApiId/")]
        public string GetUserApiId()
        {
            
            string user = User.Identity.GetUserId();
            return user;
        }


        // GET: api/Users
        public IQueryable<UserT> GetUserTs()
        {
            return db.UserTs;
        }
        // GET: api/Users/Search/Email//IQueryable<UserT>         
        [HttpGet]
        ////[Route("api/Users/Search/UserApiID={UserApiID}")]
        [Route("api/UserCredentials/UserApiID={UserApiID}")]
        public async Task<IHttpActionResult> SearchUserUserApiID(string UserApiID)
        {
            UserT login = await db.UserTs.Where(x => x.UserApiID == UserApiID).SingleOrDefaultAsync();
            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }
        //UserT login = await db.UserTs.Where(UserT => UserT.UserApiID == UserApiID).SingleOrDefaultAsync();
        //UserT loginn = await db.UserTs.SingleOrDefaultAsync(x => x.Email == email && x.Password == pasword) as UserT;
        //[Authorize]
        [HttpGet]        
        [Route("api/UserCredentials/email={email}/pasword={pasword}")]
        [ResponseType(typeof(UserT))]
        public async Task<IHttpActionResult> SearchUseremail(string email ,string pasword)
        {

            UserT login =await db.UserTs.SingleOrDefaultAsync(x => x.Email == email && x.Password == pasword);

            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }


        // GET: api/Users/5
        //[ResponseType(typeof(UserT))]
        //public IHttpActionResult GetUserT(string id)
        //{
        //    UserT userT = db.UserTs.Find(id);
        //    if (userT == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(userT);
        //}
        [ResponseType(typeof(UserT))]
        public HttpResponseMessage GetUserT(string id)
        {
            UserT userT = db.UserTs.Find(id);            
            if (userT == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
                // could also throw a HttpResponseException(HttpStatusCode.NotFound)
            }

            return Request.CreateResponse(HttpStatusCode.OK, userT); 
        }
                                           


    // PUT: api/Users/5
    [ResponseType(typeof(void))]
        public IHttpActionResult PutUserT(string id, UserT userT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userT.UserID = "1024";
            if (id != userT.UserID)
            {
                return BadRequest();
            }

            db.Entry(userT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(UserT))]
        public IHttpActionResult PostUserT(UserT userT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
                //string user = User.Identity.GetUserId();
                //userT.UserApiID = user ;

                db.UserTs.Add(userT);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = userT.UserID }, userT);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }



        }

        // DELETE: api/Users/5
        [ResponseType(typeof(UserT))]
        public IHttpActionResult DeleteUserT(int id)
        {
            UserT userT = db.UserTs.Find(id);
            if (userT == null)
            {
                return NotFound();
            }

            db.UserTs.Remove(userT);
            db.SaveChanges();

            return Ok(userT);
        }


    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserTExists(string id)
        {
            return db.UserTs.Count(e => e.UserID == id) > 0;
        }
    }
}