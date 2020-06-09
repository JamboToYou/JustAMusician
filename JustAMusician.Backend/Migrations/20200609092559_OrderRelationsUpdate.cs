using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class OrderRelationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "orders",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "forBand",
                table: "orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "OrderGenre",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderGenre", x => new { x.OrderId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_OrderGenre_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "genreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderGenre_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderInstrument",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInstrument", x => new { x.OrderId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_OrderInstrument_instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "instruments",
                        principalColumn: "instrumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderInstrument_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderGenre_GenreId",
                table: "OrderGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInstrument_InstrumentId",
                table: "OrderInstrument",
                column: "InstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderGenre");

            migrationBuilder.DropTable(
                name: "OrderInstrument");

            migrationBuilder.DropColumn(
                name: "forBand",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "orders",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);
        }
    }
}
