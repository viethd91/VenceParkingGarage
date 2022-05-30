using Microsoft.EntityFrameworkCore.Migrations;

namespace VenceParkingGarage.Infrastructure.Persistence.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ParkingLevels",
                columns: new[] { "Id", "Level" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "Color", "LicensePlate", "RequiredParkingSpace", "Type" },
                values: new object[,]
                {
                    { 1, "Toyota", "Red", "A-123", 0, 1 },
                    { 2, "Honda", "White", "A-456", 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "ParkingSlots",
                columns: new[] { "Id", "Number", "ParkingLevelId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "ParkingSlots",
                columns: new[] { "Id", "Number", "ParkingLevelId" },
                values: new object[] { 2, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingLevels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkingSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkingLevels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Vehicles");
        }
    }
}
