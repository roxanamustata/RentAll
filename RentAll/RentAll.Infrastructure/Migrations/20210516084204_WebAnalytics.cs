using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentAll.Infrastructure.Migrations
{
    public partial class WebAnalytics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Floors_FloorId",
                table: "Units");

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WebAnalytics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestIPAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequestAuthenticated = table.Column<bool>(type: "bit", nullable: false),
                    ContentLength = table.Column<byte>(type: "tinyint", nullable: false),
                    BrowserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrowserVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebAnalytics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leases_CenterId",
                table: "Leases",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Centers_CenterId",
                table: "Leases",
                column: "CenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Floors_FloorId",
                table: "Units",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Centers_CenterId",
                table: "Leases");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Floors_FloorId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "WebAnalytics");

            migrationBuilder.DropIndex(
                name: "IX_Leases_CenterId",
                table: "Leases");

            migrationBuilder.AlterColumn<int>(
                name: "FloorId",
                table: "Units",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Floors_FloorId",
                table: "Units",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
