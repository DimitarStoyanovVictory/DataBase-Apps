using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using DatabaseAppsHomework03Performance;

public class Test
{
    static void Main()
    {
        var context = new AdsEntities1();

        var stopWatch = new Stopwatch();
        stopWatch.Start();
        NotOptimizedMethod(context);
        Console.WriteLine("Not optimized method: {0}", stopWatch.Elapsed);
        stopWatch.Restart();
        OptimizedMethod(context);
        Console.WriteLine("Optimized method: {0}", stopWatch.Elapsed);
    }

    private static void OptimizedMethod(AdsEntities1 context)
    {
        var ads = context.Ads
            .Where(c => c.AdStatus.Status == "Published")
            .Select(ad => new
            {
                Title = ad.Title,
                Category = ad.Category,
                Town = ad.Town,
                PublishDate = ad.Date
            })
            .OrderBy(ad => ad.PublishDate)
            .ToList();

        //foreach (var ad in ads)
        //{
        //    Console.WriteLine("Title {0}; Category {1}; Town {2};", ad.Title, ad.Category != null ? ad.Category.Name : "null", ad.Town != null ? ad.Category.Name : "null");
        //}
    }

    private static void NotOptimizedMethod(AdsEntities1 context)
    {
        var ads = context.Ads.ToList()
            .Where(c => c.AdStatus.Status == "Published")
            .Select(ad => new
            {
                Title = ad.Title,
                Category = ad.Category,
                Town = ad.Town,
                PublishDate = ad.Date
            })
            .ToList()
            .OrderBy(ad => ad.PublishDate);

        //foreach (var ad in ads)
        //{
        //    Console.WriteLine("Title {0}; Category {1}; Town {2};", ad.Title, ad.Category != null ? ad.Category.Name : "null", ad.Town != null ? ad.Category.Name : "null");
        //}
    }
}

