using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class FixGenreHierarchy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genres_genres_GenreId1",
                table: "genres");

            migrationBuilder.RenameColumn(
                name: "GenreId1",
                table: "genres",
                newName: "parentGenreId");

            migrationBuilder.RenameIndex(
                name: "IX_genres_GenreId1",
                table: "genres",
                newName: "IX_genres_parentGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_genres_genres_parentGenreId",
                table: "genres",
                column: "parentGenreId",
                principalTable: "genres",
                principalColumn: "genreId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_genres_genres_parentGenreId",
                table: "genres");

            migrationBuilder.RenameColumn(
                name: "parentGenreId",
                table: "genres",
                newName: "GenreId1");

            migrationBuilder.RenameIndex(
                name: "IX_genres_parentGenreId",
                table: "genres",
                newName: "IX_genres_GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_genres_genres_GenreId1",
                table: "genres",
                column: "GenreId1",
                principalTable: "genres",
                principalColumn: "genreId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
