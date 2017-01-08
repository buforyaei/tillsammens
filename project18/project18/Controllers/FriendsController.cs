using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using project18.Models;

namespace project18.Controllers
{
    public class FriendsController : ApiController
    {
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult GetFriends(int id)
        {
            try
            {
                using (var db = new DataModelContainer())
                {
                    var invitations =
                        db.InvitationSet
                            .Where(invitation => (invitation.RecieverId == id || invitation.SenderId == id)
                                                 && invitation.Status.Contains("Accepted"))
                            .ToList();
                    var friends = new List<User>();
                    foreach (var i in invitations)
                    {
                        if (i.SenderId == id) friends.Add(db.UserSet.Find(i.RecieverId));
                        else friends.Add(db.UserSet.Find(i.SenderId));
                    }
                    var sortedFriends = (from f in friends
                        where f.CloseDate > DateTime.Now
                        select new User
                        {
                            Id = f.Id,
                            Login = f.Login,
                            PhotoUri = f.PhotoUri,
                            LastVisit = f.LastVisit,
                            Desc = f.Desc,
                            X = f.X,
                            Y = f.Y,
                        }).ToList();
                    return Ok(sortedFriends);
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
