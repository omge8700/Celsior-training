using BankingApplication.Context;
using BankingApplication.Exceptions;
using BankingApplication.Interface;
using BankingApplication.Models;
using BankingApplication.Repositories;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplicationUnitTesting
{
    internal class EmployeeRepositoryTest
    {
       BankingContext context;
       EmployeeRepository repository;
        DbContextOptions options;

        [SetUp]
        
        public void Setup()
        {
            options = new DbContextOptionsBuilder<BankingContext>()
                .UseInMemoryDatabase("TestAdd")
                .Options;
            context = new BankingContext((DbContextOptions<BankingContext>)options);
            repository = new EmployeeRepository(context);   

        }

        [Test]

        public async Task EmployeeAdd_Succcss_Test()
        {
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "TestOmSIngh",
                EmployeeEmail = "testsingh@gmail.com",
                Role = EmployeeRole.Zone_Manager
                

            };

            var result = await repository.Create(employee);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.EmployeeId);
        }

        [Test]

        public async Task EmployeeAddFailed_CouldNotAddException_Test()
        {
            var employee = new Employee
            {
                EmployeeId = 0,
                EmployeeName = null,
                EmployeeEmail = "testsingh@gmail.com",
                Role = EmployeeRole.Zone_Manager
            }; 

            var exception = Assert.ThrowsAsync<CouldNotAddException>
                (async () => await repository.Create(employee));
            Assert.IsNotNull(exception);
            Assert.AreEqual(" User Add Failed ", exception.Message);

        }

        [Test]

        public async Task Get_Succss_test()
        {
            var employee = new Employee
            {
                EmployeeId = 2,
                EmployeeEmail = "testom@gmail.com",
                Role = EmployeeRole.Zone_Manager,
                EmployeeName = " ZOOkeeper"
            };

            await repository.Create(employee);
            var result = await repository.Get("testom@gmail.com");
            Assert.IsNotNull(result);
            Assert.AreEqual ("testom@gmail.com", result.EmployeeEmail);
        }

        [Test]

        public async Task GetAllEmployee_Success_test()
        {

            var employee = new Employee
            {
                EmployeeId = 3,
                EmployeeEmail = "testoms@gmail.com",
                Role = EmployeeRole.Branch_Manager,
                EmployeeName = "ZooStalker"
            };

            await repository.Create(employee);
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
            var _repository = new EmployeeRepository(_context);

            var exception = Assert.ThrowsAsync<EmptyCollectionException>
                 (async () => await _repository.GetAll());
            Assert.IsNotNull(exception);
            Assert.AreEqual("Customers Collection Empty", exception.Message);
        }

        [Test]

        public async Task Delete_Succss_Test()

        {
            var employee = new Employee
            {
                EmployeeId = 7,
                EmployeeEmail = "testomsingh@gmail.com",
                Role = EmployeeRole.Branch_Manager,
                EmployeeName = "ZoosStalker"
            };

            var addedEmployee =await repository.Create(employee);
            var result = await repository.Delete(addedEmployee.EmployeeEmail);
            Assert.IsNotNull(result);

        }

      

        //update




    }




    
}
