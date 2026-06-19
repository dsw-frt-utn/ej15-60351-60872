using Dsw2026Ej15.Api.Middleware;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Interfaces;

namespace Dsw2026Ej15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();
            builder.Services.AddHealthChecks();
            //var services = new ServiceCollection();

            var app = builder.Build();

            //var serviceProvider = services.BuildServiceProvider();
            //var persistencia = serviceProvider.GetService<IPersistence>();

            if (app.Environment.IsDevelopment())
            {
                //  app.MapOpenApi();
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
