using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinergyRP.Domain.Entidades.Seguridad;

namespace SinergyRP.Infrastructure.Persistencia.Configuraciones;

public class RolPermisoConfiguracion : IEntityTypeConfiguration<RolPermiso>
{
    public void Configure(EntityTypeBuilder<RolPermiso> builder)
    {
        builder.ToTable("RolesPermisos");

        builder.HasKey(x => new { x.RolId, x.PermisoId });

        builder.HasOne<Rol>()
            .WithMany()
            .HasForeignKey(x => x.RolId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Permiso>()
            .WithMany()
            .HasForeignKey(x => x.PermisoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
