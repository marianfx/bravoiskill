using Microsoft.EntityFrameworkCore.Migrations;

namespace BravoiSkill.Infrastructure.Migrations
{
    public partial class EditSkillProp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillLargeCategories_SkillSmallCategories_SmallCategoryId",
                table: "SkillLargeCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillLargeCategories_LargeCategoryId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_SkillLargeCategories_SmallCategoryId",
                table: "SkillLargeCategories");

            migrationBuilder.DropColumn(
                name: "SmallCategoryId",
                table: "SkillLargeCategories");

            migrationBuilder.RenameColumn(
                name: "LargeCategoryId",
                table: "Skills",
                newName: "SmallCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_LargeCategoryId",
                table: "Skills",
                newName: "IX_Skills_SmallCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "LargeCategoryId",
                table: "SkillSmallCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SkillSmallCategories_LargeCategoryId",
                table: "SkillSmallCategories",
                column: "LargeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillSmallCategories_SmallCategoryId",
                table: "Skills",
                column: "SmallCategoryId",
                principalTable: "SkillSmallCategories",
                principalColumn: "SmallCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSmallCategories_SkillLargeCategories_LargeCategoryId",
                table: "SkillSmallCategories",
                column: "LargeCategoryId",
                principalTable: "SkillLargeCategories",
                principalColumn: "LargeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillSmallCategories_SmallCategoryId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSmallCategories_SkillLargeCategories_LargeCategoryId",
                table: "SkillSmallCategories");

            migrationBuilder.DropIndex(
                name: "IX_SkillSmallCategories_LargeCategoryId",
                table: "SkillSmallCategories");

            migrationBuilder.DropColumn(
                name: "LargeCategoryId",
                table: "SkillSmallCategories");

            migrationBuilder.RenameColumn(
                name: "SmallCategoryId",
                table: "Skills",
                newName: "LargeCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_SmallCategoryId",
                table: "Skills",
                newName: "IX_Skills_LargeCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "SmallCategoryId",
                table: "SkillLargeCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SkillLargeCategories_SmallCategoryId",
                table: "SkillLargeCategories",
                column: "SmallCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillLargeCategories_SkillSmallCategories_SmallCategoryId",
                table: "SkillLargeCategories",
                column: "SmallCategoryId",
                principalTable: "SkillSmallCategories",
                principalColumn: "SmallCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillLargeCategories_LargeCategoryId",
                table: "Skills",
                column: "LargeCategoryId",
                principalTable: "SkillLargeCategories",
                principalColumn: "LargeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
