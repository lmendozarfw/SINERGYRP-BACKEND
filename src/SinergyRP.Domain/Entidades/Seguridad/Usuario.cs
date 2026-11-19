using SinergyRP.Domain.Guardias;

namespace SinergyRP.Domain.Entidades.Seguridad;

public class Usuario : EntidadBase, IEliminacionLogica, ICreacionActualizacion, ICreacionActualizacionPor
{
    public string Codigo {get; private set;} = string.Empty;
    public string Nombre {get; private set;} = string.Empty;
    public string PasswordHash {get; private set;} = string.Empty;
    public bool Activo {get; private set;}
    public DateTime? FechaEliminacion {get; private set;}
    public bool DebeCambiarPassword {get; private set;}
    public DateTime? UltimoAcceso {get; private set;}
    public DateTime FechaCreacion {get; private set;}
    public DateTime? FechaActualizacion {get; private set;}
    public int? CreadoPorId {get; private set;}
    public int? ActualizadoPorId {get; private set;}

    public Usuario(string codigo, string nombre, string passwordHash, int? creadoPorId)
    {
        Codigo = GuardiaDominio.NoEsNullOVacio(codigo, nameof(codigo));
        Nombre = GuardiaDominio.NoEsNullOVacio(nombre, nameof(nombre));
        PasswordHash = GuardiaDominio.NoEsNullOVacio(passwordHash, nameof(passwordHash));
        CreadoPorId = GuardiaDominio.IdNumerico(creadoPorId, nameof(creadoPorId));
        FechaCreacion = DateTime.UtcNow;
    }
}