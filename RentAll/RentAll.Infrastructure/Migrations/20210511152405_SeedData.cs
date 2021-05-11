using Microsoft.EntityFrameworkCore.Migrations;

namespace RentAll.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AbstractUnits",
                columns: new[] { "Id", "Area", "Discriminator", "MonthlyMaintenanceCostSqm", "MonthlyRentSqm", "UnitCode" },
                values: new object[,]
                {
                    { 3, 5000.0, "OfficeUnit", 3.0, 15.0, "A1" },
                    { 4, 500.0, "OfficeUnit", 3.0, 30.0, "A2" }
                });

            migrationBuilder.InsertData(
                table: "AbstractUnits",
                columns: new[] { "Id", "Area", "Discriminator", "MonthlyMarketingFeeSqm", "MonthlyRentSqm", "UnitCode" },
                values: new object[,]
                {
                    { 1, 500.0, "RetailUnit", 1.0, 15.0, "A1" },
                    { 2, 50.0, "RetailUnit", 1.0, 30.0, "A2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AbstractUnits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AbstractUnits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AbstractUnits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AbstractUnits",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
