using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking_status",
                columns: table => new
                {
                    booking_status_id = table.Column<short>(nullable: false),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_status", x => x.booking_status_id);
                });

            migrationBuilder.CreateTable(
                name: "Desks_status",
                columns: table => new
                {
                    desks_status_id = table.Column<short>(nullable: false),
                    status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks_status", x => x.desks_status_id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    position_id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roles_id = table.Column<short>(nullable: false),
                    role_type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roles_id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    room_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false),
                    max_employees = table.Column<short>(nullable: false),
                    floor = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.room_id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPlans",
                columns: table => new
                {
                    workplan_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workplan_type = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    min_days_per_month = table.Column<byte>(nullable: false),
                    max_days_per_month = table.Column<byte>(nullable: false),
                    priority = table.Column<short>(nullable: true),
                    guaranteed_desk = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPlans", x => x.workplan_id);
                });

            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    day_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    start_of_work = table.Column<TimeSpan>(type: "time", nullable: true),
                    end_of_work = table.Column<TimeSpan>(type: "time", nullable: true),
                    is_dayoff = table.Column<bool>(nullable: false),
                    room_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.day_id);
                    table.ForeignKey(
                        name: "FK_Calendar_Rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    desk_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false),
                    macBook = table.Column<bool>(nullable: false),
                    camera = table.Column<bool>(nullable: false),
                    headset = table.Column<bool>(nullable: false),
                    room_id = table.Column<int>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    DeskStatusLoockupID = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.desk_id);
                    table.ForeignKey(
                        name: "FK_Desks_Desks_status_DeskStatusLoockupID",
                        column: x => x.DeskStatusLoockupID,
                        principalTable: "Desks_status",
                        principalColumn: "desks_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Desks_Rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: false),
                    last_name = table.Column<string>(nullable: false),
                    positions_id = table.Column<short>(nullable: false),
                    Role = table.Column<short>(nullable: false),
                    workplan_id = table.Column<int>(nullable: true),
                    room_id = table.Column<int>(nullable: true),
                    desk_id = table.Column<int>(nullable: true),
                    date_of_change_plan = table.Column<DateTime>(nullable: true),
                    UserRoleLoockupID = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_UserRoleLoockupID",
                        column: x => x.UserRoleLoockupID,
                        principalTable: "Roles",
                        principalColumn: "roles_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Desks_desk_id",
                        column: x => x.desk_id,
                        principalTable: "Desks",
                        principalColumn: "desk_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Positions_positions_id",
                        column: x => x.positions_id,
                        principalTable: "Positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_WorkPlans_workplan_id",
                        column: x => x.workplan_id,
                        principalTable: "WorkPlans",
                        principalColumn: "workplan_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<short>(nullable: false),
                    desk_id = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    BookingStatusLoockupID = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Booking_status_BookingStatusLoockupID",
                        column: x => x.BookingStatusLoockupID,
                        principalTable: "Booking_status",
                        principalColumn: "booking_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Desks_desk_id",
                        column: x => x.desk_id,
                        principalTable: "Desks",
                        principalColumn: "desk_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Booking_status",
                columns: new[] { "booking_status_id", "description" },
                values: new object[,]
                {
                    { (short)1, "Booked" },
                    { (short)2, "Waiting" },
                    { (short)3, "Cancelled" },
                    { (short)4, "Rejected" },
                    { (short)5, "Used" }
                });

            migrationBuilder.InsertData(
                table: "Desks_status",
                columns: new[] { "desks_status_id", "status" },
                values: new object[,]
                {
                    { (short)1, "Fixed" },
                    { (short)2, "Available" },
                    { (short)3, "Booked" },
                    { (short)4, "Out of service" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "roles_id", "role_type" },
                values: new object[,]
                {
                    { (short)1, "User" },
                    { (short)2, "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_room_id",
                table: "Calendar",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Desks_DeskStatusLoockupID",
                table: "Desks",
                column: "DeskStatusLoockupID");

            migrationBuilder.CreateIndex(
                name: "IX_Desks_room_id",
                table: "Desks",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookingStatusLoockupID",
                table: "Orders",
                column: "BookingStatusLoockupID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_desk_id",
                table: "Orders",
                column: "desk_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleLoockupID",
                table: "Users",
                column: "UserRoleLoockupID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_desk_id",
                table: "Users",
                column: "desk_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_positions_id",
                table: "Users",
                column: "positions_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_room_id",
                table: "Users",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_workplan_id",
                table: "Users",
                column: "workplan_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Booking_status");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "WorkPlans");

            migrationBuilder.DropTable(
                name: "Desks_status");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
