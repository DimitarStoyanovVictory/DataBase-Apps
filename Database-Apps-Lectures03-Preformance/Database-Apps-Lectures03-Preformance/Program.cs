using System;
using System.Diagnostics;
using System.Linq;
using Database_Apps_Lectures03_Preformance;
using EntityFramework.Extensions;

public class Program
{
    static void Main()
    {
        var context = new SoftUniEntities();

        // Established connection with the base
        //var count = context.Employees.Count();
        //Console.WriteLine(count);

        //for (int image = 0; image < 1000; image++)
        //{
        //    context.Images.Add(new Image()
        //    {
        //        ImageBase64 = new string('-', 10) + image
        //    });

        //    Console.WriteLine(image);
        //}

        //context.SaveChanges();

        var sw = new Stopwatch();
        sw.Start();
        EfExtensionsDelete(context);
        Console.WriteLine("Standart: {0}", sw.Elapsed);

        sw.Restart();
        NativeDelete(context);
        Console.WriteLine("Native: {0}", sw.Elapsed);

        sw.Restart();
        EfStandartDelete(context);
        Console.WriteLine("Extensions: {0}", sw.Elapsed);
    }

    private static void EfExtensionsDelete(SoftUniEntities context)
    {
        context.Images
            .Where(i => i.ImageBase64.EndsWith("6"))
            .Delete();
    }

    private static void NativeDelete(SoftUniEntities context)
    {
        context.Database.ExecuteSqlCommand(
            "DELETE FROM Images WHERE Images.ImageBase64 LIKE '%3'");
    }

    private static void EfStandartDelete(SoftUniEntities context)
    {
        var Images = context.Images
            .Where(i => i.ImageBase64.EndsWith("5"));

        foreach (var image in Images)
        {
            context.Images.Remove(image);
        }

        context.SaveChanges();
    }
}
