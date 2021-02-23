using Microsoft.EntityFrameworkCore.Migrations;

namespace Penetration_Testing_Hub.Migrations
{
    public partial class Create4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThreadCategory",
                table: "PTHThreads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThreadCategory",
                table: "PTHThreads");
        }
    }
}
