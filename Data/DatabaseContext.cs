using Microsoft.EntityFrameworkCore;
using MigrationService.Models;

namespace MigrationService.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        public DbSet<DataModel> Data { get; set; }
        public DbSet<SiglaModel> Siglas { get; set; }
        public DbSet<DataModel> DataModels { get; set; }

        //test InMemory
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiglaModel>().HasData(
                new SiglaModel { Id = 1, Sigla = "CHG", Descricao = "Câmbio CHG" },
                new SiglaModel { Id = 2, Sigla = "CHI", Descricao = "Câmbio CHI" },
                new SiglaModel { Id = 3, Sigla = "TUR", Descricao = "Câmbio TUR" }
            );
            modelBuilder.Entity<DataModel>().HasKey(dm => dm.Id);
        }
    }
}
