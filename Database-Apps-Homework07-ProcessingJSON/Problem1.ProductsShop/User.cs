using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Models
{
    public class User
    {
        [Required]
        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        [MinLength(3), Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual int Age { get; set; }

        public virtual ICollection<User> Friedns { get; set; }
    }
}
