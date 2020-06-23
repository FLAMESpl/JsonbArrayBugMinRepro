using Microsoft.EntityFrameworkCore;

namespace JsonbArrayBugMinRepro
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder) =>
            builder.Entity<Model>(b =>
            {
                b.Property(x => x.JsonbArray).HasColumnType("jsonb[]").IsRequired();
            });

        protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
            builder.UseNpgsql("Host=127.0.0.1;Database=repro;Username=postgres;Password=postgres");
    }
}
