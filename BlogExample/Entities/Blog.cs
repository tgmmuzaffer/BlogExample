namespace Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Content { get; set; }
    }
}
