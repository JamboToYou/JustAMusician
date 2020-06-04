using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JustAMusician.Backend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "instrumentType",
                columns: table => new
                {
                    instrumentTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instrumentType", x => x.instrumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: false),
                    body = table.Column<string>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.orderId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nickname = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    passwordHash = table.Column<string>(nullable: false),
                    salt = table.Column<byte[]>(maxLength: 16, nullable: false),
                    about = table.Column<string>(nullable: false),
                    signedUpAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tagId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.tagId);
                    table.ForeignKey(
                        name: "FK_tags_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bands",
                columns: table => new
                {
                    bandId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LeaderUserId = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bands", x => x.bandId);
                    table.ForeignKey(
                        name: "FK_bands_users_LeaderUserId",
                        column: x => x.LeaderUserId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "instruments",
                columns: table => new
                {
                    instrumentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    TypeInstrumentTypeId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instruments", x => x.instrumentId);
                    table.ForeignKey(
                        name: "FK_instruments_instrumentType_TypeInstrumentTypeId",
                        column: x => x.TypeInstrumentTypeId,
                        principalTable: "instrumentType",
                        principalColumn: "instrumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_instruments_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "links",
                columns: table => new
                {
                    linkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    url = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_links", x => x.linkId);
                    table.ForeignKey(
                        name: "FK_links_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    genreId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: false),
                    BandId = table.Column<int>(nullable: true),
                    GenreId1 = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.genreId);
                    table.ForeignKey(
                        name: "FK_genres_bands_BandId",
                        column: x => x.BandId,
                        principalTable: "bands",
                        principalColumn: "bandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_genres_genres_GenreId1",
                        column: x => x.GenreId1,
                        principalTable: "genres",
                        principalColumn: "genreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_genres_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBand",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BandId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBand", x => new { x.UserId, x.BandId });
                    table.ForeignKey(
                        name: "FK_UserBand_bands_BandId",
                        column: x => x.BandId,
                        principalTable: "bands",
                        principalColumn: "bandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBand_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BandGenre",
                columns: table => new
                {
                    BandId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandGenre", x => new { x.BandId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BandGenre_bands_BandId",
                        column: x => x.BandId,
                        principalTable: "bands",
                        principalColumn: "bandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandGenre_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "genreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGenre",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGenre", x => new { x.UserId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_UserGenre_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "genreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGenre_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BandGenre_GenreId",
                table: "BandGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_bands_LeaderUserId",
                table: "bands",
                column: "LeaderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_genres_BandId",
                table: "genres",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_genres_GenreId1",
                table: "genres",
                column: "GenreId1");

            migrationBuilder.CreateIndex(
                name: "IX_genres_UserId",
                table: "genres",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_instruments_TypeInstrumentTypeId",
                table: "instruments",
                column: "TypeInstrumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_instruments_UserId",
                table: "instruments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_links_UserId",
                table: "links",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tags_OrderId",
                table: "tags",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBand_BandId",
                table: "UserBand",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGenre_GenreId",
                table: "UserGenre",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandGenre");

            migrationBuilder.DropTable(
                name: "instruments");

            migrationBuilder.DropTable(
                name: "links");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "UserBand");

            migrationBuilder.DropTable(
                name: "UserGenre");

            migrationBuilder.DropTable(
                name: "instrumentType");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "bands");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
