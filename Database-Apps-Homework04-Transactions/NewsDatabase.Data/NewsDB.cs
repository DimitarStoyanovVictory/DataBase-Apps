using System.Data.Entity;
using NewsDatabase.Data.Migrations;
using NewsDatabase.Models;

namespace NewsDatabase.Data
{
    public class NewsDB : DbContext
    {
        public NewsDB()
            : base("name=NewsDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDB,
                Configuration>());
        }

        public IDbSet<New> News { get; set; }
    }
}