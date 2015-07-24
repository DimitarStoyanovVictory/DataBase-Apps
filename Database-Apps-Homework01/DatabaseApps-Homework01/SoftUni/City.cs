using System.ComponentModel.DataAnnotations;

namespace DatabaseSoftUni
{
    public partial class City
    {
        public int CityID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int CountryID { get; set; }
    }
}
