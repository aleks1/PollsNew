using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace pollsNew.DB
{
    [ScaffoldTable(false)]
    [MetadataType(typeof(tableObjectPairMeta))]
    
    public partial class tableObjectPair
    {

    }

    class tableObjectPairMeta
    {
        [ScaffoldColumn(false)]
        public int pairId { get; set; }
    }
    
}