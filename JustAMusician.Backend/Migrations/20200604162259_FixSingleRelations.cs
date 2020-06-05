using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class FixSingleRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genres_bands_BandId",
                table: "genres");

            migrationBuilder.DropForeignKey(
                name: "FK_instruments_instrumentType_TypeInstrumentTypeId",
                table: "instruments");

            migrationBuilder.DropIndex(
                name: "IX_genres_BandId",
                table: "genres");

            migrationBuilder.DropColumn(
                name: "BandId",
                table: "genres");

            migrationBuilder.RenameColumn(
                name: "TypeInstrumentTypeId",
                table: "instruments",
                newName: "typeId");

            migrationBuilder.RenameIndex(
                name: "IX_instruments_TypeInstrumentTypeId",
                table: "instruments",
                newName: "IX_instruments_typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_instruments_instrumentType_typeId",
                table: "instruments",
                column: "typeId",
                principalTable: "instrumentType",
                principalColumn: "instrumentTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instruments_instrumentType_typeId",
                table: "instruments");

            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "instruments",
                newName: "TypeInstrumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_instruments_typeId",
                table: "instruments",
                newName: "IX_instruments_TypeInstrumentTypeId");

            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "genres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_genres_BandId",
                table: "genres",
                column: "BandId");

            migrationBuilder.AddForeignKey(
                name: "FK_genres_bands_BandId",
                table: "genres",
                column: "BandId",
                principalTable: "bands",
                principalColumn: "bandId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_instruments_instrumentType_TypeInstrumentTypeId",
                table: "instruments",
                column: "TypeInstrumentTypeId",
                principalTable: "instrumentType",
                principalColumn: "instrumentTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
