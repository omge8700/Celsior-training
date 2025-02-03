using BankingApplication.Context;
using BankingApplication.Exceptions;
using BankingApplication.Interface;
using BankingApplication.Models;
using BankingApplication.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplicationUnitTesting
{
    internal class CustomerRepositoryTest
    {
        BankingContext context;
        CustomerRepository repository;
        DbContextOptions options;


        [SetUp]
        public void SetUp()
        {
            options = new DbContextOptionsBuilder<BankingContext>()
                .UseInMemoryDatabase("TestAdd")
                .Options;
            context = new BankingContext((DbContextOptions<BankingContext>)options);
            repository = new CustomerRepository(context);
        }

        [Test]
        public async Task CustomerAdd_Success_Test()
        {
            var customer = new Customer
            {
                CustomerID = 4,
                FirstName = "Testom",
                LastName = "TestLastNameisom",
                Address = "TestAddressisom",
                City = "TestCitydhanbad",
                DateOfBirth = DateTime.Today,
                Phone = "87874877979",
                Email = "rana@gmail.com",
                AccountNumber = "126666695"
            };

            var result = await repository.Create(customer);
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.CustomerID);
        }


        [Test]
        public async Task CustomerAddFailed_CouldNotAddException_Test()
        {
            var customer = new Customer
            {
                FirstName = null,
                LastName = "TestLastName",
                Address = "TestAddress",
                City = "TestCity",
                DateOfBirth = DateTime.Now,
                Phone = "8787470933",
                Email = "john@gmail.com",
                AccountNumber = "1234567895"
            };

            var exception = Assert.ThrowsAsync<CouldNotAddException>
                (async () => await repository.Create(customer));
            Assert.IsNotNull(exception);
            Assert.AreEqual("Customer Add Failed", exception.Message);
        }

        [Test]
        public async Task Get_Success_test()
        {
            var customer = new Customer
            {
                CustomerID = 2,
                FirstName = "Test",
                LastName = "TestLastName",
                Address = "TestAddress",
                City = "TestCity",
                DateOfBirth = DateTime.Now,
                Phone = "8787470933",
                Email = "john@gmail.com",
                AccountNumber = "1234567895"
            };

            await repository.Create(customer);
            var result = await repository.Get(2);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerID);
        }

        [Test]
        public async Task GetAllCustomer_Success_test()
        {
            var customer = new Customer
            {
                CustomerID = 3,
                FirstName = "Test",
                LastName = "TestLastName",
                Address = "TestAddress",
                City = "TestCity",
                DateOfBirth = DateTime.Now,
                Phone = "8787470933",
                Email = "john@gmail.com",
                AccountNumber = "1234567895"
            };

            await repository.Create(customer);
            var result = await repository.GetAll();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetAll_EmptyCollectionException()
        {
            var _options = new DbContextOptionsBuilder<BankingContext>()
               .UseInMemoryDatabase("Test1")
               .Options;
            var _context = new BankingContext(_options);
            var _repository = new CustomerRepository(_context);

            var exception = Assert.ThrowsAsync<EmptyCollectionException>
                (async () => await _repository.GetAll());
            Assert.IsNotNull(exception);
            Assert.AreEqual("Customers Collection Empty", exception.Message);
        }

        [Test]
        public async Task Delete_Success_Test()
        {
            var customer = new Customer
            {
                FirstName = "Test",
                LastName = "TestLastName",
                Address = "TestAddress",
                City = "TestCity",
                DateOfBirth = DateTime.Now,
                Phone = "8787470933",
                Email = "john@gmail.com",
                AccountNumber = "1234567895"
            };

            var addedCustomer = await repository.Create(customer);
            var result = await repository.Delete(addedCustomer.CustomerID);
            Assert.IsNotNull(result);
            //Assert.AreEqual(result.City, customer.City);
        }

        [Test]
        public async Task Delete_UserNotFound_InvlidOpertorException_Test()
        {
            var exception = Assert.ThrowsAsync<InvalidOperationException>
                (async () => await repository.Delete(20));
            Assert.IsNotNull(exception);
            Assert.AreEqual("User does not exist", exception.Message);
        }


        [Test]
        public async Task UpdateFirstName_Success_Test()
        {
            var customer = new Customer
            {
                CustomerID = 8,
                FirstName = "Chin",
                LastName = "Singh",
                Address = "Lucknow",
                City = "Center park",
                DateOfBirth = DateTime.UtcNow,
                Phone = "87343434343",
                Email = "ninga@gmail.com",
                AccountNumber = "3703077895"
            };

            var updatecustomer = new Customer
            {
                FirstName = "TestUpdate",
            };

            await repository.Create(customer);
            var result = await repository.Update(8, updatecustomer);
            Assert.IsNotNull(result);
            Assert.AreEqual("TestUpdate", result.FirstName);
        }

        [Test]
        public async Task UpdateLastName_Success_Test()
        {
            var customer = new Customer
            {
                CustomerID = 5,
                FirstName = "Test",
                LastName = "TestLastName",
                Address = "TestAddress",
                City = "TestCity",
                DateOfBirth = DateTime.Now,
                Phone = "8787470933",
                Email = "john@gmail.com",
                AccountNumber = "1234567895"
            };

            var updatecustomer = new Customer
            {
                LastName = "TestLastNameUpdate",
            };

            await repository.Create(customer);
            var result = await repository.Update(5, updatecustomer);
            Assert.IsNotNull(result);
            Assert.AreEqual("TestLastNameUpdate", result.LastName);
        }

        [Test]
        public async Task UpdateEmailUpdate_Success_Test()
        {
            var customer = new Customer
            {
                CustomerID = 6,
                FirstName = "Test",
                LastName = "TestLastName",
                Address = "TestAddress",
                City = "TestCity",
                DateOfBirth = DateTime.Now,
                Phone = "8787470933",
                Email = "john@gmail.com",
                AccountNumber = "1234567895"
            };

            var updatecustomer = new Customer
            {
                Email = "testemail@gmail.com",
            };

            await repository.Create(customer);
            var result = await repository.Update(6, updatecustomer);
            Assert.IsNotNull(result);
            Assert.AreEqual("testemail@gmail.com", result.Email);
        }

        [Test]
        public async Task UpdatePhoneUpdate_Success_Test()
        {
            var customer = new Customer
            {
                CustomerID = 7,
                FirstName = "Test",
                LastName = "TestLastName",
                Address = "TestAddress",
                City = "TestCity",
                DateOfBirth = DateTime.Now,
                Phone = "8787470933",
                Email = "john@gmail.com",
                AccountNumber = "1234567895"
            };

            var updatecustomer = new Customer
            {
                Phone = "878732111",
            };

            await repository.Create(customer);
            var result = await repository.Update(7, updatecustomer);
            Assert.IsNotNull(result);
            Assert.AreEqual("878732111", result.Phone);
        }

        [Test]
        public async Task UpdateCityUpdate_Success_Test()
        {
            var customer = new Customer
            {
                CustomerID = 8,
                FirstName = "Test",
                LastName = "TestLastName",
                Address = "TestAddress",
                City = "TestCity",
                DateOfBirth = DateTime.Now,
                Phone = "8787470933",
                Email = "john@gmail.com",
                AccountNumber = "1234567895"
            };

            var updatecustomer = new Customer
            {
                City = "UpdatedCity",
            };

            await repository.Create(customer);
            var result = await repository.Update(8, updatecustomer);
            Assert.IsNotNull(result);
            Assert.AreEqual("UpdatedCity", result.City);
        }

        [Test]
        public async Task UpdateAddredUpdate_Success_Test()
        {
            var customer = new Customer
            {
                CustomerID = 9,
                FirstName = "Test",
                LastName = "TestLastName",
                Address = "TestAddress",
                City = "TestCity",
                DateOfBirth = DateTime.Now,
                Phone = "8787470933",
                Email = "john@gmail.com",
                AccountNumber = "1234567895"
            };

            var updatecustomer = new Customer
            {
                Address = "UpdatedAddress",
            };

            await repository.Create(customer);
            var result = await repository.Update(9, updatecustomer);
            Assert.IsNotNull(result);
            Assert.AreEqual("UpdatedAddress", result.Address);
        }



        [Test]
        public async Task Update_UserNotFound_Exception_Test()
        {
            var updatecustomer = new Customer
            {
                Address = "UpdatedAddress",
            };
            var exception = Assert.ThrowsAsync<Exception>
                (async () => await repository.Update(16, updatecustomer));
            Assert.IsNotNull(exception);
            Assert.AreEqual("Failed Customer Update User doesn't exist", exception.Message);
        }



    }
}
