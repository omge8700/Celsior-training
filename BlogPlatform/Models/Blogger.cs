namespace BlogPlatform.Models
{
    public class Blogger 
    {

        public int BloggerID { get; set; }

        public IEnumerable<BlogPost> blogPosts { get; set; } // each blogger will be represented by the blog post it has posted



        public int userId { get; set; }

        public User User { get; set; }



        public string bio { get; set; } 

        public string profilePicture { get; set; } 

        

        

        
      
    }
}
