using BravoiSkill.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace BravoiSkill.Infrastructure.Database
{
    public class BravoiSkillDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Badge> Badges { get; set; }

        public BravoiSkillDbContext(DbContextOptions<BravoiSkillDbContext> es) : base(es) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Badge>().HasData(new Badge[] {
                new Badge{Description="Cel mai nou"},
                new Badge{Description="Cel mai avansat"},
            });
            modelBuilder.Entity<Profile>().HasData(new Profile[] {
                new Profile{Description = "Administrator"},
                new Profile{Description="User"},
                new Profile{Description="Guest"}
            });
            modelBuilder.Entity<User>().HasData(new User[] {
                new User{FirstName = "Andrei", LastName="Leahu", DateOfBirth = new System.DateTime(1996, 11, 29), Email="andrei_lh@yahoo.com", ProfileId=1},
                new User{FirstName = "Lidia-Gabriela", LastName="Burca", DateOfBirth = new System.DateTime(1996, 11, 29), Email="lidia_bu@yahoo.com", ProfileId=2},
                new User{FirstName = "Olimpia", LastName="Ticlos", DateOfBirth = new System.DateTime(1996, 11, 29), Email="olimpia_ti@yahoo.com", ProfileId=3}
            });
        }
    }
}
