using System.Collections.Generic;

namespace ForumSystem
{
    public class Tag
    {
        private ICollection<Question> _questions;

        public Tag()
        {
            _questions = new HashSet<Question>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
