using Microsoft.EntityFrameworkCore.Migrations;

namespace OutlierBookStorePhase2.Migrations
{
    public partial class AddCoverPhotoUrlToBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverPhotoUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhotoUrl",
                table: "Books");
        }
    }
}
