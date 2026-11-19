using SinergyRP.Domain.Entidades;
using SinergyRP.Domain.Guardias;

namespace SinergyRP.Domain.Entidades.Seguridad;

public class Permiso : EntidadBase, ICreacionActualizacion, ICreacionActualizacionPor
{
    public string Codigo {get; private set;} = string.Empty;
    public string Modulo {get; private set;} = string.Empty;
    public string Nombre {get; private set;} = string.Empty;
    public string? Descripcion {get; private set;}
    public bool Activo {get; private set;}
    public DateTime FechaCreacion {get; private set;}
    public DateTime? FechaActualizacion {get; private set;}
    public string? CreadoPor {get; private set;}
    public string? ActualizadoPor {get; private set;}

    public Permiso(string codigo, string modulo, string nombre, string? descripcion, string? creadoPor)
    {
        Codigo = GuardiaDominio.NoEsNullOVacio(codigo, nameof(codigo));
        Modulo = GuardiaDominio.NoEsNullOVacio(modulo, nameof(modulo));
        Nombre = GuardiaDominio.NoEsNullOVacio(nombre, nameof(nombre));
        Descripcion = GuardiaDominio.NormalizarString(descripcion, nameof(descripcion));
        CreadoPor = GuardiaDominio.NormalizarString(creadoPor, nameof(creadoPor));
        Activo = true;
        FechaCreacion = DateTime.UtcNow;
    }
}
