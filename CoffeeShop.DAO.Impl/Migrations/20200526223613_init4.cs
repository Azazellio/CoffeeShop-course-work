using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.DAO.Impl.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "RecipeDAOs");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RecipeDAOs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RecipeDAOs");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "RecipeDAOs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
