using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Library.Migrations
{
    public partial class FIfthDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "Purchased",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "Purchased");
        }
    }
}
