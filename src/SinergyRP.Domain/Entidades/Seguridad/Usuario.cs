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
    public string? CreadoPor {get; private set;}
    public string? ActualizadoPor {get; private set;}

    public Usuario(string codigo, string nombre, string passwordHash, string? creadoPor)
    {
        Codigo = GuardiaDominio.NoEsNullOVacio(codigo, nameof(codigo));
        Nombre = GuardiaDominio.NoEsNullOVacio(nombre, nameof(nombre));
        PasswordHash = GuardiaDominio.NoEsNullOVacio(passwordHash, nameof(passwordHash));
        CreadoPor = GuardiaDominio.NormalizarString(creadoPor, nameof(creadoPor));
        FechaCreacion = DateTime.UtcNow;
    }
}