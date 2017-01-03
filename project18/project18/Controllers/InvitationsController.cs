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
using project18.Models;

namespace project18.Controllers
{
    public class InvitationsController : ApiController
    {
        private DataModelContainer db = new DataModelContainer();

        // GET: api/Invitations
        public IQueryable<Invitation> GetInvitationSet()
        {
            return db.InvitationSet;
        }

        // GET: api/Invitations/5
        [ResponseType(typeof(IEnumerable<Invitation>))]
        public IHttpActionResult GetInvitation(int id)
        {
            var invList = db.InvitationSet
                .Where(i => i.RecieverId==id).ToList();
            return Ok(invList);
        }

        // PUT: api/Invitations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvitation(int id, Invitation invitation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invitation.Id)
            {
                return BadRequest();
            }

            db.Entry(invitation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvitationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
      
        // POST: api/Invitations
        [ResponseType(typeof(Invitation))]
        public IHttpActionResult PostInvitation(Invitation invitation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var invitations = db.InvitationSet.Where(i =>
                    (i.RecieverId == invitation.RecieverId &&
                    i.SenderId == invitation.SenderId) ||(
                    i.SenderId == invitation.RecieverId &&
                    i.RecieverId == invitation.SenderId))
                    .ToList();
                if (invitations.Any())
                {
                    return NotFound();
                }
                db.InvitationSet.Add(invitation);
                db.SaveChanges();
                return Ok();
            } catch (Exception e)
            {
                return InternalServerError(e);
            }
           
        }
      
        // DELETE: api/Invitations/5
        [ResponseType(typeof(Invitation))]
        public IHttpActionResult DeleteInvitation(int id)
        {
            Invitation invitation = db.InvitationSet.Find(id);
            if (invitation == null)
            {
                return NotFound();
            }

            db.InvitationSet.Remove(invitation);
            db.SaveChanges();

            return Ok(invitation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvitationExists(int id)
        {
            return db.InvitationSet.Count(e => e.Id == id) > 0;
        }
    }
}