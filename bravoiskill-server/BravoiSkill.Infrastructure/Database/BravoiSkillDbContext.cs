using BravoiSkill.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace BravoiSkill.Infrastructure.Database
{
    public class BravoiSkillDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Badge> Badges { get; set; }

        public BravoiSkillDbContext(DbContextOptions<BravoiSkillDbContext> es) : base(es) {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
