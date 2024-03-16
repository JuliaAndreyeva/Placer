using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placer.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Bookings",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
