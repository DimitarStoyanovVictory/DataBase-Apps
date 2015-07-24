using System;
using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Student
    {
        private ICollection<Course> _courses;

        public Student()
        {
            _courses = new HashSet<Course>();
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual DateTime RegstrationDate { get; set; }

        public virtual DateTime? Birthday { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }
    }
}
