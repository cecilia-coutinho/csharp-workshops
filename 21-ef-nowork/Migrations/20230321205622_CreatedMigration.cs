using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Migrations
{
    public partial class CreatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LeaveBalance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LeaveTypeDescription = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.LeaveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StatusList",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusList", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    LeaveRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestedDays = table.Column<float>(type: "real", nullable: false),
                    FkEmployeeId = table.Column<int>(type: "int", nullable: false),
                    FkLeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    FkStatusId = table.Column<int>(type: "int", nullable: false),
                    RequestCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.LeaveRequestId);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_FkEmployeeId",
                        column: x => x.FkEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_FkLeaveTypeId",
                        column: x => x.FkLeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_StatusList_FkStatusId",
                        column: x => x.FkStatusId,
                        principalTable: "StatusList",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_FkEmployeeId",
                table: "LeaveRequests",
                column: "FkEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_FkLeaveTypeId",
                table: "LeaveRequests",
                column: "FkLeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_FkStatusId",
                table: "LeaveRequests",
                column: "FkStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveTypes_LeaveTypeName",
                table: "LeaveTypes",
                column: "LeaveTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusList_StatusName",
                table: "StatusList",
                column: "StatusName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropTable(
                name: "StatusList");
        }
    }
}
