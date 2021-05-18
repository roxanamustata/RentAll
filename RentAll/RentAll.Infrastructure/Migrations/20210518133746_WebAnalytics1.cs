using Microsoft.EntityFrameworkCore.Migrations;

namespace RentAll.Infrastructure.Migrations
{
    public partial class WebAnalytics1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRequestAuthenticated",
                table: "WebAnalytics",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRequestAuthenticated",
                table: "WebAnalytics");
        }
    }
}
