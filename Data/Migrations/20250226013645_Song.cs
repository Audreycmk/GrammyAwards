using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrammyAwards.Data.Migrations
{
    /// <inheritdoc />
    public partial class Song : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Album",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Album",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Songs");
        }
    }
}
