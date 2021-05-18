using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentAll.Infrastructure.Migrations
{
    public partial class WebAnalytics3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "WebAnalytics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "WebAnalytics",
                type: "datetime2",
                nullable: true);
        }
    }
}
