using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMA_Leadership.Migrations
{
    public partial class CounsNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Students");
        }
    }
}
