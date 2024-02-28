using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Placer.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class droppedAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_AppUsers_Id",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tourists_AppUsers_Id",
                table: "Tourists");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_AspNetUsers_Id",
                table: "Managers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tourists_AspNetUsers_Id",
                table: "Tourists",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_AspNetUsers_Id",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tourists_AspNetUsers_Id",
                table: "Tourists");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_AppUsers_Id",
                table: "Managers",
                column: "Id",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tourists_AppUsers_Id",
                table: "Tourists",
                column: "Id",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
