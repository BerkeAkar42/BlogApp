using Repositories.Dapper;
using Repositories.Contracts;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            //Dependency Injection (DI) - Baðýmlýlýklarý azaltan, bir servis kaydý.
            //builder.Services.AddScoped<IBlogRepository, BlogRepository>(); // "Sisteme þunu diyoruz: Biri senden IBlogRepository isterse, ona git BlogRepository'den bir tane örnek ver."


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
