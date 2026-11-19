using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinergyRP.Domain.Entidades.Seguridad;

namespace SinergyRP.Infrastructure.Persistencia.Configuraciones;

public class RolConfiguracion : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("roles");

        builder
        .HasKey(x => x.Id);
        
        builder
        .Property(x => x.Id)
        .ValueGeneratedOnAdd();

        builder
        .Property(x => x.Codigo)
        .HasMaxLength(50)
        .IsRequired();
        
        builder
        .Property(x => x.Nombre)
        .HasMaxLength(200)
        .IsRequired();
        
        builder
        .Property(x => x.Descripcion)
        .HasMaxLength(500);

        builder
        .Property(x => x.Activo)
        .IsRequired();
        
        builder
        .Property(x => x.FechaCreacion)
        .IsRequired();
        
        builder
        .Property(x => x.CreadoPorId);
        
        builder
        .Property(x => x.ActualizadoPorId);

        builder
        .HasIndex(x => x.Codigo)
        .IsUnique();
    }
}
