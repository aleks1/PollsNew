using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace pollsNew.WebControls
{
    public partial class UserInfo : System.Web.UI.UserControl
    {
        public String UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                UserName = "Привет, " + System.Web.HttpContext.Current.User.Identity.Name;
                if (System.Web.HttpContext.Current.User.Identity.Name == "admin")
                {
                    AdminLink.Visible = true;
                }
                UserArea.Visible = true;
                RegLink.Visible = false;
            }
            if (!IsPostBack) { DataBind(); }
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/");
        }
    }
}