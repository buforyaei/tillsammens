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
    public class SearchController : ApiController
    {
        [ResponseType(typeof(IEnumerable<User>))]
        public IHttpActionResult Get(string phrase)
        {
            using (var db = new DataModelContainer())
            {
                try
                {
                    var users = db.UserSet.Where(user => user.Login.Contains(phrase)).ToList();
                    var sortedUsers = new List<User>();
                    if (users.Any())
                    {
                        foreach (var u in users)
                        {
                            u.Password = String.Empty;
                            u.Desc = String.Empty;
                            u.X = 0;
                            u.Y = 0;
                            u.LastVisit = new DateTime();
                            u.OpenDate = new DateTime();
                            if (u.CloseDate > DateTime.Now)
                            {
                                u.CloseDate = new DateTime();
                                sortedUsers.Add(u);
                            }  
                        }
                        return Ok(sortedUsers);
                    }
                    return Ok();
                }
                catch
                {
                    return InternalServerError();
                }
            }
        }
    }
}
