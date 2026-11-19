using SinergyRP.Domain.Entidades;
using SinergyRP.Domain.Guardias;

namespace SinergyRP.Domain.Entidades.Seguridad;

public class Rol : EntidadBase, IEliminacionLogica, ICreacionActualizacion, ICreacionActualizacionPor
{
    public string Codigo {get; private set;} = string.Empty;
    public string Nombre {get; private set;} = string.Empty;
    public string? Descripcion {get; private set;}
    public bool Activo {get; private set;}
    public DateTime? FechaEliminacion {get; private set;}
    public DateTime FechaCreacion {get; private set;}
    public DateTime? FechaActualizacion {get; private set;}
    public string? CreadoPor {get; private set;}
    public string? ActualizadoPor {get; private set;}

    public Rol(string codigo, string nombre, string? descripcion, string? creadoPor)
    {
        Codigo = GuardiaDominio.NoEsNullOVacio(codigo, nameof(codigo));
        Nombre = GuardiaDominio.NoEsNullOVacio(nombre, nameof(nombre));
        Descripcion = GuardiaDominio.NormalizarString(descripcion, nameof(descripcion));
        CreadoPor = GuardiaDominio.NormalizarString(creadoPor, nameof(creadoPor));
        Activo = true;
        FechaCreacion = DateTime.UtcNow;
    }
}
