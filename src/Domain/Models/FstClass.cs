//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class FstClass
    {
        public FstClass()
        {
            this.SndClass = new HashSet<SndClass>();
            this.News = new HashSet<News>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<SndClass> SndClass { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
    
}
