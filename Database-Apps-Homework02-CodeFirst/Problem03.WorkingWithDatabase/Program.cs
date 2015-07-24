using System;

namespace Problem03.WorkingWithDatabase
{
    public class Program
    {
        static void Main()
        {
            var context = new StudentSystemEntities();

            foreach (var student in context.Students)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(student.Homework.Content);
            }
        }
    }
}
