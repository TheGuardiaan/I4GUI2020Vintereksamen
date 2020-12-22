using Microsoft.EntityFrameworkCore.Migrations;

namespace TheHotel.Migrations
{
    public partial class NoChildrenRange0_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NoChildren",
                table: "Guests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NoChildren",
                table: "Guests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
