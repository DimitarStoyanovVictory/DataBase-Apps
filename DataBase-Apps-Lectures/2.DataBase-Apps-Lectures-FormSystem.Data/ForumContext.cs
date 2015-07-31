using System.Data.Entity;
using ForumSystem.Models;

namespace ForumSystem.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("ForumContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }
    }
}