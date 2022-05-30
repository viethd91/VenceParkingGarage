using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VenceParkingGarage.Infrastructure.Persistence.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(maxLength: 10, nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    RequiredParkingSpace = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSlots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    ParkingLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSlots_ParkingLevels_ParkingLevelId",
                        column: x => x.ParkingLevelId,
                        principalTable: "ParkingLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSlotVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingSlotId = table.Column<int>(nullable: false),
                    ParkedVehicle_VehicleId = table.Column<int>(nullable: true),
                    ParkedVehicle_LicensePlate = table.Column<string>(maxLength: 10, nullable: true),
                    ParkedVehicle_ParkedTime = table.Column<DateTime>(nullable: true),
                    CurrentlyParked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSlotVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSlotVehicles_ParkingSlots_ParkingSlotId",
                        column: x => x.ParkingSlotId,
                        principalTable: "ParkingSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSlots_ParkingLevelId",
                table: "ParkingSlots",
                column: "ParkingLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSlotVehicles_ParkingSlotId",
                table: "ParkingSlotVehicles",
                column: "ParkingSlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSlotVehicles");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "ParkingSlots");

            migrationBuilder.DropTable(
                name: "ParkingLevels");
        }
    }
}
