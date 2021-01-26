using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalPLE.AccesoDatos.Migrations
{
    public partial class sextaquitoestado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Slider");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Slider",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
