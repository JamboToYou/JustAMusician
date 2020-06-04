using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class AddedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bands_users_LeaderUserId",
                table: "bands");

            migrationBuilder.RenameColumn(
                name: "LeaderUserId",
                table: "bands",
                newName: "leaderId");

            migrationBuilder.RenameIndex(
                name: "IX_bands_LeaderUserId",
                table: "bands",
                newName: "IX_bands_leaderId");

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_OwnerUserId",
                table: "orders",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_bands_users_leaderId",
                table: "bands",
                column: "leaderId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_OwnerUserId",
                table: "orders",
                column: "OwnerUserId",
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
                name: "FK_orders_users_OwnerUserId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_OwnerUserId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "leaderId",
                table: "bands",
                newName: "LeaderUserId");

            migrationBuilder.RenameIndex(
                name: "IX_bands_leaderId",
                table: "bands",
                newName: "IX_bands_LeaderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_bands_users_LeaderUserId",
                table: "bands",
                column: "LeaderUserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
