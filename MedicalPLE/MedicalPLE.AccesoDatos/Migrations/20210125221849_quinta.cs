using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalPLE.AccesoDatos.Migrations
{
    public partial class quinta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contenido",
                table: "Slider",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contenido",
                table: "Slider");
        }
    }
}
