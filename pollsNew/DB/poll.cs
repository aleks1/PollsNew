//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pollsNew.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class poll
    {
        public int pollId { get; set; }
        public int userId { get; set; }
        public int objectId { get; set; }
        public Nullable<System.DateTime> dateofpoll { get; set; }
        public Nullable<int> points { get; set; }
        public Nullable<int> isCurrent { get; set; }
        public int attributeId { get; set; }
        public int tableId { get; set; }
        public int pairId { get; set; }
    
        public virtual attribute attribute { get; set; }
        public virtual tableObject tableObject { get; set; }
        public virtual tableObjectPair tableObjectPair { get; set; }
        public virtual table table { get; set; }
        public virtual user user { get; set; }
    }
}
