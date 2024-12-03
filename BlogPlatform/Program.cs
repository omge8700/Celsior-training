using BlogPlatform.Context;
using BlogPlatform.Interfaces;
using BlogPlatform.Models;
using BlogPlatform.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BlogPlatform.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
#endregion


#region Contexts
builder.Services.AddDbContext<BlogPlatformContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"));
});
#endregion

#region Repositories
builder.Services.AddScoped<IRepository<string,User>, UserRepository>();
builder.Services.AddScoped<IRepository<int,Blogger>, BloggerRepository>();
//builder.Services.AddScoped<BloggerRepository>();

//builder.Services.AddScoped<IRepository<Reader>, ReaderRepository>();
//builder.Services.AddScoped<IRepository<BlogPost>, BlogPostRepository>();
//builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
#endregion

#region Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
        };
    });
#endregion
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IBloggerService, BloggerService>();
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


