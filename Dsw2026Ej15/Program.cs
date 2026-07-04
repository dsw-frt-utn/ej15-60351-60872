using Dsw2026Ej15.Data;
using Dsw2026Ej15.Api.Middleware;
using Dsw2026Ej15.Api.Configurations;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Application.Interfaces;
using Dsw2026Ej15.Application.Services;

namespace Dsw2026Ej15.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAppAuthentication(builder.Configuration);
        builder.Services.AddApplicationPersistence(builder.Configuration);
        builder.Services.AddControllers();

        builder.Services.AddSwaggerConfiguration();
        builder.Services.AddHealthChecks();
        builder.Services.AddScoped<IPersistence, PersistenceEf>();
        builder.Services.AddScoped<IDoctorServices, DoctorService>();
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        builder.Services.AddSingleton<JwtService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseAuthorization();

        app.MapControllers();
        app.MapHealthChecks("/health-check");

        app.LoadSpecialityData();

        app.Run();
    }
}
