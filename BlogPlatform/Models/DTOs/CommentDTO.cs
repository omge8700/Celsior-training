namespace BlogPlatform.Models.DTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }
        public int Likes { get; set; }

    }
}
