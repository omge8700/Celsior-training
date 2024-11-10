namespace BlogPlatform.Models.DTOs
{
    public class BloggerDTO
    {
        public int userId { get; set; }

        public int BloggerID {  get; set; }

       
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public int FollowerCount { get; set; }

    }
}
