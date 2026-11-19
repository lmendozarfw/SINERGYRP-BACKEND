using System.Security.Cryptography;
using SinergyRP.Application.Seguridad;

namespace RfidTraceability.Infrastructure.Security;

public class HasheadorDeContrasenas : IHasheadorDeContrasenas
{
    private const int CON_ITERACIONES = 600_000;
    private const int CON_LONGITUD_SAL = 16;
    private const int CON_LONGITUD_HASH = 32;

    public string GenerarHash(string contrasena)
    {
        byte[] sal = RandomNumberGenerator.GetBytes(CON_LONGITUD_SAL);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            contrasena,
            sal,
            CON_ITERACIONES,
            HashAlgorithmName.SHA256,
            CON_LONGITUD_HASH
        );

        return string.Join(
            '.',
            "PBKDF2",
            CON_ITERACIONES,
            Convert.ToBase64String(sal),
            Convert.ToBase64String(hash)
        );
    }

    public bool Verificar(string contrasena, string hashAlmacenado)
    {
        string[] partes = hashAlmacenado.Split('.');

        if (partes.Length != 4 || partes[0] != "PBKDF2")
            return false;

        if (!int.TryParse(partes[1], out int iteraciones))
            return false;

        if (iteraciones <= 0)
            return false;

        try
        {
            byte[] sal = Convert.FromBase64String(partes[2]);
            byte[] hashOriginal = Convert.FromBase64String(partes[3]);

            byte[] hashCalculado = Rfc2898DeriveBytes.Pbkdf2(
                contrasena,
                sal,
                iteraciones,
                HashAlgorithmName.SHA256,
                hashOriginal.Length
            );

            return CryptographicOperations.FixedTimeEquals(
                hashOriginal,
                hashCalculado
            );
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
