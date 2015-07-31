using System;
using System.Linq;

namespace ForumSystem.Data
{
    public class Program
    {
        static void Main()
        {
            var context = new ForumContext();
            var count = context.Questions.Count();
            Console.WriteLine(count);
            //var question = new Question();

            //question.Id = 1;

            //count.Add(question);

            //Console.WriteLine(question);
        }
    }
}
