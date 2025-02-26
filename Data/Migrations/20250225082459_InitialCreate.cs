using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrammyAwards.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSongs",
                table: "Artists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfSongs",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
