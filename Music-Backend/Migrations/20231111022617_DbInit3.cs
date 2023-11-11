using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Backend.Migrations
{
    public partial class DbInit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "National",
                table: "Artist",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "National",
                table: "Artist");
        }
    }
}
