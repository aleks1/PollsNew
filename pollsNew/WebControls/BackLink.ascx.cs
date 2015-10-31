using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pollsNew.WebControls
{
    public partial class BackLink : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;
                if (Request.UrlReferrer==null)
                {
                    LinkButton1.Visible = false;    
                }
                
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"]!=null)
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());
            }
        }
    }
}