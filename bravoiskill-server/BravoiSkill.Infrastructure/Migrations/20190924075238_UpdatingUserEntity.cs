using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BravoiSkill.Infrastructure.Migrations
{
    public partial class UpdatingUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BadgeId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BadgeId1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skype",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    BadgeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.BadgeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BadgeId1",
                table: "Users",
                column: "BadgeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Badge_BadgeId1",
                table: "Users",
                column: "BadgeId1",
                principalTable: "Badge",
                principalColumn: "BadgeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Badge_BadgeId1",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Badge");

            migrationBuilder.DropIndex(
                name: "IX_Users_BadgeId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BadgeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BadgeId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Skype",
                table: "Users");
        }
    }
}
