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
    public int? CreadoPorId {get; private set;}
    public int? ActualizadoPorId {get; private set;}

    public Organizacion(string codigo, string nombre, int? creadoPorId)
    {
        Codigo = GuardiaDominio.NoEsNullOVacio(codigo, nameof(codigo));
        Nombre = GuardiaDominio.NoEsNullOVacio(nombre, nameof(nombre));
        CreadoPorId = GuardiaDominio.IdNumerico(creadoPorId, nameof(creadoPorId));
        Activo = true;
        FechaCreacion = DateTime.UtcNow;
    }
}
