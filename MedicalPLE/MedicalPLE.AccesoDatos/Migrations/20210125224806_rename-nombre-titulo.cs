using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalPLE.AccesoDatos.Migrations
{
    public partial class renamenombretitulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Slider");

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Slider",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Slider");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
