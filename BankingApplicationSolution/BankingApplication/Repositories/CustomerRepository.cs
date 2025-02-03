using BankingApplication.Interface;
using BankingApplication.Context;
using BankingApplication.Exceptions;
using BankingApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication.Repositories
{
    public class CustomerRepository :  IRepository<int, Customer>
    {
        private readonly BankingContext _bankingContext;

        public CustomerRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;

        }
        public async Task<Customer> Create(Customer entity)
        {
            try
            {
                await  _bankingContext.Customers.AddAsync(entity);
                await _bankingContext.SaveChangesAsync();
                return entity ;

            }
            catch (Exception ex)
            {
                throw new CouldNotAddException("Customer Add Failed");
            }


        }

        public async Task<int> Delete(int key)
        {

            var customer = await Get(key);
            if (customer == null)
            {
                throw new InvalidOperationException("User does not exist");
            }
            _bankingContext.Customers.Remove(customer);
            await _bankingContext.SaveChangesAsync();

            return customer.CustomerID;
        }

        public async Task<Customer> Get(int key)
        {
            var customer = _bankingContext.Customers.FirstOrDefault(c => c.CustomerID == key);
            return customer;
        }

        public async  Task<IEnumerable<Customer>> GetAll()
        {
            var customers = _bankingContext.Customers.ToList();
            if (customers.Any())
            {
                return customers;
            }
            throw new EmptyCollectionException("Customers Collection Empty");

        }

        public async Task<Customer> Update(int key, Customer entity)
        {
            try
            {
                var updatedCustomer = await Get(key);
                if (updatedCustomer != null)
                {
                    if (!string.IsNullOrWhiteSpace(entity.FirstName))
                    {
                        updatedCustomer.FirstName = entity.FirstName;
                    }
                    if (!string.IsNullOrWhiteSpace(entity.LastName))
                    {
                        updatedCustomer.LastName = entity.LastName;
                    }

                    if (!string.IsNullOrWhiteSpace(entity.Email))
                    {
                        updatedCustomer.Email = entity.Email;
                    }

                    if (!string.IsNullOrWhiteSpace(entity.Address))
                    {
                        updatedCustomer.Address = entity.Address;
                    }

                    if (!string.IsNullOrWhiteSpace(entity.Phone))
                    {
                        updatedCustomer.Phone = entity.Phone;
                    }

                    if (!string.IsNullOrWhiteSpace(entity.City))
                    {
                        updatedCustomer.City = entity.City;
                    }

                    await _bankingContext.SaveChangesAsync();
                    return updatedCustomer;
                }
                else
                {
                    throw new InvalidOperationException("User doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed Customer Update {ex.Message}");
            }

        }

      
    }
}
