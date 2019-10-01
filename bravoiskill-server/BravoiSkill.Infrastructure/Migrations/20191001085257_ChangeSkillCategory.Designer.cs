﻿// <auto-generated />
using System;
using BravoiSkill.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BravoiSkill.Infrastructure.Migrations
{
    [DbContext(typeof(BravoiSkillDbContext))]
    [Migration("20191001085257_ChangeSkillCategory")]
    partial class ChangeSkillCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.Badge", b =>
                {
                    b.Property<int>("BadgeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("BadgeId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("SkillId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.SkillCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("ParentId");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentId");

                    b.ToTable("SkillCategories");
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BadgeId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Photo");

                    b.Property<int>("ProfileId");

                    b.Property<string>("Skype");

                    b.HasKey("UserId");

                    b.HasIndex("BadgeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.UserBadge", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("BadgeId");

                    b.HasKey("UserId", "BadgeId");

                    b.HasIndex("BadgeId");

                    b.ToTable("UserBadges");
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.UserSkill", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("SkillId");

                    b.HasKey("UserId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.Skill", b =>
                {
                    b.HasOne("BravoiSkill.Domain.Entities.Users.SkillCategory", "SkillCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.SkillCategory", b =>
                {
                    b.HasOne("BravoiSkill.Domain.Entities.Users.SkillCategory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.User", b =>
                {
                    b.HasOne("BravoiSkill.Domain.Entities.Users.Badge", "Badge")
                        .WithMany()
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BravoiSkill.Domain.Entities.Users.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BravoiSkill.Domain.Entities.Users.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.UserBadge", b =>
                {
                    b.HasOne("BravoiSkill.Domain.Entities.Users.Badge", "Badge")
                        .WithMany("BadgeUsers")
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BravoiSkill.Domain.Entities.Users.User", "User")
                        .WithMany("UserBadges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BravoiSkill.Domain.Entities.Users.UserSkill", b =>
                {
                    b.HasOne("BravoiSkill.Domain.Entities.Users.Skill", "Skill")
                        .WithMany("SkillUsers")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BravoiSkill.Domain.Entities.Users.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
