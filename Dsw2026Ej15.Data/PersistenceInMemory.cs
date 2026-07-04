using System.Text.Json;
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

        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            return _doctors.Where(d => d.IsActive);
        }

        public async Task<Doctor?> GetDoctorById(Guid id)
        {
            return _doctors.SingleOrDefault(d => d.Id == id && d.IsActive);
        }

        public async Task<Speciality?> GetSpecialityById(Guid id)
        {
            return _specialities.SingleOrDefault(e => e.Id == id);
        }

        public async Task<Speciality> GetSpecialityById(Guid? specialityId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            _doctors.Remove(doctor);
            _doctors.Add(doctor);
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
            catch (Exception)
            {

            }
        }
    }
}
