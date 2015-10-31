using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pollsNew.DB
{
    [DisplayName("Таблицы")]
    [MetadataType(typeof(tableMeta))]
    public partial class table
    {
    }

    class tableMeta
    {
        [DisplayName("Название таблицы")]
        public string tablename { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<objectsRElation> objectsRElations { get; set; }
        [ScaffoldColumn(false)]
        public virtual ICollection<tableObjectPair> tableObjectPairs { get; set; }

        [DisplayName("Атрибуты этой таблицы")]
        public virtual ICollection<attribute> attributes { get; set; }
        [DisplayName("Голосования")]
        public virtual ICollection<poll> polls { get; set; }
    }
}