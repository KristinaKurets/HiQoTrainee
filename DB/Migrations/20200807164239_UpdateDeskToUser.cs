using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class UpdateDeskToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_desk_id",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_desk_id",
                table: "Users",
                column: "desk_id",
                unique: true,
                filter: "[desk_id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_desk_id",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_desk_id",
                table: "Users",
                column: "desk_id");
        }
    }
}
