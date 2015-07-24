using System;
using System.Linq;
using DatabaseAppsHomework03Performance;

namespace Database_Apps_Homework03_Performance
{
    public class Program
    {
        static void Main()
        {
            var context = new AdsEntities1();

            //With no include

            //foreach (var ad in context.Ads)
            //{
            //    Console.WriteLine("Title : {0}; Status: {1}; Category: {2}; Town: {3}; User: {4};",
            //        ad.Title,
            //        ad.AdStatus.Status,
            //        ad.Category != null ? ad.Category.Name : "null",
            //        ad.Town != null ? ad.Town.Name : "null",
            //        ad.AspNetUser);
            //}

            //With include

            //var ads = context.Ads
            //    .Include(ad => ad.AdStatus)
            //    .Include(ad => ad.Category)
            //    .Include(ad => ad.Town);

            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("Title : {0} Status: {1} Category: {2} Town: {3} User: {4}",
            //        ad.Title,
            //        ad.AdStatus.Status,
            //        ad.Category != null ? ad.Category.Name : "null",
            //        ad.Town != null ? ad.Town.Name : "null",
            //        ad.AspNetUser);
            //}

            //With select

            var selectedAds = context.Ads.Select(ad => new
            {
                ad.Title,
                CurrentStatus = ad.AdStatus.Status,
                CategoryName = ad.Category.Name,
                TownName = ad.Town.Name,
                ad.AspNetUser
            });

            foreach (var ad in selectedAds)
            {
                Console.WriteLine("Title : {0} Status: {1} Category: {2} Town: {3} User: {4}",
                    ad.Title,
                    ad.CurrentStatus,
                    ad.CategoryName,
                    ad.TownName,
                    ad.AspNetUser);
            }
        }
    }
}