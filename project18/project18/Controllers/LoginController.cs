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
    public class LoginController : ApiController
    {
        private DataModelContainer db = new DataModelContainer();

        // POST api/values
        [ResponseType(typeof(User))]
        public IHttpActionResult Post(List<string> credentials)
        {
            using (var db = new DataModelContainer())
            {
                try
                {
                    var login = credentials.First();
                    var password = credentials.Last();
                    var userList =
                         db.UserSet
                         .Where(u => u.Login == login)
                         .ToList();
                    if (userList.First().Password == password && userList.First().CloseDate > DateTime.Now)
                    {
                        return Ok(userList.First());
                    }
                    return Unauthorized();
                    
                }
                catch
                {
                    return Unauthorized();
                }
            }
        }
    }
}
