using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TillsammensWeb.Models
{
    public class DataLayerConnection
    {
        public static User GetUser(int id)
        {
            using (var ctx = new DataModelContainer())
            {
                return ctx.UserSet.Find(id);
            }
        }

        public static IEnumerable<User> GetUsers()
        {
            using (var ctx = new DataModelContainer())
            {
                return ctx.UserSet.ToList();
            }
        }

        public static bool AddUser(User user)
        {
            using (var ctx = new DataModelContainer())
            {
                try
                {
                    ctx.UserSet.Add(user);
                    ctx.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}