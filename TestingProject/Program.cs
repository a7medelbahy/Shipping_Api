using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestingProject.Models;
using TestingProject.Repository.AdminRepo;
using TestingProject.Repository.BranchRepo;
using TestingProject.Repository.CityRepo;
using TestingProject.Repository.CustomerRepo;
using TestingProject.Repository.DeliveryRepo;
using TestingProject.Repository.EmployeeRepo;
using TestingProject.Repository.GovernroateRepo;
using TestingProject.Repository.OrderAdminRepo;
using TestingProject.Repository.OrderCustomerRepo;
using TestingProject.Repository.OrderDeliveryRepo;
using TestingProject.Repository.OrderEmployeeRepo;
using TestingProject.Repository.OrderRepo;
using TestingProject.Repository.WeightRepo;

namespace TestingProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ShippingContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("shipping"));
            });
            builder.Services.AddScoped<IBranchRepository, BranchRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IGovernroateRepository, GovernroateRepository>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<IOrderAdminRepositorycs, OrderAdminRepository>();
            builder.Services.AddScoped<IOrderEmployeeRepository, OrderEmployeeRepository>();
            builder.Services.AddScoped<IOrderCustomerRepository, OrderCustomerRepository>();
            builder.Services.AddScoped<IOrderDeliveryRepository, OrderDeliveryRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IWeightRepository, WeightRepository>();
            builder.Services.AddScoped<IAdminRepositrory, AdminRepository>();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            builder.Services.AddAuthentication(option =>
          option.DefaultAuthenticateScheme = "myschema")
              .AddJwtBearer("myschema", option =>
              {
                  string key = "Our Final Project this is developers team";
                  var secertKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

                  option.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer=false,
                      ValidateAudience=false,
                      IssuerSigningKey = secertKey,
                  };
              });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("MyAllowSpecificOrigins");

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}