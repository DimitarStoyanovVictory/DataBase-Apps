using System;
using System.Linq;
using StudentSystem.Data;
using StudentSystem.Enums;
using StudentSystem.Models;

namespace StudentSystem.Client
{
    public class Program
    {
        static void Main()
        {
            var context = new StudentSystemContext();

            //This is to create the data base Problem01

            int count = context.Students.;
            Console.WriteLine(count);

            //Fill created database Problem 02

            //var student = new Student()
            //{
            //    Id = 1,
            //    Name = "Dimitar Stoyanov",
            //    PhoneNumber = "+359 123 231 491",
            //    RegstrationDate = DateTime.Now,
            //};

            //var resource = new Resource()
            //{
            //    Name = "C# Data Structures - Liner Data",
            //    ResourceType = ResourceType.Video,
            //    URL = "https://softuni.bg/trainings/1147/Data-Structures-June-2015"
            //};

            //var homework = new Homework()
            //{
            //    Content = "Linear Data Structures – Stacks and Queues",
            //    ContentType = ContentType.zip,
            //    SubmissionDate = new DateTime(2016, 01, 12)
            //};

            //var course = new Course()
            //{
            //    Name = "Maths",
            //    Description = "Algebra",
            //    StartDate = new DateTime(2015, 7, 12),
            //    EndDate = new DateTime(2015, 8, 15),
            //    Price = 200
            //};

            //course.Students.Add(student);
            //course.Homeworks.Add(homework);
            //course.Resources.Add(resource);

            //student.Courses.Add(course);
            //student.Homeworks.Add(homework);

            //context.Resources.Add(resource);
            //context.Homeworks.Add(homework);
            //context.Courses.Add(course);
            //context.Students.Add(student);

            //context.SaveChanges();
        }
    }
}
