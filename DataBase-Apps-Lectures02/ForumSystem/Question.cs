using System.Collections.Generic;

namespace ForumSystem
{
    public class Question
    {
        private ICollection<Tag> _tags;

        public Question()
        {
            _tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return _tags; }

            set { _tags = value; }
        }
    }
}
