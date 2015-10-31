using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pollsNew.DB;
using System.Web.DynamicData;

namespace pollsNew.DynamicData.CustomPages.tableObjects
{
    public partial class Insert : System.Web.UI.Page
    {
        private pollsEntities context = new pollsEntities();
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
            var objectName = ((TextBox)FormView1.FindControl("objectName")).Text;
            var tableId = Convert.ToInt32(((DropDownList)FormView1.FindControl("tableId")).SelectedValue);
            tableObject curObject = new tableObject() { objectName = objectName, tableId = tableId };
            context.tableObjects.Add(curObject);
            context.SaveChanges();
            Response.Redirect(table.ListActionPath);
        }
    }
}