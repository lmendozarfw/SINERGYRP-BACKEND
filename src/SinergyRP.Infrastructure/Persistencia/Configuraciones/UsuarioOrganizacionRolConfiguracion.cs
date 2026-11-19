using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinergyRP.Domain.Entidades.Seguridad;

namespace SinergyRP.Infrastructure.Persistencia.Configuraciones;

public class UsuarioOrganizacionRolConfiguracion : IEntityTypeConfiguration<UsuarioOrganizacionRol>
{
    public void Configure(EntityTypeBuilder<UsuarioOrganizacionRol> builder)
    {
        builder.ToTable("usuarios_organizaciones_roles");

        builder.HasKey(x => new { x.UsuarioOrganizacionId, x.RolId });

        builder.HasOne(x => x.Rol)
            .WithMany()
            .HasForeignKey(x => x.RolId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
