using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Library.Migrations
{
    public partial class FourthDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo_Url",
                table: "Purchased",
                newName: "Photo_url");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Purchased",
                newName: "Purchase_date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo_url",
                table: "Purchased",
                newName: "Photo_Url");

            migrationBuilder.RenameColumn(
                name: "Purchase_date",
                table: "Purchased",
                newName: "PurchaseDate");
        }
    }
}
