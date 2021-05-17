using Microsoft.EntityFrameworkCore.Migrations;

namespace RentAll.Infrastructure.Migrations
{
    public partial class WebAnalytics2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrowserName",
                table: "WebAnalytics");

            migrationBuilder.DropColumn(
                name: "BrowserType",
                table: "WebAnalytics");

            migrationBuilder.DropColumn(
                name: "BrowserVersion",
                table: "WebAnalytics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrowserName",
                table: "WebAnalytics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrowserType",
                table: "WebAnalytics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrowserVersion",
                table: "WebAnalytics",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
