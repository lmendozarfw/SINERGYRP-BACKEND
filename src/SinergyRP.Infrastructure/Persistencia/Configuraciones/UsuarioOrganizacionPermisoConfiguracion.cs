using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinergyRP.Domain.Entidades.Seguridad;

namespace SinergyRP.Infrastructure.Persistencia.Configuraciones;

public class UsuarioOrganizacionPermisoConfiguracion : IEntityTypeConfiguration<UsuarioOrganizacionPermiso>
{
    public void Configure(EntityTypeBuilder<UsuarioOrganizacionPermiso> builder)
    {
        builder.ToTable("UsuariosOrganizacionesPermisos");

        builder.HasKey(x => new { x.UsuarioOrganizacionId, x.PermisoId });

        builder.Property(x => x.Concedido).IsRequired();

        builder.HasOne(x => x.Permiso)
            .WithMany()
            .HasForeignKey(x => x.PermisoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
