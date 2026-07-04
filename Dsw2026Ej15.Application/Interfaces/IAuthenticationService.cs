using Dsw2026Ej15.Application.Dtos;

namespace Dsw2026Ej15.Application.Interfaces;

public interface IAuthenticationService
{
    Task<string> Authentication(AuthenticationModel.Request request);
}
