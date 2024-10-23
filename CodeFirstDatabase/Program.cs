using CodeFirstDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var provider = builder.Services.BuildServiceProvider();
            var config = provider.GetService<IConfiguration>();
            builder.Services.AddDbContext<StudentDBContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}