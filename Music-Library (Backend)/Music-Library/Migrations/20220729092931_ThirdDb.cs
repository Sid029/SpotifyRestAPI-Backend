using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Library.Migrations
{
    public partial class ThirdDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artist_name",
                table: "Purchased",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo_Url",
                table: "Purchased",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist_name",
                table: "Purchased");

            migrationBuilder.DropColumn(
                name: "Photo_Url",
                table: "Purchased");
        }
    }
}
