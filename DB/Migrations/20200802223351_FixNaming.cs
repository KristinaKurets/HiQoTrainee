using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class FixNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desks_Desks_status_DeskStatusLoockupID",
                table: "Desks");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Booking_status_BookingStatusLoockupID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_UserRoleLoockupID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkPlans_workplan_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleLoockupID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_workplan_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BookingStatusLoockupID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Desks_DeskStatusLoockupID",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "UserRoleLoockupID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "workplan_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookingStatusLoockupID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeskStatusLoockupID",
                table: "Desks");

            migrationBuilder.RenameColumn(
                name: "workplan_type",
                table: "WorkPlans",
                newName: "work-plan_type");

            migrationBuilder.RenameColumn(
                name: "workplan_id",
                table: "WorkPlans",
                newName: "work-plan_id");

            migrationBuilder.AddColumn<short>(
                name: "UserRoleLookupID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "work-plan_id",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "BookingStatusLookupID",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DeskStatusLookupID",
                table: "Desks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleLookupID",
                table: "Users",
                column: "UserRoleLookupID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_work-plan_id",
                table: "Users",
                column: "work-plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookingStatusLookupID",
                table: "Orders",
                column: "BookingStatusLookupID");

            migrationBuilder.CreateIndex(
                name: "IX_Desks_DeskStatusLookupID",
                table: "Desks",
                column: "DeskStatusLookupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_Desks_status_DeskStatusLookupID",
                table: "Desks",
                column: "DeskStatusLookupID",
                principalTable: "Desks_status",
                principalColumn: "desks_status_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Booking_status_BookingStatusLookupID",
                table: "Orders",
                column: "BookingStatusLookupID",
                principalTable: "Booking_status",
                principalColumn: "booking_status_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_UserRoleLookupID",
                table: "Users",
                column: "UserRoleLookupID",
                principalTable: "Roles",
                principalColumn: "roles_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkPlans_work-plan_id",
                table: "Users",
                column: "work-plan_id",
                principalTable: "WorkPlans",
                principalColumn: "work-plan_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desks_Desks_status_DeskStatusLookupID",
                table: "Desks");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Booking_status_BookingStatusLookupID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_UserRoleLookupID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkPlans_work-plan_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleLookupID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_work-plan_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BookingStatusLookupID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Desks_DeskStatusLookupID",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "UserRoleLookupID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "work-plan_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookingStatusLookupID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeskStatusLookupID",
                table: "Desks");

            migrationBuilder.RenameColumn(
                name: "work-plan_type",
                table: "WorkPlans",
                newName: "workplan_type");

            migrationBuilder.RenameColumn(
                name: "work-plan_id",
                table: "WorkPlans",
                newName: "workplan_id");

            migrationBuilder.AddColumn<short>(
                name: "UserRoleLoockupID",
                table: "Users",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "workplan_id",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "BookingStatusLoockupID",
                table: "Orders",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DeskStatusLoockupID",
                table: "Desks",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleLoockupID",
                table: "Users",
                column: "UserRoleLoockupID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_workplan_id",
                table: "Users",
                column: "workplan_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookingStatusLoockupID",
                table: "Orders",
                column: "BookingStatusLoockupID");

            migrationBuilder.CreateIndex(
                name: "IX_Desks_DeskStatusLoockupID",
                table: "Desks",
                column: "DeskStatusLoockupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_Desks_status_DeskStatusLoockupID",
                table: "Desks",
                column: "DeskStatusLoockupID",
                principalTable: "Desks_status",
                principalColumn: "desks_status_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Booking_status_BookingStatusLoockupID",
                table: "Orders",
                column: "BookingStatusLoockupID",
                principalTable: "Booking_status",
                principalColumn: "booking_status_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_UserRoleLoockupID",
                table: "Users",
                column: "UserRoleLoockupID",
                principalTable: "Roles",
                principalColumn: "roles_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkPlans_workplan_id",
                table: "Users",
                column: "workplan_id",
                principalTable: "WorkPlans",
                principalColumn: "workplan_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
