using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pollsNew.CustomClasses;
using System.Web.UI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace pollsNew.DB
{
    [DisplayName("Объекты")]
    [MetadataType(typeof(tableObjectMeta))]
    public partial class tableObject
    {

    }

    public class tableObjectMeta {

        [DisplayName("Название объекта")]
        public String objectName { get; set; }

        public void tableObject (){
            var sdfsd = this.objectName;
        }
    }
}