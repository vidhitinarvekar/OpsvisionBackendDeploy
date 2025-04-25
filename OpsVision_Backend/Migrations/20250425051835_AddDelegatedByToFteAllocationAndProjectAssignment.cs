using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpsVision_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddDelegatedByToFteAllocationAndProjectAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FteAllocations_Staff_StaffId",
                table: "FteAllocations");

            migrationBuilder.AddColumn<int>(
                name: "DelegatedBy",
                table: "ProjectAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DelegatedBy",
                table: "FteAllocations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignments_DelegatedBy",
                table: "ProjectAssignments",
                column: "DelegatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FteAllocations_DelegatedBy",
                table: "FteAllocations",
                column: "DelegatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_FteAllocations_Staff_DelegatedBy",
                table: "FteAllocations",
                column: "DelegatedBy",
                principalTable: "Staff",
                principalColumn: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_FteAllocations_Staff_StaffId",
                table: "FteAllocations",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAssignments_Staff_DelegatedBy",
                table: "ProjectAssignments",
                column: "DelegatedBy",
                principalTable: "Staff",
                principalColumn: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FteAllocations_Staff_DelegatedBy",
                table: "FteAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FteAllocations_Staff_StaffId",
                table: "FteAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAssignments_Staff_DelegatedBy",
                table: "ProjectAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ProjectAssignments_DelegatedBy",
                table: "ProjectAssignments");

            migrationBuilder.DropIndex(
                name: "IX_FteAllocations_DelegatedBy",
                table: "FteAllocations");

            migrationBuilder.DropColumn(
                name: "DelegatedBy",
                table: "ProjectAssignments");

            migrationBuilder.DropColumn(
                name: "DelegatedBy",
                table: "FteAllocations");

            migrationBuilder.AddForeignKey(
                name: "FK_FteAllocations_Staff_StaffId",
                table: "FteAllocations",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
