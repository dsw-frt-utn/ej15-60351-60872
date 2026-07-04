using System.IO;
using System.Text.Json;
using Dsw2026Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dsw2026Ej15.Data.Extensions;

public static class DbContextExtensions
{
    public static void SeedWorkSpecialities(this Dsw2026Ej15DbContext context, string jsonPath)
    {
        if (!File.Exists(jsonPath)) return;

        if (context.Specialities.Any()) return;

        var jsonData = File.ReadAllText(jsonPath);
        var specialities = JsonSerializer.Deserialize<List<Speciality>>(jsonData);

        if (specialities != null && specialities.Any())
        {
            context.Specialities.AddRange(specialities);
            context.SaveChanges();
        }
    }
}
