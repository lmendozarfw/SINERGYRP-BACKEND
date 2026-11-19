namespace SinergyRP.Application.Seguridad;

public sealed class OpcionesJWT
{
    public const string CON_NOMBRE_SECCION = "Jwt";

    public string Emisor { get; set; } = string.Empty;
    public string Audiencia { get; set; } = string.Empty;
    public string ClaveSecreta { get; set; } = string.Empty;
    public int MinutosExpiracion { get; set; } = 60;
    public int DiasExpiracionTokenRenovacion { get; set; } = 7;
}
