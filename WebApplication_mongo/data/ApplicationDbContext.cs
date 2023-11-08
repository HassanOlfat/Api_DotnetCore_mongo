using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace WebApplication_mongo.data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<test> tests { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public DbSet<BankInfoDriver> BankInfoDrivers { get; set; }

        public static ApplicationDbContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                .Options);
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Driver>().ToCollection("Driver").HasKey(x => x._id);
            modelBuilder.Entity<BankInfoDriver>(entity =>
            {
                entity.HasOne(x => x.Driver)
                .WithMany(x => x.BankInfos)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);


            });

        }
    }
}
