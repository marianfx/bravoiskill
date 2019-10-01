using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BravoiSkill.Infrastructure.Migrations
{
    public partial class RemoveLargeAndSmallSkillAddSkillCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillSmallCategories_SmallCategoryId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "SkillSmallCategories");

            migrationBuilder.DropTable(
                name: "SkillLargeCategories");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "UserSkills");

            migrationBuilder.RenameColumn(
                name: "SmallCategoryId",
                table: "Skills",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_SmallCategoryId",
                table: "Skills",
                newName: "IX_Skills_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "BadgeId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Skills",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Badges",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SkillCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Skill_CategoryCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_SkillCategories_SkillCategories_Skill_CategoryCategoryId",
                        column: x => x.Skill_CategoryCategoryId,
                        principalTable: "SkillCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BadgeId",
                table: "Users",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategories_Skill_CategoryCategoryId",
                table: "SkillCategories",
                column: "Skill_CategoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillCategories_CategoryId",
                table: "Skills",
                column: "CategoryId",
                principalTable: "SkillCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Badges_BadgeId",
                table: "Users",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "BadgeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillCategories_CategoryId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Badges_BadgeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "SkillCategories");

            migrationBuilder.DropIndex(
                name: "IX_Users_BadgeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BadgeId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Skills",
                newName: "SmallCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CategoryId",
                table: "Skills",
                newName: "IX_Skills_SmallCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "UserSkills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Skills",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profiles",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Badges",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "SkillLargeCategories",
                columns: table => new
                {
                    LargeCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLargeCategories", x => x.LargeCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SkillSmallCategories",
                columns: table => new
                {
                    SmallCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    LargeCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSmallCategories", x => x.SmallCategoryId);
                    table.ForeignKey(
                        name: "FK_SkillSmallCategories_SkillLargeCategories_LargeCategoryId",
                        column: x => x.LargeCategoryId,
                        principalTable: "SkillLargeCategories",
                        principalColumn: "LargeCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }
    }
}
