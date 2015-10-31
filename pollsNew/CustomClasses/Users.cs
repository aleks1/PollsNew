using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pollsNew.DB;

namespace pollsNew.CustomClasses
{
    public class PollsUsers
    {
    public static int GetCurrentUserId(){
            pollsEntities context = new pollsEntities();
            return context.users.Where(u => u.username == System.Web.HttpContext.Current.User.Identity.Name).Select(u => u.userId).FirstOrDefault();
        }
    }
}