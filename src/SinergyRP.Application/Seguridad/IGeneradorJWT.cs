namespace SinergyRP.Application.Seguridad;

public sealed record JwtResultado(string TokenAcceso, DateTime FechaExpiracion);

public interface IGeneradorJWT
{
    JwtResultado Generate(
        Guid UsuarioId,
        Guid OrganizacionId,
        string Username,
        IEnumerable<string> roles);
}
