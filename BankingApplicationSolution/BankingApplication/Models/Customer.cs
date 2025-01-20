using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Cannot be blank")]
        [MinLength(5, ErrorMessage = "Name must be more than or equal to 5 letters")]
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Cannot be blank")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Cannot be blank")]
        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cannot be blank")]
        public string AccountNumber { get; set; } = string.Empty;
    }
}
