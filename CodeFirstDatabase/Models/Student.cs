using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstDatabase.Models
{
    public class Student
    {
        [Key,Required]
        public int Id { get; set; }
        [Column("StudentName",TypeName ="varchar(20)")]
        public string Name { get; set; }

        [Column("StudentGender",TypeName = "varchar(100)")]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Standard { get; set; }
    }
}
