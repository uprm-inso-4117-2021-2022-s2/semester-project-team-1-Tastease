using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tastease.Infrastructure.Data.CoreContext.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExperienceLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pantries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CookId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pantries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pantries_Cooks_CookId",
                        column: x => x.CookId,
                        principalTable: "Cooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrepTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Servings = table.Column<int>(type: "int", nullable: false),
                    ExecutionDifficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuisineId = table.Column<int>(type: "int", nullable: false),
                    CookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Cooks_CookId",
                        column: x => x.CookId,
                        principalTable: "Cooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Cuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appliances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PantryTableId = table.Column<int>(type: "int", nullable: true),
                    RecipeTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appliances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appliances_Pantries_PantryTableId",
                        column: x => x.PantryTableId,
                        principalTable: "Pantries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appliances_Recipes_RecipeTableId",
                        column: x => x.RecipeTableId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PantryTableId = table.Column<int>(type: "int", nullable: true),
                    RecipeTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Pantries_PantryTableId",
                        column: x => x.PantryTableId,
                        principalTable: "Pantries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeTableId",
                        column: x => x.RecipeTableId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeValueTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameof = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeValueTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeValueTable_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Step = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Adjustments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplianceId = table.Column<int>(type: "int", nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructions_Appliances_ApplianceId",
                        column: x => x.ApplianceId,
                        principalTable: "Appliances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instructions_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Serverity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    CookTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_Cooks_CookTableId",
                        column: x => x.CookTableId,
                        principalTable: "Cooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Allergies_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionalProperties_Ingredients_IngredientTableId",
                        column: x => x.IngredientTableId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShelfLifes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfLifes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelfLifes_Ingredients_IngredientTableId",
                        column: x => x.IngredientTableId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeasuredIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructionTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuredIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasuredIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasuredIngredients_Instructions_InstructionTableId",
                        column: x => x.InstructionTableId,
                        principalTable: "Instructions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShelfLifeValueTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nameof = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShelfLifeId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Allergies_CookTableId",
                table: "Allergies",
                column: "CookTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Guid",
                table: "Allergies",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_IngredientId",
                table: "Allergies",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_Guid",
                table: "Appliances",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_Name",
                table: "Appliances",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_PantryTableId",
                table: "Appliances",
                column: "PantryTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_RecipeTableId",
                table: "Appliances",
                column: "RecipeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_Guid",
                table: "Cooks",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_Name",
                table: "Cooks",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_Guid",
                table: "Cuisines",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuisines_Name_Region",
                table: "Cuisines",
                columns: new[] { "Name", "Region" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Guid",
                table: "Ingredients",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_Name",
                table: "Ingredients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_PantryTableId",
                table: "Ingredients",
                column: "PantryTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeTableId",
                table: "Ingredients",
                column: "RecipeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_ApplianceId",
                table: "Instructions",
                column: "ApplianceId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_Guid",
                table: "Instructions",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_RecipeId",
                table: "Instructions",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuredIngredients_Guid",
                table: "MeasuredIngredients",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasuredIngredients_IngredientId",
                table: "MeasuredIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasuredIngredients_InstructionTableId",
                table: "MeasuredIngredients",
                column: "InstructionTableId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalProperties_Guid",
                table: "NutritionalProperties",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalProperties_IngredientTableId",
                table: "NutritionalProperties",
                column: "IngredientTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Pantries_CookId",
                table: "Pantries",
                column: "CookId");

            migrationBuilder.CreateIndex(
                name: "IX_Pantries_Guid",
                table: "Pantries",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CookId",
                table: "Recipes",
                column: "CookId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CuisineId",
                table: "Recipes",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Guid",
                table: "Recipes",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeValueTable_RecipeId",
                table: "RecipeValueTable",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelfLifes_Guid",
                table: "ShelfLifes",
                column: "Guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShelfLifes_IngredientTableId",
                table: "ShelfLifes",
                column: "IngredientTableId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelfLifeValueTable_ShelfLifeId",
                table: "ShelfLifeValueTable",
                column: "ShelfLifeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "MeasuredIngredients");

            migrationBuilder.DropTable(
                name: "NutritionalProperties");

            migrationBuilder.DropTable(
                name: "RecipeValueTable");

            migrationBuilder.DropTable(
                name: "ShelfLifeValueTable");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "ShelfLifes");

            migrationBuilder.DropTable(
                name: "Appliances");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Pantries");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "Cuisines");
        }
    }
}
