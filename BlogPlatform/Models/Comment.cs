using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }


        public string Content { get; set; }



        public Reader Reader { get; set; }
        public BlogPost blogPost { get; set; }
        public int PostId { get; set; }

        public DateTime Timestampt { get; set; }

        public int Likes { get; set; } = 0;

        //public Comment (string content ,int authorId,int postId)
        //{
        //    Content = content;
        //    AuthorId = authorId;
        //    PostId = postId;
        //    Timestampt = DateTime.Now;
        //    Likes = 0;

        //}
        //public void AddComment()
        //{

        //}

        //public void EditComment (string newContent)
        //{
        //    Content = newContent;

        //}

        //public void DeleteComment()
        //{

        //}

        //public void LikeComment()
        //{
        //    Likes++;

        //}
    }

}
