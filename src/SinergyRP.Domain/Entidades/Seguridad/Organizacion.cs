using SinergyRP.Domain.Entidades;
using SinergyRP.Domain.Guardias;

namespace SinergyRP.Domain.Entidades.Seguridad;

public class Organizacion : EntidadBase, IEliminacionLogica, ICreacionActualizacion, ICreacionActualizacionPor
{
    public string Codigo {get; private set;} = string.Empty;
    public string Nombre {get; private set;} = string.Empty;
    public bool Activo {get; private set;}
    public DateTime? FechaEliminacion {get; private set;}
    public DateTime FechaCreacion {get; private set;}
    public DateTime? FechaActualizacion {get; private set;}
    public string? CreadoPor {get; private set;}
    public string? ActualizadoPor {get; private set;}

    public Organizacion(string codigo, string nombre, string? creadoPor)
    {
        Codigo = GuardiaDominio.NoEsNullOVacio(codigo, nameof(codigo));
        Nombre = GuardiaDominio.NoEsNullOVacio(nombre, nameof(nombre));
        CreadoPor = GuardiaDominio.NormalizarString(creadoPor, nameof(creadoPor));
        Activo = true;
        FechaCreacion = DateTime.UtcNow;
    }
}
