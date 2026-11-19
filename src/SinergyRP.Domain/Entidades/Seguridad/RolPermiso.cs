using SinergyRP.Domain.Guardias;

namespace SinergyRP.Domain.Entidades.Seguridad;

public class RolPermiso
{
    public int RolId {get; private set;}
    public int PermisoId {get; private set;}

    public RolPermiso(int rolId, int permisoId)
    {
        RolId = GuardiaDominio.IdNumerico(rolId, nameof(rolId));
        PermisoId = GuardiaDominio.IdNumerico(permisoId, nameof(permisoId));
    }
}
