using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Test
{
    public class Program
    {
        static void Main()
        {
            //Product product = new Product();
            //product.Name = "Apple";
            //product.Expiry = new DateTime(2008, 12, 28);
            //product.Sizes = new[] { "Small" };

            //string json = JsonConvert.SerializeObject(product);
            var s = new JavaScriptSerializer();

            var dict = new Dictionary<int, int>
            {
                {0, 0},
                {1, 1}
            };

            //var json = s.Serialize(dict);
            var json2 = JsonConvert.SerializeObject(dict);
            var dictionary = JsonConvert.DeserializeObject(json2);
            //Console.WriteLine(json);
            Console.WriteLine(json2);
            Console.WriteLine(dictionary);
        }
    }

    internal class Product
    {
        public string Name { get; set; }

        public DateTime Expiry { get; set; }

        public string[] Sizes { get; set; }
    }
}
