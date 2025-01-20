using BankingApplication.Models;
using BankingApplication.Models.DTOs;



namespace BankingApplication.Interface
{
    public interface ICustomerService
    {
        Task<int> CreateCustomer (CreateCustomerDTO customer);
        Task<int> UpdateCustomer ( int customerId, CreateCustomerDTO customer );

        Task<int> DeleteCustomer ( int customerId );

        Task<Customer> GetCustomer ( int customerId );

        Task<IEnumerable<Customer>> GetAllCustomer();

    }
}
