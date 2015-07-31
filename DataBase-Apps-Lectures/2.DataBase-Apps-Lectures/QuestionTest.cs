using System;
using System.Collections.Generic;

namespace ForumSystem.Models
{
    public class QuestionTest : Question
    {
        private ICollection<Question> tags;

        public override ICollection<Question> Questions
        {
            get
            {
                return tags;
            }

            set { tags = value; }
        }
    }

    public class Test
    {
        public static void Main()
        {
            var question = new QuestionTest();

            question.Questions = new List<Question>();

            Console.WriteLine(question.Questions.GetType());
        }
    }
}
