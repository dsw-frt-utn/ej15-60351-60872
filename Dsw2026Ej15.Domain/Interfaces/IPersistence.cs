using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        Task<Speciality?> GetSpecialityById(Guid id);
        Task <IEnumerable<Doctor>> GetDoctor();
        Task <Doctor?> GetDoctorById(Guid id);
        Task AddDoctor(Doctor doctor);
        Task DeleteDoctor(Doctor doctor);
    }
}
