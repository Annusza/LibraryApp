using Library.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context

{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RentInfo> RentInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "DataSource=dbo.Library.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentInfo>()
                .HasOne(navigationExpression: x => x.RentedBook);

            modelBuilder.Entity<RentInfo>()
                .HasOne(navigationExpression: x => x.BorrowingUser);

            modelBuilder.Entity<Book>()
                .HasMany(navigationExpression: x => x.RentInfos);

            modelBuilder.Entity<User>()
                .HasMany(navigationExpression: x => x.RentInfos);
        }
    }
}