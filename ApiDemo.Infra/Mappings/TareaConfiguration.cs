using APIDemo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDemo.Infra.Mappings
{
    /// <summary>
    /// Clase configuration para entity framework de Tarea
    /// </summary>
    public partial class TareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> entity)
        {
            entity.HasKey(e => e.IdTarea);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.EstadoTarea).HasColumnType("smallint");

            entity.HasOne(d => d.Usuario)
                .WithMany(p => p.listaTarea)
                .HasForeignKey(fk => fk.IdUsuario);
                
            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Tarea> entity);
    }
}
