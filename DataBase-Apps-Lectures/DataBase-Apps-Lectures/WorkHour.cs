//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase_Apps_Lectures
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHour
    {
        public WorkHour()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int WorkHoursID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Task { get; set; }
        public string Comments { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
