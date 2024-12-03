namespace BlogPlatform.Models.DTOs
{
    public class BloggerDTO
    {
        public int userId { get; set; }

      

       
        public string Bio { get; set; }= string.Empty;
        public string ProfilePicture { get; set; }
        public int FollowerCount { get; set; }

    }
}
