using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [MinLength(3), Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public User Seller { get; set; }

        public User Buyer { get; set; }
    }
}
