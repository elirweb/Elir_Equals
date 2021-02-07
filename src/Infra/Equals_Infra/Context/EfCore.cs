using Equals_Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Equals_Infra.Context
{
    public class EfCore: DbContext
    {
        public DbSet<Acquirer> Acquirer { get; set; }
        public DbSet<File> File { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Equals_Util.WebConfig.GetStrinConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Mapping.Acquirer());
            modelBuilder.ApplyConfiguration(new Mapping.File());

        }

    }
}
