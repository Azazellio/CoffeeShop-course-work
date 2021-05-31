using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.DAO.Impl.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDAOs_RecipeIngredientDAOs_RecipeIngredientDAOId",
                table: "RecipeDAOs");

            migrationBuilder.DropIndex(
                name: "IX_RecipeDAOs_RecipeIngredientDAOId",
                table: "RecipeDAOs");

            migrationBuilder.DropColumn(
                name: "RecipeIngredientDAOId",
                table: "RecipeDAOs");

            migrationBuilder.AddColumn<int>(
                name: "RecipeDAOId",
                table: "RecipeIngredientDAOs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientDAOs_RecipeDAOId",
                table: "RecipeIngredientDAOs",
                column: "RecipeDAOId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredientDAOs_RecipeDAOs_RecipeDAOId",
                table: "RecipeIngredientDAOs",
                column: "RecipeDAOId",
                principalTable: "RecipeDAOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredientDAOs_RecipeDAOs_RecipeDAOId",
                table: "RecipeIngredientDAOs");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredientDAOs_RecipeDAOId",
                table: "RecipeIngredientDAOs");

            migrationBuilder.DropColumn(
                name: "RecipeDAOId",
                table: "RecipeIngredientDAOs");

            migrationBuilder.AddColumn<int>(
                name: "RecipeIngredientDAOId",
                table: "RecipeDAOs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDAOs_RecipeIngredientDAOId",
                table: "RecipeDAOs",
                column: "RecipeIngredientDAOId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDAOs_RecipeIngredientDAOs_RecipeIngredientDAOId",
                table: "RecipeDAOs",
                column: "RecipeIngredientDAOId",
                principalTable: "RecipeIngredientDAOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
