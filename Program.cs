using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Online_Bookstore.Models;
using Online_Bookstore.Services;
using Online_Bookstore.Validators;
using System.Reflection;

//Return instance of WebApplicationBuilder class
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddTransient<IValidator<Book>, BookValidator>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyDataBaseConnectionString")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<BookContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IBookIRepository,BookRepository>();
builder.Services.AddTransient<IOrdersRepository,OrdersRepository>();
builder.Services.AddTransient<IOrderItemsRepository,OrderItemsRepository>();
builder.Services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddTransient<IReviewRepository,ReviewRepository>();

// Returns an instance of WebApplication
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

// Starting Server
app.Run();
