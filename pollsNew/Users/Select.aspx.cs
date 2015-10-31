using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pollsNew.DB;
using pollsNew.CustomClasses;

namespace pollsNew.Users
{
    public partial class Select : System.Web.UI.Page
    {
        private pollsEntities context = new pollsEntities();
        private int tableId;
        private int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<table> tables = context.tables.ToList();
            tablesList.DataSource = tables;
            tablesList.DataBind();
            if (!String.IsNullOrEmpty(Request.QueryString["tableId"]))
            {
                tableId = Convert.ToInt32(Request.QueryString["tableId"]);
                userId = PollsUsers.GetCurrentUserId();
                if (context.tableObjectPairs.Where(top => top.tableId == tableId && top.userId == userId && (top.IsVoted == 0 || top.IsVoted == null)).FirstOrDefault() != null)
                {
                    Response.Redirect(String.Format("/Users/Poll.aspx?tableId={0}", tableId));                
                }
                else
                {           
                    tablesView.Visible = false;
                    objectsView.Visible = true;

                    List<tableObject> curObjects = context.tableObjects.Where(o => o.tableId == tableId).ToList();
                    if (objectsList.Items.Count < 1)
                    {
                        foreach (var item in curObjects)
                        {
                            ListItem lItem = new ListItem(item.objectName, Convert.ToString(item.objectId));
                            objectsList.Items.Add(lItem);
                        }
                    }    
                }
            }
        }

        protected void selectObjects_Click(object sender, EventArgs e)
        {
            List<ListItem> selectedObjects = objectsList.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            if (selectedObjects.Count() < 2)
            {
                Page.Validators.Add(new PollsValidator("Выберите как минимум два объекта"));
            }
            else {
                for (int i = 0; i < selectedObjects.Count()-1; i++)
                {
                    for (int j = i+1; j < selectedObjects.Count(); j++)
                    {
                        context.tableObjectPairs.Add(new tableObjectPair { 
                            object1Id = Convert.ToInt32(selectedObjects[i].Value),
                            object2Id  = Convert.ToInt32(selectedObjects[j].Value),
                            tableId = tableId,
                            userId = userId
                        });
                    }
                }
                context.SaveChanges();
                Response.Redirect(String.Format("/Users/Poll.aspx?tableId={0}",tableId));
            }            
        }    
    }
}