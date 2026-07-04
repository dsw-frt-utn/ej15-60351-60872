using System.Reflection.Metadata.Ecma335;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Dsw2026Ej15.Api.Configurations;

public static class PersistenceConfiguarationExtensions
{
    public static IServiceCollection AddApplicationPersistence(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connetingString = configuration.GetConnectionString("DefaultConnection");

        // Add services to the container.
        services.AddDbContext<Dsw2026Ej15DbContext>(options =>
        {
            options.UseSqlServer(connetingString);
        });
        return services;
    }

    public static IHost LoadSpecialityData(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var context = serviceProvider.GetRequiredService<Dsw2026Ej15DbContext>();
        context.SeedWorkSpecialities(@"specialities.json");
        return host;
    }
}
