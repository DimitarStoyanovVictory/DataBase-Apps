using System;
using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Student> _students;
        private ICollection<Resource> _resources;
        private ICollection<Homework> _homeworks;

        public Course()
        {
            _students = new HashSet<Student>();
            _resources = new HashSet<Resource>();
            _homeworks = new HashSet<Homework>();
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual decimal Price { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public virtual ICollection<Resource> Resources
        {
            get { return _resources; }
            set { _resources = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return _homeworks; }
            set { _homeworks = value; }
        }
    }
}
