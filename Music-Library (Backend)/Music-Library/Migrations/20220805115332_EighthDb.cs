using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Library.Migrations
{
    public partial class EighthDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "User",
                newName: "Creationdate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Creationdate",
                table: "User",
                newName: "CreationDate");
        }
    }
}
