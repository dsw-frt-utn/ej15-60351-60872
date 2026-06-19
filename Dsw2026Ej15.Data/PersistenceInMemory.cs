using System.Text.Json;
using System.Collections.Generic;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Data.Dtos;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence
    {
        private List<Doctor> _doctors = [];
        private List<Speciality> _specialities = [];

        public PersistenceInMemory()
        {
            LoadSpecialities();
        }

        private void LoadSpecialities()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Sources", "specialities.json");
                var json = File.ReadAllText(jsonPath);
                var specialities = JsonSerializer.Deserialize<List<SpecialityDto>>(json,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? [];
                _specialities = [.. specialities.Select(s => new Speciality(s.id, s.Name, s.Description))];
            }
            catch(Exception)
            {

            }
        }

        public Speciality? GetSpecialityById(Guid id)
        {
            return _specialities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Doctor> GetDoctor() => _doctors.Where(d => d.IsActive);

        public Doctor? GetDoctorById(Guid id)
        {
            return _doctors.SingleOrDefault(d => d.Id == id);
        }

        public void AddDoctor(Doctor doctor) => _doctors.Add(doctor);

        public void DeleteDoctor(Doctor doctor)
        {
            var index = _doctors.FindIndex(d => d.Id == doctor.Id);

            if (index >= 0)
            {
                _doctors[index].IsActive = false;
            }
        }
    }
}
