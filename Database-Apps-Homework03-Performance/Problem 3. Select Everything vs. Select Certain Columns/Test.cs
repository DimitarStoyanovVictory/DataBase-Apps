using System;
using System.Diagnostics;
using System.Linq;
using DatabaseAppsHomework03Performance;

namespace Problem_3.Select_Everything_vs.Select_Certain_Columns
{
    public class Test
    {
        static void Main()
        {
            var context = new AdsEntities1();
            
            var stopWatch = new Stopwatch();
            var count = context.Ads;

            CleanCache(context);
            stopWatch.Start();
            SelectEverything(context);
            Console.WriteLine("Not optimized method: {0}", stopWatch.Elapsed);

            CleanCache(context);
            stopWatch.Restart();
            SelectCertainColumns(context);
            Console.WriteLine("Optimized method: {0}", stopWatch.Elapsed);
        }

        private static void SelectEverything(AdsEntities1 context)
        {
            var selectAll = context.Ads.ToList();
        }

        private static void SelectCertainColumns(AdsEntities1 context)
        {
            var selectTitle = context.Ads.Select(ad => ad.Title).ToList();
        }

        private static void CleanCache(AdsEntities1 context)
        {
            context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS DBCC FREEPROCCACHE");
        }
    }
}
