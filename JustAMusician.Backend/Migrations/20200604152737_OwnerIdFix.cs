using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class OwnerIdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_OwnerUserId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "orders",
                newName: "ownerId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_OwnerUserId",
                table: "orders",
                newName: "IX_orders_ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_ownerId",
                table: "orders",
                column: "ownerId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_ownerId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ownerId",
                table: "orders",
                newName: "OwnerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_ownerId",
                table: "orders",
                newName: "IX_orders_OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_OwnerUserId",
                table: "orders",
                column: "OwnerUserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
