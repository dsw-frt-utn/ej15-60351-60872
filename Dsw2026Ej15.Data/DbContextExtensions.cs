using Dsw2026Ej15.Data.Dtos;
using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Dsw2026Ej15.Data
{
    public static class DbContextExtensions
    {
        public static void SeedFromJson(this Dsw2026Ej15DbContext context)
        {
            if (context.Specialities.Any()) return;

            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "Sources", "specialities.json");
            var json = File.ReadAllText(jsonPath);
            var dtos = JsonSerializer.Deserialize<List<SpecialityDto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];

            var specialities = dtos.Select(s => new Speciality(s.id, s.Name, s.Description));
            context.Specialities.AddRange(specialities);
            context.SaveChanges();
        }

    }
}
