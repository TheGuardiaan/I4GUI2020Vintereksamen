using Microsoft.EntityFrameworkCore.Migrations;

namespace TheHotel.Migrations
{
    public partial class roodidNullebale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCheckIns_Guests_GuestId",
                table: "FoodCheckIns");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCheckIns_Rooms_RoomId",
                table: "FoodCheckIns");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "FoodCheckIns",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "FoodCheckIns",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCheckIns_Guests_GuestId",
                table: "FoodCheckIns",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCheckIns_Rooms_RoomId",
                table: "FoodCheckIns",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCheckIns_Guests_GuestId",
                table: "FoodCheckIns");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCheckIns_Rooms_RoomId",
                table: "FoodCheckIns");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "FoodCheckIns",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "FoodCheckIns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCheckIns_Guests_GuestId",
                table: "FoodCheckIns",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCheckIns_Rooms_RoomId",
                table: "FoodCheckIns",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
