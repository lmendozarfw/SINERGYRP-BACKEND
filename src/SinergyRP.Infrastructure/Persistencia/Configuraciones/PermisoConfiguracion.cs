using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinergyRP.Domain.Entidades.Seguridad;

namespace SinergyRP.Infrastructure.Persistencia.Configuraciones;

public class PermisoConfiguracion : IEntityTypeConfiguration<Permiso>
{
    public void Configure(EntityTypeBuilder<Permiso> builder)
    {
        builder.ToTable("Permisos");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Codigo).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Modulo).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Nombre).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Descripcion).HasMaxLength(500);

        builder.Property(x => x.Activo).IsRequired();
        builder.Property(x => x.FechaCreacion).IsRequired();
        builder.Property(x => x.CreadoPor).HasMaxLength(100);
        builder.Property(x => x.ActualizadoPor).HasMaxLength(100);

        builder.HasIndex(x => x.Codigo).IsUnique();
    }
}
