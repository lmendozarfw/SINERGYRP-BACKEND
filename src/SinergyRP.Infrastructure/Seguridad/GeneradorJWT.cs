using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SinergyRP.Application.Seguridad;

namespace RfidTraceability.Infrastructure.Security;

public sealed class GeneradorJWT(IOptions<OpcionesJWT> opciones) : IGeneradorJWT
{
    public JwtResultado Generate(
        Guid UsuarioId,
        Guid OrganizacionId,
        string Username,
        IEnumerable<string> roles)
    {
        var jwt = opciones.Value;
        var ahora = DateTime.UtcNow;
        var expiracion = ahora.AddMinutes(jwt.MinutosExpiracion);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, UsuarioId.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.UniqueName, Username),
            new("organizacionId", OrganizacionId.ToString()),
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var clave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.ClaveSecreta));
        var credenciales = new SigningCredentials(clave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwt.Emisor,
            audience: jwt.Audiencia,
            claims: claims,
            notBefore: ahora,
            expires: expiracion,
            signingCredentials: credenciales);

        return new JwtResultado(new JwtSecurityTokenHandler().WriteToken(token), expiracion);
    }
}
