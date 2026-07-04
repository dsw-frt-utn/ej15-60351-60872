using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Application.Dtos;
using Dsw2026Ej15.Application.Interfaces;
using Dsw2026Ej15.Application.Services;

namespace Dsw2026Ej15.Api.Controllers;

public class DoctorsController : AppController
{
    private readonly IDoctorServices _service;

    public DoctorsController(IDoctorServices service)
    {
        _service = service;
    }
    
    [HttpPost()]
    public async Task<IActionResult> CreateDoctor(DoctorModel.Request request)
    {
        await _service.CreateDoctor(request);
        return Created();
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors = await _service.GetAllDoctor();
        return Ok(doctors);
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById([FromRoute]Guid id)
    {
        var doctor = await _service.GetDoctorById(id);
        return Ok(doctor);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor([FromRoute]Guid id)
    {
        
        await _service.DeleteDoctor(id);
        return NoContent();
    }
}
