using BlogPlatform.Context;
using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Repository;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


#region Contexts
builder.Services.AddDbContext<BlogPlatformContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"));
});
#endregion

#region Repositories
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Blogger>, BloggerRepository>();
builder.Services.AddScoped<IRepository<Reader>, ReaderRepository>();
builder.Services.AddScoped<IRepository<BlogPost>, BlogPostRepository>();
builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
#endregion

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


