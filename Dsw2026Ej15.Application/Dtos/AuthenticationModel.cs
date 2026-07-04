namespace Dsw2026Ej15.Application.Dtos;

public record AuthenticationModel
{
    public record Request(string User, string Password);
}
