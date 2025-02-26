using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrammyAwards.Data.Migrations
{
    /// <inheritdoc />
    public partial class Artist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSongs",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "NumberOfSongs",
                table: "Artists");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
