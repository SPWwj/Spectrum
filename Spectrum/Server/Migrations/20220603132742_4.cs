using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spectrum.Server.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PortalAddress",
                table: "SpectrumPortal",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SpectrumPortal_PortalAddress",
                table: "SpectrumPortal",
                column: "PortalAddress",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SpectrumPortal_PortalAddress",
                table: "SpectrumPortal");

            migrationBuilder.AlterColumn<string>(
                name: "PortalAddress",
                table: "SpectrumPortal",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
