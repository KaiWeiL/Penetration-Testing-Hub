using Microsoft.EntityFrameworkCore.Migrations;

namespace Penetration_Testing_Hub.Migrations
{
    public partial class production2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ToolOrTech",
                table: "PTHThreads",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToolOrTech",
                table: "PTHThreads");
        }
    }
}
