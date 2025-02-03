using BankingApplication.Context;
using BankingApplication.Interface;
using BankingApplication.Exceptions;
using BankingApplication.Models;

namespace BankingApplication.Repositories
{
    public class EmployeeRepository : IRepository<string , Employee>

    {
        private readonly BankingContext _bankingContext;

        public EmployeeRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;

        }

        public async Task<Employee> Create(Employee entity)
        {
            try
            {
                var user = _bankingContext.Employees.FirstOrDefault(x => x.EmployeeEmail == entity.EmployeeEmail);
                if (user == null)
                {
                    await _bankingContext.Employees.AddAsync(entity);
                    await _bankingContext.SaveChangesAsync();
                    return entity;
                }

                else
                {
                    throw new InvalidOperationException(" User Already Exists");

                }

            }

            catch (Exception ex)
            {
                throw new CouldNotAddException(" User Add Failed ");

            }
        }

  

        public async Task<Employee> Get(string key)
        {
            var user = _bankingContext.Employees.FirstOrDefault(u => u.EmployeeEmail == key);

            return user;



        }

  

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var users =  _bankingContext.Employees.ToList();

            if (users.Any())
            {
                return users;

            }
            throw new EmptyCollectionException("Users collection empty");
        }

        public async Task<Employee> Update(string key, Employee entity)
        {
            throw new NotImplementedException();

        }

         public async  Task <int> Delete(string key)
        {
            var user = await  Get(key);

            if (user == null)
            {
                throw new InvalidOperationException(" User not exits");
            }

            _bankingContext.Employees.Remove(user);

            await  _bankingContext.SaveChangesAsync();

            return user.EmployeeId;
        }

       
    }
}
