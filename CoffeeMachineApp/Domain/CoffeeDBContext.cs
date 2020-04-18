namespace Domain
{
    using Domain.Model;
    using Microsoft.EntityFrameworkCore;

    public class CoffeeDBContext : DbContext
    {
        public CoffeeDBContext(DbContextOptions<CoffeeDBContext> options)
            : base(options)
        {
        }

        public DbSet<Badge> Badges { get; set; }

        public DbSet<ClientSelection> ClientSelections { get; set; }

        public DbSet<DrinkType> DrinkTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Badge>()
                .HasOne(b => b.ClientSelection)
                .WithOne(b => b.Badge)
                .HasForeignKey<ClientSelection>(e => e.BadgeId);

            //modelBuilder.Entity<Badge>().ToTable("Badges");
            //modelBuilder.Entity<ClientSelection>().ToTable("Badges");
        }

    }
}
