using Microsoft.EntityFrameworkCore.Migrations;

namespace VenceParkingGarage.Infrastructure.Persistence.Migrations
{
    public partial class SeedInitialData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "ParkingSlots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ParkingSlots");
        }
    }
}
