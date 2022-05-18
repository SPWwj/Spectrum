using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spectrum.Server.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortalID",
                table: "SpectrumUsers");

            migrationBuilder.DropColumn(
                name: "PortalName",
                table: "SpectrumUsers");
        }
    }
}
