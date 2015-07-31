using System.Collections.Generic;

namespace ForumSystem.Models
{
    public class Question
    {
        private ICollection<Tag> _tags;
        private ICollection<Question> _questions;

        public Question()
        {
            _tags = new HashSet<Tag>();
            _questions = new HashSet<Question>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public virtual User Authour { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return _tags; }

            set { _tags = value; }
        }

        public virtual ICollection<Question> Questions
        {
            get { return _questions; }

            set { _questions = value; }
        }
    }
}
