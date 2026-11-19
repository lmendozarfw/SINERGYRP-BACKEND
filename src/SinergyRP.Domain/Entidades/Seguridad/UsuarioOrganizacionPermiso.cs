using SinergyRP.Domain.Guardias;

namespace SinergyRP.Domain.Entidades.Seguridad;

public class UsuarioOrganizacionPermiso
{
    public int UsuarioOrganizacionId {get; private set;}
    public int PermisoId {get; private set;}
    public bool Concedido {get; private set;} = true;

    public Permiso Permiso {get; private set;} = null!;

    public UsuarioOrganizacionPermiso(int usuarioOrganizacionId, int permisoId)
    {
        UsuarioOrganizacionId = GuardiaDominio.IdNumerico(usuarioOrganizacionId, nameof(usuarioOrganizacionId));
        PermisoId = GuardiaDominio.IdNumerico(permisoId, nameof(permisoId));
    }
}
