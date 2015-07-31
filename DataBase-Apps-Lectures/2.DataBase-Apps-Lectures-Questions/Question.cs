using DataBase_Apps_Lectures;

namespace QuestionSystem
{
    public class Question
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public virtual User Authour { get; set; }
    }
}
