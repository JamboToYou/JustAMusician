using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class AddedOrderTagRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genres_users_UserId",
                table: "genres");

            migrationBuilder.DropForeignKey(
                name: "FK_tags_orders_OrderId",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "IX_tags_OrderId",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "IX_genres_UserId",
                table: "genres");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "genres");

            migrationBuilder.CreateTable(
                name: "OrderTag",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTag", x => new { x.OrderId, x.TagId });
                    table.ForeignKey(
                        name: "FK_OrderTag_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTag_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "tags",
                        principalColumn: "tagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInstrument",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstrument", x => new { x.UserId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_UserInstrument_instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "instruments",
                        principalColumn: "instrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInstrument_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTag_TagId",
                table: "OrderTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstrument_InstrumentId",
                table: "UserInstrument",
                column: "InstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTag");

            migrationBuilder.DropTable(
                name: "UserInstrument");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "tags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "genres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tags_OrderId",
                table: "tags",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_genres_UserId",
                table: "genres",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_genres_users_UserId",
                table: "genres",
                column: "UserId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tags_orders_OrderId",
                table: "tags",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
