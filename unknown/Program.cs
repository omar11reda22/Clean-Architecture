
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using unknown.Models;

namespace unknown
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("key");
            // Add services to the container.
            builder.Services.AddDbContext<ManytomanyContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connection , option => option.EnableRetryOnFailure()));
            builder.Services.AddControllers();
            builder.Services.AddIdentity<ApplicationUsers,IdentityRole>().AddEntityFrameworkStores<ManytomanyContext>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           // builder.Services.AddCors(op => op.AddPolicy());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();
            app.MapControllers();

            app.Run();
        }
    }
}
