using BankingApplication.Interface;
using BankingApplication.Context;
using BankingApplication.Exceptions;
using BankingApplication.Models;
namespace BankingApplication.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
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
                await _bankingContext.Customers.AddAsync(entity);
                await _bankingContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new CouldNotAddException(" Customer Add Failed ");

            }
        }

        public async Task<Customer> Delete(int key)
        {
            var customer = await Get(key);

            if(customer == null)
            {
                throw new InvalidOperationException(" User does not exits");
            }
            _bankingContext.Customers.Remove(customer);
            await _bankingContext.SaveChangesAsync();
            return customer;
            
        }

        public Task<Customer> Get(int key)
        {
            var customer = _bankingContext.Customers.FirstOrDefault(c => c.CustomerID == key);

            return customer;
        }

        public Task<IEnumerable<Customer>> GetAll(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(int key, Customer value)
        {
            throw new NotImplementedException();
        }
    }
}
