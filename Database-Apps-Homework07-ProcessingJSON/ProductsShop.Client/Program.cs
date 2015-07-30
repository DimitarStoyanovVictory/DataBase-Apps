using System;
using System.Linq;
using ProductsShop.Data;

namespace ProductsShop.Client
{
    public class Program
    {
        static void Main()
        {
            var context = new ProductShopDbContext();
            Console.WriteLine(context.Users.Count());
        }
    }
}
