using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheHotel.Migrations
{
    public partial class GuestEntiFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoB",
                table: "Guests");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Guests",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<int>(
                name: "NoChildren",
                table: "Guests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Guests",
                type: "int",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NoChildren",
                table: "Guests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DoB",
                table: "Guests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
