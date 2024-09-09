using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kingdoms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlayer3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gold",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gold",
                table: "Players");
        }
    }
}
