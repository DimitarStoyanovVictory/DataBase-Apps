using StudentSystem.Enums;

namespace StudentSystem.Models
{
    public class Resource
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ResourceType ResourceType { get; set; }

        public virtual string URL { get; set; }
    }
}
