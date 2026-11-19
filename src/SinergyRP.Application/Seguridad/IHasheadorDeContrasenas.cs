namespace SinergyRP.Application.Seguridad;

public interface IHasheadorDeContrasenas
{
    string GenerarHash(string constrasena);

    bool Verificar(string constrasena, string constrasenaHash);
}
