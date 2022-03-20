using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tastease.Infrastructure.Data.CoreContext.Migrations
{
    public partial class updated_shelf_life : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShelfLifeValueTable");

            migrationBuilder.DropIndex(
                name: "IX_ShelfLifes_Guid",
                table: "ShelfLifes");

            migrationBuilder.DropIndex(
                name: "IX_NutritionalProperties_Guid",
                table: "NutritionalProperties");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "ShelfLifes");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "NutritionalProperties");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "ShelfLifes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "ShelfLifes");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "ShelfLifes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "NutritionalProperties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ShelfLifeValueTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelfLifeId = table.Column<int>(type: "int", nullable: false),
                    Nameof = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfLifeValueTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelfLifeValueTable_ShelfLifes_ShelfLifeId",
                        column: x => x.ShelfLifeId,
                        principalTable: "ShelfLifes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShelfLifes_Guid",
                table: "ShelfLifes",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalProperties_Guid",
                table: "NutritionalProperties",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShelfLifeValueTable_ShelfLifeId",
                table: "ShelfLifeValueTable",
                column: "ShelfLifeId");
        }
    }
}
