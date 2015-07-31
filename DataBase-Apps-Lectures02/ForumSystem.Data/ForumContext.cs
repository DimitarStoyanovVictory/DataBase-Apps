using System.Data.Entity;

namespace ForumSystem.Data
{
    public class ForumContext : DbContext
    {
  
        public ForumContext()
            : base("ForumContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}