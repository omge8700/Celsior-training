using System.ComponentModel.DataAnnotations;

namespace BankingApplication.Models.DTOs
{
    public class CreateCustomerDTO
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string? Address { get; set; }
        public string? City { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string phone { get; set; } = string.Empty;

        public string Email { get; set; }= string.Empty;



    }
}
