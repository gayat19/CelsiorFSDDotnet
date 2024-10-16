using EFCoreFirstAPI.Contexts;
using EFCoreFirstAPI.Interfaces;
using EFCoreFirstAPI.Models;
using EFCoreFirstAPI.Repositories;
using EFCoreFirstAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFirstAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Contexts
            builder.Services.AddDbContext<ShoppingContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region OtherServices
            builder.Services.AddAutoMapper(typeof(Customer));
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, Customer>, CustomerRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<ICustomerBasicService, CustomerBasicService>();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
