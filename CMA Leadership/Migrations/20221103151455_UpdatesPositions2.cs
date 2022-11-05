using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMA_Leadership.Migrations
{
    public partial class UpdatesPositions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Updated_Position",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Updated_Rank",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated_Position",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Updated_Rank",
                table: "Students");
        }
    }
}
