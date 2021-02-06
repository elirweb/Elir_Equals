using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equals_Infra.Common
{
    public class MapBase<T> : IEntityTypeConfiguration<T> where T : Equals_Domain.Base.Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
