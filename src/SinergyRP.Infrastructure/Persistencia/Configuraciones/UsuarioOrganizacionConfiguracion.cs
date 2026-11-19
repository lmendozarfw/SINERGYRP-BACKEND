using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinergyRP.Domain.Entidades.Seguridad;

namespace SinergyRP.Infrastructure.Persistencia.Configuraciones;

public class UsuarioOrganizacionConfiguracion : IEntityTypeConfiguration<UsuarioOrganizacion>
{
    public void Configure(EntityTypeBuilder<UsuarioOrganizacion> builder)
    {
        builder.ToTable("usuarios_organizaciones");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.UsuarioId).IsRequired();
        builder.Property(x => x.OrganizacionId).IsRequired();
        builder.Property(x => x.FechaCreacion).IsRequired();

        builder.HasIndex(x => new { x.UsuarioId, x.OrganizacionId }).IsUnique();

        builder.HasOne(x => x.Usuario)
            .WithMany()
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Organizacion)
            .WithMany()
            .HasForeignKey(x => x.OrganizacionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Roles)
            .WithOne()
            .HasForeignKey(x => x.UsuarioOrganizacionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Permisos)
            .WithOne()
            .HasForeignKey(x => x.UsuarioOrganizacionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
