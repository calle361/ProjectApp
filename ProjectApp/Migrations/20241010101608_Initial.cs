﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProjectDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDbs", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaskDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDbs_ProjectDbs_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ProjectDbs",
                columns: new[] { "Id", "CreatedDate", "Title", "UserName" },
                values: new object[] { -1, new DateTime(2024, 10, 10, 12, 16, 7, 696, DateTimeKind.Local).AddTicks(2827), "Learn ASP.NET Core with MVC", "anderslm@kth.se" });

            migrationBuilder.InsertData(
                table: "TaskDbs",
                columns: new[] { "Id", "Description", "LastUpdated", "ProjectId", "Status" },
                values: new object[,]
                {
                    { -2, "Do it yourself!", new DateTime(2024, 10, 10, 12, 16, 7, 696, DateTimeKind.Local).AddTicks(3034), -1, 0 },
                    { -1, "Follow the turtorials", new DateTime(2024, 10, 10, 12, 16, 7, 696, DateTimeKind.Local).AddTicks(3030), -1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDbs_ProjectId",
                table: "TaskDbs",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDbs");

            migrationBuilder.DropTable(
                name: "ProjectDbs");
        }
    }
}
