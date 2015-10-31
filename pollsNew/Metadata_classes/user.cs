using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace pollsNew.DB
{
    [DisplayName("Пользователи")]
    public partial class user
    {
        //public user()
        //{
            
        //}

        //public void createPairs(pollsEntities context)
        //{
        //    List<tableObject> allObjects = context.tableObjects.Where(o => o.objectId != this.objectId && o.tableId == this.tableId).ToList();
        //    foreach (var item in allObjects)
        //    {
        //        context.tableObjectPairs.Add(new tableObjectPair() { tableId = this.tableId, object1Id = this.objectId, object2Id = item.objectId });
        //    }
        //    context.SaveChanges();
        //}
    }
}