using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Data;

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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
