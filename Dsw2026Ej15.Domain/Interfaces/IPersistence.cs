using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        Speciality? GetSpecialityById(Guid id);
        IEnumerable<Doctor> GetDoctor();
        Doctor? GetDoctorById(Guid id);
        void AddDoctor(Doctor doctor);
        void DeleteDoctor(Doctor doctor);
    }
}
