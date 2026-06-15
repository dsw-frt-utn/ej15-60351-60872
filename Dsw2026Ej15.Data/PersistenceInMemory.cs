using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using System.Collections.Generic;
using Dsw2026Ej15.Domain;

namespace Dsw2026Ej15.Data
{
    internal class PersistenceInMemory : IPercistence
    {
        private readonly List<Doctor> _doctors = new List<Doctor>();
        private readonly List<Speciality> _specialities = new List<Speciality>();

        public PersistenceInMemory()
        {
            LoadSpecialities();
        }

        private void LoadSpecialities()
        {
            string filePath = "specialities.json";

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);

                var list = JsonSerializer.Deserialize<List<Speciality>>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (list != null)
                {
                    _specialities.AddRange(list);
                }
            }
            else
            {
                _specialities.Add(new Speciality(Guid.NewGuid(),"General","Descripcion general"));
            }
        }

        public IEnumerable<Speciality> GetSpecialities()
        {
            return _specialities;
        }

        public Speciality? GetSpecialityById(Guid id)
        {
            return _specialities.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Doctor> GetDoctor()
        {
            return _doctors;
        }

        public Doctor? GetDoctorById(Guid id)
        {
            return _doctors.FirstOrDefault(d => d.Id == id);
        }

        public void AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public bool DeleteDoctor(Guid id)
        {
            var doctor = GetDoctorById(id);
            if (doctor == null) return false;

            _doctors.Remove(doctor);
            return true;
        }
    }
}
