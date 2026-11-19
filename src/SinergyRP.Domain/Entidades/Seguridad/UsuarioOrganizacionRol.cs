using SinergyRP.Domain.Guardias;

namespace SinergyRP.Domain.Entidades.Seguridad;

public class UsuarioOrganizacionRol
{
    public int UsuarioOrganizacionId {get; private set;}
    public int RolId {get; private set;}

    public Rol Rol {get; private set;} = null!;

    public UsuarioOrganizacionRol(int usuarioOrganizacionId, int rolId)
    {
        UsuarioOrganizacionId = GuardiaDominio.IdNumerico(usuarioOrganizacionId, nameof(usuarioOrganizacionId));
        RolId = GuardiaDominio.IdNumerico(rolId, nameof(rolId));
    }
}
