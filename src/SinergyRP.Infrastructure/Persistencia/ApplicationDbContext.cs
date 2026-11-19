using Microsoft.EntityFrameworkCore;
using SinergyRP.Domain.Entidades.Seguridad;

namespace SinergyRP.Infrastructure.Persistencia;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Organizacion> Organizaciones => Set<Organizacion>();
    public DbSet<Permiso> Permisos => Set<Permiso>();
    public DbSet<Rol> Roles => Set<Rol>();
    public DbSet<RolPermiso> PermisosRol => Set<RolPermiso>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<UsuarioOrganizacion> OrganizacionesUsuario => Set<UsuarioOrganizacion>();
    public DbSet<UsuarioOrganizacionPermiso> PermisosUsuarioOrganizacion => Set<UsuarioOrganizacionPermiso>();
    public DbSet<UsuarioOrganizacionRol> RolesUsuarioOrganizacion => Set<UsuarioOrganizacionRol>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}