using Microsoft.EntityFrameworkCore.Migrations;

namespace Penetration_Testing_Hub.Migrations
{
    public partial class Create3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PTHPosts_PTHThreads_StageTechnique_Reconnaissance_ToolId",
                table: "PTHPosts");

            migrationBuilder.RenameColumn(
                name: "StageTechnique_Reconnaissance_ToolId",
                table: "PTHPosts",
                newName: "PTHThreadId");

            migrationBuilder.RenameIndex(
                name: "IX_PTHPosts_StageTechnique_Reconnaissance_ToolId",
                table: "PTHPosts",
                newName: "IX_PTHPosts_PTHThreadId");

            migrationBuilder.AddForeignKey(
                name: "FK_PTHPosts_PTHThreads_PTHThreadId",
                table: "PTHPosts",
                column: "PTHThreadId",
                principalTable: "PTHThreads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PTHPosts_PTHThreads_PTHThreadId",
                table: "PTHPosts");

            migrationBuilder.RenameColumn(
                name: "PTHThreadId",
                table: "PTHPosts",
                newName: "StageTechnique_Reconnaissance_ToolId");

            migrationBuilder.RenameIndex(
                name: "IX_PTHPosts_PTHThreadId",
                table: "PTHPosts",
                newName: "IX_PTHPosts_StageTechnique_Reconnaissance_ToolId");

            migrationBuilder.AddForeignKey(
                name: "FK_PTHPosts_PTHThreads_StageTechnique_Reconnaissance_ToolId",
                table: "PTHPosts",
                column: "StageTechnique_Reconnaissance_ToolId",
                principalTable: "PTHThreads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
