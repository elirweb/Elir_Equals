using System;
using System.Collections.Generic;
using System.Text;
using Equals_Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equals_Infra.Mapping
{
    public class Acquirer : Common.MapBase<Equals_Domain.Entites.Acquirer>
    {
        public override void Configure(EntityTypeBuilder<Equals_Domain.Entites.Acquirer> builder)
        {
            base.Configure(builder);
            builder.ToTable("Acquirer");
            builder.Property(p => p.Id).HasColumnName("IdAcquirer");
        }
    }
}
