using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spectrum.Server.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortalID",
                table: "SpectrumUsers");

            migrationBuilder.DropColumn(
                name: "PortalName",
                table: "SpectrumUsers");

            migrationBuilder.AddColumn<int>(
                name: "SpectrumPortalLimit",
                table: "SpectrumUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SpectrumPortal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpectrumPortal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpectrumPortal_SpectrumUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "SpectrumUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpectrumPortal_ApplicationUserId",
                table: "SpectrumPortal",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpectrumPortal");

            migrationBuilder.DropColumn(
                name: "SpectrumPortalLimit",
                table: "SpectrumUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "PortalID",
                table: "SpectrumUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PortalName",
                table: "SpectrumUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
