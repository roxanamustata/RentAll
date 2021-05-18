using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentAll.Infrastructure.Migrations
{
    public partial class WebAnalytics2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ContentLength",
                table: "WebAnalytics",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "WebAnalytics",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentLength",
                table: "WebAnalytics");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "WebAnalytics");
        }
    }
}
