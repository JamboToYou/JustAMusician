using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class FixUserInstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instruments_users_UserId",
                table: "instruments");

            migrationBuilder.DropIndex(
                name: "IX_instruments_UserId",
                table: "instruments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "instruments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "instruments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_instruments_UserId",
                table: "instruments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_instruments_users_UserId",
                table: "instruments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
