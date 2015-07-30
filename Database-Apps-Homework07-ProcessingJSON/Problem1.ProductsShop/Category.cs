using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [MinLength(3), MaxLength(15), Required]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
