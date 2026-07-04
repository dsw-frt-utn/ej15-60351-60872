using System.Security.Authentication;
using Dsw2026Ej15.Application.Dtos;
using Dsw2026Ej15.Application.Interfaces;

namespace Dsw2026Ej15.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly JwtService _jwtService;

    public AuthenticationService(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public async Task<string> Authentication(AuthenticationModel.Request request)
    {
        if (!request.User.Equals("admin", StringComparison.InvariantCultureIgnoreCase) ||
            !request.Password.Equals("12345"))
            throw new AuthenticationException();
        return _jwtService.GenerateToken(request.User, "administrador");
    }
}
