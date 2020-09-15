using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai_EFCore.Migrations
{
    public partial class AlteTableId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Pedidoitens",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Pedidoitens");
        }
    }
}
