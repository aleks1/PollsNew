using System;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using pollsNew.DB;
using System.Linq;
using System.Web.Security;

namespace pollsNew
{
    public partial class _Default : System.Web.UI.Page
    {
        private pollsEntities context = new pollsEntities();
        private table curTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                curTable = context.tables.FirstOrDefault();
                setTable(curTable.tableId);
                info.Text = "";
            }            
        }

        protected void tableChoice_SelectedIndexChanged(object sender, EventArgs e)
        {            
            setTable(Convert.ToInt32(tableChoice.SelectedValue));
        }

        private void setTable(int curTableID) {
            var objects = context.polls.Join(context.tableObjects, p => p.objectId, to => to.objectId, (p, to) => new { p, to }).
                Where(p => p.p.tableId == curTableID && p.p.isCurrent == 1).GroupBy(p => p.p.objectId).Select(p => new
                {
                    objectName = p.Select(s => s.to.objectName).FirstOrDefault(),
                    points = p.Sum(s => s.p.points),
                    count = p.Where(s => s.p.objectId == s.to.objectId && s.p.isCurrent == 1).Select(s => s.p.userId).Distinct().Count()
                }).OrderByDescending(p => p.points).ToList();
            if (objects.Count > 0)
            {
                objectsGrid.DataSource = objects;
                info.Text = "";
            }
            else {
                info.Text = "Выбранная таблица не содержит голосований";
            }
            objectsGrid.DataBind();
            
        }
    }
}
