using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kingdoms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LocationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Holdings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Holdings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Holdings");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Holdings");
        }
    }
}