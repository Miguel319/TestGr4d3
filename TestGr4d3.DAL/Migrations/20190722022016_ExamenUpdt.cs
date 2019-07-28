using Microsoft.EntityFrameworkCore.Migrations;

namespace TestGr4d3.DAL.Migrations
{
    public partial class ExamenUpdt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Examenes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Examenes");
        }
    }
}
