using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class AddLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BadRequestLog",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Method = table.Column<string>(nullable: true),
                    Exeption = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadRequestLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RequestProcessingLog",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HTTPMethod = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    StatusCode = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestProcessingLog", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BadRequestLog");

            migrationBuilder.DropTable(
                name: "RequestProcessingLog");
        }
    }
}
