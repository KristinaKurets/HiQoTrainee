using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "booking-cancellation-notification",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "booking-confirmation-notification",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "calendar-sync-notification",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "booking-cancellation-notification",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "booking-confirmation-notification",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "calendar-sync-notification",
                table: "Users");
        }
    }
}
