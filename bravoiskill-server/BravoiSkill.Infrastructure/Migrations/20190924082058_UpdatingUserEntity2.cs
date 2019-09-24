using Microsoft.EntityFrameworkCore.Migrations;

namespace BravoiSkill.Infrastructure.Migrations
{
    public partial class UpdatingUserEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Badge_BadgeId1",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Badge",
                table: "Badge");

            migrationBuilder.RenameTable(
                name: "Badge",
                newName: "Badges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badges",
                table: "Badges",
                column: "BadgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Badges_BadgeId1",
                table: "Users",
                column: "BadgeId1",
                principalTable: "Badges",
                principalColumn: "BadgeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Badges_BadgeId1",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Badges",
                table: "Badges");

            migrationBuilder.RenameTable(
                name: "Badges",
                newName: "Badge");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badge",
                table: "Badge",
                column: "BadgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Badge_BadgeId1",
                table: "Users",
                column: "BadgeId1",
                principalTable: "Badge",
                principalColumn: "BadgeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
