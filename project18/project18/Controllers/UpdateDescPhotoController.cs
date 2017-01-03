using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using project18.Models;

namespace project18.Controllers
{
    public class UpdateDescPhotoController : ApiController
    {
        private DataModelContainer db = new DataModelContainer();
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var userDb = db.UserSet.Where(u => u.Id == user.Id).ToArray()[0];
                userDb.Desc = user.Desc;
                userDb.PhotoUri = user.PhotoUri;
                db.Entry(userDb).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(userDb);
            }
            catch (Exception e)
            {
                 return InternalServerError(e);
            }
        }
    }
}
