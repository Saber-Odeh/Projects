using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1.Migrations
{
    public partial class updatePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "CallsLogSummary",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "CallsLogSummary");
        }
    }
}
