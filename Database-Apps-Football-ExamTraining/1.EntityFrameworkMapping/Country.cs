//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1.EntityFrameworkMapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    {
        public Country()
        {
            this.InternationalMatchesAway = new HashSet<InternationalMatch>();
            this.InternationalMatchesHome = new HashSet<InternationalMatch>();
            this.Leagues = new HashSet<League>();
            this.Teams = new HashSet<Team>();
        }
    
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<int> Population { get; set; }
        public Nullable<int> AreaSqKm { get; set; }
        public string Capital { get; set; }
    
        public virtual ICollection<InternationalMatch> InternationalMatchesAway { get; set; }
        public virtual ICollection<InternationalMatch> InternationalMatchesHome { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
