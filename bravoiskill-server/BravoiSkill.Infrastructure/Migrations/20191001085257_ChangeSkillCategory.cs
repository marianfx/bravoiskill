using Microsoft.EntityFrameworkCore.Migrations;

namespace BravoiSkill.Infrastructure.Migrations
{
    public partial class ChangeSkillCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillCategories_SkillCategories_Skill_CategoryCategoryId",
                table: "SkillCategories");

            migrationBuilder.DropIndex(
                name: "IX_SkillCategories_Skill_CategoryCategoryId",
                table: "SkillCategories");

            migrationBuilder.DropColumn(
                name: "Skill_CategoryCategoryId",
                table: "SkillCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "SkillCategories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategories_ParentId",
                table: "SkillCategories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillCategories_SkillCategories_ParentId",
                table: "SkillCategories",
                column: "ParentId",
                principalTable: "SkillCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillCategories_SkillCategories_ParentId",
                table: "SkillCategories");

            migrationBuilder.DropIndex(
                name: "IX_SkillCategories_ParentId",
                table: "SkillCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "SkillCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Skill_CategoryCategoryId",
                table: "SkillCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategories_Skill_CategoryCategoryId",
                table: "SkillCategories",
                column: "Skill_CategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillCategories_SkillCategories_Skill_CategoryCategoryId",
                table: "SkillCategories",
                column: "Skill_CategoryCategoryId",
                principalTable: "SkillCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
