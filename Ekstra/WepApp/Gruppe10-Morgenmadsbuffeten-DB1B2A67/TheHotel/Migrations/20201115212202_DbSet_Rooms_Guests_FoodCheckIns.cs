using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheHotel.Migrations
{
    public partial class DbSet_Rooms_Guests_FoodCheckIns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNr = table.Column<string>(nullable: false),
                    RoomSize = table.Column<int>(nullable: false),
                    Price = table.Column<string>(nullable: true),
                    RoomStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DoB = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<int>(maxLength: 6, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    CheckInDay = table.Column<DateTime>(nullable: false),
                    CheckOutDay = table.Column<DateTime>(nullable: false),
                    NoAdults = table.Column<int>(nullable: false),
                    NoChildren = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                    table.ForeignKey(
                        name: "FK_Guests_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodCheckIns",
                columns: table => new
                {
                    FoodCheckInId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDate = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    GuestId = table.Column<int>(nullable: true),
                    Adults = table.Column<bool>(nullable: false),
                    Children = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCheckIns", x => x.FoodCheckInId);
                    table.ForeignKey(
                        name: "FK_FoodCheckIns_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodCheckIns_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodCheckIns_GuestId",
                table: "FoodCheckIns",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCheckIns_RoomId",
                table: "FoodCheckIns",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_RoomId",
                table: "Guests",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodCheckIns");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
