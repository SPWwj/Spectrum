using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spectrum.Server.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_SpectrumMission_SpectrumMissionId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_SpectrumUsers_ApplicationUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_SpectrumPortal_SpectrumUsers_ApplicationUserId",
                table: "SpectrumPortal");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "SpectrumPortal",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "SpectrumMissionId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_SpectrumMission_SpectrumMissionId",
                table: "Order",
                column: "SpectrumMissionId",
                principalTable: "SpectrumMission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_SpectrumUsers_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId",
                principalTable: "SpectrumUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpectrumPortal_SpectrumUsers_ApplicationUserId",
                table: "SpectrumPortal",
                column: "ApplicationUserId",
                principalTable: "SpectrumUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_SpectrumMission_SpectrumMissionId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_SpectrumUsers_ApplicationUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_SpectrumPortal_SpectrumUsers_ApplicationUserId",
                table: "SpectrumPortal");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "SpectrumPortal",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpectrumMissionId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_SpectrumMission_SpectrumMissionId",
                table: "Order",
                column: "SpectrumMissionId",
                principalTable: "SpectrumMission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_SpectrumUsers_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId",
                principalTable: "SpectrumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpectrumPortal_SpectrumUsers_ApplicationUserId",
                table: "SpectrumPortal",
                column: "ApplicationUserId",
                principalTable: "SpectrumUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
