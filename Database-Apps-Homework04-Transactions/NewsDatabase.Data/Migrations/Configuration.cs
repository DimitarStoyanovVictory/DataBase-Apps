using System.Data.Entity.Migrations;
using NewsDatabase.Models;

namespace NewsDatabase.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NewsDB>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "NewsDatabase.Data.News";
        }

        protected override void Seed(NewsDB context)
        {
            context.News.AddOrUpdate(
                n => n.Content,
                new New()
                {
                    Content = "Judgment day in the Bible"
                }
                );

            context.SaveChanges();
        }
    }
}
