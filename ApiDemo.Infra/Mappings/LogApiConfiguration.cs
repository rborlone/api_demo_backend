using APIDemo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDemo.Infra.Mappings
{
    /// <summary>
    /// Clase configuration para entity framework de Tarea
    /// </summary>
    public partial class LogApiConfiguration : IEntityTypeConfiguration<LogApi>
    {
        public void Configure(EntityTypeBuilder<LogApi> entity)
        {
            entity.HasKey(e => e.Id);

        }

        partial void OnConfigurePartial(EntityTypeBuilder<LogApi> entity);
    }
}
