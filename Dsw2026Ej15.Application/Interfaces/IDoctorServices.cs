
using Dsw2026Ej15.Application.Dtos;

namespace Dsw2026Ej15.Application.Interfaces;

public interface IDoctorServices
{
    Task CreateDoctor(DoctorModel.Request request);
    Task<IEnumerable<DoctorModel.Response>> GetAllDoctor();
    Task<DoctorModel.Response> GetDoctorById(Guid id);
    Task DeleteDoctor(Guid id);
} 
