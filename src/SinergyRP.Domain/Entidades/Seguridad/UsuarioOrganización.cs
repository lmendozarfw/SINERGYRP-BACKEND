using System.Collections.ObjectModel;
using SinergyRP.Domain.Guardias;

namespace SinergyRP.Domain.Entidades.Seguridad;

public class UsuarioOrganizacion : EntidadBase, ICreacionActualizacion
{
    public int OrganizacionId {get; private set;}
    public int UsuarioId {get; private set;}
    public DateTime FechaCreacion {get; private set;}
    public DateTime? FechaActualizacion {get; private set;}

    // navegaciones
    public Usuario Usuario {get; private set;} = null!;
    public Organizacion Organizacion {get; private set;} = null!;

    private readonly Collection<UsuarioOrganizacionRol> _roles = new();
    public IReadOnlyCollection<UsuarioOrganizacionRol> Roles => _roles;

    private readonly Collection<UsuarioOrganizacionPermiso> _permisos = new();
    public IReadOnlyCollection<UsuarioOrganizacionPermiso> Permisos => _permisos;

    public UsuarioOrganizacion(int organizacionId, int usuarioId)
    {
        OrganizacionId = GuardiaDominio.IdNumerico(organizacionId, nameof(organizacionId));
        UsuarioId = GuardiaDominio.IdNumerico(usuarioId, nameof(usuarioId));
        FechaCreacion = DateTime.UtcNow;
    }
}
