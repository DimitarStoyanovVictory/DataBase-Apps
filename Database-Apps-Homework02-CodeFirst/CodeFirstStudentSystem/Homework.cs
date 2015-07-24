using System;
using System.Collections.Generic;
using StudentSystem.Enums;

namespace StudentSystem.Models
{
    public class Homework
    {
        public virtual int Id { get; set; }

        public virtual string Content { get; set; }

        public virtual ContentType ContentType { get; set; }

        public virtual DateTime SubmissionDate { get; set; }

        public virtual int StudentId { get; set; }
    }
}
