using System;

namespace ForumSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public Gender GenderType { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }
    }
}