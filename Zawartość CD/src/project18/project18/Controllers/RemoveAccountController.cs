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
    public class RemoveAccountController : ApiController
    {
        [ResponseType(typeof(bool))]
        public IHttpActionResult Post(int id)
        {
            try
            {
                using (var db = new DataModelContainer())
                {
                    var user = db.UserSet.Where(i => i.Id == id);
                    var u = user.ToList();
                    if (u.Any())
                    {
                        u[0].CloseDate = DateTime.Now;
                        db.Entry(u[0]).State = EntityState.Modified;
                        db.SaveChanges();
                      
                        return Ok(true);
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
