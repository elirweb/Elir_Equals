using System;
using System.Collections.Generic;
using System.Text;
using Equals_Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equals_Infra.Mapping
{
    public class File : Common.MapBase<Equals_Domain.Entites.File>
    {
        public override void Configure(EntityTypeBuilder<Equals_Domain.Entites.File> builder)
        {
            base.Configure(builder);

            builder.ToTable("File");
            builder.Property(p => p.Id).HasColumnName("IdFile");

            builder.HasOne(u => u.Acquirer).WithOne(c => c.File).
             HasForeignKey<Equals_Domain.Entites.File>(b => b.IdAcquirer);

            builder.HasIndex(c => c.IdAcquirer).IsUnique(false);
        }
    }
}
