using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using ProductsShop.Models;

namespace ProductsShop.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ProductShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProductsShop.Data.ProductShopDbContext";
        }

        // Problem 2.	Seed the Database // I have done only first two problems only
        protected override void Seed(ProductShopDbContext context)
        {
            XDocument userDocument = XDocument.Load("../../users.xml");

            string jsonUsers = JsonConvert.SerializeXNode(userDocument, Formatting.Indented);

            var users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);

            users.ForEach(user => context.Users.Add(user));

            string jsonProducts = File.ReadAllText("../..products.json");

            var products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);

            products.ForEach(product => context.Prodcuts.Add(product));

            string jsonCategories = File.ReadAllText("../..categories.json");

            var categories = JsonConvert.DeserializeObject<List<Product>>(jsonCategories);

            categories.ForEach(category => context.Prodcuts.Add(category));
        }
    }
}
