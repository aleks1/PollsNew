using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pollsNew.DB;
using pollsNew.CustomClasses;
using System.Web.UI.HtmlControls;

namespace pollsNew.Users
{
    public partial class Poll : System.Web.UI.Page
    {
        private pollsEntities context = new pollsEntities();
        private tableObject object1;
        private tableObject object2;
        private int tableId;
        private int userId = PollsUsers.GetCurrentUserId();
        private List<attribute> curAttributes;
        private tableObjectPair currentPair;
        
        protected void Page_Init(object sender, EventArgs e)
        {
            tableId = Convert.ToInt32(Request.QueryString["tableId"]);
            curAttributes = context.attributes.Where(a => a.tableId == tableId).ToList();              
            currentPair = context.tableObjectPairs.Where(top => top.userId == userId && top.tableId == tableId && (top.IsVoted == 0 || top.IsVoted == null)).FirstOrDefault();
            if (currentPair != null)
            {
                object1 = context.tableObjects.Where(o => o.objectId == currentPair.object1Id).FirstOrDefault();
                object2 = context.tableObjects.Where(o => o.objectId == currentPair.object2Id).FirstOrDefault();
                object1Name.Text = object1.objectName;
                object2Name.Text = object2.objectName;

                foreach (var item in curAttributes)
                {
                    HtmlInputRadioButton radio1 = new HtmlInputRadioButton();
                    radio1.Name = item.attributeName;
                    radio1.Value = object1.objectId.ToString();

                    HtmlInputRadioButton radio2 = new HtmlInputRadioButton();
                    radio2.Name = item.attributeName;
                    radio2.Value = object2.objectId.ToString();

                    Object1Radio.Controls.Add(radio1);
                    Object1Radio.Controls.Add(new HtmlGenericControl("br"));
                    Object2Radio.Controls.Add(radio2);
                    Object2Radio.Controls.Add(new HtmlGenericControl("br"));

                    Label text = new Label();                    
                    text.Text = item.attributeName;
                    attributes.Controls.Add(text);
                    
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                 List<HtmlInputRadioButton> list1 = Object1Radio.Controls.OfType<HtmlInputRadioButton>().Where(c => c.Checked == true).ToList();
                 List<HtmlInputRadioButton> list2 = Object2Radio.Controls.OfType<HtmlInputRadioButton>().Where(c => c.Checked == true).ToList();
                 list1.AddRange(list2);                 

                 if (list1.Count() < curAttributes.Count())
                 {
                     Page.Validators.Add(new PollsValidator("Выберите как минимум два объекта"));
                 }
                 else
                 {
                     tableObjectPair removingPair = context.tableObjectPairs.Where(p => ((p.object1Id == object1.objectId && p.object2Id == object2.objectId) || (p.object2Id == object1.objectId && p.object1Id == object2.objectId)) && p.userId == userId && p.IsVoted == 1).FirstOrDefault();
                     if (removingPair != null)
                     {
                         List<poll> removingPolls = context.polls.Where(p => p.pairId == removingPair.pairId).ToList();
                         foreach (var item in removingPolls)
                         {
                             //context.polls.Remove(item);
                             item.isCurrent = 0;  
                         }
                         //removingPair.IsVoted = 1;
                     }

                     List<HtmlInputRadioButton> list3 = Object1Radio.Controls.OfType<HtmlInputRadioButton>().Where(c => c.Checked == false).ToList();
                     List<HtmlInputRadioButton> list4 = Object2Radio.Controls.OfType<HtmlInputRadioButton>().Where(c => c.Checked == false).ToList();
                     list3.AddRange(list4);
                     foreach (var item in list1)
                     {
                         attribute curAttribute = context.attributes.Where(a=>a.attributeName == item.Name && a.tableId == tableId).FirstOrDefault();
                         poll newPoll = new poll()
                         {
                             userId = userId,
                             objectId = Convert.ToInt32(item.Value),
                             dateofpoll = DateTime.Now,
                             points = curAttribute.attributeWeight,
                             isCurrent = 1,
                             attributeId = curAttribute.attributeId,
                             tableId = tableId,
                             pairId = currentPair.pairId
                         };
                         context.polls.Add(newPoll);
                     }
                     foreach (var item in list3)
                     {
                         attribute curAttribute = context.attributes.Where(a => a.attributeName == item.Name && a.tableId == tableId).FirstOrDefault();
                         poll newPoll = new poll()
                         {
                             userId = userId,
                             objectId = Convert.ToInt32(item.Value),
                             dateofpoll = DateTime.Now,
                             points = 0,
                             isCurrent = 1,
                             attributeId = curAttribute.attributeId,
                             tableId = tableId,
                             pairId = currentPair.pairId
                         };
                         context.polls.Add(newPoll);
                     }
                     currentPair.IsVoted = 1;
                     context.SaveChanges();
                     if (context.tableObjectPairs.Where(top => top.tableId == tableId && top.userId == userId && (top.IsVoted == 0 || top.IsVoted == null)).FirstOrDefault() != null)
	                    {                            
                            Response.Redirect(Request.RawUrl);
	                    }
                     else
                     {
                         Response.Redirect("/");
                     }                     
                 }                
            }
        }
    }
}