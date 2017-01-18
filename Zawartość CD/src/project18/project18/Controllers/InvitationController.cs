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
    public class InvitationController : ApiController
    {
        [ResponseType(typeof (Invitation))]
        public IHttpActionResult Post(int[] ids)
        {
            try
            {
                using (var db = new DataModelContainer())
                {
                    var invitations = db.InvitationSet.ToList();
                    var invs = invitations.Where(i =>
                        (i.RecieverId == ids[0] && i.SenderId == ids[1]) ||
                        (i.SenderId == ids[0] && i.RecieverId == ids[1]))
                        .ToList();
                    if (invitations.Any())
                    {
                        return Ok(invs[0]);
                    }
                    return InternalServerError();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
