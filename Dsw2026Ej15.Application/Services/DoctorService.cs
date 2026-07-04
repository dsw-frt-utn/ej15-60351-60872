using Dsw2026Ej15.Application.Dtos;
using Dsw2026Ej15.Application.Interfaces;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Exceptions;

namespace Dsw2026Ej15.Application.Services;

public class DoctorService : IDoctorServices
{
    private PersistenceInMemory _persistence;

    public DoctorService(PersistenceInMemory persistence)
    {
        _persistence = persistence;
    }

    public async Task CreateDoctor(DoctorModel.Request request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenseNumber))
        {
            throw new ValidationException("Nombre y matricula son requeridos");
        }

        var speciality = await _persistence.GetSpecialityById(request.SpecialityId);

        if (speciality is null)
        {
            throw new ValidationException("La especialidad no existe");
        }

        var doctor = new Doctor(request.Name, request.LicenseNumber, speciality);
        await _persistence.SaveDoctor(doctor);
    }


    public async Task<IEnumerable<DoctorModel.Response>> GetAllDoctor()
    {
        var doctorDb = await _persistence.GetAllDoctor();
        var doctorModels = doctorDb.Select(d => new DoctorModel.Response
            (
                d.Name,
                d.LicenseNumber,
                d.Speciality?.Name,
                d.Id
            ));
        return doctorModels;
    }

    public async Task<DoctorModel.Response> GetDoctorById(Guid id)
    {
        var doctor = await GetDoctor(id);
        return new DoctorModel.Response
        (
            doctor.Name,
            doctor.LicenseNumber,
            doctor.Speciality?.Name,
            doctor.Id
        );
    }

    public async Task DeleteDoctor(Guid id)
    {
        var doctor = await GetDoctor(id)!;
        doctor.Deactivate();
    }

    private async Task<Doctor?> GetDoctor(Guid id)
    {
        return await _persistence.GetDoctorById(id) ?? throw new EntityNotFoundException("Medico no encontrado");
    }
}
