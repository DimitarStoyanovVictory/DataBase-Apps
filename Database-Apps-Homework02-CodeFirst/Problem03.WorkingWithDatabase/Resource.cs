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
    
    public partial class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResourceType { get; set; }
        public string URL { get; set; }
        public Nullable<int> Course_Id { get; set; }
    
        public virtual Cours Cours { get; set; }
    }
}
