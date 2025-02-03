using BankingApplication.Interface;
using BankingApplication.Models;
using BankingApplication.Models.DTOs;
using BankingApplication.Repositories;

namespace BankingApplication.Services
{
    public class CustomerService : ICustomerService 
    {
        private readonly IRepository<int, Customer> _customerRepo;

        public CustomerService(IRepository<int, Customer> CustomerRepository)
        {
            _customerRepo = CustomerRepository;
        }




        private string GenerateAccountNumber()
        {
            Random random = new Random();
            string accountNumber = "";

            for (int i = 0; i < 14; i++)
            {
                accountNumber += random.Next(0, 10).ToString();
            }

            return accountNumber;
        }




        public async  Task<int> CreateCustomer(CreateCustomerDTO customer)
        {
            try
            {
                var accountNumber = GenerateAccountNumber();
                var newCustomer = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Phone = customer.phone,
                    Address = customer.Address,
                    City = customer.City,
                    DateOfBirth = customer.DateOfBirth,
                    AccountNumber = accountNumber,
                };

                var addCustomer = await _customerRepo.Create(newCustomer);
                return addCustomer.CustomerID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
             
        }

        public  async Task<int> DeleteCustomer(int customerId)
        {
            var deletedCustomerId = await _customerRepo.Delete(customerId);

            return deletedCustomerId;
            
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            var customers = await _customerRepo.GetAll();
            return customers;
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            var customer = await _customerRepo.Get(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException($"Customer with Id: {customerId} is not Found..");
            }
            return customer;
        }

        public async Task<int> UpdateCustomer(int customerId, CreateCustomerDTO updatecustomer)
        {
            try
            {
                var newUpdateCustomer = new Customer
                {
                    FirstName = updatecustomer.FirstName,
                    LastName = updatecustomer.LastName,
                    Email = updatecustomer.Email,
                    Phone = updatecustomer.phone,
                    Address =   updatecustomer.Address,
                    City = updatecustomer.City,
                };
                var updatedCustomer = await _customerRepo.Update(customerId, newUpdateCustomer);

                return updatecustomer.CustomerID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
