﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Penetration_Testing_Hub.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StageTechnique_Reconnaissance_Tool_Posts");

            migrationBuilder.DropTable(
                name: "StageTechnique_Reconnaissance_Tools");

            migrationBuilder.CreateTable(
                name: "PTHThreads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTHThreads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PTHPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StageTechnique_Reconnaissance_ToolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTHPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PTHPosts_PTHThreads_StageTechnique_Reconnaissance_ToolId",
                        column: x => x.StageTechnique_Reconnaissance_ToolId,
                        principalTable: "PTHThreads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PTHPosts_StageTechnique_Reconnaissance_ToolId",
                table: "PTHPosts",
                column: "StageTechnique_Reconnaissance_ToolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PTHPosts");

            migrationBuilder.DropTable(
                name: "PTHThreads");

            migrationBuilder.CreateTable(
                name: "StageTechnique_Reconnaissance_Tools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageTechnique_Reconnaissance_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StageTechnique_Reconnaissance_Tool_Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PostFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StageTechnique_Reconnaissance_ToolId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageTechnique_Reconnaissance_Tool_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StageTechnique_Reconnaissance_Tool_Posts_StageTechnique_Reconnaissance_Tools_StageTechnique_Reconnaissance_ToolId",
                        column: x => x.StageTechnique_Reconnaissance_ToolId,
                        principalTable: "StageTechnique_Reconnaissance_Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StageTechnique_Reconnaissance_Tool_Posts_StageTechnique_Reconnaissance_ToolId",
                table: "StageTechnique_Reconnaissance_Tool_Posts",
                column: "StageTechnique_Reconnaissance_ToolId");
        }
    }
}
