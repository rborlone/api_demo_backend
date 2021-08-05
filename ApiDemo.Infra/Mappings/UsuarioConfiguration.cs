using APIDemo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDemo.Infra.Mappings
{
    /// <summary>
    /// Clase configuration para entity framework de Usuario
    /// </summary>
    public partial class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PasswordHash).HasMaxLength(256);

            entity.Property(e => e.PasswordSalt).HasMaxLength(256);

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.listaTarea)
                .WithOne(p => p.Usuario)
                .HasForeignKey(d => d.IdUsuario).OnDelete(DeleteBehavior.Cascade);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Usuario> entity);
    }
}
