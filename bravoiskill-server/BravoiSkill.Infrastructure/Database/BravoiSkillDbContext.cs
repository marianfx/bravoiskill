﻿using BravoiSkill.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace BravoiSkill.Infrastructure.Database
{
    public class BravoiSkillDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SkillCategory> SkillCategory { get; set; }
        public DbSet<UserSkill> UserSkill { get; set; }
        public DbSet<UserBadge> UserBadge { get; set; }

        public BravoiSkillDbContext(DbContextOptions<BravoiSkillDbContext> es) : base(es) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => new { us.UserId, us.SkillId });
            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserId);
            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.Skill)
                .WithMany(s => s.SkillUsers)
                .HasForeignKey(us => us.SkillId);

            modelBuilder.Entity<UserBadge>()
                .HasKey(ub => new { ub.UserId, ub.BadgeId });
            modelBuilder.Entity<UserBadge>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBadges)
                .HasForeignKey(ub => ub.UserId);
            modelBuilder.Entity<UserBadge>()
                .HasOne(ub => ub.Badge)
                .WithMany(b => b.BadgeUsers)
                .HasForeignKey(ub => ub.BadgeId);
        }
    }
}
