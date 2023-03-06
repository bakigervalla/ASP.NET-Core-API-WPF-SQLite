using Microsoft.EntityFrameworkCore;
using Solid.SqliteProvider.DomainModel;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Solid.SqliteProvider
{
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        { }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>().HasKey(m => m.Id);
            builder.Entity<Recipient>().HasKey(m => m.Id);

            //builder.Entity<Package>()
            //    .HasMany(c => c.Recipients)
            //    .HasForeignKey<int>(s => s.CurrentGradeId);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<Recipient>();
            updateUpdatedProperty<Package>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedRecipient =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
        }
    }
}