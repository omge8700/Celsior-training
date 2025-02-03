using BankingApplication.Context;
using BankingApplication.Interface;
using BankingApplication.Models;
using BankingApplication.Repositories;
using BankingApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace BankingApplication

{
    public class Program
    {
        public static void Main(string[] args)
        {



            var builder = WebApplication.CreateBuilder(args);


            
            builder.Services.AddDbContext<BankingContext>(options =>
            {
               options.UseSqlServer(builder.Configuration.GetConnectionString("DemoConnection"));
            });



            //builder.Services.AddDbContext<BankingContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoConnection"));
            //});

            // Add services to the container.
            builder.Services.AddScoped<IRepository<string, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IRepository<int, Customer>, CustomerRepository>();


            builder.Services.AddScoped<ICustomerService, CustomerService>();

            // adding controllers

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()  // Allows all origins (you can restrict this to specific domains)
                          .AllowAnyMethod()  // Allows all HTTP methods (GET, POST, PUT, DELETE, etc.)
                          .AllowAnyHeader(); // Allows any headers (like Authorization)
                });
            });



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }

}
