using Microsoft.EntityFrameworkCore.Migrations;

namespace I4GUI2020Vintereksamen.Data.Migrations
{
    public partial class ProfilePicture_ChanceTo_ImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePath",
                table: "AspNetUsers",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "AspNetUsers",
                newName: "ProfilePath");
        }
    }
}
