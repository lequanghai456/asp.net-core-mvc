using Microsoft.EntityFrameworkCore.Migrations;

namespace DoanRapphim.Migrations
{
    public partial class updatephong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Daxoa",
                table: "Phong",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Daxoa",
                table: "Phong");
        }
    }
}
