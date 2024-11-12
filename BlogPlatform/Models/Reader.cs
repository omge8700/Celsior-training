namespace BlogPlatform.Models
{
    public class Reader 
    {

        public string Avatar {  get; set; }
        public string PersonalInfo { get; set; }

        public int userId;

        public int postId { get;  set; }

        public Reader(int userId,int postId) { 
            
               this.userId = userId;
               this.postId = postId;
        }
        public string commentonpost { get; set; }

        //public void FollowBlogger(int bloggerId)
        //{

        //}

        //public Comment CommentOnPost(int postId ,string content)
        //{
        //    return new Comment(content, userId, postId);

        //}

        //public void LikePost (int postId)
        //{

        //}
    }
}
