using Microsoft.EntityFrameworkCore.Migrations;

namespace RentAll.Infrastructure.Migrations
{
    public partial class AddDescriptionToCenter : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Centers",
                type: "nvarchar(max)",
                nullable: true);

            

            

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
                name: "FK_Units_Floors_FloorId",
                table: "Units");

            

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Centers");

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
