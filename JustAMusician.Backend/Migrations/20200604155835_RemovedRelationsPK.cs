using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class RemovedRelationsPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserInstrument");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGenre");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserBand");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BandGenre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserInstrument",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserGenre",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserBand",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BandGenre",
                nullable: false,
                defaultValue: 0);
        }
    }
}
