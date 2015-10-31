using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using pollsNew.CustomClasses;
using pollsNew.DB;

namespace pollsNew
{
    public partial class Login : System.Web.UI.Page
    {
        private pollsEntities context = new pollsEntities();

        protected void Page_Load(object sender, EventArgs e)
        {          

        }
        public void Button1Click(object sender, EventArgs e){
            string name = authname.Text;
            string password = authpassword.Text;
            user curUser = context.users.Where(u => u.username == name && u.passwordHash == password).FirstOrDefault();
            if (curUser!=null)
            {
                FormsAuthentication.SetAuthCookie(name, false);
                Response.Redirect(Request["ReturnUrl"] ?? "/");
            }
            else
            {
                Page.Validators.Add(new PollsValidator("Данные неверны!"));
            }
        }
        public void Button2Click(object sender, EventArgs e)
        {
            string name = regname.Text;
            string password = regpassword.Text;
            user curUser = (user)context.users.Where(u => u.username == name).FirstOrDefault();
            if (curUser==null)
            {
                user newUser = new user() { username = name, passwordHash = password };
                context.users.Add(newUser);
                context.SaveChanges();                
                FormsAuthentication.SetAuthCookie(name, false);
                Response.Redirect(Request["ReturnUrl"] ?? "/");    
            }
            else
            {
                Page.Validators.Add(new PollsValidator("Such user already exists"));
            }
            
        }
    }
}