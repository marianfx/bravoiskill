using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BravoiSkill.Infrastructure.Migrations
{
    public partial class AddSmallAndLargeSkillCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillCategories_CategoryId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "SkillCategories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Skills",
                newName: "LargeCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CategoryId",
                table: "Skills",
                newName: "IX_Skills_LargeCategoryId");

            migrationBuilder.CreateTable(
                name: "SkillSmallCategories",
                columns: table => new
                {
                    SmallCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSmallCategories", x => x.SmallCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SkillLargeCategories",
                columns: table => new
                {
                    LargeCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    SmallCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLargeCategories", x => x.LargeCategoryId);
                    table.ForeignKey(
                        name: "FK_SkillLargeCategories_SkillSmallCategories_SmallCategoryId",
                        column: x => x.SmallCategoryId,
                        principalTable: "SkillSmallCategories",
                        principalColumn: "SmallCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillLargeCategories_SmallCategoryId",
                table: "SkillLargeCategories",
                column: "SmallCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillLargeCategories_LargeCategoryId",
                table: "Skills",
                column: "LargeCategoryId",
                principalTable: "SkillLargeCategories",
                principalColumn: "LargeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillLargeCategories_LargeCategoryId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "SkillLargeCategories");

            migrationBuilder.DropTable(
                name: "SkillSmallCategories");

            migrationBuilder.RenameColumn(
                name: "LargeCategoryId",
                table: "Skills",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_LargeCategoryId",
                table: "Skills",
                newName: "IX_Skills_CategoryId");

            migrationBuilder.CreateTable(
                name: "SkillCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategories", x => x.CategoryId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillCategories_CategoryId",
                table: "Skills",
                column: "CategoryId",
                principalTable: "SkillCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
