using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Music_Backend.Migrations
{
    public partial class DbInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Listens",
                table: "Song",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Playlist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Album",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Listens",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Album");
        }
    }
}
