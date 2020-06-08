using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class EnsureBandLeaderRelated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bands_users_leaderId",
                table: "bands");

            migrationBuilder.DropForeignKey(
                name: "FK_links_users_UserId",
                table: "links");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "links",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "leaderId",
                table: "bands",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_bands_users_leaderId",
                table: "bands",
                column: "leaderId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_links_users_UserId",
                table: "links",
                column: "UserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bands_users_leaderId",
                table: "bands");

            migrationBuilder.DropForeignKey(
                name: "FK_links_users_UserId",
                table: "links");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "links",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "leaderId",
                table: "bands",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_bands_users_leaderId",
                table: "bands",
                column: "leaderId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_links_users_UserId",
                table: "links",
                column: "UserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
