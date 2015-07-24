using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseSoftUni
{
    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public DateTime LoginTime { get; set; }

        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
