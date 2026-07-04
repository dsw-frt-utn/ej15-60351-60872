using Dsw2026Ej15.Application.Dtos;
using Dsw2026Ej15.Application.Interfaces;
using Dsw2026Ej15.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2026Ej15.Api.Controllers;

[Route("user")]
public class UserController : AppController
{
    private readonly IAuthenticationService _service;

    public UserController(IAuthenticationService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Authenticate(AuthenticationModel.Request request)
    {
        var token = await _service.Authentication(request);
        return Ok(token);
    }
}
