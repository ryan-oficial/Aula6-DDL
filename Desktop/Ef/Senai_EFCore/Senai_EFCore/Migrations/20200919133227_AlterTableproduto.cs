using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai_EFCore.Migrations
{
    public partial class AlterTableproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlIMagem",
                table: "Produtos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlIMagem",
                table: "Produtos");
        }
    }
}
