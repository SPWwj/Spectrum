using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spectrum.Server.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_SpectrumMission_SpectrumMissionId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_SpectrumMissionId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SpectrumMissionId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "MissionUUID",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MissionUUID",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "SpectrumMissionId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_SpectrumMissionId",
                table: "Order",
                column: "SpectrumMissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_SpectrumMission_SpectrumMissionId",
                table: "Order",
                column: "SpectrumMissionId",
                principalTable: "SpectrumMission",
                principalColumn: "Id");
        }
    }
}
