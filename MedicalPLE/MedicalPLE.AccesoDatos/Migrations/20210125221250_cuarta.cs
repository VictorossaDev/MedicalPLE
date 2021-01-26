using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalPLE.AccesoDatos.Migrations
{
    public partial class cuarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contenido",
                table: "Slider");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Slider");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Slider",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Slider");

            migrationBuilder.AddColumn<string>(
                name: "Contenido",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
