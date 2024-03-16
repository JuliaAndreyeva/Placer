using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placer.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedProptoTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingLimitDays",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "BookingPrice",
                table: "Tours",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingLimitDays",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "BookingPrice",
                table: "Tours");
        }
    }
}
