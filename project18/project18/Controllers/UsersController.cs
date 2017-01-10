using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using project18.Models;

namespace project18.Controllers
{
    public class UsersController : ApiController
    {
        private DataModelContainer db = new DataModelContainer();

        // GET: api/Users
        public IQueryable<User> GetUserSet()
        {
            return db.UserSet;
        }
        // POST: api/Users
        [ResponseType(typeof (User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var users = db.UserSet.Where
                    (u => u.Login == user.Login).ToList();
                if (users.Any())
                {
                    return Unauthorized();
                }
                db.UserSet.Add(user);
                db.SaveChanges();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.UserSet.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.UserSet.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.UserSet.Count(e => e.Id == id) > 0;
        }
    }
}