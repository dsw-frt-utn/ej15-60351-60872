using Dsw2026Ej15.Api.Middleware;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dsw2026Ej15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;DataBase=Dsw2026Ej15;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Dsw2026Ej15DbContext>( options =>
            {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IPersistence, PersistenceEF>();
            builder.Services.AddHealthChecks();
            //var services = new ServiceCollection();

            var app = builder.Build();

            //var serviceProvider = services.BuildServiceProvider();
            //var persistencia = serviceProvider.GetService<IPersistence>();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Dsw2026Ej15DbContext>();
                context.Database.Migrate();
                context.SeedFromJson(); // método de extensión
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.MapHealthChecks("/health-check");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
