using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Presentation.Migrations
{
    public partial class basket_persistence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasketString",
                table: "CustomerAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasketString",
                table: "CustomerAccounts");
        }
    }
}
