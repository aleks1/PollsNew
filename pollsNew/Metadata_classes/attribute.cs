using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace pollsNew.DB
{
    [DisplayName("Атрибуты")]
    [MetadataType(typeof(attributeMeta))]
    public partial class attribute
    {
    }

    public class attributeMeta
    {
        [Required]
        [DisplayName("Название атрибута")]
        public string attributeName { get; set; }

        [Range(1, 10, ErrorMessage = "Значение должно быть в пределах 1-10")]
        public Nullable<int> attributeWeight { get; set; }
    }
}