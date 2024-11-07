using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace BlogPlatform.Models
{
    public class BlogPost 
    {
        [Key]
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        private string TagsSerialized { get; set; }
        [NotMapped]
        public List<string> Tags
        {
            get => string.IsNullOrEmpty(TagsSerialized) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(TagsSerialized);
            set => TagsSerialized = JsonSerializer.Serialize(value);
        }

        public int AuthorId {  get; set; }

        public DateTime PublicationDate { get; set; }

        public string Status {  get; set; }

        public BlogPost()
        {
            
        }
        public BlogPost(string title,string content ,List<string> tags ,int authorId )
        {
            Title = title;
            Content = content;

            Tags = tags;
            AuthorId = authorId;

            PublicationDate = DateTime.Now;

            Status = "public ";
            
        }

        public void Publish()
        {
            Status = "public ";
        }

        public void Schedule(DateTime date)
        {
            Status = "scheduled";
        }

        public void Edit(string newContent)
        {
            Content = newContent;

        }

        public void Delete()
        {

        }
    }
}
