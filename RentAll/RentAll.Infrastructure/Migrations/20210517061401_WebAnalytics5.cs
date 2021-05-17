using Microsoft.EntityFrameworkCore.Migrations;

namespace RentAll.Infrastructure.Migrations
{
    public partial class WebAnalytics5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentLength",
                table: "WebAnalytics");

            migrationBuilder.DropColumn(
                name: "IsRequestAuthenticated",
                table: "WebAnalytics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ContentLength",
                table: "WebAnalytics",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequestAuthenticated",
                table: "WebAnalytics",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
