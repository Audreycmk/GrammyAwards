using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrammyAwards.Data.Migrations
{
    /// <inheritdoc />
    public partial class Award : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Awards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Awards");
        }
    }
}
