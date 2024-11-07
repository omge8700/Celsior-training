namespace BlogPlatform.Models
{
    public class Blogger : User
    {
        public int userId { get; set; }

        public Blogger(int userId)
        {
            this.userId = userId;
        }

        public string bio { get; set; } = string.Empty;

        public string profilePicture { get; set; } = string.Empty;

        public long followercount { get; set; }

        public BlogPost CreatePost(string title, string content, List<string> tags)
        {
            return new BlogPost(title, content,tags,userId);


        }

        public void EditPost(int postId, string newContent )
        {

        }

        public void DeletePost(int postId)
        {


        }

        public void ModerateComments(int postId)
        {

        }
      
    }
}
