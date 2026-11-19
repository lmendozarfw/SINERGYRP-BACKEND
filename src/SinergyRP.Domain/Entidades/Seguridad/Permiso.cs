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
    public int? CreadoPorId {get; private set;}
    public int? ActualizadoPorId {get; private set;}

    public Permiso(string codigo, string modulo, string nombre, string? descripcion, int? creadoPorId)
    {
        Codigo = GuardiaDominio.NoEsNullOVacio(codigo, nameof(codigo));
        Modulo = GuardiaDominio.NoEsNullOVacio(modulo, nameof(modulo));
        Nombre = GuardiaDominio.NoEsNullOVacio(nombre, nameof(nombre));
        Descripcion = GuardiaDominio.NormalizarString(descripcion, nameof(descripcion));
        CreadoPorId = GuardiaDominio.IdNumerico(creadoPorId, nameof(creadoPorId));
        Activo = true;
        FechaCreacion = DateTime.UtcNow;
    }
}
