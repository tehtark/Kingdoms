using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kingdoms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialBuildingProductionRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionRate",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionRate",
                table: "Buildings");
        }
    }
}
