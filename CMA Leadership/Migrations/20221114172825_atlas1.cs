using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMA_Leadership.Migrations
{
    public partial class atlas1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Years_Attended = table.Column<int>(type: "int", nullable: true),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated_Rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Current_Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Current_Rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
