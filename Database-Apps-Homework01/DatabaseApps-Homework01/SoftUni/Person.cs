using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseSoftUni
{
    [Table("Persons")]
    public partial class Person
    {
        public int PersonID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
