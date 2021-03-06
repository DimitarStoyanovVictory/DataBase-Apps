//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Problem03.WorkingWithDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cours
    {
        public Cours()
        {
            this.Homework = new HashSet<Homework>();
            this.Resources = new HashSet<Resource>();
            this.Students = new HashSet<Student>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    
        public virtual ICollection<Homework> Homework { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
