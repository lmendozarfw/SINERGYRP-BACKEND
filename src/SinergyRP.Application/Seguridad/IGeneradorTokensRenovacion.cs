namespace SinergyRP.Application.Seguridad;

public interface IGeneradorTokensRenovacion
{
    string Generar();

    string Hashear(string token);
}
