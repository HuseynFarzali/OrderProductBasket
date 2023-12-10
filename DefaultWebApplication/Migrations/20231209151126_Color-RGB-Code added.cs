using Microsoft.EntityFrameworkCore.Migrations;

namespace DefaultWebApplication.Migrations
{
    public partial class ColorRGBCodeadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RgbCode",
                table: "Colors",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RgbCode",
                table: "Colors");
        }
    }
}
