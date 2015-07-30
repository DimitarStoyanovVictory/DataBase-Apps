using System.Linq;
using NewsDatabase.Data;

namespace NewsDataBase.Client
{
    public class NewsDBContextProgram
    {
        static void Main()
        {
            var context = new NewsDB();
            var count = context.News.Count();
        }
    }
}
