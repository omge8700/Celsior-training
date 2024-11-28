namespace BlogPlatform.Models
{
    public class Reader 
    {
        
        public int ReaderID {  get; set; }
        public string Avatar {  get; set; }
        public string PersonalInfo { get; set; }

        public int userId;

        public User user { get; set; }


        public int postId { get;  set; }

        public Reader(int userId,int postId) { 
            
               this.userId = userId;
               this.postId = postId;
        }
        public IEnumerable<Comment> Comments { get; set; }

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
