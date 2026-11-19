namespace SinergyRP.Domain.Guardias;

public static class GuardiaDominio
{
    public static string NoEsNullOVacio(string valor, string nombreParametro)
    {
        valor = valor.Trim();
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException($"La propiedad {nombreParametro} es requerida.", nombreParametro);
        }
        return valor;
    }

    public static string? NormalizarString(string? valor, string nombreParametro)
    {
        if (!string.IsNullOrWhiteSpace(valor))
        {
            valor = valor.Trim();
        }
        return valor ?? null;
    }

    public static DateOnly? NormalizarDateOnly(DateOnly? valor, string nombreParametro)
    {
        if (valor is null)
        {
            return null;
        }
        if (valor.Value == DateOnly.MinValue)
        {
            throw new ArgumentException("The date is not valid.", nombreParametro);
        }

        return valor.Value;
    }

    public static DateOnly NormalizarDateOnly(DateOnly valor, string nombreParametro)
    {
        if (valor == DateOnly.MinValue)
        {
            throw new ArgumentException("The date is not valid.", nombreParametro);
        }

        return valor;
    }

    public static int MayorACero(int valor, string nombreParametro)
    {
        if (valor <= 0)
        {
            throw new ArgumentException($"La propiedad {nombreParametro} debe ser mayor a cero.", nombreParametro);
        }
        return valor;
    }

    public static int IdNumerico(int valor, string nombreParametro)
    {
        if (valor < 0)
        {
            throw new ArgumentException($"La propiedad {nombreParametro} debe ser un identificador válido.", nombreParametro);
        }
        return valor;
    }

    public static int? IdNumerico(int? valor, string nombreParametro)
    {
        if (valor is null)
        {
            return null;
        }
        if (valor < 0)
        {
            throw new ArgumentException($"La propiedad {nombreParametro} debe ser un identificador válido.", nombreParametro);
        }
        return valor;
    }

    public static TEnum EstaEnEnum<TEnum>(TEnum valor, string nombreParametro) where TEnum : struct, Enum
    {
        var isValid = Enum.IsDefined(typeof(TEnum), valor);
        if (!isValid)
        {
            throw new ArgumentException($"La propiedad {nombreParametro} no es un valor aceptado.", nombreParametro);
        }
        return valor;
    }

    public static DateTime DateTimeNoPredeterminada(DateTime valor, string nombreParametro)
    {
        if (valor == default)
        {
            throw new ArgumentException($"La propiedad {nombreParametro} es requerida.", nombreParametro);
        }
        return valor;
    }
}