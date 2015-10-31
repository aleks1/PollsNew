using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using pollsNew.DB;
using System.ComponentModel.DataAnnotations;

namespace pollsNew.DynamicData.CustomPages.attribute
{
    public partial class Insert : System.Web.UI.Page
    {
        protected MetaTable table;

        protected void Page_Init(object sender, EventArgs e)
        {
            table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
            FormView1.SetMetaTable(table, table.GetColumnValuesFromRoute(Context));
            DetailsDataSource.EntityTypeFilter = table.EntityType.Name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = table.DisplayName;
        }

        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == DataControlCommands.CancelCommandName)
            {
                Response.Redirect(table.ListActionPath);
            }
        }

        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                Response.Redirect(table.ListActionPath);
            }
            pollsEntities context = new pollsEntities();
            pollsNew.DB.attribute newAttribute = new pollsNew.DB.attribute();
            var validationContext = new ValidationContext(newAttribute,null,null);
            newAttribute.attributeName = ((TextBox)FormView1.FindControl("attributeName")).Text;
            newAttribute.attributeWeight = Convert.ToInt32(((TextBox)FormView1.FindControl("attributeWeight")).Text);
            newAttribute.tableId = Convert.ToInt32(((DropDownList)FormView1.FindControl("tableId")).SelectedValue);
            context.attributes.Add(newAttribute);
            context.SaveChanges();
            Response.Redirect(table.ListActionPath);
        }
    }
}