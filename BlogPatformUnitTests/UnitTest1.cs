using BlogPlatform.Context;
using BlogPlatform.Models;
using BlogPlatform.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BlogPatformUnitTests
{
    public class Tests
    {
        DbContextOptions options;
        BlogPlatformContext context;
        UserRepository repository;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<BlogPlatformContext>()
                .UseInMemoryDatabase("addtest")
                .Options;
            context = new BlogPlatformContext((DbContextOptions<BlogPlatformContext>)options);
            repository = new UserRepository(context);
        }

        [Test]

        public async  Task  AddUserTest_Success()

        {
            var user = new User()
            {
                email = "johnnynaorem7@gmail.com",
                password = Encoding.UTF8.GetBytes("TestPassword"),
                HashKey = Encoding.UTF8.GetBytes("TestHashKey"),
                role = "blogger",
                username = "omge8700"
            };

            var newusers = await repository.Add(user);
            //assert
            Assert.IsNotNull(newusers);
            Assert.AreEqual(1, newusers.userId);

        }




    }
}