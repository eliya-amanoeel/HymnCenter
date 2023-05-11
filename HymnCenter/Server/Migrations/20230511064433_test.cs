using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HymnCenter.Server.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Hymns",
                columns: table => new
                {
                    HymnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lyrics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleting = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymns", x => x.HymnId);
                });

            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Footer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleting = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleting = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryHymn",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    HymnsHymnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryHymn", x => new { x.CategoriesCategoryId, x.HymnsHymnId });
                    table.ForeignKey(
                        name: "FK_CategoryHymn_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryHymn_Hymns_HymnsHymnId",
                        column: x => x.HymnsHymnId,
                        principalTable: "Hymns",
                        principalColumn: "HymnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HymnListing",
                columns: table => new
                {
                    HymnsHymnId = table.Column<int>(type: "int", nullable: false),
                    ListingsListingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HymnListing", x => new { x.HymnsHymnId, x.ListingsListingId });
                    table.ForeignKey(
                        name: "FK_HymnListing_Hymns_HymnsHymnId",
                        column: x => x.HymnsHymnId,
                        principalTable: "Hymns",
                        principalColumn: "HymnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HymnListing_Listings_ListingsListingId",
                        column: x => x.ListingsListingId,
                        principalTable: "Listings",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryHymn_HymnsHymnId",
                table: "CategoryHymn",
                column: "HymnsHymnId");

            migrationBuilder.CreateIndex(
                name: "IX_HymnListing_ListingsListingId",
                table: "HymnListing",
                column: "ListingsListingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryHymn");

            migrationBuilder.DropTable(
                name: "HymnListing");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Hymns");

            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}
