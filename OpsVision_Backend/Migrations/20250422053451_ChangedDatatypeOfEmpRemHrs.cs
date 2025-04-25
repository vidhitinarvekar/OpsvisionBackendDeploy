using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpsVision_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDatatypeOfEmpRemHrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "EmpRemainingHours",
                table: "FteCommittedLogs",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "EmpRemainingHours",
                table: "FteCommittedLogs",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");
        }
    }
}
