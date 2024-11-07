namespace BlogPlatform.Models
{
    public class Reader : User
    {

        public string Avatar {  get; set; }
        public string PersonalInfo { get; set; }

        public void FollowBlogger(int bloggerId)
        {

        }

        public Comment CommentOnPost(int postId ,string content)
        {
            return new Comment(content, userId, postId);

        }

        public void LikePost (int postId)
        {

        }
    }
}
