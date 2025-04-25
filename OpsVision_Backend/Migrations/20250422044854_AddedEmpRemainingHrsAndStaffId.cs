using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpsVision_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmpRemainingHrsAndStaffId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EmpRemainingHours",
                table: "FteCommittedLogs",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "FteCommittedLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StaffNumber",
                table: "Staff",
                column: "StaffNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FteCommittedLogs_StaffId",
                table: "FteCommittedLogs",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_FteCommittedLogs_Staff_StaffId",
                table: "FteCommittedLogs",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FteCommittedLogs_Staff_StaffId",
                table: "FteCommittedLogs");

            migrationBuilder.DropIndex(
                name: "IX_Staff_StaffNumber",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_FteCommittedLogs_StaffId",
                table: "FteCommittedLogs");

            migrationBuilder.DropColumn(
                name: "EmpRemainingHours",
                table: "FteCommittedLogs");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "FteCommittedLogs");
        }
    }
}
