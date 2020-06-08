using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MolodegBackend.Models;

namespace MolodegBackend
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Placard> Placards { get; set; }
        public DbSet<Supporter> Supporter { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Placard>().HasKey(u => u.Id);
            builder.Entity<Placard>().Property(p => p.Name).IsRequired();
            builder.Entity<Placard>().Property(p => p.ShortDescription).IsRequired();
            builder.Entity<Placard>().Property(p => p.ShortDescription).IsRequired();
            builder.Entity<Placard>().Property(p => p.UserId).IsRequired();
            builder.Entity<Placard>().HasOne(p => p.User).WithMany(b => b.Placards).HasForeignKey(i => i.UserId);

            builder.Entity<Supporter>().HasKey(u => u.Id);
            builder.Entity<Supporter>().HasOne(p => p.User).WithMany(b => b.Supporters).HasForeignKey(i => i.UserId);
            builder.Entity<Supporter>().HasOne(p => p.Placard).WithMany(b => b.Supporters).HasForeignKey(i => i.CardId);
        }
    }
}
