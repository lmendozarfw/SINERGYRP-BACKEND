using System.Security.Cryptography;
using System.Text;
using SinergyRP.Application.Seguridad;

namespace RfidTraceability.Infrastructure.Security;

public sealed class GeneradorTokensRenovacion : IGeneradorTokensRenovacion
{
    public string Generar()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    public string Hashear(string token)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(token));
        return Convert.ToHexString(bytes);
    }
}
