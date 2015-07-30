namespace NewsDatabase.Models
{
    public class New
    {
        private string _content;

        public New()
        {
        }

        public New(string content)
        {
            _content = content;
        }

        public int Id { get; set; }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
