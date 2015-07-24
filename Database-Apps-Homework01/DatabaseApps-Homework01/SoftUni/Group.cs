using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSoftUni
{
    public partial class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
        }

        public int GroupID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
