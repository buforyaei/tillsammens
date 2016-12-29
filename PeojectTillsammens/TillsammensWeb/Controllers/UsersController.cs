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
using System.Workflow.ComponentModel.Compiler;
using TillsammensWeb.Models;

//using TillsammensWeb.Models;

namespace TillsammensWeb.Controllers
{
    public class UsersController : ApiController
    {
        private DataModelContainer1 db = new DataModelContainer1();

       // GET: api/Users
       [ResponseType(typeof(IEnumerable<User>))]
        public IEnumerable<User> GetUserSet()
        {
            try
            {
                db.UserSet.Add(new User()
                {
                    Description = "Hey there I'm using GeoFriends!",
                    Password = "roza13",
                    LastVisit = DateTime.Now,
                    Login = "hojeczka90",
                    PhotoUri = "http://www.alebilet.pl/blog/content/images/2016/10/Ariana-Grande-2-500x375c.jpg",

                    X = 50.0335829,
                    Y = 18.3982267
                });
               db.SaveChanges();
            }
            catch
            {

            }

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