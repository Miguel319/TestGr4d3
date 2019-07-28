using Microsoft.EntityFrameworkCore.Migrations;

namespace TestGr4d3.DAL.Migrations
{
    public partial class ExamenT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tema",
                table: "Examenes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tema",
                table: "Examenes");
        }
    }
}
