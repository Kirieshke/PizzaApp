using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaApp.Migrations
{
    public partial class Add_Ingrdient_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Pizzas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pizzas");
        }
    }
}
