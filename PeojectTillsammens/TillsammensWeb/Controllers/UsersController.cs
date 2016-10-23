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
using TillsammensWeb.Models;

namespace TillsammensWeb.Controllers
{
    public class UsersController : ApiController
    {
        private DataModelContainer db = new DataModelContainer();

        // GET: api/Users
        [ResponseType(typeof(IQueryable<User>))]
        public IQueryable<User> GetUserSet()
        {
            //db.UserSet.Add(new User()
            //{
            //    Desc = "Hey there I'm using GeoFriends!",
            //    FriendList = "",
            //    Id = 0,
            //    LastVisit = DateTime.Now.ToString(),
            //    Login = "hojeczka90",
            //    MailAddress = "patipatka@o2.pl",
            //    Password = "password",
            //    X = "1",
            //    Y = "1"
            //});
            //db.SaveChanges();
            var users = db.UserSet;
            return users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.UserSet.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            ///db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserSet.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
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