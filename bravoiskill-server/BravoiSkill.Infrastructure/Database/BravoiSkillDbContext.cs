using BravoiSkill.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace BravoiSkill.Infrastructure.Database
{
    public class BravoiSkillDbContext : DbContext
    {
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<SkillReview> SkillReviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }

        public BravoiSkillDbContext(DbContextOptions<BravoiSkillDbContext> es) : base(es) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => new { us.UserId, us.SkillId });
            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.Skill)
                .WithMany(s => s.SkillUsers)
                .HasForeignKey(us => us.SkillId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserBadge>()
                .HasKey(ub => new { ub.UserId, ub.BadgeId });
            modelBuilder.Entity<UserBadge>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBadges)
                .HasForeignKey(ub => ub.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserBadge>()
                .HasOne(ub => ub.Badge)
                .WithMany(b => b.BadgeUsers)
                .HasForeignKey(ub => ub.BadgeId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SkillCategory>()
                .HasOne(p => p.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.ParentId);
        }
    }
}
