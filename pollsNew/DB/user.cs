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
    
    public partial class user
    {
        public user()
        {
            this.tableObjectPairs = new HashSet<tableObjectPair>();
            this.polls = new HashSet<poll>();
        }
    
        public int userId { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
    
        public virtual ICollection<tableObjectPair> tableObjectPairs { get; set; }
        public virtual ICollection<poll> polls { get; set; }
    }
}
