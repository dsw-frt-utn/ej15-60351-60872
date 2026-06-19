using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Domain.Exceptions;

namespace Dsw2026Ej15.Api.Controllers
{
    public class DoctorsController : AppController
    {
        private IPersistence _persistence;

        public DoctorsController(IPersistence persistence)
        {
            _persistence = persistence;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorModel.Request request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenseNumber))
            {
                throw new ValidationException("Nombre y matricula son requeridos"); 
            }

            var speciality = _persistence.GetSpecialityById(request.SpecialityId);

            if (speciality == null)
            {
                throw new ValidationException("La especialidad no existe");
            }

            var doctor = new Doctor(request.Name, request.LicenseNumber, speciality);
            _persistence.AddDoctor(doctor);

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = _persistence.GetDoctor().Select(d => new DoctorModel.Response(d.Id, d.Name, d.LicenseNumber, d.Speciality.Name)); ;

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(Guid id)
        {
            var doctor = _persistence.GetDoctorById(id);

            if (doctor is null || !doctor.IsActive)
            {
                throw new ValidationException("El medico no fue encontrado");
            }

            var response = new DoctorModel.Response(doctor.Id, doctor.Name, doctor.LicenseNumber, doctor.Speciality.Name);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            var doctor = _persistence.GetDoctorById(id);

            if (doctor is null || doctor.IsActive == false)
            {
                throw new ValidationException("El medico no esta activo o no fue encontrado");
            }

            _persistence.DeleteDoctor(doctor);

            return NoContent();
        }
    }
}
