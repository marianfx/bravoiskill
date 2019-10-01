using Microsoft.EntityFrameworkCore.Migrations;

namespace BravoiSkill.Infrastructure.Migrations
{
    public partial class RemovedBadgeUsersLinkLeftover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Badges_BadgeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BadgeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BadgeId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BadgeId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BadgeId",
                table: "Users",
                column: "BadgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Badges_BadgeId",
                table: "Users",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "BadgeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
