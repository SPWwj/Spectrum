using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spectrum.Server.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpectrumProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Special = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Offer = table.Column<double>(type: "float", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    SpectrumPortalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpectrumProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpectrumProduct_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpectrumProduct_SpectrumPortal_SpectrumPortalId",
                        column: x => x.SpectrumPortalId,
                        principalTable: "SpectrumPortal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpectrumProduct_ProductCategoryId",
                table: "SpectrumProduct",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpectrumProduct_SpectrumPortalId",
                table: "SpectrumProduct",
                column: "SpectrumPortalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpectrumProduct");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
