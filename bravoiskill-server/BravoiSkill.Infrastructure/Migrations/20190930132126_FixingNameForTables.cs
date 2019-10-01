using Microsoft.EntityFrameworkCore.Migrations;

namespace BravoiSkill.Infrastructure.Migrations
{
    public partial class FixingNameForTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_SkillCategory_CategoryId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Badges_BadgeId",
                table: "UserBadge");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Users_UserId",
                table: "UserBadge");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Department_DepartmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_Skill_SkillId",
                table: "UserSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkill_Users_UserId",
                table: "UserSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSkill",
                table: "UserSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBadge",
                table: "UserBadge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillCategory",
                table: "SkillCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "UserSkill",
                newName: "UserSkills");

            migrationBuilder.RenameTable(
                name: "UserBadge",
                newName: "UserBadges");

            migrationBuilder.RenameTable(
                name: "SkillCategory",
                newName: "SkillCategories");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkill_SkillId",
                table: "UserSkills",
                newName: "IX_UserSkills_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBadge_BadgeId",
                table: "UserBadges",
                newName: "IX_UserBadges_BadgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_CategoryId",
                table: "Skills",
                newName: "IX_Skills_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSkills",
                table: "UserSkills",
                columns: new[] { "UserId", "SkillId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBadges",
                table: "UserBadges",
                columns: new[] { "UserId", "BadgeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillCategories",
                table: "SkillCategories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillCategories_CategoryId",
                table: "Skills",
                column: "CategoryId",
                principalTable: "SkillCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadges_Badges_BadgeId",
                table: "UserBadges",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "BadgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadges_Users_UserId",
                table: "UserBadges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Skills_SkillId",
                table: "UserSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkills_Users_UserId",
                table: "UserSkills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillCategories_CategoryId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadges_Badges_BadgeId",
                table: "UserBadges");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadges_Users_UserId",
                table: "UserBadges");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Skills_SkillId",
                table: "UserSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSkills_Users_UserId",
                table: "UserSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSkills",
                table: "UserSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBadges",
                table: "UserBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillCategories",
                table: "SkillCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "UserSkills",
                newName: "UserSkill");

            migrationBuilder.RenameTable(
                name: "UserBadges",
                newName: "UserBadge");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "SkillCategories",
                newName: "SkillCategory");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_UserSkills_SkillId",
                table: "UserSkill",
                newName: "IX_UserSkill_SkillId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBadges_BadgeId",
                table: "UserBadge",
                newName: "IX_UserBadge_BadgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CategoryId",
                table: "Skill",
                newName: "IX_Skill_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSkill",
                table: "UserSkill",
                columns: new[] { "UserId", "SkillId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBadge",
                table: "UserBadge",
                columns: new[] { "UserId", "BadgeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillCategory",
                table: "SkillCategory",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_SkillCategory_CategoryId",
                table: "Skill",
                column: "CategoryId",
                principalTable: "SkillCategory",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Badges_BadgeId",
                table: "UserBadge",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "BadgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Users_UserId",
                table: "UserBadge",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Department_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_Skill_SkillId",
                table: "UserSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkill_Users_UserId",
                table: "UserSkill",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
