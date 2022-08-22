using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Library.Migrations
{
    public partial class SeventhDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Artist_ID",
                table: "Artist",
                newName: "Artist_id");

            migrationBuilder.AddColumn<string>(
                name: "Artist_name",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo_url",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist_name",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Photo_url",
                table: "Artist");

            migrationBuilder.RenameColumn(
                name: "Artist_id",
                table: "Artist",
                newName: "Artist_ID");
        }
    }
}
