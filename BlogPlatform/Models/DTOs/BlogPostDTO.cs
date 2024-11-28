namespace BlogPlatform.Models.DTOs
{
    public class BlogPostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

      
        public List<string> Tags { get; set; }
        public int BloggerID { get; set; }
        public string Status { get; set; }


    }
}
