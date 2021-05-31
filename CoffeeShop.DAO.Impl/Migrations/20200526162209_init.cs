using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.DAO.Impl.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientDAOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientDAOs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineDAOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineDAOs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientDAOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    IngredientDAOId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientDAOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientDAOs_IngredientDAOs_IngredientDAOId",
                        column: x => x.IngredientDAOId,
                        principalTable: "IngredientDAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrinkDAOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MachineDAOId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkDAOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrinkDAOs_MachineDAOs_MachineDAOId",
                        column: x => x.MachineDAOId,
                        principalTable: "MachineDAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineIngredientDAOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineDAOId = table.Column<int>(nullable: true),
                    IngredientDAOId = table.Column<int>(nullable: true),
                    MaxCapacityIngredient = table.Column<int>(nullable: false),
                    CurrentCapacityIngredient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineIngredientDAOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineIngredientDAOs_IngredientDAOs_IngredientDAOId",
                        column: x => x.IngredientDAOId,
                        principalTable: "IngredientDAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachineIngredientDAOs_MachineDAOs_MachineDAOId",
                        column: x => x.MachineDAOId,
                        principalTable: "MachineDAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineServesDAOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineDAOId = table.Column<int>(nullable: true),
                    DrinkDAOId = table.Column<int>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineServesDAOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineServesDAOs_DrinkDAOs_DrinkDAOId",
                        column: x => x.DrinkDAOId,
                        principalTable: "DrinkDAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachineServesDAOs_MachineDAOs_MachineDAOId",
                        column: x => x.MachineDAOId,
                        principalTable: "MachineDAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDAOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    DrinkDAOId = table.Column<int>(nullable: true),
                    RecipeIngredientDAOId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDAOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDAOs_DrinkDAOs_DrinkDAOId",
                        column: x => x.DrinkDAOId,
                        principalTable: "DrinkDAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeDAOs_RecipeIngredientDAOs_RecipeIngredientDAOId",
                        column: x => x.RecipeIngredientDAOId,
                        principalTable: "RecipeIngredientDAOs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkDAOs_MachineDAOId",
                table: "DrinkDAOs",
                column: "MachineDAOId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineIngredientDAOs_IngredientDAOId",
                table: "MachineIngredientDAOs",
                column: "IngredientDAOId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineIngredientDAOs_MachineDAOId",
                table: "MachineIngredientDAOs",
                column: "MachineDAOId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineServesDAOs_DrinkDAOId",
                table: "MachineServesDAOs",
                column: "DrinkDAOId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineServesDAOs_MachineDAOId",
                table: "MachineServesDAOs",
                column: "MachineDAOId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDAOs_DrinkDAOId",
                table: "RecipeDAOs",
                column: "DrinkDAOId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDAOs_RecipeIngredientDAOId",
                table: "RecipeDAOs",
                column: "RecipeIngredientDAOId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientDAOs_IngredientDAOId",
                table: "RecipeIngredientDAOs",
                column: "IngredientDAOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineIngredientDAOs");

            migrationBuilder.DropTable(
                name: "MachineServesDAOs");

            migrationBuilder.DropTable(
                name: "RecipeDAOs");

            migrationBuilder.DropTable(
                name: "DrinkDAOs");

            migrationBuilder.DropTable(
                name: "RecipeIngredientDAOs");

            migrationBuilder.DropTable(
                name: "MachineDAOs");

            migrationBuilder.DropTable(
                name: "IngredientDAOs");
        }
    }
}
