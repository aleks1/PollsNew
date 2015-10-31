using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace pollsNew.DB
{
    [DisplayName("Голосования")]
    [ReadOnly(true)]
    [MetadataType(typeof(pollMeta))]
    public partial class poll
    {
    }

    [DisplayColumn("dateofpoll")]
    public class pollMeta
    {
        [ScaffoldColumn(false)]
        public int tableObjectPair { get; set; }

        [DisplayName("Дата голосования")]
        public DateTime dateofpoll { get; set; }

        [DisplayName("Баллы")]
        public int points { get; set; }

        [DisplayName("Объект")]
        public tableObject tableObject { get; set; }
    }
}