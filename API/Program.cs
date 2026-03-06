using Repositories.Dapper;
using Repositories.Contracts;
using Services.Contracts;
using Services.Services.BlogService;

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
            //"Sisteme þunu diyoruz: Biri senden Interface isterse, ona git Iplemente edilmiþ class'dan bir tane örnek ver."

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); //appsetting.json'daki Database Connection String'ini okuduk.
            builder.Services.AddScoped<IBlogRepository>(sp => new BlogRepository(connectionString));

            builder.Services.AddScoped<IBlogService, BlogService>(); //Servisi DI yaptýk.


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
